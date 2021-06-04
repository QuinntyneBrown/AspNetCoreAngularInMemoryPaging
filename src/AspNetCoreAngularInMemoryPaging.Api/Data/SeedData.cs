using AspNetCoreAngularInMemoryPaging.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreAngularInMemoryPaging.Api.Data
{
    public static class SeedData
    {
        public static void Seed(AspNetCoreAngularInMemoryPagingDbContext context)
        {
            foreach(var team in new List<Team>
            {
                new("Chicago","Bulls"),
                new("Toronto","Raptors"),
                new("New York","Knicks"),
                new("Charlotte","Hornets"),
                new("Miami","Heat"),
                new("Utah","Jazz"),
                new("Dalls","Mavericks"),
                new("Boston","Celtics"),
                new("Brooklyn","Nets"),
                new("Memphis","Grizzlies"),
                new("Denver","Nuggets"),
                new("Detroit","Pistons"),
            })
            {
                AddIfDoesntExist(team);
            }

            void AddIfDoesntExist(Team team)
            {
                if(context.Teams.SingleOrDefault(x => x.Name == team.Name) == null)
                {
                    context.Teams.Add(team);
                    context.SaveChanges();
                }
            }
        }
    }
}
