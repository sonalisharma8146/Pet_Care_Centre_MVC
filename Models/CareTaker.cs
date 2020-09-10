using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Care_Centre_MVC.Models
{
    //Care taker information
    public class CareTaker
    {
        //Care taker id
        public int Id { get; set; }

        //Care taker Name
        public string Name { get; set; }

        //Care taker number.
        public string  PhoneNumber {get; set;}
    }
}
