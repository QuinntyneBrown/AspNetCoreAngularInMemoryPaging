using System;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public class PlayerDto
    {
        public Guid PlayerId { get; set; }
        public Guid TeamId { get; set; }
        public string Name { get; set; }
    }
}
