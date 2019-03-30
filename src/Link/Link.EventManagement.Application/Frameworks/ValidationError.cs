using System;

namespace Link.EventManagement.Application.Frameworks
{
    public sealed class ValidationError : Exception
    {
        public ValidationError(string fieldName, string message)
            : base(message)
        {
            FieldName = fieldName;
        }

        public string FieldName { get; }
    }
}