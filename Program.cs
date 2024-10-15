using System;
using System.Xml;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFile = @"C:\Users\andre\source\repos\lab3\lab3\XMLFile1.xml";
            string searchSurname = "Іваненко"; 

            using (XmlTextReader reader = new XmlTextReader(xmlFile))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Employee")
                    {
                        string surname = null, departmentNumber = null, position = null, experience = null, salary = null;

                        while (reader.Read() && !(reader.NodeType == XmlNodeType.EndElement && reader.Name == "Employee"))
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                switch (reader.Name)
                                {
                                    case "surname":
                                        surname = reader.ReadElementContentAsString();
                                        break;
                                    case "DepartmentNumber":
                                        departmentNumber = reader.ReadElementContentAsString();
                                        break;
                                    case "Position":
                                        position = reader.ReadElementContentAsString();
                                        break;
                                    case "Experience":
                                        experience = reader.ReadElementContentAsString();
                                        break;
                                    case "Salary":
                                        salary = reader.ReadElementContentAsString();
                                        break;
                                }
                            }
                        }

                        if (surname == searchSurname)
                        {
                            Console.WriteLine($"Номер цеху: {departmentNumber}, Посада: {position}, Стаж роботи: {experience}, Заробітна плата: {salary}");
                        }
                    }
                }
            }
        }
    }
}