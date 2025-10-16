// ============================================
// KOKOMIJA - Main JavaScript
// Core functionality and utilities
// ============================================

(function() {
    'use strict';

    // ============================================
    // Navbar Scroll Effect
    // ============================================
    class NavbarScroll {
        constructor() {
            this.navbar = document.querySelector('.navbar-kokomija');
            this.scrollThreshold = 100;
            this.init();
        }

        init() {
            if (!this.navbar) return;

            window.addEventListener('scroll', () => {
                if (window.scrollY > this.scrollThreshold) {
                    this.navbar.classList.add('navbar-scrolled');
                } else {
                    this.navbar.classList.remove('navbar-scrolled');
                }
            });
        }
    }

    // ============================================
    // Dropdown Hover Effect (Desktop only)
    // ============================================
    class DropdownHover {
        constructor() {
            this.dropdowns = document.querySelectorAll('.navbar .dropdown');
            this.init();
        }

        init() {
            if (window.innerWidth < 992) return; // Only on desktop

            this.dropdowns.forEach(dropdown => {
                const toggle = dropdown.querySelector('.dropdown-toggle');
                const menu = dropdown.querySelector('.dropdown-menu');

                if (!toggle || !menu) return;

                dropdown.addEventListener('mouseenter', () => {
                    menu.classList.add('show');
                    toggle.setAttribute('aria-expanded', 'true');
                });

                dropdown.addEventListener('mouseleave', () => {
                    menu.classList.remove('show');
                    toggle.setAttribute('aria-expanded', 'false');
                });
            });
        }
    }

    // ============================================
    // Shopping Cart
    // ============================================
    class ShoppingCart {
        constructor() {
            this.cart = this.loadCart();
            this.updateCartUI();
        }

        loadCart() {
            const saved = localStorage.getItem('kokomija-cart');
            return saved ? JSON.parse(saved) : [];
        }

        saveCart() {
            localStorage.setItem('kokomija-cart', JSON.stringify(this.cart));
            this.updateCartUI();
        }

        addItem(product) {
            const existingItem = this.cart.find(item => 
                item.id === product.id && 
                item.size === product.size && 
                item.color === product.color
            );

            if (existingItem) {
                existingItem.quantity += product.quantity || 1;
            } else {
                this.cart.push({
                    ...product,
                    quantity: product.quantity || 1
                });
            }

            this.saveCart();
            this.showNotification('Product added to cart!', 'success');
        }

        removeItem(index) {
            this.cart.splice(index, 1);
            this.saveCart();
            this.showNotification('Product removed from cart', 'info');
        }

        updateQuantity(index, quantity) {
            if (quantity <= 0) {
                this.removeItem(index);
            } else {
                this.cart[index].quantity = quantity;
                this.saveCart();
            }
        }

        getTotal() {
            return this.cart.reduce((total, item) => total + (item.price * item.quantity), 0);
        }

        getItemCount() {
            return this.cart.reduce((count, item) => count + item.quantity, 0);
        }

        updateCartUI() {
            const badge = document.querySelector('.cart-badge');
            if (badge) {
                const count = this.getItemCount();
                badge.textContent = count;
                badge.style.display = count > 0 ? 'flex' : 'none';
            }
        }

        showNotification(message, type = 'info') {
            // Simple toast notification
            const toast = document.createElement('div');
            toast.className = `toast-notification toast-${type}`;
            toast.textContent = message;
            document.body.appendChild(toast);

            setTimeout(() => {
                toast.classList.add('show');
            }, 100);

            setTimeout(() => {
                toast.classList.remove('show');
                setTimeout(() => toast.remove(), 300);
            }, 3000);
        }

        clear() {
            this.cart = [];
            this.saveCart();
        }
    }

    // ============================================
    // Search Functionality
    // ============================================
    class SearchManager {
        constructor() {
            this.searchInput = document.querySelector('.navbar-search input');
            this.searchResults = document.querySelector('.search-results');
            this.debounceTimer = null;
            this.init();
        }

        init() {
            if (!this.searchInput) return;

            this.searchInput.addEventListener('input', (e) => {
                clearTimeout(this.debounceTimer);
                this.debounceTimer = setTimeout(() => {
                    this.performSearch(e.target.value);
                }, 300);
            });

            // Close search results when clicking outside
            document.addEventListener('click', (e) => {
                if (this.searchResults && !this.searchInput.contains(e.target)) {
                    this.searchResults.classList.remove('show');
                }
            });
        }

        async performSearch(query) {
            if (query.length < 2) {
                if (this.searchResults) {
                    this.searchResults.classList.remove('show');
                }
                return;
            }

            try {
                const response = await fetch(`/api/search?q=${encodeURIComponent(query)}`);
                const results = await response.json();
                this.displayResults(results);
            } catch (error) {
                console.error('Search error:', error);
            }
        }

        displayResults(results) {
            if (!this.searchResults) return;

            if (results.length === 0) {
                this.searchResults.innerHTML = '<p class="p-3 text-muted">No results found</p>';
            } else {
                this.searchResults.innerHTML = results.map(item => `
                    <a href="/product/${item.slug}" class="search-result-item">
                        <img src="${item.image}" alt="${item.name}" />
                        <div>
                            <h6>${item.name}</h6>
                            <p class="price">${item.price} PLN</p>
                        </div>
                    </a>
                `).join('');
            }

            this.searchResults.classList.add('show');
        }
    }

    // ============================================
    // Smooth Scroll
    // ============================================
    function initSmoothScroll() {
        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
            anchor.addEventListener('click', function(e) {
                const href = this.getAttribute('href');
                if (href === '#' || href === '#!') return;

                const target = document.querySelector(href);
                if (target) {
                    e.preventDefault();
                    target.scrollIntoView({
                        behavior: 'smooth',
                        block: 'start'
                    });
                }
            });
        });
    }

    // ============================================
    // Lazy Loading Images
    // ============================================
    function initLazyLoading() {
        const images = document.querySelectorAll('img[data-src]');
        
        if (!('IntersectionObserver' in window)) {
            // Fallback for older browsers
            images.forEach(img => {
                img.src = img.dataset.src;
                img.removeAttribute('data-src');
            });
            return;
        }
        
        const imageObserver = new IntersectionObserver((entries, observer) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    img.src = img.dataset.src;
                    img.removeAttribute('data-src');
                    observer.unobserve(img);
                }
            });
        });

        images.forEach(img => imageObserver.observe(img));
    }

    // ============================================
    // Animate on Scroll
    // ============================================
    function initScrollAnimations() {
        const elements = document.querySelectorAll('[data-animate]');
        
        if (!('IntersectionObserver' in window)) {
            // Just show elements without animation
            elements.forEach(el => el.style.opacity = 1);
            return;
        }
        
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const animation = entry.target.dataset.animate;
                    entry.target.classList.add(`animate-${animation}`);
                    observer.unobserve(entry.target);
                }
            });
        }, {
            threshold: 0.1
        });

        elements.forEach(el => observer.observe(el));
    }

    // ============================================
    // Initialize Everything
    // ============================================
    function init() {
        // Initialize components
        new NavbarScroll();
        new DropdownHover();
        new SearchManager();
        
        // Initialize cart
        window.cart = new ShoppingCart();

        // Initialize utilities
        initSmoothScroll();
        initLazyLoading();
        initScrollAnimations();

        // Add back to top button
        const backToTop = document.getElementById('back-to-top');
        if (backToTop) {
            window.addEventListener('scroll', () => {
                if (window.scrollY > 500) {
                    backToTop.style.display = 'flex';
                } else {
                    backToTop.style.display = 'none';
                }
            });

            backToTop.addEventListener('click', () => {
                window.scrollTo({
                    top: 0,
                    behavior: 'smooth'
                });
            });
        }
    }

    // Run when DOM is ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', init);
    } else {
        init();
    }

})();
