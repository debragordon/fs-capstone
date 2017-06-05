using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChickChick.Models;

namespace ChickChick.DAL
{
    public class AppContext : DbContext
    {
        public AppContext() : base("ChickChickApp") { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<WaitingStudent> WaitingStudents { get; set; }

    }
}