using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CETRepo
    {
        private CETDBContext db;

        public CETRepo()
        {
            db = new CETDBContext();
        }

        public User_Details ValidateUser(string username, string password)
        {
            User_Details user = db.User_Details.Where(u => u.User_EmailId == username && u.User_Password == password).FirstOrDefault();

            if (user != null)
            { 
            return user;
            }
            else
            {
                return null;
            }
        }

        public bool RegisterUser(User_Details user)
        {
            if(user == null)
            {
                return false;
            }
         
            try
            {
                db.User_Details.Add(user);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public User_Details GetUser(int ? userid)
        {
            var user = db.User_Details.Find(userid);
            if (user != null) 
            {
                return user;
            }
            return null;
        }
        public bool UpdateUser(string emailId, User_Details user) 
        {
            var olddata = db.User_Details.Where(d => d.User_EmailId == emailId).FirstOrDefault();
            try
            {
                if (olddata != null)
                {
                    olddata.User_ID = user.User_ID;
                    olddata.User_First_Name = user.User_First_Name;
                    olddata.User_Last_Name = user.User_Last_Name;
                    olddata.User_EmailId = user.User_EmailId;
                    olddata.User_Password = user.User_Password;

                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
              return false;
            }
        }
        public bool AddEmployee(Employee_Details employee)
        {
            if(employee != null)
            {
                return false;
            }
            try
            {
                db.Employee_Details.Add(employee);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public List<Employee_Details> GetEmployeeDetails() 
        {
            try
            {
                return db.Employee_Details.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateEmployee(int empid, Employee_Details employee)
        {
            var oldemp = db.Employee_Details.Find(empid);
            if(oldemp != null)
            {
                oldemp.Employee_Full_Name = employee.Employee_Full_Name;
                oldemp.Employee_Address = employee.Employee_Address;
                oldemp.Employee_Phone = employee.Employee_Phone;
                oldemp.Employee_Company = employee.Employee_Company;
                oldemp.Employee_Experience = employee.Employee_Experience;
                oldemp.Employee_Join_Date = employee.Employee_Join_Date;
                oldemp.Employee_Career_Level = employee.Employee_Career_Level;
                oldemp.Off_Shore_Start_Date = employee.Off_Shore_End_Date;
                oldemp.Off_Shore_End_Date = employee.Off_Shore_End_Date;
                oldemp.Employee_Skill = employee.Employee_Skill;

                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(int empid)
        {
            try
            {
                Employee_Details employee = FindByPk(empid);
                db.Employee_Details.Remove(employee);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Employee_Details FindByPk(int empid)
        {
            Employee_Details employee = null;
            try
            {
                employee = db.Employee_Details.Find(empid);
            }
            catch
            {
                employee = null;
            }
            return employee;
        }

        public Employee_Details GetEmployeeByID(int empid)
        {
            Employee_Details employee = null;
            try
            {
                employee = db.Employee_Details.Find(empid);
            }
            catch
            {
                employee = null;
            }
            return employee;
        }

        public List<GetAllEmployeesByName_Result> SearchEmployeeByName(string empName)
        {
            try
            {
                return db.GetAllEmployeesByName(empName).ToList();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<GetAllEmployeesByCompany_Result> SearchEmployeeByCompanyName(string empCName)
        {
            try
            {
                return db.GetAllEmployeesByCompany(empCName).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<GetAllEmployeesBySkill_Result> SearchEmployeeBySkills(string skill)
        {
            try
            {
                return db.GetAllEmployeesBySkill(skill).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
