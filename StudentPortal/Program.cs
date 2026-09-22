using System;

namespace StudentPortal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your full name: ");
            String fullName = Console.ReadLine().Trim();
            String upperFullName = fullName.ToUpper();
            int nameLength = upperFullName.Length;
            Console.Write("Enter your age: ");
            int age = -1;
            try
            {
                age = Convert.ToInt32(Console.ReadLine().Trim());
                if (age > 0 && age < 150)
                {
                    Console.WriteLine($"\nPROFILE SUMMARY:\nNAME: {upperFullName}\nAGE: {age}\nNAME LENGTH: {nameLength}");
                }
                else
                {
                    Console.WriteLine("Invalid age. Try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Pls try again.");
            }
        }
    }
}
