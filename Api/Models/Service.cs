﻿using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class Service
    {
        public string Status { get; set; }
        public List<Incident> Incidents { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
