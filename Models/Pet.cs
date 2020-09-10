using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Care_Centre_MVC.Models
{
    //Pet information.
    public class Pet
    {
        //Pet id
        public int Id { get; set; }

        //Pet name
        public string Name { get; set; }

        //Pet type
        public PetType PetType { get; set; }


    }


    public enum PetType { 
        DOG,CAT 
    
    }
}
