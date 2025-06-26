using System;
using System.Globalization;
using SystemWorker.Entities;
using SystemWorker.Enums;

namespace SystemWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string department = Console.ReadLine()!;
            Department departmentObject = new Department(department);

            Console.WriteLine("Enter worker data: ");

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Level (Junior, MidLevel, Senior): ");
            string levelString = Console.ReadLine()!;
            WorkerLevel workerLevel;
            if (!Enum.TryParse(levelString, true, out workerLevel))
            {
                Console.WriteLine("Nível inválido. Use Junior, MidLevel ou Senior.");
                return;
            }

            Console.Write("Base Salary: ");
            double salary = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            Worker worker = new Worker(name, workerLevel, salary);

            Console.Write("How many contracts to this worker? ");
            int contractsNumber = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < contractsNumber; i++)
            {
                Console.WriteLine($"Enter # {i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine()!);

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine()!);

                HourContract contract = new HourContract(data, valuePerHour, duration);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine()!;
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3, 4));

            double income = worker.Income(year, month);

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {departmentObject.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {income.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
