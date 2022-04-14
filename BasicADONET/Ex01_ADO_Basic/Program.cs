using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Data 작업
using System.Data;
using System.Data.SqlClient;

namespace Ex01_ADO_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //연결 문자열 생성
            string strConn = @"Data Source=DESKTOP-TA6KUCJ\SQLEXPRESS;uid=sa;pwd=1004;database=kosadb";

            // 연결객체생성
            SqlConnection conn = new SqlConnection(); //커넥션
            conn.ConnectionString = strConn;
            conn.Open(); //연결시도

            Console.WriteLine("연결상태 : {0}", conn.State);
            Console.WriteLine("연결 DB : {0}", conn.Database);
            Console.WriteLine("연결서버버전 : {0}", conn.ServerVersion);

            // 명령객체생성
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select empno, ename, job, sal from emp";    // sql 구문
            comm.CommandType = CommandType.Text;    // 생략 가능
            // comm.CommandType = CommandType.StoredProcedure;  // sql구문에 프로시져 있을때 사용
            comm.Connection = conn;

            // 명령 실행 3가지
            // comm.ExecuteNonQuery(); // DML (insert, update, delete) >> 데이터 집합을 만들지 않는 작업
            // comm.ExecuteReader();   // select (다중행, 멀티컬럼)   >>   ex) select empno 
            // comm.ExecuteScalar();   // select (단일행, 단일컬럼)   >>  ex) select sum(sal) , select count(sal)

            // 명령 처리하기
            // select   >>  출력
            // DML  >>  조건처리

            SqlDataReader reader = comm.ExecuteReader();    //서버의 메모리에 데이터가 만들어지고 그 데이터에 접근(read)하는 객체

            while (reader.Read())   // Read() : row에 접근 (밑의 행으로 이동하며 읽음)
            {
                Console.WriteLine("사번 : {0}, 이름 : {1}, 직종 : {2}, 급여 : {3}", reader["empno"], reader["ename"], reader["job"], reader["sal"]);
                // select한 데이터의 row개수만큼 출력

                reader.Close();
                conn.Close();
                Console.WriteLine("연결상태 : {0}", conn.State);
            }*/

            //연결 문자열 생성
            string strConn = @"Data Source=DESKTOP-TA6KUCJ\SQLEXPRESS;uid=sa;pwd=1004;database=kosadb";

            SqlConnection conn = null;  // 연결객체
            SqlDataReader dr = null;    // 서버의 데이터 접근(read)하는 객체
            SqlCommand comm = null; // 명령 객체
            string sql = "select empno, ename, job, sal from emp";  // sql구문

            try
            {
                conn = new SqlConnection(strConn);  // 연결객체 생성
                conn.Open();    // 연결시도
                comm = new SqlCommand(sql, conn);   // 명령객체 생성
                dr = comm.ExecuteReader();  // 명령실행 (select)

                while (dr.Read())
                {
                    Console.WriteLine("사번 : {0}, 이름 : {1}, 직종 : {2}, 급여 : {3}", dr["empno"], dr["ename"], dr["job"], dr["sal"]);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } finally // 자원해제보장
            {
                dr.Close();
                conn.Close();
            }
        }
    }
}

/*
  using (SqlConnection conn = new SqlConnection(strConn))
  {
   conn.Open();
    // TSQL문장과 Connection 객체를 지정
   SqlCommand cmd = new SqlCommand(sql, conn);
    // 데이터는 서버에서 가져오도록 실행
   SqlDataReader rdr = cmd.ExecuteReader();
  }
 */