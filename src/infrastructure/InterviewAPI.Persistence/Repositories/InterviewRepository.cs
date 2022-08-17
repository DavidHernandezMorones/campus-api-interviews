using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Context;
using InterviewAPI.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories
{
    public class InterviewRepository : RepositoryBase<Interview>, IInterviewRepository
    {
        public InterviewRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }

        public override async Task<List<Interview>> GetAll()
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public override async Task<List<Interview>> GetByCondition(Expression<Func<Interview, bool>> expression)
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public override void Create(Interview entity)
        {
            InterviewContext.Set<Interview>().Attach(entity);
        }

        public override void Update(Interview entity)
        {
            // InterviewContext.Entry(entity).State = EntityState.Modified;
            InterviewContext.Set<Interview>().Update(entity);
        }
    }
}