using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Care_Centre_MVC.Models
{
    //Pet care session
    public class PetCareSession
    {
        //Pet care id
        public int Id { get; set; }

        //Pet care taker id
        public int CareTakerId { get; set; }

        //Pets id 
        public int PetId { get; set; }

        //Care taker link
        public CareTaker CareTaker { get; set; }

        //Pet relationship link
        public Pet Pet { get; set; }

        //Start time
        public DateTime Start { get; set; }

        //End time
        public DateTime End { get; set; }

    }
}
