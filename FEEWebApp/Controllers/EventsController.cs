using Core.Entites;
using Core.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace FEEWebApp.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventsController : BaseController<IEventsRepository, Events>
    {
        private readonly IEventsRepository eventsRepository;
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventsController(IEventsRepository eventsRepository, IUniteOfWork uniteOfWork, IHttpContextAccessor httpContextAccessor)
            : base(eventsRepository, uniteOfWork, httpContextAccessor)
        {

            _uniteOfWork = uniteOfWork;
            this.eventsRepository = eventsRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
