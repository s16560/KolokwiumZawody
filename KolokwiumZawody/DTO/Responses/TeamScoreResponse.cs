using KolokwiumZawody.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumZawody.DTO.Responses
{
    public class TeamScoreResponse
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        public float Score { get; set; }
    }
}
