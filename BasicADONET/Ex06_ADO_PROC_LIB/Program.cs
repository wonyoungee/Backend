using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmpDao;

namespace Ex06_ADO_PROC_LIB
{
    /*
    public SqlDataReader getEmpAllList() { return null; }   //1번
    public List<Emp> getEmpList() { return null; }  //2번    => 이게 더 편함!!
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpData empdata = new EmpData();
            int result = empdata.insertDept(new Dept(50,"IT", "SEOUL"));
            Console.WriteLine(result);

            //update
            result = empdata.updateDept(new Dept(50, "IT TEAM", "Busan"));
            Console.WriteLine(result);

            //select
            List<Dept> list = empdata.getDeptList();
            foreach(Dept d in list)
            {
                Console.WriteLine("deptno : " + d.Deptno + "    dname : " + d.Dname + "    loc : " + d.Loc);
            }

            //select 조건 조회
            Dept dept = empdata.getDeptListByDeptno(50);
            Console.WriteLine("deptno : " + dept.Deptno + "    dname : " + dept.Dname + "    loc : " + dept.Loc);

            //delete
            result = empdata.deleteDept(50);
            Console.WriteLine(result);
            
        }
    }
}
