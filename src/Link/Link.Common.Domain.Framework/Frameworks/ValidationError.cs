using System;

namespace Link.Common.Domain.Framework.Frameworks
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