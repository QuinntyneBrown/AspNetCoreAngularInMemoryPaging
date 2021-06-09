using System;
using System.Collections.Generic;

namespace AspNetCoreAngularInMemoryPaging.Api.Models
{
    public class Team
    {
        public Guid TeamId { get; private set; }
        public string City { get; private set; }
        public string Name { get; private set; }
        public List<Player> Players { get; private set; } = new();

        public Team(string city, string name)
        {
            City = city;
            Name = name;
        }

        public Team(string city, string name, List<Player> players)
        {
            City = city;
            Name = name;
            Players = players;
        }

        private Team()
        {

        }
    }
}
