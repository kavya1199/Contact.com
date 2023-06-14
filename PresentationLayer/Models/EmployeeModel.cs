using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class EmployeeModel
    {
        public int Employee_ID { get; set; }
        public string Employee_Full_Name { get; set; }
        public string Employee_Address { get; set; }
        public string Employee_Phone { get; set; }
        public string Employee_Company { get; set; }
        public System.DateTime Employee_Join_Date { get; set; }
        public decimal Employee_Experience { get; set; }
        public string Employee_Career_Level { get; set; }
        public string Employee_Skill { get; set; }
        public System.DateTime Off_Shore_Start_Date { get; set; }
        public System.DateTime Off_Shore_End_Date { get; set; }
    }
}