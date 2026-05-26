using AngularApp1.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController : ControllerBase
    {
        [HttpGet(Name = "GetMural")]
        public IEnumerable<PictureModel> GetMural()
        {
            return new[]
            {
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
           };
        }
    }
}
