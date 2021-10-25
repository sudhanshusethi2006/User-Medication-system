using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using UserMedication.Models;

using static UserMedication.UtilityClass;

namespace UserMedication
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IUnitOfWork, UnitOfWork>();
                })
                .Build();

            // Seed Data 

            var UnitOfWork = ActivatorUtilities.CreateInstance<UnitOfWork>(host.Services);


            UnitOfWork.seedDataRepository.CreateSeedData();



            // Add User
            var IsAdded = UnitOfWork.UserMedicationRepository.Add(new UserMedicationData
            {
                Name = "sudhanshu Seth",
                Email = "Sudhanshu@hotmail.com",
                IsActive = true,
                Province = (int)Provinces.Ontario,
                Medication = new List<int> { (int)Medications.obesity }
            });

            // Deactivate User

            var userid = 1;
            var isDeactivated = UnitOfWork.UserMedicationRepository.DeactivateUser(userid);


            // update user

            var IsUpdated = UnitOfWork.UserMedicationRepository.Update(new UserMedicationData
            {
                UserId = 1,
                Name = "sudhanshu Seth2",
                Email = "Sudhanshu2@hotmail.com",
                IsActive = true,
                Province = (int)Provinces.NewBrunswick,
                Medication = new List<int> { (int)Medications.depression }
            });



            // search criteria 

            var province = Provinces.Alberta;
            var isActive = true;
            var medications = new List<Medications> { Medications.depression, Medications.obesity };
            var result = UnitOfWork.UserMedicationRepository.Search(isActive, province, medications);


            Console.WriteLine(new string('-', 40));
            foreach (var user in result.Result)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
            }
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true)
                .AddEnvironmentVariables();

        }
    }
}
