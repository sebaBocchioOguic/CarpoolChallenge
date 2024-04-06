using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class car
    {
        // private atribute 'id' for car
        private int id;

        // private atribute 'seats available' for car
        private int seatsAvailable;

        // public property for 'id'
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        // Number of available seats in car
        public int SeatsAvailable
        {
            get { return seatsAvailable; }
            set { seatsAvailable = value; }
        }


        // Constructor of car with parameters
        public car(int param_id, int param_seats)
        {
            Id = param_id;
            SeatsAvailable = param_seats;
        }


    }
}
