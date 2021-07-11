using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank_C_Sharp_Basic
{
    public class EmployeesManagementSolution
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> companyDictionary = new Dictionary<string, int>();
            Dictionary<string, int> companyAge = new Dictionary<string, int>();
            List<string> companyList = new List<string>();

            foreach (var emp in employees)
            {
                if (companyDictionary[emp.Company] > 0)
                {
                    companyDictionary[emp.Company]++;
                    companyAge[emp.Company] += emp.Age;
                }
                else
                {
                    companyDictionary[emp.Company]++;
                    companyAge[emp.Company] += emp.Age;
                    companyList.Add(emp.Company);
                }
            }

            string[] companyArr = companyList.ToArray();
            Array.Sort(companyArr, StringComparer.InvariantCulture);

            Dictionary<string, int> output = new Dictionary<string, int>();
            foreach (string str in companyArr)
            {
                double avg = (double)companyAge[str] / (double)companyDictionary[str];
                int ans = (int)Math.Round(avg, 0, MidpointRounding.AwayFromZero);
                output[str] = ans;
            }
            return output;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> companyDictionary = new Dictionary<string, int>();
            List<string> companyList = new List<string>();

            foreach (var emp in employees)
            {
                if (companyDictionary[emp.Company] > 0)
                {
                    companyDictionary[emp.Company]++;
                }
                else
                {
                    companyDictionary[emp.Company]++;
                    companyList.Add(emp.Company);
                }
            }

            string[] companyArr = companyList.ToArray();
            Array.Sort(companyArr, StringComparer.InvariantCulture);

            Dictionary<string, int> output = new Dictionary<string, int>();
            foreach (string str in companyArr)
            {
                output[str] = companyDictionary[str];
            }
            return output;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> companyDictionary = new Dictionary<string, int>();
            Dictionary<string, Employee> companyOldestEmployee = new Dictionary<string, Employee>();
            List<string> companyList = new List<string>();

            foreach (var emp in employees)
            {
                if (companyDictionary[emp.Company] > 0)
                {
                    companyDictionary[emp.Company]++;
                    companyOldestEmployee[emp.Company] = emp.Age >= companyOldestEmployee[emp.Company].Age ? emp : companyOldestEmployee[emp.Company];
                }
                else
                {
                    companyDictionary[emp.Company]++;
                    companyOldestEmployee[emp.Company] = emp;
                    companyList.Add(emp.Company);
                }
            }

            string[] companyArr = companyList.ToArray();
            Array.Sort(companyArr, StringComparer.InvariantCulture);

            Dictionary<string, Employee> output = new Dictionary<string, Employee>();
            foreach (string str in companyArr)
            {
                output[str] = companyOldestEmployee[str];
            }
            return output;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
