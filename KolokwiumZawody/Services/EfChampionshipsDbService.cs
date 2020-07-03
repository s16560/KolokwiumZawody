using KolokwiumZawody.DTO.Responses;
using KolokwiumZawody.Exceptions;
using KolokwiumZawody.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumZawody.Services
{
    public class EfChampionshipsDbService : IChampionshipsDbService
    {
        private readonly ChampionshipDbContext _context;
        public EfChampionshipsDbService(ChampionshipDbContext context)
        {
            _context = context;
        }
        public List<TeamScoreResponse> GetTeamsWithScores(int id)
        {
            var championship = _context.Championships                               
                                 .FirstOrDefault(c => c.IdChampionship == id);

            if (championship == null) {
                throw new ChampionshipDoesNotExistException($"Championship with id {id} doesn't exist");
            }
           
            var championshipTeams = _context.ChampionshipTeams
                                    .Where(c => c.IdChampionship == championship.IdChampionship)
                                    .Include(c => c.Team)
                                    .OrderBy(c => c.Score).ToList();

            var result = new List<TeamScoreResponse>();

            foreach (ChampionshipTeam c in championshipTeams)
            {
                var idTeam = c.IdTeam;
                var teamName = c.Team.TeamName;
                var maxAge = c.Team.MaxAge;
                var score = c.Score;

                result.Add(new TeamScoreResponse { IdTeam = idTeam, TeamName = teamName, MaxAge = maxAge, Score = score });
            }
   
            return result;
        }
    }
}
