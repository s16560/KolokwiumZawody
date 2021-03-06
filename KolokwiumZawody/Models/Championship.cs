﻿using System.Collections;
using System.Collections.Generic;

namespace KolokwiumZawody.Models
{
    public class Championship
    {
        public int IdChampionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }
        public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }
    }
}