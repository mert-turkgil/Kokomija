using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.AspNetCore.Hosting;

namespace Kokomija.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<CarouselService> _logger;

        public CarouselService(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment environment,
            ILogger<CarouselService> logger)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _logger = logger;
        }

        public async Task<IEnumerable<CarouselSlide>> GetHomepageSlidesAsync()
        {
            return await _unitOfWork.CarouselSlides.GetActiveSlidesByLocationAsync("home");
        }

        public async Task<IEnumerable<CarouselSlide>> GetSlidesByLocationAsync(string location, int? categoryId = null)
        {
            return await _unitOfWork.CarouselSlides.GetActiveSlidesByLocationAsync(location, categoryId);
        }

        public async Task<IEnumerable<CarouselSlide>> GetAllSlidesAsync()
        {
            return await _unitOfWork.CarouselSlides.GetAllOrderedAsync();
        }

        public async Task<CarouselSlide?> GetSlideByIdAsync(int id)
        {
            return await _unitOfWork.CarouselSlides.GetByIdAsync(id);
        }

        public async Task<CarouselSlide> CreateSlideAsync(CarouselSlide slide, string createdBy)
        {
            slide.CreatedBy = createdBy;
            slide.CreatedAt = DateTime.UtcNow;
            slide.IsActive = true;
            slide.IsDeleted = false;

            await _unitOfWork.CarouselSlides.AddAsync(slide);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide '{Title}' created by {User}", slide.Title, createdBy);

            return slide;
        }

        public async Task<CarouselSlide> UpdateSlideAsync(CarouselSlide slide, string updatedBy)
        {
            var existingSlide = await _unitOfWork.CarouselSlides.GetByIdAsync(slide.Id);
            if (existingSlide == null)
            {
                throw new ArgumentException($"Carousel slide with ID {slide.Id} not found");
            }

            // Update properties
            existingSlide.Title = slide.Title;
            existingSlide.Subtitle = slide.Subtitle;
            existingSlide.ImagePath = slide.ImagePath;
            existingSlide.MobileImagePath = slide.MobileImagePath;
            existingSlide.ImageAlt = slide.ImageAlt;
            existingSlide.LinkUrl = slide.LinkUrl;
            existingSlide.ButtonText = slide.ButtonText;
            existingSlide.ButtonClass = slide.ButtonClass;
            existingSlide.DisplayOrder = slide.DisplayOrder;
            existingSlide.IsActive = slide.IsActive;
            existingSlide.StartDate = slide.StartDate;
            existingSlide.EndDate = slide.EndDate;
            existingSlide.Location = slide.Location;
            existingSlide.CategoryId = slide.CategoryId;
            existingSlide.BackgroundColor = slide.BackgroundColor;
            existingSlide.TextColor = slide.TextColor;
            existingSlide.TextAlign = slide.TextAlign;
            existingSlide.AnimationType = slide.AnimationType;
            existingSlide.Duration = slide.Duration;
            existingSlide.CustomCssClass = slide.CustomCssClass;
            existingSlide.UpdatedBy = updatedBy;
            existingSlide.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CarouselSlides.Update(existingSlide);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide '{Title}' updated by {User}", existingSlide.Title, updatedBy);

            return existingSlide;
        }

        public async Task<bool> DeleteSlideAsync(int id, string deletedBy)
        {
            var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(id);
            if (slide == null)
            {
                return false;
            }

            // Soft delete
            slide.IsDeleted = true;
            slide.DeletedAt = DateTime.UtcNow;
            slide.DeletedBy = deletedBy;
            slide.IsActive = false;

            _unitOfWork.CarouselSlides.Update(slide);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide '{Title}' deleted by {User}", slide.Title, deletedBy);

            return true;
        }

        public async Task<bool> ToggleActiveStatusAsync(int id)
        {
            var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(id);
            if (slide == null)
            {
                return false;
            }

            slide.IsActive = !slide.IsActive;
            slide.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CarouselSlides.Update(slide);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide '{Title}' active status toggled to {Status}", 
                slide.Title, slide.IsActive);

            return true;
        }

        public async Task UpdateDisplayOrdersAsync(Dictionary<int, int> slideOrders)
        {
            await _unitOfWork.CarouselSlides.UpdateDisplayOrdersAsync(slideOrders);
            _logger.LogInformation("Display orders updated for {Count} carousel slides", slideOrders.Count);
        }

        public async Task<string> UploadImageAsync(IFormFile file, string subfolder = "")
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file provided");
            }

            // Validate file type
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            
            if (!allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"Invalid file type. Allowed: {string.Join(", ", allowedExtensions)}");
            }

            // Validate file size (max 5MB)
            if (file.Length > 5 * 1024 * 1024)
            {
                throw new ArgumentException("File size exceeds 5MB limit");
            }

            // Generate unique filename
            var fileName = $"{Guid.NewGuid()}{extension}";
            var uploadPath = Path.Combine(_environment.WebRootPath, "Img", "Carousel", subfolder);

            // Ensure directory exists
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, fileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return relative path
            var relativePath = Path.Combine("Carousel", subfolder, fileName).Replace("\\", "/");
            _logger.LogInformation("Carousel image uploaded: {Path}", relativePath);

            return relativePath;
        }

        public async Task<bool> DeleteImageAsync(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return false;
            }

            try
            {
                var fullPath = Path.Combine(_environment.WebRootPath, "Img", imagePath);
                
                if (File.Exists(fullPath))
                {
                    await Task.Run(() => File.Delete(fullPath));
                    _logger.LogInformation("Carousel image deleted: {Path}", imagePath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting carousel image: {Path}", imagePath);
                return false;
            }
        }
    }
}
