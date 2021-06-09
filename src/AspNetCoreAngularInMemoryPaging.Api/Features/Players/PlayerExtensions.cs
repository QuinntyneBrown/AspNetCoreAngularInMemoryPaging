using System;
using AspNetCoreAngularInMemoryPaging.Api.Models;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public static class PlayerExtensions
    {
        public static PlayerDto ToDto(this Player player)
        {
            return new ()
            {
                PlayerId = player.PlayerId,
                TeamId = player.TeamId,
                Name = player.Name
            };
        }
        
    }
}
