using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace TrainingDay1
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            
           

            while (true)
            {
                List<Employee> list = Fileread();
                Console.WriteLine("1 - Add Employee 2 - All Employees 3 -  Update Employee 4 - Delete Employee");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("ID : ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Name : ");
                    string name = Console.ReadLine();
                    Console.Write("Age : ");
                    int age = int.Parse(Console.ReadLine());
                    list.Add(new Employee(id, name, age));
                    FileWrite(list);
                }
                if(choice == 2)
                {
                    
                    foreach (Employee emp in list)
                    {
                        Console.WriteLine("ID - "+emp.employeeID+" Name - "+emp.employeeName);
                    }
                }
                if (choice == 3)
                {
                    Console.Write("ID : ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Name : ");
                    string name = Console.ReadLine();
                    Console.Write("Age : ");
                    int age = int.Parse(Console.ReadLine());
                    list.Add(new Employee(id, name, age));
                }
                if (choice == 4)
                {
                    Console.Write("ID : ");
                    int id = int.Parse(Console.ReadLine());
                    Remove(id);
                }
            }
            
            
        }
        static void FileWrite(List<Employee> input)
        {
            FileStream fs1 = new FileStream("employe.txt", FileMode.Truncate, FileAccess.Write);
            fs1.Close();
            FileStream fs = new FileStream("employe.txt", FileMode.OpenOrCreate, FileAccess.Write);
            string employees="";
            foreach (Employee emp in input)
            {
                employees+= emp.employeeID + "," + emp.employeeName + "," + emp.employeeAge + ";";
            }
           

           

            StreamWriter sw = new StreamWriter(fs);
            sw.Flush();
            Console.WriteLine(input.Count);
            sw.Write(Encrypt(employees));
            sw.Close();

            fs.Close();
        }
        static List<Employee> Fileread()
        {
            FileStream fs = new FileStream("employe.txt", FileMode.OpenOrCreate, FileAccess.Read);
            List<Employee> list = new List<Employee>();
           
            StreamReader sr = new StreamReader(fs);
            string line = Dencrypt(sr.ReadToEnd());
            sr.Close();
            fs.Close();
            string[] employees=line.Split(';');
            for(int i = 0; i < employees.Length-1; i++)
            {
                string[] empDet=employees[i].Split(',');
                int empID = int.Parse(empDet[0]);
                string empName = empDet[1];
                int empAge = int.Parse(empDet[2]);
                Employee employee=new Employee(empID,empName, empAge);
                list.Add(employee);
                
            }
            
            return list;
        }
        static void Remove(int id)
        {
            List<Employee> list = Fileread();
            for (int i = 0; i < list.Count; i++)
            {
                
                if (id == list[i].employeeID)
                {
                    list.RemoveAt(i);
                }
            }

            FileWrite(list);
        }
        static string Encrypt(string input)
        {
            string output = "";
            foreach (char c in input)
            {

                int ascii = (int)c;
                if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
                {
                    ascii += 3;
                    if (ascii > 90 && ascii < 94 || ascii > 122)
                    {
                        ascii -= 26;
                    }
                    char encryptedChar = (char)ascii;
                    output += encryptedChar;
                }
                else
                {
                    output += c;
                }

            }
            return output;
        }
        static string Dencrypt(string input)
        {
            string output = "";
            foreach (char c in input)
            {

                int ascii = (int)c;
                if (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122)
                {
                    ascii -= 3;
                    if (ascii > 90 && ascii < 97 || ascii < 65)
                    {
                        ascii += 26;
                    }
                    char encryptedChar = (char)ascii;
                    output += encryptedChar;
                }
                else
                {
                    output += c;
                }

            }
            return output;
        }
    }
    class Employee
    {
        public int employeeID;
        public string employeeName;
        public int employeeAge;
        public Employee(int id, string name, int age)
        {
            employeeID = id;
            employeeName = name;
            employeeAge = age;
        }
    }

}
