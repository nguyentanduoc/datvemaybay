using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatVeMayBay.EntityViews
{
    //: IValidatableObject
    public class SearchEVTicket
    {

        public int MA_SAN_BAY_DI { get; set; }
        public int MA_SAN_BAY_DEN { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime NGAY_DI { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (DateTime.Now > NGAY_DI)
            {
                results.Add(new ValidationResult("Ngày đi trong quá khứ"));
            }
            if (MA_SAN_BAY_DI == MA_SAN_BAY_DEN)
            {
                results.Add(new ValidationResult("Điểm đi và đến bị trùng"));
            }

            return results;
        }
    }
}