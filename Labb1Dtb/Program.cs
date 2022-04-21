using Labb1Dtb.Models;
using System;
using System.Linq;

namespace Labb1Dtb
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateFreeTimes();

            static void PopulateFreeTimes()
            {
                using ConnectionDb contex = new ConnectionDb();



                // Anstallda anstalld2 = new Anstallda()
                //{
                //    FirstName = "Johanna",
                //    LastName = "Johansson"
                //};
                //contex.Employees.Add(anstalld2);
                contex.SaveChanges();
                Console.Write("Välkommen är du Admin eller Personal?");
                string input = Console.ReadLine();
                string personalId = "";
                string ledighetsTyp = "";
                if (input == "Personal")
                {
                    Console.Write("Fyll i ditt id 1-5\n>>");
                    personalId = Console.ReadLine();

                    Console.Write("Vilken ledighetstyp vill du ansöka för?: \n[1]Föräldrarledighet  \n[2]Semester  \n[3]vård av barn\n>>");
                    ledighetsTyp = Console.ReadLine();
                    if (ledighetsTyp == "1")
                    {
                        Console.Write("Start datum?\n>>");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Slutdatum?\n>>");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        //Console.Write("Vänligen ange typ");
                        //string typ = Console.ReadLine();
                        Ledighet ledighet = new Ledighet()
                        {
                            StartDate = startDate,
                            EndDate = endDate,
                            Type = "Föräldrarledig",
                            EmployeeId = Int32.Parse(personalId)
                        };
                        contex.FreeTimes.Add(ledighet);
                        contex.SaveChanges();
                    }
                    else if (ledighetsTyp == "2")
                    {
                        Console.Write("Start datum?\n>>");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Slutdatum?\n>>");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        Ledighet ledighet = new Ledighet()
                        {
                            StartDate = startDate,
                            EndDate = endDate,
                            Type = "Semester",
                            EmployeeId = Int32.Parse(personalId)
                        };
                        contex.FreeTimes.Add(ledighet);
                        contex.SaveChanges();
                    }
                    else if (ledighetsTyp == "3")
                    {
                        Console.Write("Start datum?\n>>");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Slutdatum?\n>>");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        Ledighet ledighet = new Ledighet()
                        {
                            StartDate = startDate,
                            EndDate = endDate,
                            Type = "Vård av barn",
                            EmployeeId = Int32.Parse(personalId)
                        };
                        contex.FreeTimes.Add(ledighet);
                        contex.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Du måste göra ett gilltigt val,1,2 eller3!");
                    }
                }
                else if (input == "Admin")
                {
                    string val = "";
                    string manad = "";
                    string anstalldId = "";
                    string namn = "";
                    Console.Write("Vill du söka på namn = 1 Id = 2\\n");
                    val = Console.ReadLine();
                    if (val == "1")
                    {
                        Console.WriteLine("Vilken månad vill du se? Ange månad 1-12\n>>");
                        manad = Console.ReadLine();
                        Console.WriteLine("Vilken Anställd Id 1-5?\n>>");
                        anstalldId = Console.ReadLine();

                        var ledighet = contex.FreeTimes
                            .Where(x => x.EmployeeId == Int32.Parse(anstalldId))
                            .Where(y => y.StartDate.Month == Int32.Parse(manad));
                        foreach (var item in ledighet)
                        {
                            Console.WriteLine("Id: " + item.EmployeeId);
                            Console.WriteLine("Start datum: " + item.StartDate);
                            Console.WriteLine("Slut datum: " + item.EndDate);
                            Console.WriteLine("Typ av ledighet: " + item.Type);

                        }
                    }
                    else if (val == "2")
                    {
                        Console.WriteLine("Vilket namn vill du se?\n");
                        namn = Console.ReadLine();
                        var ledighet = contex.FreeTimes.Join(contex.Employees,
                            sc => sc.EmployeeId,
                            soc => soc.EmployeeId,
                            (sc, soc)=>new {sc,soc })
                       .Where(j => j.soc.FirstName == namn);
                        foreach (var item in ledighet)
                        {
                            Console.WriteLine("Namn: " + item.soc.FirstName);
                            Console.WriteLine("Start datum: " + item.sc.StartDate);
                            Console.WriteLine("Slut datum: " + item.sc.EndDate);
                            Console.WriteLine("Typ av ledighet: " + item.sc.Type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du måste välja ett gilltigt val, försök igen!");
                    }
                }

            }

        }
    }
}
