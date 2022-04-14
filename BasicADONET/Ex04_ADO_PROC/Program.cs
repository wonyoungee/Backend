using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Data 작업
using System.Data;
using System.Data.SqlClient;
using DBCONNLIB;

namespace Ex04_ADO_PROC
{
    /*
         create proc usp_GetEmpListByEmpno
        @empno int = null
        as 
	        if @empno is null
		        select empno, ename, job, mgr, sal from emp
	        else
		        select empno, ename, job, mgr, sal from emp
                where empno = @empno
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(DBCONN.Constr);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "usp_GetEmpListByEmpno";
            comm.CommandType = CommandType.StoredProcedure; // 주의!! 필수로 적어야함!!

            Console.Write("사번을 입력하세요");
            int empno = int.Parse(Console.ReadLine());

            comm.Parameters.Add("@empno", SqlDbType.Int);   // 주의!
            comm.Parameters["@empno"].Value = empno;    // 주의!

            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            dr.Close();
            conn.Close();
        }
    }
}
