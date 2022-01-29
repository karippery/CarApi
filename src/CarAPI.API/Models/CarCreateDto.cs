using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CarCreateDto
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Model { get; set; }
    }
}
