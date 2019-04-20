﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Domain.Services.Interfaces
{
    public interface IExpertService
    {
        Task<Expert> GetExpert(ExpertId expertsId);

        Task<List<Expert>> GetExperts(IEnumerable<ExpertId> expertsId);
    }
}
