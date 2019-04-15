﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Domain.Model.Interfaces
{
    public interface IExpertService
    {
        Task<List<Expert>> GetExperts(IEnumerable<ExpertId> expertsId);
    }
}