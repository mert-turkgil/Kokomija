/**
 * Blog Editor - Professional UI/UX Module
 * Handles auto-save, validation, SEO analysis, and user guidance
 */

class BlogEditor {
    constructor(options = {}) {
        this.options = {
            autoSaveInterval: options.autoSaveInterval || 30000, // 30 seconds
            blogId: options.blogId || 0,
            form: options.form || '#blogForm',
            ...options
        };
        
        this.editorInstances = {};
        this.formData = {};
        this.hasUnsavedChanges = false;
        this.autoSaveTimer = null;
        this.seoAnalysisTimer = null;
        this.lastSaveTime = null;
        this.saveIndicator = null;
        
        this.init();
    }

    init() {
        this.createSaveIndicator();
        this.setupFormChangeDetection();
        this.setupAutoSave();
        this.setupSlugGeneration();
        this.setupCharacterCounters();
        this.setupImageDragDrop();
        this.setupBeforeUnload();
        this.setupRealTimeValidation();
        this.initializeSEOAnalysis();
        this.setupAnimations();
    }

    createSaveIndicator() {
        const indicator = `
            <div id="blogSaveIndicator" class="blog-save-indicator">
                <div class="save-status" id="saveStatus">
                    <i class="fas fa-circle"></i>
                    <span id="saveStatusText">Ready</span>
                </div>
                <div class="last-saved" id="lastSaved" style="display: none;">
                    Last saved: <span id="lastSavedTime">Never</span>
                </div>
            </div>
        `;
        
        $('form' + this.options.form).prepend(indicator);
        this.saveIndicator = $('#blogSaveIndicator');
    }

    setupFormChangeDetection() {
        const form = $(this.options.form);
        
        // Track input changes
        form.on('input change', 'input, textarea, select', () => {
            this.markAsUnsaved();
        });
        
        // Track CKEditor changes
        $(document).on('editorChange', () => {
            this.markAsUnsaved();
        });
    }

    setupAutoSave() {
        // Auto-save every 30 seconds if there are changes
        this.autoSaveTimer = setInterval(() => {
            if (this.hasUnsavedChanges) {
                this.performAutoSave();
            }
        }, this.options.autoSaveInterval);
    }

    async performAutoSave() {
        this.updateSaveStatus('saving', 'Auto-saving...');
        
        try {
            const formData = this.collectFormData();
            
            const response = await fetch('/AdminBlog/AutoSaveDraft', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                },
                body: JSON.stringify(formData)
            });

            const result = await response.json();
            
