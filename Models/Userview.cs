using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Payroll_Sys.Models
{
    public class Userview
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Salary { get; set; }
    }

    public class DefaultConnection:DbContext
    {
        public DefaultConnection(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Userview> Userviews { get; set; }
    }
}