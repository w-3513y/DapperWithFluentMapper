using System.Collections.Generic;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryBase<Player> _repository;
        public PlayerController(IRepositoryBase<Player> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _repository.GetAll();
        }


    }

}