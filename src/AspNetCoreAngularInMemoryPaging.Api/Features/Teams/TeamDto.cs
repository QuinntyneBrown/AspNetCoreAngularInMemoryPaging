using System;
using System.Collections.Generic;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class TeamDto
    {
        public Guid TeamId { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public List<PlayerDto> Players { get; set; } = new();
    }
}
