using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BugTracker.API.Models;
using Newtonsoft.Json;

namespace BugTracker.API.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Companies.Any())
            {
                var companyData = File.ReadAllText("Data/InitDatabaseValues/CompanySeedData.json");
                var companies = JsonConvert.DeserializeObject<List<Company>>(companyData);
                foreach (var company in companies)
                {
                    context.Companies.Add(company);
                }
                context.SaveChanges();
            }

            if (!context.Projects.Any())
            {
                var projectData = File.ReadAllText("Data/InitDatabaseValues/ProjectsSeedData.json");
                var projects = JsonConvert.DeserializeObject<List<Project>>(projectData);
                foreach (var project in projects)
                {
                    context.Projects.Add(project);
                }
                context.SaveChanges();
            }

            if (!context.Teams.Any())
            {
                var teamData = File.ReadAllText("Data/InitDatabaseValues/TeamSeedData.json");
                var teams = JsonConvert.DeserializeObject<List<Team>>(teamData);
                foreach (var team in teams)
                {
                    context.Teams.Add(team);
                }
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employeeData = File.ReadAllText("Data/InitDatabaseValues/EmployeeSeedData.json");
                var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData);
                foreach (var employee in employees)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("asdqwe123", out passwordHash, out passwordSalt);
                    employee.PasswordHash = passwordHash;
                    employee.PasswordSalt = passwordSalt;
                    employee.Username = employee.Username.ToLower();
                    context.Employees.Add(employee);
                }

                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                var tasksData = File.ReadAllText("Data/InitDatabaseValues/TasksSeedData.json");
                var tasks = JsonConvert.DeserializeObject<List<Task>>(tasksData);
                foreach (var task in tasks)
                {
                    context.Tasks.Add(task);
                }
                context.SaveChanges();
            }


        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}