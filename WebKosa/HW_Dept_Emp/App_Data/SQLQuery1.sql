-- HW_Dept_Emp
use KosaDB

-- ��ü ��ȸ
create proc selectAllDept
as
	begin
		select * from Dept
	end

exec selectAllDept

-- deptno�� emp ��ȸ
create proc selectEmpByDept
@Deptno int
as
	begin
		select * from EMP where DEPTNO = @Deptno
	end

exec selectEmpByDept 10

