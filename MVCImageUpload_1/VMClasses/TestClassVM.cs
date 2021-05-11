using MVCImageUpload_1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCImageUpload_1.VMClasses
{
    public class TestClassVM
    {
        public TestClass TestClass { get; set; }
        public List<TestClass> TestClasses { get; set; }
    }
}