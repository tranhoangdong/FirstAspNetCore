using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Emtyties
{
  public  class Student
    {
        public int StudentID { set; get; }
        public string StudentName { set; get; }    
        public int? Mark { set; get; }  
        public string City { set; get; }
    }
}
