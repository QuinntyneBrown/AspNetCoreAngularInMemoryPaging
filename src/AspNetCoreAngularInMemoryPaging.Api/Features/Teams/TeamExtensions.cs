using System;
using AspNetCoreAngularInMemoryPaging.Api.Models;

namespace AspNetCoreAngularInMemoryPaging.Api.Features
{
    public static class TeamExtensions
    {
        public static TeamDto ToDto(this Team team)
        {
            return new()
            {
                TeamId = team.TeamId,
                City = team.City,
                Name = team.Name
            };
        }

    }
}
