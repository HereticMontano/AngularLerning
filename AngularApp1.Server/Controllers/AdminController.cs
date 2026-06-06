using AngularApp1.Server.Model;
using AngularApp1.Server.Service;
using AngularApp1.Server.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repository.Interface;

namespace AngularApp1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;
        private readonly IProcessImagService _processImagService;
        private readonly IOptions<StorageSettings> _storageSettings;

        public AdminController(IGalleryRepository galleryRepository, IProcessImagService processImagService, IOptions<StorageSettings> storageSettings)
        {
            _galleryRepository = galleryRepository;
            _processImagService = processImagService;
            _storageSettings = storageSettings;
        }

        [HttpPost("Login")]
        public void Login()
        {

        }

        [HttpPost("AddGallery")]
        public async Task<IActionResult> AddGalleryAsync(CreateGalleryRequest galleryModel)
        {
            if (string.IsNullOrEmpty(galleryModel.Title))
            {
                return BadRequest("El título de la galería es requerido.");
            }

            await _galleryRepository.CreateAsync(new Repository.Entity.Gallery
            {
                Title = galleryModel.Title
            });
            return Created();
        }

        [HttpPost("AddPicture")]
        public async Task<IActionResult> AddPictureAsync(AddPictureRequest request)
        {
            try
            {
                var originalPicture = _processImagService.DecodeBase64ToBytes(request.Base64Picture);

                var resizedPicture = await _processImagService.ResizePictureAsync(originalPicture, 0.5);

                string nameFile = $"{Guid.NewGuid()}";
                var pathOriginal = Path.Combine(_storageSettings.Value.RootPictures, $"{nameFile}_Original.jpg");
                var pathLowQuality = Path.Combine(_storageSettings.Value.RootPictures, $"{nameFile}_Resized.jpg");

                System.IO.File.WriteAllBytes(pathOriginal, originalPicture);
                System.IO.File.WriteAllBytes(pathLowQuality, resizedPicture);

                var isCreated = await _galleryRepository.AddPictureToGalleryAsync(request.IdGallery, new Repository.Entity.Picture
                {
                    Title = request.Title,
                    Description = request.Description,
                    UrlLocationHighCuality = pathOriginal,
                    UrlLocationLowCuality = pathLowQuality

                });

                return isCreated ? Created() : NotFound();


            }
            catch (FormatException)
            {
                return BadRequest("Base64Picture no es un Base64 válido.");
            }


        }

        [HttpDelete("DeletePicture/{galleryId}/{pictureId}")]
        public async Task<IActionResult> DeletePictureAsync(string galleryId, string pictureId)
        {
            var deletedPicture = await _galleryRepository.DeletePictureFromGalleryAsync(galleryId, pictureId);
            
            if (deletedPicture is null)
            {
                return NotFound();
            }

            if (System.IO.File.Exists(deletedPicture.UrlLocationHighCuality))
            {
                System.IO.File.Delete(deletedPicture.UrlLocationHighCuality);
            }

            if (System.IO.File.Exists(deletedPicture.UrlLocationLowCuality))
            {
                System.IO.File.Delete(deletedPicture.UrlLocationLowCuality);
            }

            return NoContent();
        }

        [HttpDelete("DeleteGallery/{id}")]
        public async Task<IActionResult> DeleteGalleryAsync(string id)
        {
            var gallery = await _galleryRepository.GetByIdAsync(id);
            
            if (gallery is null)
            {
                return NotFound();
            }

            foreach (var picture in gallery.Pictures)
            {
                if (System.IO.File.Exists(picture.UrlLocationHighCuality))
                {
                    System.IO.File.Delete(picture.UrlLocationHighCuality);
                }

                if (System.IO.File.Exists(picture.UrlLocationLowCuality))
                {
                    System.IO.File.Delete(picture.UrlLocationLowCuality);
                }
            }

            await _galleryRepository.DeleteGalleryAsync(id);

            return NoContent();
        }
    }
}

