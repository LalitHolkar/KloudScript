using Assignmet.Entity.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Data
{
    public class AssignmentContext:DbContext
    {
        public AssignmentContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GenerateURL> GenerateURL { get; set; }
    }
}
