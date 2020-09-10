using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Centre_MVC.Models;

namespace Pet_Care_Centre_MVC.Models
{
    //Connects the database with model classes
    public class Pet_Care_Centre_MVCDataContext : DbContext
    {
        public Pet_Care_Centre_MVCDataContext (DbContextOptions<Pet_Care_Centre_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<Pet_Care_Centre_MVC.Models.CareTaker> CareTaker { get; set; }

        public DbSet<Pet_Care_Centre_MVC.Models.Pet> Pet { get; set; }

        public DbSet<Pet_Care_Centre_MVC.Models.PetCareSession> PetCareSession { get; set; }
    }
}
