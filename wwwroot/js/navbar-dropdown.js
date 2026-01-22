// Enhanced navbar dropdown hover with delay
document.addEventListener('DOMContentLoaded', function() {
    const dropdownHovers = document.querySelectorAll('.dropdown-hover');
    let closeTimeout;
    
    dropdownHovers.forEach(dropdown => {
        const menu = dropdown.querySelector('.dropdown-menu');
        if (!menu) return;
        
        // Show dropdown on hover
        dropdown.addEventListener('mouseenter', function() {
            // Clear any pending close timeout
            if (closeTimeout) {
                clearTimeout(closeTimeout);
                closeTimeout = null;
            }
            
            // Show the dropdown
            menu.classList.add('show');
        });
        
        // Hide dropdown with delay on mouse leave
        dropdown.addEventListener('mouseleave', function() {
            // Add a 300ms delay before hiding
            closeTimeout = setTimeout(() => {
                menu.classList.remove('show');
            }, 300);
        });
        
        // Keep dropdown open when hovering over the menu itself
        menu.addEventListener('mouseenter', function() {
            // Clear any pending close timeout
            if (closeTimeout) {
                clearTimeout(closeTimeout);
                closeTimeout = null;
            }
            
            // Ensure menu stays visible
            menu.classList.add('show');
        });
        
        // Hide dropdown with delay when leaving the menu
        menu.addEventListener('mouseleave', function() {
            // Add a 300ms delay before hiding
            closeTimeout = setTimeout(() => {
                menu.classList.remove('show');
            }, 300);
        });
    });
});
