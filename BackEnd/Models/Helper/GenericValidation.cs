using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace assignment_tess.Models.Helper
{
    public class GenericValidation
    {
        public class FormatEmail : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    if (value is string)
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            Regex rg = new Regex(@"^[\w-\.]{3,}@([\w-]+\.)+[\w-]{2,4}$");
                            MatchCollection match = rg.Matches(value.ToString());
                            if (match.Count <= 0)
                            {
                                return new ValidationResult($"Format {validationContext.DisplayName} Tidak Valid");
                            }
                        }
                    }
                }

                return ValidationResult.Success;
            }
        }
        public class FormatNoHP : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    if (value is string)
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            if (value.ToString().Substring(0, 2) != "08") return new ValidationResult($"Format {validationContext.DisplayName} Tidak Valid");
                        }
                    }
                }

                return ValidationResult.Success;
            }
        }
        public class FormatNoTelp : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    if (value is string)
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            if (value.ToString().Substring(0, 1) != "0") return new ValidationResult($"Format {validationContext.DisplayName} Tidak Valid");
                        }
                    }
                }

                return ValidationResult.Success;
            }
        }
        public class OnlyNumber : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    if (value is string)
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            Regex rg = new Regex(@"^\d+$");
                            MatchCollection match = rg.Matches(value.ToString());
                            if (match.Count <= 0)
                            {
                                return new ValidationResult($"Format {validationContext.DisplayName} Harus Angka");
                            }
                        }
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}
