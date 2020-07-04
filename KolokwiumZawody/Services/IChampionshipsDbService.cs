using KolokwiumZawody.DTO.Requests;
using KolokwiumZawody.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumZawody.Services
{
    public interface IChampionshipsDbService
    {
        public List<TeamScoreResponse> GetTeamsWithScores(int id);
        public void JoinPlayer(JoinPlayerRequest request, int id);
    }
}
