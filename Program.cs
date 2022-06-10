using System.Globalization;
using System;
using EXE_130.Entities.Enums;
using EXE_130.Entities;


namespace EXE_130
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter a worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");

          // WorkerLevel level = new WorkerLevel();
         //  Enum.TryParse(Console.ReadLine(), out level);

           WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel),Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration hours: ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerhour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY):");
            string monthAndyear = Console.ReadLine();
            int month = int.Parse(monthAndyear.Substring(0, 2));
            int year = int.Parse(monthAndyear.Substring(3));
            Console.WriteLine ("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " +monthAndyear + ":" + worker.Income(year, month));
        }
    }
}
