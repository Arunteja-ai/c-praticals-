using System;

namespace StudentAdmissionManagement
{
    class Student
    {
        // Private Data Members
        private int studentId;
        private string studentName;
        private string course;
        private double admissionFee;

        // Default Constructor
        public Student()
        {
            studentId = 0;
            studentName = "";
            course = "";
            admissionFee = 0.0;
        }

        // Parameterized Constructor
        public Student(int id, string name, string course, double fee)
        {
            studentId = id;
            studentName = name;
            this.course = course;
            admissionFee = fee;
        }

        // Display Method
        public void DisplayDetails()
        {
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("   STUDENT ADMISSION DETAILS");
            Console.WriteLine("====================================");
            Console.WriteLine("Student ID      : " + studentId);
            Console.WriteLine("Student Name    : " + studentName);
            Console.WriteLine("Course          : " + course);
            Console.WriteLine("Admission Fee   : " + admissionFee);
            Console.WriteLine("====================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================");
            Console.WriteLine(" STUDENT ADMISSION MANAGEMENT");
            Console.WriteLine("====================================");

            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter Admission Fee: ");
            double fee = Convert.ToDouble(Console.ReadLine());

            // Create Object
            Student student = new Student(id, name, course, fee);

            // Display Details
            student.DisplayDetails();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}