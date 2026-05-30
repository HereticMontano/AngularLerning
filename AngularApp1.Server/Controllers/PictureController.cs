using AngularApp1.Server.Enum;
using AngularApp1.Server.Model;
using AngularApp1.Server.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repository.Interface;

namespace AngularApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;
        private readonly IOptions<StorageSettings> _storageSettings;  

        public PictureController(IGalleryRepository galleryRepository, IOptions<StorageSettings> storageSettings)
        {
            _galleryRepository = galleryRepository;
            _storageSettings = storageSettings;
        }

        [HttpGet("GetGallery")]
        public async Task<IEnumerable<PictureModel>> GetGallery(string galleryId)
        {
            var gallery = await _galleryRepository.GetByIdAsync(galleryId);

            if (gallery is null)
            {
                return [];
            }

            return gallery.Pictures.Select(picture => new PictureModel
            {
                URLLocationLowCuality = Path.Combine(_storageSettings.Value.RequestPath, Path.GetFileName(picture.UrlLocationLowCuality)),
                URLLocationHighCuality = Path.Combine(_storageSettings.Value.RequestPath, Path.GetFileName(picture.UrlLocationHighCuality)),
                Title = picture.Title,
                Description = picture.Description
            });
        }

        [HttpGet("Studio")]
        public IEnumerable<PictureModel> GetStudio()
        {
            return GetPicture(PictureType.Studio);
        }

        private IEnumerable<PictureModel> GetPicture(PictureType pictureType)
        {
            return pictureType switch
            {
                PictureType.Mural => [
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/navalosa-cropped.jpg?1769380103",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/navalosa-cropped_orig.jpg",
                       Title = "Mural Low Cuality",
                       Description = "Mural Low Cuality"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/1-isa.jpg?1769382318",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/1-isa.jpg?1769382318",
                       Title = "Mural 2 - Isa",
                       Description = "Mural - Isa"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/editor/alphabet-insta.jpg?1769380078",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/editor/alphabet-insta.jpg?1769380078",
                       Title = "Mural 3 - Alphabet",
                       Description = "Mural - Alphabet Insta"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/la-ola-cropped_orig.jpg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/la-ola-cropped_orig.jpg",
                       Title = "Mural 4 - La Ola",
                       Description = "Mural - La Ola Cropped"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/navalosa-situation-cropped_orig.jpg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/navalosa-situation-cropped_orig.jpg",
                       Title = "Mural 5 - Navalosa Situation",
                       Description = "Mural - Navalosa Situation"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/editor/1-hands.jpg?1769381677",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/editor/1-hands.jpg?1769381677",
                       Title = "Mural 6 - Hands",
                       Description = "Mural - Hands"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/1-jorge.jpg?1769382215",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/1-jorge.jpg?1769382215",
                       Title = "Mural 7 - Jorge",
                       Description = "Mural - Jorge"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/cowslip-big_orig.jpeg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/cowslip-big_orig.jpeg",
                       Title = "Mural 8 - Cowslip",
                       Description = "Mural - Cowslip Big"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/redpath-mural_orig.jpeg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/redpath-mural_orig.jpeg",
                       Title = "Mural 9 - Redpath",
                       Description = "Mural - Redpath"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/fratillery-big_orig.jpeg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/fratillery-big_orig.jpeg",
                       Title = "Mural 10 - Fratillery",
                       Description = "Mural - Fratillery Big"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/1-galayos.jpg?1769382366",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/1-galayos.jpg?1769382366",
                       Title = "Mural 11 - Galayos",
                       Description = "Mural - Galayos"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/foto-mural-balia_orig.jpg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/foto-mural-balia_orig.jpg",
                       Title = "Mural 12 - Balia",
                       Description = "Mural - Balia"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/colour-welcome.jpg?1769382485",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/published/colour-welcome.jpg?1769382485",
                       Title = "Mural 13 - Welcome",
                       Description = "Mural - Colour Welcome"
                   }
                ],
                PictureType.Studio =>
                [
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/5136632.jpg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/5136632_orig.jpg",
                       Title = "Studio 1",
                       Description = "Studio 1"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/6458756.jpg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/6458756_orig.jpg",
                       Title = "Studio 2",
                       Description = "Studio 2"
                   },
                   new PictureModel
                   {
                       URLLocationLowCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/8437915.jpg",
                       URLLocationHighCuality = "https://mairiupton.weebly.com/uploads/2/3/1/5/2315001/8437915_orig.jpg",
                       Title = "Studio 3",
                       Description = "Studio 3"
                   }
                ],
                _ => throw new ArgumentOutOfRangeException(nameof(pictureType), pictureType, null)
            };
        }
    }
}
