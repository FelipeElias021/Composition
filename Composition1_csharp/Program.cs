using System;
using System.Globalization;
using Composition1_csharp.Entities;
using Composition1_csharp.Entities.Enums;

namespace Composition1_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(departmentName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            AddContractsCw(worker);

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nChoose a option: ");
                Console.Write("> 1. Worker Info\n> 2. All contracts\n> 3. Add contracts\n> 4. Remove Contracts\n> 5. Caculate income\n> 6. Leave\n> ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine(worker);
                        break;
                    case 2:
                        foreach (HourContract contracts in worker.Contracts)
                        {
                            Console.WriteLine("\n" + contracts);
                        }
                        break;
                    case 3:
                        AddContractsCw(worker);
                        break;
                    case 4:
                        Console.Write("\nEnter the id contract: ");
                        int id = int.Parse(Console.ReadLine());
                        worker.RemoveContratct(id);

                        break;
                    case 5:
                        Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
                        string monthAndYear = Console.ReadLine();
                        int month = int.Parse(monthAndYear.Substring(0, 2));
                        int year = int.Parse(monthAndYear.Substring(3, 4));
                        Console.WriteLine($"Name: {worker.Name}");
                        Console.WriteLine($"Department: {worker.Depart.Name}");
                        Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)} ETC");
                        break;
                    case 6:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Wrong number, try again.");
                        break;
                }
                Console.ReadLine();
            }

            static void AddContractsCw(Worker worker)
            {
                Console.WriteLine("\nHow many many contracts to this worker? ");
                int numContracts = int.Parse(Console.ReadLine());

                for (int i = 0; i < numContracts; i++)
                {
                    Console.WriteLine($"\nEnter #{i + 1} contract data:");

                    Console.Write("Id: ");
                    int id = int.Parse(Console.ReadLine());
                    id = worker.CheckId(id);

                    Console.Write("Date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Value per hour: ");
                    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Duration (hours): ");
                    int hours = int.Parse(Console.ReadLine());

                    HourContract contract = new HourContract(id, date, valuePerHour, hours);
                    worker.AddContract(contract);
                }
            }
        }
    }
}