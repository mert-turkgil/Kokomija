# Image Folder Structure - Kokomija

This document describes the image folder structure for the Kokomija e-commerce platform.

## Folder Structure

```
wwwroot/
└── Img/
    ├── ProductImage/          # Product images
    │   ├── {product-guid}.jpg
    │   ├── {product-guid}.webp
    │   └── ...
    │
    ├── Blog/                  # Blog images
    │   ├── Temp/             # Temporary blog images (during editing)
    │   │   ├── {temp-guid}.jpg
    │   │   └── ...
    │   ├── {blog-guid}.jpg   # Published blog images
    │   ├── {blog-guid}.webp
    │   └── ...
    │
    └── Carousel/             # Carousel/slider images
        ├── {carousel-guid}.jpg
        ├── {carousel-guid}.webp
        ├── mobile/           # Mobile-optimized carousel images (optional)
        │   ├── {carousel-guid}.jpg
        │   └── ...
        └── ...
```2

## Image Upload Workflows

### 1. Product Images

**Location**: `wwwroot/Img/ProductImage/`

**Upload Process**:
1. User uploads product image via admin panel
2. Image is validated (format, size)
3. Image is saved with GUID filename: `{Guid.NewGuid()}.{extension}`
4. Image path stored in `ProductImages` table: `ProductImage/{guid}.jpg`
5. Multiple images per product supported via `ProductImages.DisplayOrder`

**Supported Formats**: JPG, PNG, WEBP, GIF
**Max Size**: 5MB per image
**Recommended Dimensions**: 1000x1000px (square) or 1000x1200px (portrait)

**Example**:
```csharp
// Upload
var imagePath = await _productImageService.UploadAsync(file);
// Result: "ProductImage/abc123.jpg"

// Database
ProductImage {
    Id = 1,
    ProductId = 5,
    ImagePath = "ProductImage/abc123.jpg",
    DisplayOrder = 1
}
```

---

### 2. Blog Images

**Location**: `wwwroot/Img/Blog/` (published) or `wwwroot/Img/Blog/Temp/` (draft)

**Upload Process**:

#### Draft/Editing Mode:
1. User uploads image while editing blog post
2. Image saved to `Blog/Temp/{guid}.{extension}`
3. Image path stored temporarily in blog draft

#### Publishing:
1. When blog is published, images are moved from `Temp/` to `Blog/`
2. Database updated with new path: `Blog/{guid}.jpg`
3. Old temp files cleaned up

#### Cleanup:
- Temp files older than 7 days automatically deleted
- Orphaned temp files (no associated draft) deleted

**Supported Formats**: JPG, PNG, WEBP, GIF
**Max Size**: 10MB per image (blog posts may have large images)
**Recommended Dimensions**: 1200x630px (featured), 800x600px (inline)

**Example**:
```csharp
// Draft upload
var tempPath = await _blogService.UploadTempImageAsync(file);
// Result: "Blog/Temp/xyz789.jpg"

// On publish
await _blogService.PublishBlogAsync(blogId);
// Images moved: "Blog/Temp/xyz789.jpg" → "Blog/xyz789.jpg"

// Database
Blog {
    Id = 1,
    FeaturedImage = "Blog/xyz789.jpg",
    Content = "<img src='/Img/Blog/xyz789.jpg' />"
}
```

---

### 3. Carousel/Slider Images

**Location**: `wwwroot/Img/Carousel/`

**Upload Process**:
1. Admin uploads carousel image
2. Image validated (format, size, dimensions)
3. Image saved to `Carousel/{guid}.{extension}`
4. Optional mobile version saved to `Carousel/mobile/{guid}.{extension}`
5. Image path stored in `CarouselSlides` table

**Supported Formats**: JPG, PNG, WEBP
**Max Size**: 5MB per image
**Recommended Dimensions**: 
- Desktop: 1920x600px (banner) or 1920x1080px (full-screen)
- Mobile: 768x1024px (portrait) or 768x400px (landscape)

**Example**:
```csharp
// Desktop upload
var imagePath = await _carouselService.UploadImageAsync(file);
// Result: "Carousel/def456.jpg"

// Mobile upload (optional)
var mobileImagePath = await _carouselService.UploadImageAsync(mobileFile, "mobile");
// Result: "Carousel/mobile/def456.jpg"

// Database
CarouselSlide {
    Id = 1,
    Title = "Summer Sale",
    ImagePath = "Carousel/def456.jpg",
    MobileImagePath = "Carousel/mobile/def456.jpg",
    Location = "home",
    DisplayOrder = 1
}
```

---

## Image Optimization Recommendations

### 1. Format Selection
- **WEBP**: Best for web (smaller size, good quality) - recommended
- **JPG**: Good compatibility, reasonable size
- **PNG**: Use only for images requiring transparency
- **GIF**: Only for animations (discouraged, use video instead)

