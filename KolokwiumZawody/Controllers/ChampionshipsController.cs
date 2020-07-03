using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolokwiumZawody.Exceptions;
using KolokwiumZawody.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumZawody.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipsDbService _dbService;

        public ChampionshipsController(IChampionshipsDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTeamsWithScores(int id) {
            try
            {
                var response = _dbService.GetTeamsWithScores(id);
                return Ok(response);
            }
            catch (ChampionshipDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}