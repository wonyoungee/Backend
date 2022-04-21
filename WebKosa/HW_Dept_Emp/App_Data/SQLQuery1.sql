-- HW_Dept_Emp
use KosaDB

-- 전체 조회
create proc selectAllDept
as
	begin
		select * from Dept
	end

exec selectAllDept

-- deptno로 emp 조회
create proc selectEmpByDept
@Deptno int
as
	begin
		select * from EMP where DEPTNO = @Deptno
	end

exec selectEmpByDept 10

