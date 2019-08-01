using System;
using System.ComponentModel.DataAnnotations;

namespace AvaliadorGastronomico.Domain.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MinLengthAttribute : ValidationAttribute
    {
        private int _minCharacters;
        public MinLengthAttribute(int minCharacters)
        {
            _minCharacters = minCharacters;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
}
