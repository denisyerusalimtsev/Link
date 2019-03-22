using System;
using System.Collections.Generic;
using System.Text;

namespace Link.EventManagement.Application.Frameworks.Events
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HandleAttribute : Attribute
    {
        public HandleAttribute(Type eventType)
        {
            EventType = eventType;
        }

        public Type EventType { get; }
    }
}
