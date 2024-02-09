using TARpe22ShopMyyrsepp.Core.Domain;
using TARpe22ShopMyyrsepp.Core.Dto;

namespace TARpe22ShopMyyrsepp.Core.ServiceInterface
{
    public interface IFilesServicesCar
    {
        void FilesToApiCar(CarDto dto, Car car);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiCarDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiCarDto dto);
    }
}
