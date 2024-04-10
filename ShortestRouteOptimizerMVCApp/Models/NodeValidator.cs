using System;
using System.ComponentModel.DataAnnotations;

namespace ShortestRouteOptimizerMVCApp.Models
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public sealed class NodeValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool isValid = false;
            char node;
            if (value == null)
            {
                return isValid;
            }

            isValid = char.TryParse(value.ToString().ToUpper(), out node);

            if (isValid)
            {
                isValid = node >= char.Parse("A") && node <= char.Parse("I");
            }

            return isValid;
        }
    }
}