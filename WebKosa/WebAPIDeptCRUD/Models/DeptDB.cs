using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//추가
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPIDeptCRUD.Models
{
    public class DeptDB
    {
        // DB연결 - Web.config
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // CRUD 함수
        public List<Dept> GetAll()
        {
            //SqlConnection, SqlCommand, DataReader ... Procedure ...

            List<Dept> depts = new List<Dept>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("selectAllDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    depts.Add(new Dept
                    {
                        Deptno = Convert.ToInt32(dr["Deptno"]),
                        Dname = dr["Dname"].ToString(),
                        Loc = dr["Loc"].ToString(),
                    });
                }
                return depts;
            }
        }

      

    /*
        public Emp ListByEmpno(int empno)
        {
            Emp emp = new Emp();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("selectEmpno", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", empno);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.empno = Convert.ToInt32(dr["empno"]);
                    emp.ename = dr["ename"].ToString();
                    emp.job = dr["job"].ToString();
                    emp.mgr = (dr["mgr"] == DBNull.Value) ? (int?)null : Convert.ToInt32(dr["mgr"]);
                    emp.hiredate =dr["hiredate"].ToString();
                    emp.sal = Convert.ToInt32(dr["sal"]);
                    emp.comm = (dr["comm"] == DBNull.Value) ? (int?)null : Convert.ToInt32(dr["comm"]);
                    emp.deptno = Convert.ToInt32(dr["deptno"]);
                }
                return emp;
            }
        }
    */

        public int Add(Dept dept)
        {
            int returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("insertDept", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Deptno", dept.Deptno);
                comm.Parameters.AddWithValue("@Dname", dept.Dname);
                comm.Parameters.AddWithValue("@Loc", dept.Loc);
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }

        public int Update(Dept dept)
        {
            int returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("updateDept", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Deptno", dept.Deptno);
                comm.Parameters.AddWithValue("@Dname", dept.Dname);
                comm.Parameters.AddWithValue("@Loc", dept.Loc);
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
                SqlCommand comm = new SqlCommand("deleteDept", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@Deptno", ID); //procedure  insert or  update 
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }
    }
}