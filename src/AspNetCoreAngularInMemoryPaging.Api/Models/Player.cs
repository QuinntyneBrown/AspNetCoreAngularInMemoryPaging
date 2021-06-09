using System;

namespace AspNetCoreAngularInMemoryPaging.Api.Models
{
    public class Player
    {
        public Guid PlayerId { get; private set; }
        public Guid TeamId { get; private set; }
        public string Name { get; private set; }

        public Player(Guid teamId, string name)
        {
            TeamId = teamId;
            Name = name;
        }

        public Player(string name)
        {            
            Name = name;
        }

        private Player()
        {

        }
    }
}
