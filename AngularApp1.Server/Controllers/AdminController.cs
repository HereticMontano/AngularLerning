using AngularApp1.Server.Enum;
using AngularApp1.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;

namespace AngularApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {        
        private readonly IGalleryRepository _galleryRepository;
        public AdminController(IGalleryRepository galleryRepository) 
        {
            _galleryRepository = galleryRepository;
        }
        public void Login()
        {
     
        }

    }
}
