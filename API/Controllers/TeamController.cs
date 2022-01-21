using System.Collections.Generic;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IRepositoryBase<Team> _repository;
        public TeamController(IRepositoryBase<Team> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return _repository.GetAll();
        }


    }

}