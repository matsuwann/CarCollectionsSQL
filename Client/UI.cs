using CarCollectionData;
using CarCollectionModel;
using CarCollectionBusiness;

using System;
using new_email_tool;

namespace Client
{
    internal class UI
    {
        static void Main(string[] args)
        {
            CarGetServices services = new CarGetServices();
            CarCUD carCUD = new CarCUD();
            EmailService emailService = new EmailService();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Obscura Car Management");
                Console.WriteLine("1. Display all cars");
                Console.WriteLine("2. Add a car");
                Console.WriteLine("3. Update a car");
                Console.WriteLine("4. Delete a car");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        DisplayCars(services);
                        break;
                    case "2":
                        AddCar(carCUD, emailService);
                        break;
                    case "3":
                        UpdateCar(carCUD, emailService);
                        break;
                    case "4":
                        DeleteCar(carCUD, emailService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void DisplayCars(CarGetServices services)
        {
            var cars = services.GetAllCars();
            foreach (var item in cars)
            {
                Console.WriteLine("Brand: " + item.Brand);
                Console.WriteLine("Model: " + item.Model);
                Console.WriteLine("Year Model: " + item.YearModel);
                Console.WriteLine();
            }
        }

        static bool AddCar(CarCUD carCUD, EmailService emailService)
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Year: ");
            string yearModel = Console.ReadLine();

            if (carCUD.CreateCar(brand, model, yearModel))
            {
                Console.WriteLine("Car added successfully.");

                emailService.SendEmail("Car Added", "A new car has been added");
                return true;
            }
            return false;
        }

        static bool UpdateCar(CarCUD carCUD, EmailService emailService)
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            if (carCUD.UpdateCar(brand, model))
            {
                Console.WriteLine("Car updated successfully.");
                emailService.SendEmail("Car Updated", "The car has been updated");
                return true;
            }
            return false;
        }

        static bool DeleteCar(CarCUD carCUD, EmailService emailService)
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Year: ");
            string yearModel = Console.ReadLine();

            Cars carToDelete = new Cars { Brand = brand, Model = model, YearModel = yearModel };

            if (carCUD.DeleteCar(carToDelete))
            {
                Console.WriteLine("Car deleted successfully.");

                emailService.SendEmail("Car Deleted", "The car has been deleted");
                return true;
            }
            return false;
        }
    }
}
