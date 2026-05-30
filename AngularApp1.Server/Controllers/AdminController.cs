using AngularApp1.Server.Model;
using AngularApp1.Server.Service;
using AngularApp1.Server.Settings;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;

namespace AngularApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;
        private readonly IProcessImagService _processImagService;
        private readonly StorageSettings _storageSettings;

        public AdminController(IGalleryRepository galleryRepository, IProcessImagService processImagService, StorageSettings storageSettings)
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
                var pathOriginal = Path.Combine(_storageSettings.RootPictures, $"{nameFile}_Original.jpg");
                var pathLowQuality = Path.Combine(_storageSettings.RootPictures, $"{nameFile}_Resized.jpg");

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
    }
}

