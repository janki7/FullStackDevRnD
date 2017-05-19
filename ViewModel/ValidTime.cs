using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FullstackPluralsightProjectToLearn.ViewModel
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime);

            return (isValid);
            //return base.IsValid(value);
        }

    }
}