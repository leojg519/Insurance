using System;
using System.Collections.Generic;
using System.Data.Entity;
using Insurance.DAL;
using Insurance.Enums;
using Insurance.Models;

namespace Insurance.DAL
{
    public class InsuranceInitializer : DropCreateDatabaseIfModelChanges<InsuranceContext>
    {
        protected override void Seed(InsuranceContext context)
        {
            var clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "jd@email.com",
                    Address = "123 ST",
                    Phone = "12345",
                    Policies = new List<Policy>
                    {
                        new Policy{
                            Id = 1,
                            Name = "Fire",
                            Coverages = new List<Coverage>
                            {
                                new Coverage
                                {
                                    Id = 1,
                                    Type = CoverageType.Fire
                                },
                                new Coverage
                                {
                                    Id = 2,
                                    Type = CoverageType.Earthquake
                                },
                                new Coverage
                                {
                                    Id = 3,
                                    Type = CoverageType.Lost
                                },
                                new Coverage
                                {
                                    Id = 4,
                                    Type = CoverageType.Robbery
                                }
                            },
                            CoverPercentage = 90,
                            Description = "FireEQ",
                            CoverMonths = 12,
                            Price = 500,
                            Risk = RiskType.Medium,
                            StartDate = DateTime.Now
                        }
                    }
                }
            };
            clients.ForEach(client => context.Clients.Add(client));
            context.SaveChanges();
        }
    }
}