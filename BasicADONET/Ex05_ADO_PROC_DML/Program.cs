using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Data 작업
using System.Data;
using System.Data.SqlClient; 
using DBCONNLIB;

namespace Ex05_ADO_PROC_DML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DML
            using (SqlConnection conn = new SqlConnection(DBCONN.Constr))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateDataEmp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                int empno = 7788;
                string ename = "아무개";
                int sal = 5555;

                // parameter 설정하기
                //cmd.Parameters.Add();
                cmd.Parameters.AddWithValue("@empno", empno);
                cmd.Parameters.AddWithValue("@ename", ename);
                cmd.Parameters.AddWithValue("@sal", sal);

                // return값 처리
                cmd.Parameters.Add("@return", SqlDbType.Int);
                cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;   // return값임을 알려줘야함.

                ////////////////////////////////////////////////////////////

                conn.Open();
                cmd.ExecuteNonQuery();

                int result = (int) cmd.Parameters["@return"].Value;
                Console.WriteLine("result : " + result);
            }
        }
    }
}
/*
 create proc usp_UpdateDataEmp
@empno int,
@ename varchar(9),
@sal int
as
	declare @result int
	begin try
		update EMP
		set ENAME = @ename, SAL = @sal
		where empno = @empno
		set @result = @@ROWCOUNT
	end try
	begin catch
		set @result = -1
	end catch
	return @result
*/