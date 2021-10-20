using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SkiPicker.Models;

namespace SkiPicker.Services
{
    public class SkiPickerService
    {
        public IWebHostEnvironment WebHostEnvironment {get;}
        public Random RandomGenerator { get; }


        public SkiPickerService(IWebHostEnvironment webHostEnvrionment, Random random)
        {
            WebHostEnvironment = webHostEnvrionment;
            RandomGenerator = random;
        }

        public int CalculateSkiLength(SkiInfo skiInfo)
        {
            if (skiInfo == null)
                throw new ArgumentNullException("Info is null");

            if (skiInfo.Age < 0)
                throw new ArgumentException("Age may not be negative");

            if (skiInfo.Height < 0)
            {
                throw new ArgumentException("Height may not be negative");
            }

            int skiLength = skiInfo.Height;

            if (skiInfo.Age < 5)
                return skiLength;

            if (skiInfo.Age < 9)
                return skiLength + RandomGenerator.Next(11) + 10;

            if (skiInfo.SkiType.Equals(SkiInfo.SkiTypes.Classic))
                return Math.Min(skiLength + 20, 207);
            
            return skiLength + RandomGenerator.Next(6) + 10;
        }
    }
}
