using Dapper.Business.Models;
using Dapper.Business.Repositories;
using Dapper.Business.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperAPI.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public readonly PlayerRepository playerRepository;
        public PlayerController()
        {
            playerRepository = new PlayerRepository();
        }

        [HttpGet]//Çalışıyor
        public async Task<IEnumerable<Player>> Get()
        {
            return await playerRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] PlayerAddRequest players)
        {
            if (ModelState.IsValid)
            {
                playerRepository.Add(players);
            }
        }

        [HttpGet("{id}")] //Çalışıyor
        public async Task<Player> Get(int id)
        {
            return await playerRepository.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Player players)
        {
            players.id = id;
            if (ModelState.IsValid)
            {
                playerRepository.Update(players);
            }
        }

        [HttpDelete]
        public async void Delete(int id)
        {
            playerRepository.Delete(id);
        }
    }
}
