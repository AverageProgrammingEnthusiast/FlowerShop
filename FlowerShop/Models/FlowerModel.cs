using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models
{
    public class FlowersModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Flowering { get; set; }

        public string Colour { get; set; }

        public int Size { get; set; }

        public FlowersModel(int id, string name, string flowering, string colour, int size)
        {
            Id = id;
            Name = name;
            Flowering = flowering;
            Colour = colour;
            Size = size;
        }

        public FlowersModel()
        {

            Id = 1;
            Name = "Rose";
            Flowering = "June";
            Colour = "Red";
            Size = 30;
           

        }
    }
}