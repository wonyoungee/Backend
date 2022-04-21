using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//추가
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HW_Dept_Emp.Models
{
    public class DeptDB
    {
        // DB연결 - Web.config
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // CRUD 함수
        public List<Dept> ListAll()
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

        public List<Emp> EmpByDeptno(int Deptno)
        {
            List<Emp> emps = new List<Emp>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("selectEmpByDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Deptno", Deptno);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emps.Add(new Emp
                    {
                        empno = Convert.ToInt32(dr["empno"]),
                        ename = dr["ename"].ToString(),
                        job = dr["job"].ToString(),
                        mgr = (dr["mgr"] == DBNull.Value) ? (int?)null : Convert.ToInt32(dr["mgr"]),
                        hiredate = dr["hiredate"].ToString(),
                        sal = Convert.ToInt32(dr["sal"]),
                        comm = (dr["comm"] == DBNull.Value) ? (int?)null : Convert.ToInt32(dr["comm"]),
                        deptno = Convert.ToInt32(dr["deptno"])
                    });
                }
                return emps;
            }
        }
    }
}