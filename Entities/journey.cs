using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class journey
    {

        // private atribute 'id' for journey
        private int id;

        // private atribute 'people' for journey
        private int people;

        // private atribute 'travelInCar' for CarOfTravel
        private int travelInCar;

        // public property for 'id'
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        // public property for 'people'
        public int People
        {
            get { return people; }
            set { people = value; }
        }

        //public property for 'travelIn'
        public int TravelInCar
        {
            get { return travelInCar; }
            set { travelInCar = value; }
        }

        // Constructor of group with parameters
        public journey(int param_id, int param_people)
        {
            Id = param_id;
            People = param_people;
            TravelInCar = 0;

        }

    }
}
