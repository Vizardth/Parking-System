using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class ParkingManager
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        private int totalSlots = 0;

        public void CreateParkingLot(int slots)
        {
            totalSlots = slots;
            for (int i = 0; i < slots; i++)
            {
                parkingLots.Add(new ParkingLot { SlotNumber = i + 1 });
            }
            Console.WriteLine($"Created a parking lot with {slots} slots");
        }

        public void ParkVehicle(string registrationNumber, string color, string type)
        {
            var availableSlot = parkingLots.FirstOrDefault(p => p.Vehicle == null);
            if (availableSlot == null)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }
            availableSlot.Vehicle = new Vehicle
            {
                RegistrationNumber = registrationNumber,
                Color = color,
                Type = type,
                CheckInTime = DateTime.Now
            };
            Console.WriteLine($"Allocated slot number: {availableSlot.SlotNumber}");
        }

        public void LeaveSlot(int slotNumber)
        {
            var slot = parkingLots.FirstOrDefault(p => p.SlotNumber == slotNumber);
            if (slot == null || slot.Vehicle == null)
            {
                Console.WriteLine($"Slot number {slotNumber} is already free");
                return;
            }
            slot.Vehicle = null;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }

        public void PrintStatus()
        {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
            foreach (var slot in parkingLots.Where(p => p.Vehicle != null))
            {
                Console.WriteLine($"{slot.SlotNumber}\t{slot.Vehicle.RegistrationNumber}\t{slot.Vehicle.Type}\t{slot.Vehicle.RegistrationNumber}\t{slot.Vehicle.Color}");
            }
        }

        public void PrintVehicleTypeCount(string type)
        {
            var count = parkingLots.Count(p => p.Vehicle != null && p.Vehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(count);
        }

        public void PrintVehiclesWithOddPlate()
        {
            var oddPlates = parkingLots.Where(p => p.Vehicle != null && IsOddPlate(p.Vehicle.RegistrationNumber))
                                        .Select(p => p.Vehicle.RegistrationNumber);
            Console.WriteLine(string.Join(", ", oddPlates));
        }

        public void PrintVehiclesWithEvenPlate()
        {
            var evenPlates = parkingLots.Where(p => p.Vehicle != null && !IsOddPlate(p.Vehicle.RegistrationNumber))
                                        .Select(p => p.Vehicle.RegistrationNumber);
            Console.WriteLine(string.Join(", ", evenPlates));
        }

        public void PrintVehiclesWithColour(string color)
        {
            var vehicles = parkingLots.Where(p => p.Vehicle != null && p.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                                      .Select(p => p.Vehicle.RegistrationNumber);
            Console.WriteLine(string.Join(", ", vehicles));
        }

        public void PrintSlotsForVehiclesWithColour(string color)
        {
            var slots = parkingLots.Where(p => p.Vehicle != null && p.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                                   .Select(p => p.SlotNumber);
            Console.WriteLine(string.Join(", ", slots));
        }

        public void PrintSlotForRegistrationNumber(string registrationNumber)
        {
            var slot = parkingLots.FirstOrDefault(p => p.Vehicle != null && p.Vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
            if (slot != null)
            {
                Console.WriteLine(slot.SlotNumber);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        private bool IsOddPlate(string registrationNumber)
        {
            var parts = registrationNumber.Split('-');

            if (parts.Length >= 2)
            {
                var numericPart = parts[1];

                if (int.TryParse(numericPart, out int numericValue))
                {
                    return numericValue % 2 != 0;
                }
            }

            return false;
        }



    }
}
