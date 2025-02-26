﻿using Microsoft.EntityFrameworkCore;
using SkillsShowcase.Shared.Domain.Models;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.Repositories
{
    public class AssassinsRepository(AppDbContext appDbContext)
    {
        //GET ASSASSINS FROM CONTEXT
        internal async Task<AssassinsForApiCall[]> GetAssassinsFromContext()
        {
            Assassins[]? result = await appDbContext.Assassins.ToArrayAsync();
            return result.Select(assassin => new AssassinsForApiCall
            {
                AssassinId = assassin.AssassinId,
                FirstName = assassin.FirstName,
                LastName = assassin.LastName,
                Age = assassin.Age,
                Height = assassin.Height,
                RegisteredDate = assassin.RegisteredDate,
                State = assassin.State,
                MartialArt = assassin.MartialArt,
                Weapon = assassin.Weapon,
            }).ToArray();
        }
        //CREATE ASSASSIN FROM CONTEXT
        internal async Task CreateNewAssassin(AssassinsForApiCall assassinsForApiCall)
        {
            Assassins assassin = new()
            {
                FirstName = assassinsForApiCall.FirstName,
                LastName = assassinsForApiCall.LastName,
                Age = assassinsForApiCall.Age,
                Height = assassinsForApiCall.Height,
                RegisteredDate = assassinsForApiCall.RegisteredDate,
                State = assassinsForApiCall.State,
                MartialArt = assassinsForApiCall.MartialArt,
                Weapon = assassinsForApiCall.Weapon,
            };
            await appDbContext.Assassins.AddAsync(assassin);
            await appDbContext.SaveChangesAsync();
        }
    }
}
