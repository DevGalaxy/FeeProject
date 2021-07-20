using Core.Entites;
using Core.IRepository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEEWebApp.Controllers
{
    public class PositionController : BaseController<IPosition, Position>
    {
        private readonly IPosition _repo;
        private readonly IUniteOfWork _uniteOfWork;

        public PositionController(IUniteOfWork uniteOfWork, IPosition repo)
            : base(repo, uniteOfWork)
        {
            _repo = repo;
            _uniteOfWork = uniteOfWork;
        }
    }
}
