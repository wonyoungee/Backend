using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Data 작업
using System.Data;
using System.Data.SqlClient;
using DBCONNLIB;
 
namespace Ex03_ADO_Scalar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 사원테이블에서 사원의 평균 급여를 구하고 화면에 출력하세요.
           
            SqlConnection conn = null;  // 연결객체
            SqlCommand comm = null; // 명령 객체
            string sql = "select avg(sal) as avgsal from emp";  // 컬럼1개이므로 reader 필요없음!

            try
            {
                conn = new SqlConnection(DBCONN.Constr);  // 연결객체 생성
                conn.Open();    // 연결시도
                comm = new SqlCommand(sql, conn);   // 명령객체 생성
                int avgsal = (int)comm.ExecuteScalar();   // db가 데이터 set 안 만듦.

                Console.WriteLine(avgsal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally // 자원해제보장
            {
               
                conn.Close();
            }
        }
    }
}
