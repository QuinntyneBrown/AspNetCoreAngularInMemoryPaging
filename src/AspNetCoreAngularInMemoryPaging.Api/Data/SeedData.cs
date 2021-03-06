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
                new("Chicago","Bulls", new() { 
                    new("Michael Jordan"),
                    new("Scottie Pippen"),
                    new("Dennis Rodman"),
                    new("John Paxton")
                }),
                new("Toronto","Raptors", new() { 
                    new("Pascal Siakam"),
                    new("Kawahi Leonard"),
                    new("Fred Vanfleet"),
                    new("Norman Powel"),
                    new("Kyle Lowry"),
                    new("DeMar DeRozan"),
                    new("Marc Gasol"),
                    new("Danny Green")
                }),
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
