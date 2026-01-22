// ============================================
// KOKOMIJA - Theme Management
// Dark/Light Mode Toggle
// ============================================

(function() {
    'use strict';

    const THEME_KEY = 'kokomija-theme';
    const THEME_DARK = 'dark';
    const THEME_LIGHT = 'light';

    class ThemeManager {
        constructor() {
            this.themeToggle = document.getElementById('theme-toggle');
            this.init();
        }

        init() {
            // Load saved theme or default to light
            const savedTheme = this.getSavedTheme();
            this.setTheme(savedTheme, false);

            // Setup event listeners
            if (this.themeToggle) {
                this.themeToggle.addEventListener('change', () => {
                    const newTheme = this.themeToggle.checked ? THEME_DARK : THEME_LIGHT;
                    this.setTheme(newTheme, true);
                });
            }

            // Listen for system theme changes
            window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
                if (!localStorage.getItem(THEME_KEY)) {
                    this.setTheme(e.matches ? THEME_DARK : THEME_LIGHT, false);
                }
            });
        }

        getSavedTheme() {
            const saved = localStorage.getItem(THEME_KEY);
            if (saved) return saved;

            // Check system preference
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                return THEME_DARK;
            }

            return THEME_LIGHT;
        }

        setTheme(theme, save = true) {
            // Update DOM - Bootstrap 5 theme attribute
            const html = document.documentElement;
            html.setAttribute('data-bs-theme', theme);
            html.classList.remove(THEME_DARK, THEME_LIGHT);
            html.classList.add(theme);
            
            // Also set on body for backwards compatibility
            document.body.setAttribute('data-theme', theme);
            document.body.setAttribute('data-bs-theme', theme);

            // Update toggle state
            if (this.themeToggle) {
                this.themeToggle.checked = theme === THEME_DARK;
            }

            // Update Bootstrap theme color meta tag
            const metaThemeColor = document.querySelector('meta[name="theme-color"]');
            if (metaThemeColor) {
                metaThemeColor.setAttribute('content', theme === THEME_DARK ? '#1A1D23' : '#FFFFFF');
            }

            // Save to localStorage
            if (save) {
                localStorage.setItem(THEME_KEY, theme);
            }

            // Dispatch custom event
            window.dispatchEvent(new CustomEvent('themeChanged', { detail: { theme } }));
        }

        toggleTheme() {
            const currentTheme = document.documentElement.getAttribute('data-bs-theme');
            const newTheme = currentTheme === THEME_DARK ? THEME_LIGHT : THEME_DARK;
            this.setTheme(newTheme);
        }
    }

    // Initialize theme manager when DOM is ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', () => {
            window.themeManager = new ThemeManager();
        });
    } else {
        window.themeManager = new ThemeManager();
    }

})();
