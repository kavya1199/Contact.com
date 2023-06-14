using DataAccessLayer;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class CETController : Controller
    {
        CETRepo repo = new CETRepo();
        // GET: CET
        public ActionResult ListAllEmployee()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("AuthenticateUser","User");
            }

            List<DataAccessLayer.Employee_Details> emps = repo.GetEmployeeDetails();
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach(var e in emps)
            {
                EmployeeModel employee = new EmployeeModel();
                employee.Employee_Full_Name = e.Employee_Full_Name;
                employee.Employee_Address = e.Employee_Address;
                employee.Employee_Company = e.Employee_Company;
                employee.Employee_Experience = e.Employee_Experience;
                employee.Employee_Career_Level = e.Employee_Career_Level;
                employee.Employee_Phone = e.Employee_Phone;
                employee.Employee_Join_Date = e.Employee_Join_Date;
                employee.Employee_Skill = e.Employee_Skill;
                employee.Off_Shore_Start_Date = e.Off_Shore_Start_Date;
                employee.Off_Shore_End_Date = e.Off_Shore_End_Date;

                employees.Add(employee);

            }
            return View(employees);
        }
    }
}