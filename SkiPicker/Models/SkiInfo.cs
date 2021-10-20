using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkiPicker.Models
{
    public class SkiInfo
    {
        public SkiInfo()
        {

        }

        public SkiInfo(int age, int height, SkiTypes skiType)
        {
            Age = age;
            Height = height;
            SkiType = skiType;
        }

        public enum SkiTypes
        {
            Classic, 
            Freestyle
        }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public SkiTypes SkiType { get; set; }
    }
}
