﻿using System;
using Link.Common.Domain.Framework.Models;

namespace Link.EmailManagement.Domain.Model.Entities
{
    public class ExpertId : ValueObject<ExpertId>
    {
        public static ExpertId NewExpertId => new ExpertId(Guid.NewGuid().ToString());

        public ExpertId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Id);

        protected override bool EqualsCore(ExpertId other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
