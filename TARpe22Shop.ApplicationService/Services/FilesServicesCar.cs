using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopMyyrsepp.Core.Domain;
using TARpe22ShopMyyrsepp.Core.Dto;
using TARpe22ShopMyyrsepp.Core.ServiceInterface;
using TARpe22ShopMyyrsepp.Data;

namespace TARpe22ShopMyyrsepp.ApplicationServices.Services
{
    public class FilesServicesCar : IFilesServicesCar
    {
        private readonly TARpe22ShopMyyrseppContext _context;
        private readonly IHostingEnvironment _webHost;
        public FilesServicesCar(TARpe22ShopMyyrseppContext context, IHostingEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public void FilesToApiCar(CarDto dto, Car realEstate)
        {
            string uniqueFileName = null;
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.WebRootPath + "\\multipleFileUpload\\");
                }
                foreach (var image in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                        FileToApiCar path = new FileToApiCar
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            CarId = realEstate.Id
                        };
                        _context.FilesToApiCar.AddAsync(path);
                    }
                }
            }
        }
        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiCarDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var imageId = await _context.FilesToApiCar
                    .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
                var filePath = _webHost.WebRootPath + "\\multipleFileUpload\\" + imageId.ExistingFilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                _context.FilesToApiCar.Remove(imageId);
                await _context.SaveChangesAsync();
            }
            return null;
        }
        public async Task<FileToApi> RemoveImageFromApi(FileToApiCarDto dto)
        {
            var imageId = await _context.FilesToApiCar
                .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
            var filePath = _webHost.WebRootPath + "\\multipleFileUpload\\" + imageId.ExistingFilePath;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FilesToApiCar.Remove(imageId);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
