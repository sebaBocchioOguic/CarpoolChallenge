using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabifyCarpoolChallenge
{
    internal class Program
    {

        // Collection of Cars
        static public List<Entities.car> cars = new List<Entities.car>();

        // Collection of Journeys
        static public List<Entities.journey> journeys = new List<Entities.journey>();

        static void Main(string[] args)
        {
            // Initiating Message
            Console.WriteLine("INITIATING CARPOOL CHALLENGE");
            Console.WriteLine("----------------------------\n");
            
            try
            {
                // Add Cars with a Random seed
                AddCars();

                // Show Cars in List in Console
                ShowCars();

                // Add Journey with a random seed
                AddJourney(101, 3);
                AddJourney(102, 2);
                AddJourney(103, 4);
                AddJourney(104, 1);
                AddJourney(105, 2);
                AddJourney(106, 6);
                AddJourney(107, 5);
                AddJourney(108, 4);
                AddJourney(109, 2);
                AddJourney(110, 3);

                // Show Journeys in List in Console
                ShowJourneys();

                ShowCars();

                LocationGroup(105);
                LocationGroup(108);

                DropoffGroup(105);
                DropoffGroup(108);

                ShowJourneys();
                ShowCars();

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }

            Console.ReadKey();
        }




        // Function for Adding Cars from Given List
        static private void AddCars()
        {

            /* From the challenge: PUT /cars - Load the list of available cars in the service
             * and remove all previous data (existing journeys and cars).
             * This method may be called more than once during the life cycle of the service. */

            // Generate seed for random
            Random rnd = new Random();

            // Empty List of Cars and Journeys
            cars.Clear();
            journeys.Clear();

            // id car variable
            int idCar = 0;

            // Loop for simulating addition of cars
            for (int i = 0; i < 5; i++)
            {
                // Instance of objects using class car from namespace Entities
                Entities.car car = new Entities.car(++idCar, rnd.Next(4, 7)); // Random 4-6

                // Addition of car to list cars
                cars.Add(car);
            }
        }




        // Function for Showing List of Cars Available in App
        static public void ShowCars()
        {
            Console.WriteLine("CARS AVAILABLE:");
            foreach (var carAvailable in cars)
            {
                Console.WriteLine($"Id {carAvailable.Id} - Seats {carAvailable.SeatsAvailable}");
            }
        }




        // Function for Adding a new Journey and try to locate it in an available car
        static public void AddJourney(int param_id, int param_people)
        {
            /* From the challenge: POST /journey - A group of people requests to perform a journey.
             * People requests cars in groups of 1 to 6. */

            // Instance of objects using class group from namespace Entities
            Entities.journey journey = new Entities.journey(param_id, param_people);

            // Locate Requested Journey in an Available Car
            LocateJourneyInAvailableCar(journey);

            // Addition of journey to list Journeys
            journeys.Add(journey);

        }




        // Function for Showing List of Journeys in App
        static public void ShowJourneys()
        {
            Console.WriteLine("JOURNEYS AVAILABLE:");
            foreach (var JourneyAvailable in journeys)
            {
                Console.WriteLine($"Id {JourneyAvailable.Id} - People {JourneyAvailable.People} - TravelInCar {JourneyAvailable.TravelInCar}");
            }
        }




        // Locate Requested Journey in an Available Car
        static public void LocateJourneyInAvailableCar(Entities.journey param_journey)
        {
            foreach (var Car in cars)
            {
                // When a Car has enough available seats
                if(Car.SeatsAvailable >= param_journey.People)
                {
                    // Reserve seats in car
                    Car.SeatsAvailable -= param_journey.People;

                    // TravelInCar in journey
                    param_journey.TravelInCar = Car.Id;

                    // Breaks the foreach and return to main function
                    break;
                }
                                
            }
        }





        // Search de location of a group (the car they're travelling in)
        static public void LocationGroup(int param_journey_id)
        {
            /* POST /locate - Given a group ID such that ID=X, return the car the group is traveling
             * with, or no car if they are still waiting to be served. */

            Entities.journey JourneyResult = journeys.Find(x => x.Id == param_journey_id);

            int CarUsed = JourneyResult.TravelInCar;

            Console.WriteLine($"Group Id {JourneyResult.Id} Travel in car {CarUsed}");

        }





        // Dropoff a Group
        static public void DropoffGroup(int param_journey_id)
        {
            /* POST /dropoff - A group of people requests to be dropped off. Whether they traveled or not. */

            // Search for the group
            Entities.journey JourneyResult = journeys.SingleOrDefault(x => x.Id == param_journey_id);
            
            // If group exists
            if (JourneyResult != null)
            {
                // Add available seats to car (if group is located)
                if(JourneyResult.TravelInCar != 0)
                {
                    Entities.car CarResult = cars.Single(y => y.Id == JourneyResult.TravelInCar);
                    CarResult.SeatsAvailable += JourneyResult.People;
                }
                
                // Remove group from list journeys
                journeys.Remove(JourneyResult);
            }
                
        }

    }
}
