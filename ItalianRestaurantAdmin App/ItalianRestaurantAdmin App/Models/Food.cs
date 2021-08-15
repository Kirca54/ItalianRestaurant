using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItalianRestaurantAdmin_App.Models
{
    public class Food
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public String Image { get; set; }
        public String Description { get; set; }
        public int Rating { get; set; }
        public int Price { get; set; }

        
    }
}
