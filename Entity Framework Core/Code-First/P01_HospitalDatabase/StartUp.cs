using System;
using P01_HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Initializer;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var context = new HospitalContext();
                DatabaseInitializer.ResetDatabase(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}