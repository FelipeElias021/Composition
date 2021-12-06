using System.Globalization;
using System.Collections.Generic;
using Composition1_csharp.Entities.Enums;


namespace Composition1_csharp.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        //Associação
        public Department Depart { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department depart)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Depart = depart;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContratct(int id)
        {
            int cont = 0;
            foreach (HourContract contracts in Contracts.ToList())
            {
                if (contracts.Id == id)
                {
                    Contracts.Remove(contracts);
                    Console.WriteLine($"Contract {id} removed successfully");
                    cont--; //The count will decrease because the number of contracts will decrease
                }
                else
                {
                    cont++;
                }
            }
            if (cont == Contracts.Count())
            {
                Console.WriteLine("This id doesn't exist.");
            }
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }

            return sum;
        }

        public int CheckId(int id)
        {

            foreach (HourContract contract in Contracts)
            {
                if (contract.Id == id) //compare all the Id with the id parameter
                {
                    Console.WriteLine("Id already in use, try another Id!");
                    Console.Write("Id: ");
                    id = int.Parse(Console.ReadLine());
                    CheckId(id); //Will check again
                }
            }
            return id;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nLevel: {Level}\nBase salary: {BaseSalary.ToString("F2", CultureInfo.InvariantCulture)} ETC\nDepartment: {Depart.Name}\nNumber of contracts: {Contracts.Count}";
        }
    }
}
