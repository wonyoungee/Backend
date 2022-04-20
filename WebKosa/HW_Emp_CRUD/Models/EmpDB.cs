using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//추가
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HW_Emp_CRUD.Models
{
    public class EmpDB
    {
        // DB연결 - Web.config
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // CRUD 함수
        public List<Emp> ListAll()
        {
            //SqlConnection, SqlCommand, DataReader ... Procedure ...

            List<Emp> emps = new List<Emp>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("selectAllEmp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emps.Add(new Emp
                    {
                        empno = Convert.ToInt32(dr["empno"]),
                        ename = dr["ename"].ToString(),
                        job = dr["job"].ToString(),
                        mgr = (dr["mgr"]== DBNull.Value) ? (int?)null : Convert.ToInt32(dr["mgr"]),
                        hiredate = dr["hiredate"].ToString(),
                        sal = Convert.ToInt32(dr["sal"]),
                        comm = (dr["comm"] == DBNull.Value) ? (int?)null : Convert.ToInt32(dr["comm"]),
                        deptno = Convert.ToInt32(dr["deptno"])
                    });
                }
                return emps;
            }
        }

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

        public int Add(Emp emp)
        {
            int returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("InsertUpdateEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@empno", emp.empno); //procedure  insert or  update 
                comm.Parameters.AddWithValue("@ename", emp.ename);
                comm.Parameters.AddWithValue("@job", emp.job);
                comm.Parameters.AddWithValue("@mgr", emp.mgr);
                comm.Parameters.AddWithValue("@hiredate", emp.hiredate);
                comm.Parameters.AddWithValue("@sal", emp.sal);
                comm.Parameters.AddWithValue("@comm", emp.comm);
                comm.Parameters.AddWithValue("@deptno", emp.deptno);
                comm.Parameters.AddWithValue("@Action", "insert");
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }

        public int Update(Emp emp)
        {
            int returnvalue = 0;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("InsertUpdateEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@empno", emp.empno); //procedure  insert or  update 
                comm.Parameters.AddWithValue("@ename", emp.ename);
                comm.Parameters.AddWithValue("@job", emp.job);
                comm.Parameters.AddWithValue("@mgr", emp.mgr);
                comm.Parameters.AddWithValue("@hiredate", emp.hiredate);
                comm.Parameters.AddWithValue("@sal", emp.sal);
                comm.Parameters.AddWithValue("@comm", emp.comm);
                comm.Parameters.AddWithValue("@deptno", emp.deptno);
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
                SqlCommand comm = new SqlCommand("deleteEmp", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@empno", ID); //procedure  insert or  update 
                returnvalue = comm.ExecuteNonQuery();
            }
            return returnvalue;
        }
    }
}