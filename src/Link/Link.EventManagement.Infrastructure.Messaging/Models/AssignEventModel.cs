﻿using Link.EventManagement.Infrastructure.DataAccess.MongoDb.Models;
using System.Collections.Generic;

namespace Link.EventManagement.Infrastructure.Messaging.Models
{
    public class AssignEventModel
    {
        public AssignEventModel(EventTransfer ev, List<ExpertStorageDto> experts)
        {
            Event = ev;
            Experts = experts;
        }

        public EventTransfer Event { get; set; }

        public List<ExpertStorageDto> Experts { get; set; }
    }
}
