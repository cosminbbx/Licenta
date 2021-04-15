using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalEventPlaner.Web.Models.Validation
{
    public class ListHasElements : ValidationAttribute
    {
        public override bool IsValid(object mylist)
        {
            if (mylist == null)
                return false;

            return true;
        }
    }
}
