using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        // Other annotations
        //[RegularExpression("abc")]
        //[Range(1,10)]
        //[DisplayFormat(DataFormatString =)]
        //[DisplayFormat(NullDisplayText =)]
        //[DataType(DataType.Password)]
        
        [Required]
        public string Name { get; set; }

        [Display(Name = "Type of food")]
        public CuisineType Cuisine { get; set; }
    }
}
