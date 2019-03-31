using System;

namespace Link.Common.Domain.Framework.Frameworks.Events
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
