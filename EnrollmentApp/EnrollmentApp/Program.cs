using System;
using System.ComponentModel.Design;

namespace EnrollmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("**********************");
                Console.WriteLine("Wellcome to my College");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1:View all programs avaliable");
                Console.WriteLine("2: Enroll");
                Console.WriteLine("3: View all avaliable course for this semister");
                Console.Write("Select an option");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank tou for visiting the college");
                        return;
                    case "1":
                        CollegeRegistrar.DisplayAllProgramNames();
                        break;
                    case "2":
                        Console.WriteLine("First name:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("last name:");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Birth day(mm/dd/yyyy");
                        DateTime birthDate = new DateTime();
                        try
                        {
                            birthDate = DateTime.Parse(Console.ReadLine());
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                        }
                        Console.WriteLine("select student type");
                        var studentTypes = Enum.GetNames(typeof(StudentType));
                        for (int i = 0; i < studentTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}:{studentTypes[i]}");
                        }

                        var studentType = Enum.Parse<StudentType>(Console.ReadLine());

                        Console.WriteLine("Select sex");
                        var sexs = Enum.GetNames(typeof(Gender));
                        for (var i = 0; i < sexs.Length; i++)
                        {
                            Console.WriteLine($"{i}:{sexs[i]}");
                        }
                        var sex = Enum.Parse<Gender>(Console.ReadLine());
                        Console.WriteLine("Select program");
                        programsNames program = GetPrgramNames();
                        CollegeRegistrar.EnrollStudent(firstName, lastName, birthDate, studentType, sex, program);
                        break;
                    case "3":
                        Console.WriteLine("Select program");
                        program = GetPrgramNames();
                        Console.WriteLine("Select semister");
                        var semisters = Enum.GetNames(typeof(semisterNames));
                        for (int i = 0; i < semisters.Length; i++)
                        {
                            Console.WriteLine($"{i}:{semisters[i]}");
                        }
                        var semister = Enum.Parse<semisterNames>(Console.ReadLine());


                        Console.WriteLine("Select your Batch");
                        var batches = Enum.GetNames(typeof(SemisterYear));
                        for (int i = 0; i < batches.Length; i++)
                        {
                            Console.WriteLine($"{i}:{batches[i]}");
                        }
                        var batch = Enum.Parse<SemisterYear>(Console.ReadLine());
                        var courses = CollegeRegistrar.DisplayCoursesForYearPerSemister(semister, batch, program);
                        foreach (var course in courses)
                        {
                            Console.WriteLine(course.Name);
                        }

                        break;
                    case "4":
                    case "5":

                    default:
                        Console.WriteLine("Plase try again again");
                        break;
                }


            }

        }
        private static programsNames GetPrgramNames()
        {
            var prgrams = Enum.GetNames(typeof(programsNames));
            for (int i = 0; i < prgrams.Length; i++)
            {
                Console.WriteLine($"{i}:{prgrams[i]}");
            }
            var program = Enum.Parse<programsNames>(Console.ReadLine());
            return program;
        }
    }
}
