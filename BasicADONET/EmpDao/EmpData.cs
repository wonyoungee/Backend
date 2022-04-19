using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Data 작업
using System.Data;
using System.Data.SqlClient;

using DBCONNLIB;

namespace EmpDao
{
    public class EmpData
    {
        private string constr;

        public EmpData()
        {
            constr = DBCONN.Constr;
        }
        // 연결객체(pool)

        /* CRUD 함수*/
        // 전체조회 (select deptno, dname, loc from dept)
        //public SqlDataReader getEmpAllList() { return null; }   //1번
        public List<Dept> getDeptList() {
            List<Dept> list = new List<Dept>();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAllDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Dept(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString()));
                }
            }
            return list;
        }  //2번
 
        // 부분조회 (PK로 조회  ex) select deptno, dname, loc from dept where deptno=@deptno)  >> 오라클 where deptno=?
        public Dept getDeptListByDeptno(int deptno) {
            Dept dept = new Dept();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectDataDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@deptno", deptno);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dept.Deptno = int.Parse(dr[0].ToString());
                    dept.Dname = dr[1].ToString();
                    dept.Loc = dr[2].ToString();
                }
            }
            return dept;
        }

        // 삽입 (insert into dept(deptno, dname, loc) values (@deptno, @dname, @loc))
        public int insertDept(Dept dept) {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertDataDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // parameter 설정하기
                cmd.Parameters.AddWithValue("@deptno", dept.Deptno);
                cmd.Parameters.AddWithValue("@dname", dept.Dname);
                cmd.Parameters.AddWithValue("@loc", dept.Loc);

                // return값 처리
                cmd.Parameters.Add("@return", SqlDbType.Int);
                cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;   // return값임을 알려줘야함.

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@return"].Value;
            }
         }
        // 삭제 (delete from dept where deptno=@deptno)
        public int deleteDept(int deptno) {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteDataDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parameter 설정하기
                cmd.Parameters.AddWithValue("@deptno", deptno);   //parameter와 값을 같이 넣어준다.
                //DB내 컬럼명과 똑같이 해주는게 좋다. 

                //return 값 처리
                cmd.Parameters.Add("@return", SqlDbType.Int);
                cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
                //output으로 잡았으면 output

                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@return"].Value;
            }
        }
        // 수정 (update dept set dname=@dname, loc=@loc where deptno=@deptno)
        public int updateDept(Dept dept) {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateDataDept", conn);
                cmd.CommandType = CommandType.StoredProcedure;//프로시져 알려줌
                cmd.Parameters.AddWithValue("@deptno", dept.Deptno);
                cmd.Parameters.AddWithValue("@dname", dept.Dname);
                cmd.Parameters.AddWithValue("@loc", dept.Loc);

                cmd.Parameters.Add("@return", SqlDbType.Int);
                cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;//리턴에 값 넣기
                conn.Open();
                cmd.ExecuteNonQuery();//select가 아니라 non

                int result = (int)cmd.Parameters["@return"].Value;//리턴안에 잇는 값 가져오기
                return result;
            }
        }
    }

    public class Dept
    {
        private int deptno;
        private string dname;
        private string loc;

        public Dept() { }

        public Dept(int deptno, string dname, string loc)
        {
            this.deptno = deptno;
            this.dname = dname;
            this.loc = loc;
        }

        public int Deptno
        {
            get { return this.deptno; }
            set { this.deptno = value; }
        }

        public string Dname
        {
            get { return this.dname; }
            set { this.dname = value; }

        }

        public string Loc
        {
            get { return this.loc; }
            set { this.loc = value; }
        }
    }
}
