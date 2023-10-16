using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem
{
    class Vehicle
    {
        public string VehicleId { get; }
        public string Type { get; }
        public double DailyRate { get; }

        public Vehicle(string vehicleId, string type, double dailyRate)
        {
            VehicleId = vehicleId;
            Type = type;
            DailyRate = dailyRate;
        }
    }

    class Rental
    {
        public string RentalId { get; }
        public Customer Customer { get; }
        public Vehicle Vehicle { get; }
        public DateTime RentalStartDate { get; }
        public int RentalDuration { get; }

        public Rental(string rentalId, Customer customer, Vehicle vehicle, DateTime startDate, int duration)
        {
            RentalId = rentalId;
            Customer = customer;
            Vehicle = vehicle;
            RentalStartDate = startDate;
            RentalDuration = duration;
        }

        public double CalculateRentalCost()
        {
            return Vehicle.DailyRate * RentalDuration;
        }
    }

    class Customer
    {
        public string CustomerId { get; }
        public string Name { get; }

        public Customer(string customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }

        public void RentVehicle(Vehicle vehicle, DateTime startDate, int duration)
        {
            Rental rental = new Rental(Guid.NewGuid().ToString(), this, vehicle, startDate, duration);
            double rentalCost = rental.CalculateRentalCost();
            Console.WriteLine($"{Name} rented a {vehicle.Type} for {duration} days. Rental cost: Rs.{rentalCost}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create some vehicles
            Vehicle vehicle1 = new Vehicle("V001", "Compact Car", 30.0);
            Vehicle vehicle2 = new Vehicle("V002", "SUZUKI", 50.0);
            Vehicle vehicle3 = new Vehicle("V003", "Truck", 70.0);

            // Create a customer
            Customer customer = new Customer("C001", "Kanika");

            // Rent vehicles
            customer.RentVehicle(vehicle1, DateTime.Now, 5);
            customer.RentVehicle(vehicle2, DateTime.Now, 7);

            Console.Read();
        }
    }
}