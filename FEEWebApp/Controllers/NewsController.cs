using Infrastructure.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUniteOfWork _unitOfWork;
        public NewsController(IUniteOfWork uniteOfWork)
        {
            this._unitOfWork = uniteOfWork;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(new { data = _unitOfWork.news.GetAll() });
        }



    }
}
