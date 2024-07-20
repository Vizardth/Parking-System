using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingManager manager = new ParkingManager();
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                var command = input.Split(' ');

                switch (command[0])
                {
                    case "create_parking_lot":
                        manager.CreateParkingLot(int.Parse(command[1]));
                        break;
                    case "park":
                        manager.ParkVehicle(command[1], command[2], command[3]);
                        break;
                    case "leave":
                        manager.LeaveSlot(int.Parse(command[1]));
                        break;
                    case "status":
                        manager.PrintStatus();
                        break;
                    case "type_of_vehicles":
                        manager.PrintVehicleTypeCount(command[1]);
                        break;
                    case "registration_numbers_for_vehicles_with_odd_plate":
                        manager.PrintVehiclesWithOddPlate();
                        break;
                    case "registration_numbers_for_vehicles_with_even_plate":
                        manager.PrintVehiclesWithEvenPlate();
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        manager.PrintVehiclesWithColour(command[1]);
                        break;
                    case "slot_numbers_for_vehicles_with_colour":
                        manager.PrintSlotsForVehiclesWithColour(command[1]);
                        break;
                    case "slot_number_for_registration_number":
                        manager.PrintSlotForRegistrationNumber(command[1]);
                        break;
                }
            }
        }
    }
}
