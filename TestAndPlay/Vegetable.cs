using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAndPlay
{
    [Serializable]
    public class Vegetable
    {
        private string nutrient;
        private string color;


        public string Nutrient
        {
            get { return nutrient; }
            set { nutrient = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
