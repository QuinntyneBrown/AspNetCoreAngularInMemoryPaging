using AspNetCoreAngularInMemoryPaging.Api.Models;
using System.Linq;

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
                Name = team.Name,
                Players = team.Players.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