            if (result.success) {
                this.hasUnsavedChanges = false;
                this.lastSaveTime = new Date();
                this.updateSaveStatus('saved', 'All changes saved');
                
                // Update blog ID if this was a new post
                if (result.blogId && this.options.blogId === 0) {
                    this.options.blogId = result.blogId;
                    $('input[name="Id"]').val(result.blogId);
                }
                
                this.updateLastSavedTime();
            } else {
                this.updateSaveStatus('error', 'Auto-save failed');
            }
        } catch (error) {
            console.error('Auto-save error:', error);
            this.updateSaveStatus('error', 'Auto-save failed');
        }
    }

    collectFormData() {
        const form = $(this.options.form);
        const formData = {
            Id: this.options.blogId,
            CategoryId: parseInt(form.find('[name="CategoryId"]').val()) || 0,
            ProductId: form.find('[name="ProductId"]').val() || null,
            FeaturedImage: form.find('[name="FeaturedImage"]').val() || null,
            IsPublished: form.find('[name="IsPublished"]').is(':checked'),
            PublishedDate: form.find('[name="PublishedDate"]').val() || null,
            AllowComments: form.find('[name="AllowComments"]').is(':checked'),
            Translations: []
        };

        // Collect translations
        form.find('.translation-group').each((index, element) => {
            const translation = {
                Id: parseInt($(element).find('[name$=".Id"]').val()) || 0,
                CultureCode: $(element).find('[name$=".CultureCode"]').val(),
                Title: $(element).find('[name$=".Title"]').val() || '',
                Slug: $(element).find('[name$=".Slug"]').val() || '',
                Content: this.getEditorContent($(element).find('.blog-editor').attr('id')) || '',
                Excerpt: $(element).find('[name$=".Excerpt"]').val() || '',
                Tags: $(element).find('[name$=".Tags"]').val() || '',
                MetaDescription: $(element).find('[name$=".MetaDescription"]').val() || '',
                MetaKeywords: $(element).find('[name$=".MetaKeywords"]').val() || ''
            };
            formData.Translations.push(translation);
        });

        return formData;
    }

    getEditorContent(editorId) {
        if (this.editorInstances[editorId]) {
            return this.editorInstances[editorId].getData();
        }
        return '';
    }

    setupSlugGeneration() {
        $(document).on('blur', 'input[name$=".Title"]', (e) => {
            const titleInput = $(e.target);
            const translationGroup = titleInput.closest('.translation-group');
            const slugInput = translationGroup.find('input[name$=".Slug"]');
            const cultureCode = translationGroup.find('input[name$=".CultureCode"]').val();
            
            // Only auto-generate if slug is empty
            if (!slugInput.val() || slugInput.val().trim() === '') {
                const slug = this.generateSlug(titleInput.val());
                slugInput.val(slug);
                this.validateSlug(slug, cultureCode, slugInput);
            }
        });

        // Validate slug on manual input
        $(document).on('blur', 'input[name$=".Slug"]', (e) => {
            const slugInput = $(e.target);
            const translationGroup = slugInput.closest('.translation-group');
            const cultureCode = translationGroup.find('input[name$=".CultureCode"]').val();
            this.validateSlug(slugInput.val(), cultureCode, slugInput);
        });
    }

    generateSlug(text) {
        return text
            .toLowerCase()
            .replace(/[^\w\s-]/g, '')
            .replace(/\s+/g, '-')
            .replace(/--+/g, '-')
            .trim();
    }

    async validateSlug(slug, cultureCode, inputElement) {
        if (!slug) return;

        const feedbackElement = inputElement.siblings('.slug-feedback');
        feedbackElement.html('<i class="fas fa-spinner fa-spin"></i> Checking...').removeClass('text-danger text-success').addClass('text-info');

        try {
            const response = await fetch('/AdminBlog/ValidateSlug', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                },
                body: JSON.stringify({
                    Slug: slug,
                    CultureCode: cultureCode,
                    BlogId: this.options.blogId
                })
            });

            const result = await response.json();
            
            if (result.isAvailable) {
                feedbackElement.html('<i class="fas fa-check-circle"></i> Available').removeClass('text-info text-danger').addClass('text-success');
            } else {
                feedbackElement.html('<i class="fas fa-exclamation-circle"></i> Already in use').removeClass('text-info text-success').addClass('text-danger');
            }
        } catch (error) {
            console.error('Slug validation error:', error);
            feedbackElement.html('').removeClass('text-info text-success text-danger');
        }
    }

    setupCharacterCounters() {
        // Character counter for fields with limits
        const fieldsWithLimits = [
            { selector: 'input[name$=".Title"]', limit: 200 },
            { selector: 'textarea[name$=".Excerpt"]', limit: 500 },
            { selector: 'textarea[name$=".MetaDescription"]', limit: 160 },
            { selector: 'textarea[name$=".MetaKeywords"]', limit: 500 },
            { selector: 'input[name$=".Tags"]', limit: 500 }
        ];

        fieldsWithLimits.forEach(field => {
            $(document).on('input', field.selector, (e) => {
                this.updateCharacterCount($(e.target), field.limit);
            });
            
            // Initialize counters
            $(field.selector).each((i, element) => {
                this.updateCharacterCount($(element), field.limit);
            });
        });
    }

    updateCharacterCount(input, limit) {
        const current = input.val().length;
        const remaining = limit - current;
        const counterElement = input.siblings('.char-counter');
        
        if (counterElement.length === 0) {
            input.after(`<div class="char-counter"></div>`);
        }
        
        const counter = input.siblings('.char-counter');
        
        if (remaining >= 0) {
            counter.html(`<small class="text-muted">${remaining} characters remaining</small>`);
            input.removeClass('is-invalid');
        } else {
            counter.html(`<small class="text-danger">${Math.abs(remaining)} characters over limit</small>`);
            input.addClass('is-invalid');
        }
    }

    setupImageDragDrop() {
        const dropZone = $('.featured-image-upload');
        
        if (dropZone.length === 0) return;

        dropZone.on('dragover', (e) => {
            e.preventDefault();
            e.stopPropagation();
            dropZone.addClass('drag-over');
        });

        dropZone.on('dragleave', (e) => {
            e.preventDefault();
            e.stopPropagation();
            dropZone.removeClass('drag-over');
        });

        dropZone.on('drop', (e) => {
            e.preventDefault();
            e.stopPropagation();
            dropZone.removeClass('drag-over');
            
            const files = e.originalEvent.dataTransfer.files;
            if (files.length > 0) {
                const fileInput = dropZone.find('input[type="file"]')[0];
                fileInput.files = files;
                $(fileInput).trigger('change');
            }
        });

        // Image preview
        dropZone.find('input[type="file"]').on('change', (e) => {
            const file = e.target.files[0];
            if (file && file.type.startsWith('image/')) {
                this.previewImage(file, dropZone);
            }
        });
    }

    previewImage(file, container) {
        const reader = new FileReader();
        reader.onload = (e) => {
            const preview = `
                <div class="image-preview animated fadeIn">
                    <img src="${e.target.result}" alt="Preview" class="img-fluid rounded">
                    <button type="button" class="btn btn-sm btn-danger remove-preview">
                        <i class="fas fa-times"></i> Remove
                    </button>
                </div>
            `;
            container.find('.image-preview').remove();
            container.append(preview);
            
            container.find('.remove-preview').on('click', () => {
                container.find('.image-preview').addClass('fadeOut').delay(300).queue(function() {
                    $(this).remove();
                });
                container.find('input[type="file"]').val('');
                container.find('input[type="hidden"]').val('');
            });
        };
        reader.readAsDataURL(file);
    }

    setupBeforeUnload() {
        $(window).on('beforeunload', (e) => {
            if (this.hasUnsavedChanges) {
                const message = 'You have unsaved changes. Are you sure you want to leave?';
                e.returnValue = message;
                return message;
            }
        });

        // Don't warn on form submit
        $(this.options.form).on('submit', () => {
            this.hasUnsavedChanges = false;
        });
    }

    setupRealTimeValidation() {
        // Real-time validation for required fields
        $(document).on('blur', 'input[required], textarea[required], select[required]', (e) => {
            const input = $(e.target);
            if (input.val().trim() === '') {
                input.addClass('is-invalid');
                if (input.siblings('.invalid-feedback').length === 0) {
                    input.after('<div class="invalid-feedback">This field is required</div>');
                }
            } else {
                input.removeClass('is-invalid');
            }
        });
    }

    initializeSEOAnalysis() {
        // Analyze SEO when content changes (debounced)
        $(document).on('input blur', 'input[name$=".Title"], textarea[name$=".MetaDescription"], input[name$=".MetaKeywords"]', () => {
            clearTimeout(this.seoAnalysisTimer);
            this.seoAnalysisTimer = setTimeout(() => this.performSEOAnalysis(), 1000);
        });

        $(document).on('editorChange', () => {
            clearTimeout(this.seoAnalysisTimer);
            this.seoAnalysisTimer = setTimeout(() => this.performSEOAnalysis(), 2000);
        });
    }

    async performSEOAnalysis() {
        const activeTab = $('.tab-pane.active');
        if (activeTab.length === 0) return;

        const title = activeTab.find('input[name$=".Title"]').val() || '';
        const content = this.getEditorContent(activeTab.find('.blog-editor').attr('id')) || '';
        const metaDescription = activeTab.find('textarea[name$=".MetaDescription"]').val() || '';
        const keywords = activeTab.find('textarea[name$=".MetaKeywords"]').val() || '';

        try {
            const response = await fetch('/AdminBlog/AnalyzeSEO', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                },
                body: JSON.stringify({ Title: title, Content: content, MetaDescription: metaDescription, Keywords: keywords })
            });

            const result = await response.json();
            if (result.success) {
                this.updateSEODisplay(result.data, activeTab);
            }
        } catch (error) {
            console.error('SEO analysis error:', error);
        }
    }

    updateSEODisplay(data, container) {
        let seoPanel = container.find('.seo-analysis-panel');
        
        if (seoPanel.length === 0) {
            seoPanel = $('<div class="seo-analysis-panel card mt-3 animated fadeIn"></div>');
            container.append(seoPanel);
        }

        const ratingClass = data.rating === 'excellent' ? 'success' : data.rating === 'good' ? 'warning' : 'danger';
        const ratingText = data.rating === 'excellent' ? 'Excellent' : data.rating === 'good' ? 'Good' : 'Needs Improvement';

        let suggestionsHtml = '';
        if (data.suggestions && data.suggestions.length > 0) {
            suggestionsHtml = '<ul class="mt-2 mb-0">';
            data.suggestions.forEach(suggestion => {
                suggestionsHtml += `<li><small>${suggestion}</small></li>`;
            });
            suggestionsHtml += '</ul>';
        }

        seoPanel.html(`
            <div class="card-body">
                <h6 class="card-title">
                    <i class="fas fa-search"></i> SEO Analysis
                </h6>
                <div class="row">
                    <div class="col-md-6">
                        <div class="seo-score">
                            <div class="progress" style="height: 25px;">
                                <div class="progress-bar bg-${ratingClass}" role="progressbar" 
                                     style="width: ${data.percentage}%;" 
                                     aria-valuenow="${data.percentage}" aria-valuemin="0" aria-valuemax="100">
                                    ${data.score}/${data.maxScore}
                                </div>
                            </div>
                            <small class="text-${ratingClass} mt-1 d-block">
                                <strong>${ratingText}</strong>
                            </small>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="seo-stats">
                            <small class="d-block"><i class="fas fa-font"></i> ${data.wordCount || 0} words</small>
                            <small class="d-block"><i class="fas fa-clock"></i> ${data.readingTime || 0} min read</small>
                        </div>
                    </div>
                </div>
                ${suggestionsHtml ? `<div class="seo-suggestions mt-2"><strong>Suggestions:</strong>${suggestionsHtml}</div>` : ''}
            </div>
        `);
    }

    setupAnimations() {
        // Smooth tab transitions
        $('a[data-bs-toggle="tab"]').on('shown.bs.tab', function (e) {
            $(e.target.getAttribute('href')).addClass('animated fadeIn');
            setTimeout(() => {
                $(e.target.getAttribute('href')).removeClass('animated fadeIn');
            }, 500);
        });
    }

    registerEditor(id, instance) {
        this.editorInstances[id] = instance;
        
        // Track editor changes
        instance.model.document.on('change:data', () => {
            this.markAsUnsaved();
            $(document).trigger('editorChange');
        });
    }

    markAsUnsaved() {
        this.hasUnsavedChanges = true;
        this.updateSaveStatus('unsaved', 'Unsaved changes');
    }

    updateSaveStatus(status, text) {
        const statusElement = $('#saveStatus');
        const iconElement = statusElement.find('i');
        const textElement = $('#saveStatusText');

        statusElement.removeClass('status-saved status-saving status-unsaved status-error');
        
        switch(status) {
            case 'saved':
                statusElement.addClass('status-saved');
                iconElement.removeClass().addClass('fas fa-check-circle');
                break;
            case 'saving':
                statusElement.addClass('status-saving');
                iconElement.removeClass().addClass('fas fa-spinner fa-spin');
                break;
            case 'unsaved':
                statusElement.addClass('status-unsaved');
                iconElement.removeClass().addClass('fas fa-circle');
                break;
            case 'error':
                statusElement.addClass('status-error');
                iconElement.removeClass().addClass('fas fa-exclamation-circle');
                break;
        }
        
        textElement.text(text);
    }

    updateLastSavedTime() {
        if (!this.lastSaveTime) return;
        
        const timeAgo = this.getTimeAgo(this.lastSaveTime);
        $('#lastSavedTime').text(timeAgo);
        $('#lastSaved').show();
    }

    getTimeAgo(date) {
        const seconds = Math.floor((new Date() - date) / 1000);
        
        if (seconds < 60) return 'just now';
        if (seconds < 3600) return Math.floor(seconds / 60) + ' minutes ago';
        if (seconds < 86400) return Math.floor(seconds / 3600) + ' hours ago';
        return date.toLocaleString();
    }

    destroy() {
        if (this.autoSaveTimer) {
            clearInterval(this.autoSaveTimer);
        }
        if (this.seoAnalysisTimer) {
            clearTimeout(this.seoAnalysisTimer);
        }
        $(window).off('beforeunload');
    }
}

// Export for use in views
window.BlogEditor = BlogEditor;