### 2. Compression
- Product images: 80-85% quality
- Blog images: 85-90% quality (higher quality for readability)
- Carousel images: 90-95% quality (hero images need high quality)

### 3. Responsive Images
- Generate multiple sizes for different devices
- Use `<picture>` element with multiple sources
- Implement lazy loading for below-fold images

### 4. CDN Integration (Future)
- Move images to CDN for faster delivery
- Keep folder structure consistent
- Update paths in database to CDN URLs

---

## Security Considerations

### 1. File Validation
```csharp
// Validate extension
var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
if (!allowedExtensions.Contains(extension))
    throw new ArgumentException("Invalid file type");

// Validate size
if (file.Length > maxSizeInBytes)
    throw new ArgumentException($"File too large (max {maxSizeInBytes / 1024 / 1024}MB)");

// Validate content (check magic bytes)
using var stream = file.OpenReadStream();
var header = new byte[8];
await stream.ReadAsync(header, 0, 8);
// Check magic bytes match extension
```

### 2. Filename Sanitization
- Always use GUID for filenames (prevent path traversal)
- Never use user-provided filenames directly
- Strip metadata (EXIF) to prevent information leakage

### 3. Access Control
- Product images: Public (no auth required)
- Blog images: Public after publishing, temp folder protected
- Carousel images: Public (no auth required)

### 4. Storage Limits
- Set per-user upload quotas
- Monitor total storage usage
- Implement cleanup routines for orphaned files

---

## Maintenance Tasks

### Daily Tasks
- Clean up temp blog images older than 7 days
- Check for orphaned files (no database reference)

### Weekly Tasks
- Generate thumbnail sizes if missing
- Verify all database image paths exist on disk
- Compress old images if needed

### Monthly Tasks
- Archive old product images from deleted products
- Review storage usage and plan for scaling
- Update CDN if implemented

---

## Database Schema References

### ProductImages Table
```sql
CREATE TABLE ProductImages (
    Id INT PRIMARY KEY,
    ProductId INT NOT NULL,
    ImagePath NVARCHAR(500) NOT NULL,  -- "ProductImage/abc123.jpg"
    DisplayOrder INT DEFAULT 0,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE()
)
```

### Blogs Table
```sql
CREATE TABLE Blogs (
    Id INT PRIMARY KEY,
    FeaturedImage NVARCHAR(500),       -- "Blog/xyz789.jpg"
    Content NVARCHAR(MAX),             -- Contains <img src="/Img/Blog/xyz789.jpg">
    CreatedAt DATETIME2 DEFAULT GETUTCDATE()
)
```

### CarouselSlides Table
```sql
CREATE TABLE CarouselSlides (
    Id INT PRIMARY KEY,
    ImagePath NVARCHAR(500) NOT NULL,  -- "Carousel/def456.jpg"
    MobileImagePath NVARCHAR(500),     -- "Carousel/mobile/def456.jpg"
    Location NVARCHAR(50) NOT NULL,    -- "home", "category"
    DisplayOrder INT DEFAULT 0,
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE()
)
```

---

## API Endpoints (Future Implementation)

### Product Images
```
POST   /api/products/{id}/images        - Upload product image
DELETE /api/products/{id}/images/{imgId} - Delete product image
PUT    /api/products/{id}/images/reorder - Update display order
```

### Blog Images
```
POST   /api/blogs/images/temp           - Upload temp image (draft)
POST   /api/blogs/{id}/images           - Upload published image
DELETE /api/blogs/images/{path}         - Delete blog image
POST   /api/blogs/images/cleanup        - Clean temp folder
```

### Carousel Images
```
GET    /api/carousel                    - Get active carousel slides
POST   /api/carousel                    - Create carousel slide with image
PUT    /api/carousel/{id}               - Update carousel slide
DELETE /api/carousel/{id}               - Delete carousel slide
PUT    /api/carousel/reorder            - Update display order
```

---

## Implementation Checklist

- [x] Create folder structure (`ProductImage`, `Blog`, `Blog/Temp`, `Carousel`)
- [x] Create `CarouselSlide` entity
- [x] Create `CarouselSlideRepository`
- [x] Create `CarouselService` with upload/delete methods
- [x] Register `CarouselService` in DI container
- [ ] Create image upload helper service
- [ ] Implement blog temp image workflow
- [ ] Add image validation middleware
- [ ] Create cleanup background job for temp files
- [ ] Add image optimization (resize, compress)
- [ ] Implement responsive image generation
- [ ] Add admin UI for carousel management
- [ ] Create API endpoints for image management
- [ ] Add CDN integration (optional)

---

**Last Updated**: January 2025
**Folder Structure Version**: 1.0
