using System;

namespace AspNetCoreAngularInMemoryPaging.Api.Models
{
    public class Team
    {
        public Guid TeamId { get; private set; }
        public string City { get; private set; }
        public string Name { get; private set; }

        public Team(string city, string name)
        {
            City = city;
            Name = name;
        }

        private Team()
        {

        }
    }
}
