using MVCImageUpload_1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCImageUpload_1.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {

        }

        public DbSet<TestClass> TestClasses { get; set; }
    }
}