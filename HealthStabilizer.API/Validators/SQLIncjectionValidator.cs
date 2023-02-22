using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStabilizer.API.Validators
{
    public class SQLIncjectionValidator
    {

        /// <summary>
        /// Returning true when Validation pass SQL incjection is not detect
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool Validate(string text)
        {
            var textToLower = text.ToLower();
            if
                (textToLower.IndexOf('*') != -1 || textToLower.IndexOf("'") != -1 ||
                textToLower.IndexOf(';') != -1 || textToLower.IndexOf('-') != -1 ||
                textToLower.IndexOf(',') != -1 || textToLower.IndexOf('.') !=-1 ||
                textToLower.Contains("drop") || textToLower.Contains("select") ||
                textToLower.Contains("update") || textToLower.Contains("delete") ||
                textToLower.Contains("insert") || textToLower.Contains("execute") )
                return false;
            return true;
        }
    }
}
