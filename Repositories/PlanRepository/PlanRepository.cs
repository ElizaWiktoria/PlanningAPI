﻿using Microsoft.EntityFrameworkCore;
using PlanningAPI.DataContext;
using PlanningAPI.Models;

namespace PlanningAPI.Repositories.PlanRepository
{
    public class PlanRepository : GenericRepository<Plan>, IPlanRepository
    {
        public PlanRepository(DataContextEF dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Plan> GetPlansIncludingRoutine()
        {
            return _dbContext.Plans
                .Include(x => x.Routine)
                .AsQueryable()
                .ToList();
        }
    }
}