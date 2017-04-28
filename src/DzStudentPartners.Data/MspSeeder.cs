using System;
using System.Collections.Generic;
using System.Linq;
using DzStudentPartners.Domain;

namespace DzStudentPartners.Data
{
    public class MspSeeder
    {
        private readonly MspContext _context;

        public MspSeeder(MspContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Camps.Any()) return;

            _context.Camps.AddRange(new List<MspCamp>{
                new MspCamp{
                    Name = "Asp Net Core Web Api",
                    Tag = "aspcore101",
                    Description = "A camp about how to build a web api with the new Asp Net Core framework",
                    EventDate = new DateTime(2017, 4, 15),
                    Location = new Location{
                        Address1 = "Online"
                    },
                    Msps = new List<Msp>{
                        new Msp{
                            Name = "Salah Yasin",
                            Twitter = "@syasin",
                            Region = "Centre",
                            University = "USTHB",
                            Rank = 10,
                            Points = 24.5d,
                            Skills = new List<Skill>{
                                new Skill{Name = ".NET"},
                                new Skill{Name = "C#"},
                                new Skill{Name = "Entity Framework"},
                                new Skill{Name = "Docker"},
                                new Skill{Name = "Asp Net Core"}
                            }
                        },
                        new Msp{
                            Name = "Sharifah Israa",
                            Twitter = "@sisraa",
                            Region = "Centre",
                            University = "USTHB",
                            Rank = 1,
                            Points = 200,
                            Skills = new List<Skill>{
                                new Skill{Name = ".NET"},
                                new Skill{Name = "C#"},
                                new Skill{Name = "Java"},
                                new Skill{Name = "Xamarin"},
                                new Skill{Name = "Android"}
                            }
                        }
                    }
                },
                new MspCamp{
                    Name = "Advanced Xamarin",
                    Tag = "xam304",
                    Description = "A camp about advanced features of Xamarin",
                    EventDate = new DateTime(2017, 5, 13),
                    Location = new Location{
                        Address1 = "Microsoft Algeria",
                        Wilaya = "Algiers"
                    },
                    Msps = new List<Msp>{
                        new Msp{
                            Name = "Maqsud Amirah",
                            Twitter = "@amaqsud",
                            Region = "Centre",
                            University = "ESI",
                            Rank = 5,
                            Points = 125,
                            Skills = new List<Skill>{
                                new Skill{Name = ".NET"},
                                new Skill{Name = "C#"},
                                new Skill{Name = "Sharepoint"},
                                new Skill{Name = "Docker"},
                                new Skill{Name = "Azure"}
                            }
                        },
                        new Msp{
                            Name = "Rajab Naseem",
                            Twitter = "@rnaseem",
                            Region = "Centre",
                            University = "ESI",
                            Rank = 3,
                            Points = 189.4d,
                            Skills = new List<Skill>{
                                new Skill{Name = ".NET"},
                                new Skill{Name = "C#"},
                                new Skill{Name = "Swift"},
                                new Skill{Name = "Xamarin"},
                                new Skill{Name = "Android"}
                            }
                        }
                    }
                }
            });

            _context.SaveChanges();
        }
    }
}