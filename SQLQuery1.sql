use KosaDB

select * from emp;

create proc usp_GetEmpListByEmpno
/*input parameter*/
@empno int = null
as 
	if @empno is null
		select empno, ename, job, mgr, sal from emp
	else
		select empno, ename, job, mgr, sal from emp
		where empno=@empno

exec usp_GetEmpListByEmpno

-------------------------------------------------------
-- <Procedure 만들기>

-- insert procedure	>>	usp_InsertDataEmp

create proc usp_InsertDataEmp
@empno int,
@ename varchar(10),
@job varchar(9),
@mgr int,
@hiredate datetime,
@sal int,
@comm int,
@deptno int
as
	insert into EMP(EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO)
	values (@empno, @ename, @job, @mgr, @hiredate, @sal, @comm, @deptno)


-- update procedure >> 사번, 이름, 급여를 parameter로 받아서 (이름, 급여 수정)
--						프로시저 안에서 예외처리하기 (try~)
--							예외발생 X시, @@rowcount 리턴
--							예외 발생시, -1 리턴

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


-- delete procedure	>> 사번을 parameter로 받기

create proc usp_DeleteDataEmp
@empno int
as
	delete EMP
	where EMPNO=@empno


/******* Basic ADONET 솔루션에서... Ex05_ADO_PROC_DML 에서 usp_UpdateDataEmp 실행 **********/
select * from emp where empno=7788


/**Dept CRUD procedure**/
select * from dept
delete dept where deptno = 50

-- selectall
create proc usp_SelectAllDept
as
	begin
		select * from DEPT
	end

-- select by deptno
create proc usp_SelectDataDept
@deptno int
as
	begin
		select * from DEPT where DEPTNO=@deptno
	end

-- insert
create proc usp_InsertDataDept
@deptno int,
@dname varchar(14),
@loc varchar(13)
as
	declare @result int
	begin try
		insert into DEPT(DEPTNO, DNAME, LOC)
		values (@deptno, @dname, @loc)
		set @result = @@ROWCOUNT
	end try
	begin catch
		set @result = -1
	end catch
	return @result


-- delete
create proc usp_DeleteDataDept
@deptno int
as
    declare @msg int
    if(EXISTS(select deptno from DEPT where DEPTNO = @deptno))
    begin
        set @msg = @@ROWCOUNT
        delete from dept where deptno= @deptno
    end
    
    else
    begin
        set @msg = -1
    end
    return @msg


-- update
create proc usp_UpdateDataDept
@deptno int,
@dname nvarchar(40),
@loc nvarchar(40)
as
    declare @result int
    begin try
        UPDATE DEPT SET DNAME = @dname, LOC = @loc
        WHERE DEPTNO = @deptno
        SET @result = 1 
    end try
    begin catch
        SET @result = -1
    end catch
    return @result



------------------------------------------------------------------



/**************** WebApp_Procedure 솔루션***************/

Create table user_registration
(
 UserID int identity(1,1),	-- identity(1,1) : 초기값 1부터 1씩 증가
 Name varchar(50),
 UserAddress varchar(50),
 Gender varchar(6),
 UserPassword varchar(50)
)


Create procedure user_regprocedure

 @UName varchar(50),
 @UAddress varchar(50),
 @Gender varchar(6),
 @U_Password varchar(50)
  AS
  BEGIN
     INSERT INTO user_registration VALUES (@UName,@UAddress,@Gender,@U_Password)
  END

select * from user_registration