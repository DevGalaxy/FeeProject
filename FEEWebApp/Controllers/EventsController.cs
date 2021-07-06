using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseController<IEventsRepository, Events>
    {
        private readonly IEventsRepository eventsRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public EventsController(IEventsRepository eventsRepository, IUniteOfWork uniteOfWork)
            : base(eventsRepository, uniteOfWork)
        {
          
            _uniteOfWork = uniteOfWork;
            this.eventsRepository = eventsRepository;
        }
    }
}
