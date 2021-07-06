﻿using Core.Entites;
using Infrastructure.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FEEWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainBarController : BaseController<IMainBarRepository, MainBar>
    {
        private readonly IMainBarRepository mainBarRepository;
        private readonly IUniteOfWork _uniteOfWork;

        public MainBarController(IUniteOfWork uniteOfWork, IMainBarRepository mainBarRepository)
            : base(mainBarRepository, uniteOfWork)
        {
            
            _uniteOfWork = uniteOfWork;
            this.mainBarRepository = mainBarRepository;
        }
    } 
}