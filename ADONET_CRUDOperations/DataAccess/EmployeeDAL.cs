using ADONET_CRUDOperations.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADONET_CRUDOperations.DataAccess
{
    public class EmployeeDAL
    {
        public string InsertData(Employee objEmp)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_InsertUpdateDelete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tEmpID", 0);
                cmd.Parameters.AddWithValue("@EmpID", objEmp.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", objEmp.EmpName);
                cmd.Parameters.AddWithValue("@Email", objEmp.Email);
                cmd.Parameters.AddWithValue("@Phone", objEmp.Phone);
                cmd.Parameters.AddWithValue("@CNIC", objEmp.CNIC);
                cmd.Parameters.AddWithValue("@Address", objEmp.Address);
                cmd.Parameters.AddWithValue("@Status", objEmp.Status);
                cmd.Parameters.AddWithValue("@isActive", objEmp.isActive);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception ex)
            {
                return result = ex.Message;
            }
            finally
            {
                con.Close();
            }

        }

        public string UpdateData(Employee objEmp)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_InsertUpdateDelete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tEmpID",objEmp.tEmpID);
                cmd.Parameters.AddWithValue("@EmpID", objEmp.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", objEmp.EmpName);
                cmd.Parameters.AddWithValue("@Email", objEmp.Email);
                cmd.Parameters.AddWithValue("@Phone", objEmp.Phone);
                cmd.Parameters.AddWithValue("@CNIC", objEmp.CNIC);
                cmd.Parameters.AddWithValue("@Address", objEmp.Address);
                cmd.Parameters.AddWithValue("@Status", objEmp.Status);
                cmd.Parameters.AddWithValue("@isActive", objEmp.isActive);
                cmd.Parameters.AddWithValue("@CreatedDate", objEmp.CreatedDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", null);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }

        }

        public string DeleteData(Employee objEmp)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_InsertUpdateDelete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tEmpID", objEmp.tEmpID);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }


        public List<Employee> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Employee> empList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_InsertUpdateDelete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tEmpID", null);
                //cmd.Parameters.AddWithValue("@EmpID", null);
                //cmd.Parameters.AddWithValue("@Name", null);
                //cmd.Parameters.AddWithValue("@Email", null);
                //cmd.Parameters.AddWithValue("@Phone", null);
                //cmd.Parameters.AddWithValue("@CNIC", null);
                //cmd.Parameters.AddWithValue("@Address", null);
                //cmd.Parameters.AddWithValue("@Status", null);
                //cmd.Parameters.AddWithValue("@isActive", null);
                //cmd.Parameters.AddWithValue("@CreatedDate", null);
                //cmd.Parameters.AddWithValue("@ModifiedDate", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                empList = new List<Employee>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Employee empObj = new Employee();
                    empObj.tEmpID = Convert.ToInt32(ds.Tables[0].Rows[i]["tempID"].ToString());
                    empObj.EmployeeID = Convert.ToInt32(ds.Tables[0].Rows[i]["empID"].ToString());
                    empObj.EmpName = ds.Tables[0].Rows[i]["name"].ToString();
                    empObj.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    empObj.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                    empObj.CNIC = ds.Tables[0].Rows[i]["cnic"].ToString();
                    empObj.Address = ds.Tables[0].Rows[i]["address"].ToString();
                    empObj.Status = ds.Tables[0].Rows[i]["status"].ToString();
                    empObj.isActive = ds.Tables[0].Rows[i]["isActive"].ToString();
                    empList.Add(empObj);
                }
                return empList;
            }
            catch(Exception ex)
            {
                var exc = ex.Message;
                return empList;
            }
            finally
            {
                con.Close();
            }
        }

        public Employee SelectDatabyID(string tEmpID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Employee empObj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("usp_InsertUpdateDelete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tEmpID", tEmpID);
                //cmd.Parameters.AddWithValue("@Name", null);
                //cmd.Parameters.AddWithValue("@Address", null);
                //cmd.Parameters.AddWithValue("@Mobileno", null);
                //cmd.Parameters.AddWithValue("@Birthdate", null);
                //cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    empObj = new Employee();
                    empObj.tEmpID = Convert.ToInt32(ds.Tables[0].Rows[i]["tempID"].ToString());
                    empObj.EmployeeID = Convert.ToInt32(ds.Tables[0].Rows[i]["empID"].ToString());
                    empObj.EmpName = ds.Tables[0].Rows[i]["name"].ToString();
                    empObj.Email = ds.Tables[0].Rows[i]["email"].ToString();
                    empObj.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                    empObj.CNIC = ds.Tables[0].Rows[i]["cnic"].ToString();
                    empObj.Address = ds.Tables[0].Rows[i]["address"].ToString();
                    empObj.Status = ds.Tables[0].Rows[i]["status"].ToString();
                    empObj.isActive = ds.Tables[0].Rows[i]["isActive"].ToString();
                }
                return empObj;
            }
            catch
            {
                return empObj;
            }
            finally
            {
                con.Close();
            }
        }
    }
}