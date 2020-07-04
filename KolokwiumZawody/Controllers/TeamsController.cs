using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolokwiumZawody.DTO.Requests;
using KolokwiumZawody.Exceptions;
using KolokwiumZawody.Models;
using KolokwiumZawody.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumZawody.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly IChampionshipsDbService _dbService;

        public TeamsController(IChampionshipsDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("{id:int}/players")]
        public IActionResult JoinPlayer(JoinPlayerRequest request, int id) {
            try
            {
                _dbService.JoinPlayer(request, id);
                return Ok("Player has joined to the team");
            }
            catch (PlayerDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
            catch (PlayerTeamAlreadyExistException e) {
                return BadRequest(e.Message);
            }
            catch (PlayerTooOldException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}