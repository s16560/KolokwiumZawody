using KolokwiumZawody.DTO.Requests;
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
                                    .OrderBy(c => c.Score)
                                    .ToList();

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

        public void JoinPlayer(JoinPlayerRequest request, int id)
        {      
            var player = _context.Players
                        .Where(p => p.FirstName == request.firstName)
                        .Where(p => p.LastName == request.lastName)
                        .Where(p => p.DateOfBirth == request.birthDate)
                        .SingleOrDefault();

            //czy gracz istnieje
            if (player == null) {
                throw new PlayerDoesNotExistException("Gracz nie istnieje");
            }

            //czy gracz przypisany do drużyny
            var playerTeamExist = _context.PlayerTeams
                            .Any(pt => pt.IdPlayer == player.IdPlayer
                                && pt.IdTeam == id);

            if (playerTeamExist) {
                throw new PlayerTeamAlreadyExistException("Gracz jest już przypisany do drużyny");
            }

            var team = _context.Teams.Where(t => t.IdTeam == id).SingleOrDefault();

            //czy spelnia kryterium wieku
            var playerAge = (DateTime.Now.Year - request.birthDate.Year);

            if (playerAge > team.MaxAge) {
                throw new PlayerTooOldException("Gracz zbyt zaawansowany wiekowo");
            }

            PlayerTeam pt = new PlayerTeam {
               // IdPlayer = player.IdPlayer,
               // IdTeam = id,
                NumOnShirt = request.numOnShirt,
                Comment = request.comment,
                Player = player,
                Team = team      
            };

            _context.PlayerTeams.Add(pt);
            _context.SaveChanges();
        }
    }
}
