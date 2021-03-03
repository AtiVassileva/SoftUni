namespace P01_HospitalDatabase.Initializer
{
    using System;
    using Data;
    using Generators;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializer
    {
        private static Random rnd = new Random();

        public static void ResetDatabase(HospitalContext context)
        {
                context.Database.Migrate();
                InitialSeed(context);
        }

        private static void InitialSeed(HospitalContext context)
        {
            SeedMedicaments(context);

            SeedPatients(context, 200);

            SeedPrescriptions(context);
        }

        private static void SeedMedicaments(HospitalContext context)
        {
            MedicamentGenerator.InitialMedicamentSeed(context);
        }

        private static void SeedPatients(HospitalContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                context.Patients.Add(PatientGenerator.NewPatient(context));
            }

            context.SaveChanges();
        }

        private static void SeedPrescriptions(HospitalContext context)
        {
            PrescriptionGenerator.InitialPrescriptionSeed(context);
        }
    }
}