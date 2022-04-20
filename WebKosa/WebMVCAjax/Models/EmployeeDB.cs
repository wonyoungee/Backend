using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//추가
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebMVCAjax.Models
{
    public class EmployeeDB     // DAO(Data Access Object)
    {
        // DB연결 - Web.config
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // CRUD 함수
        public List<Employee> ListAll()
        {
            //SqlConnection, SqlCommand, DataReader ... Procedure ...
            
            List<Employee> employees = new List<Employee>();
            
            using(SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("selectEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(dr["employeeid"]),
                        Name = dr["name"].ToString(),
                        Age = Convert.ToInt32(dr["age"]),
                        State = dr["state"].ToString(),
                        Country = dr["country"].ToString()
                    });
                }
                return employees;
            }
        }

        public int Add(Employee emp)
        {
            int returnvalue = 0;
            using(SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("InsertUPdateEmployee", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", emp.EmployeeID); //procedure  insert or  update 
                comm.Parameters.AddWithValue("@Name", emp.Name);
                comm.Parameters.AddWithValue("@Age", emp.Age);
                comm.Parameters.AddWithValue("@State", emp.State);
                comm.Parameters.AddWithValue("@Country", emp.Country);
                comm.Parameters.AddWithValue("@Action", "Insert");
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }

        public int Update(Employee emp)
        {
            int returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("InsertUPdateEmployee", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", emp.EmployeeID); //procedure  insert or  update 
                comm.Parameters.AddWithValue("@Name", emp.Name);
                comm.Parameters.AddWithValue("@Age", emp.Age);
                comm.Parameters.AddWithValue("@State", emp.State);
                comm.Parameters.AddWithValue("@Country", emp.Country);
                comm.Parameters.AddWithValue("@Action", "update");
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }

        public int Delete(int ID)
        {
            int returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("deleteEmployee", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@id", ID); //procedure  insert or  update 
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }
    }
}