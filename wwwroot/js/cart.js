// ============================================
// CART MANAGEMENT SYSTEM
// Handles both guest (localStorage) and authenticated user carts
// ============================================

class CartManager {
    constructor() {
        this.isAuthenticated = document.body.dataset.authenticated === 'true';
        this.cartBadge = document.querySelector('.cart-badge');
        this.cartPreviewItems = document.getElementById('cartPreviewItems');
        
        this.init();
    }
    
    init() {
        // Initialize cart count on page load
        this.updateCartCount();
        this.updateCartPreview();
        
        // Listen for storage events (cart updates in other tabs)
        window.addEventListener('storage', (e) => {
            if (e.key === 'guestCart') {
                this.updateCartCount();
                this.updateCartPreview();
            }
        });
    }
    
    // Get cart items
    async getCartItems() {
        if (this.isAuthenticated) {
            try {
                const response = await fetch('/api/cart/items');
                if (response.ok) {
                    return await response.json();
                }
            } catch (error) {
                console.error('Error fetching cart items:', error);
            }
            return [];
        } else {
            return JSON.parse(localStorage.getItem('guestCart') || '[]');
        }
    }
    
    // Update cart count badge
    async updateCartCount() {
        if (!this.cartBadge) return;
        
        const items = await this.getCartItems();
        const count = items.reduce((total, item) => total + (item.quantity || 1), 0);
        
        this.cartBadge.textContent = count;
        this.cartBadge.style.display = count > 0 ? 'flex' : 'none';
    }
    
    // Update cart preview dropdown
    async updateCartPreview() {
        if (!this.cartPreviewItems) return;
        
        const items = await this.getCartItems();
        
        console.log('Cart items received:', items); // Debug log
        
        if (items.length === 0) {
            this.cartPreviewItems.innerHTML = `
                <div class="text-center py-4 text-muted">
                    <i class="fas fa-shopping-cart mb-2" style="font-size: 2rem; opacity: 0.3;"></i>
                    <p class="mb-0">Your cart is empty</p>
                </div>
            `;
            return;
        }
        
        // Fetch product details for guest cart items
        const cartHtml = await Promise.all(items.map(async (item) => {
            let productData = item;
            
            // For guest cart, we need to fetch product details
            if (!this.isAuthenticated) {
                try {
                    const response = await fetch(`/api/products/${item.productId}`);
                    if (response.ok) {
                        const product = await response.json();
                        productData = {
                            ...item,
                            name: product.name,
                            price: product.price,
                            image: product.images?.[0]?.imageUrl || 'logo_black.png',
                            colorName: item.colorId ? await this.getColorName(item.colorId) : null,
                            sizeName: item.sizeId ? await this.getSizeName(item.sizeId) : null
                        };
                    }
                } catch (error) {
                    console.error('Error fetching product details:', error);
                }
            } else {
                // For authenticated users, normalize the data structure
                productData = {
                    productId: item.productId,
                    name: item.productName,  // API returns productName
                    price: item.price,
                    image: item.imageUrl?.replace('/img/', '') || 'logo_black.png',
                    colorId: item.colorId,
                    colorName: item.colorName,
                    sizeId: item.sizeId,
                    sizeName: item.sizeName,
                    quantity: item.quantity
                };
            }
            
            console.log('Processed product data:', productData); // Debug log
            return this.renderCartItem(productData);
        }));
        
        this.cartPreviewItems.innerHTML = cartHtml.join('');
        
        // Attach remove handlers
        this.attachRemoveHandlers();
    }
    
    // Render a single cart item
    renderCartItem(item) {
        const metaParts = [];
        if (item.colorName) metaParts.push(item.colorName);
        if (item.sizeName) metaParts.push(item.sizeName);
        const meta = metaParts.length > 0 ? metaParts.join(' / ') : '';
        
        // Ensure we have valid data
        const productName = item.name || 'Product';
        const productImage = item.image || 'logo_black.png';
        const productPrice = item.price || 0;
        
        return `
            <div class="cart-preview-item" data-product-id="${item.productId}" data-color-id="${item.colorId || ''}" data-size-id="${item.sizeId || ''}">
                <img src="/img/${productImage}" alt="${productName}" onerror="this.src='/img/logo_black.png'">
                <div class="cart-item-details">
                    <h6>${productName}</h6>
                    ${meta ? `<div class="cart-item-meta">${meta}</div>` : ''}
                    <div class="cart-item-price">
                        ${productPrice ? `${productPrice.toLocaleString('pl-PL', { style: 'currency', currency: 'PLN' })}` : ''}
                        ${item.quantity > 1 ? ` x ${item.quantity}` : ''}
                    </div>
                </div>
                <button class="cart-item-remove" data-product-id="${item.productId}" data-color-id="${item.colorId || ''}" data-size-id="${item.sizeId || ''}">
                    <i class="fas fa-times"></i>
                </button>
            </div>
        `;
    }
    
    // Attach remove button handlers
    attachRemoveHandlers() {
        const removeButtons = this.cartPreviewItems.querySelectorAll('.cart-item-remove');
        removeButtons.forEach(btn => {
            btn.addEventListener('click', async (e) => {
                const productId = parseInt(btn.dataset.productId);
                const colorId = btn.dataset.colorId ? parseInt(btn.dataset.colorId) : null;
                const sizeId = btn.dataset.sizeId ? parseInt(btn.dataset.sizeId) : null;
                
                await this.removeFromCart(productId, colorId, sizeId);
            });
        });
    }
    
    // Remove item from cart
    async removeFromCart(productId, colorId, sizeId) {
        if (this.isAuthenticated) {
            try {
                const response = await fetch('/api/cart/remove', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ productId, colorId, sizeId })
                });
                
                if (response.ok) {
                    this.updateCartCount();
                    this.updateCartPreview();
                }
            } catch (error) {
                console.error('Error removing from cart:', error);
            }
        } else {
            let guestCart = JSON.parse(localStorage.getItem('guestCart') || '[]');
            guestCart = guestCart.filter(item => 
                !(item.productId === productId && 
                  item.colorId === colorId && 
                  item.sizeId === sizeId)
            );
            localStorage.setItem('guestCart', JSON.stringify(guestCart));
            this.updateCartCount();
            this.updateCartPreview();
        }
    }
    
    // Helper methods to get color/size names
    async getColorName(colorId) {
        try {
            const response = await fetch(`/api/colors/${colorId}`);
            if (response.ok) {
                const color = await response.json();
                return color.displayName || color.name;
            }
        } catch (error) {
            console.error('Error fetching color:', error);
        }
        return null;
    }
    
    async getSizeName(sizeId) {
        try {
            const response = await fetch(`/api/sizes/${sizeId}`);
            if (response.ok) {
                const size = await response.json();
                return size.displayName || size.name;
            }
        } catch (error) {
            console.error('Error fetching size:', error);
        }
        return null;
    }
    
    // Merge guest cart with user cart on login
    async mergeGuestCartOnLogin() {
        const guestCart = JSON.parse(localStorage.getItem('guestCart') || '[]');
        
        if (guestCart.length === 0) return;
        
        try {
            const response = await fetch('/api/cart/merge', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(guestCart)
            });
            
            if (response.ok) {
                // Clear guest cart after successful merge
                localStorage.removeItem('guestCart');
                this.isAuthenticated = true;
                this.updateCartCount();
                this.updateCartPreview();
            }
        } catch (error) {
            console.error('Error merging cart:', error);
        }
    }
}

// Initialize cart manager when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    window.cartManager = new CartManager();
});
