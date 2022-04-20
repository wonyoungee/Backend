use KosaDB

create table employee(
	employeeID int identity(1,1) not null,
	Name nvarchar(50),
	Age int,
	State nvarchar(50),
	Country nvarchar(50),
	constraint pk_employee_id primary key(employeeID)
)


-- 전체 데이터 select 프로시져
create proc selectEmployee
as
	begin
		select * from employee
	end

exec selectEmployee

-- insert / update 프로시져
create proc InsertUpdateEmployee
(
	@id int,
	@Name nvarchar(50),
	@Age int,
	@State nvarchar(50),
	@Country nvarchar(50),
	@Action varchar(10)
)
as
	begin
		if @Action = 'insert'
		begin
			insert into employee(name, age, state, country)
			values(@name, @age, @state, @country)
		end
		if @Action = 'update'
		begin
			update employee set name=@name, age=@age, state = @state, country = @country
			where employeeID = @id
		end
	end

-- delete 프로시져
create proc deleteEmployee
(
	@id int
)
as
	begin
		delete from employee where employeeID=@id
	end





----------------------------------------------------------------
-- HW_Emp_CRUD

-- 전체 데이터 select 프로시져
create proc selectAllEmp
as
	begin
		select * from emp
	end

exec selectAllEmp


-- 부분 데이터 select 프로시져
create proc selectEmpno
@empno int
as
	begin
		select * from emp
		where EMPNO = @empno
	end

exec selectEmpno 7369


-- insert / update 프로시져
create proc InsertUpdateEmp
(
	@empno int,
	@ename varchar(10),
	@job varchar(9),
	@mgr int,
	@hiredate datetime,
	@sal int,
	@comm int,
	@deptno int,
	@Action varchar(10)
)
as
	begin
		if @Action = 'insert'
		begin
			insert into emp(empno, ename, job, mgr, hiredate, sal, comm, deptno)
			values(@empno, @ename, @job, @mgr, @hiredate, @sal, @comm, @deptno)
		end
		if @Action = 'update'
		begin
			update emp set ename=@ename, job=@job, mgr=@mgr, hiredate=@hiredate, sal=@sal, comm=@comm, deptno=@deptno
			where empno=@empno
		end
	end

exec InsertUpdateEmp 1, 22, 3, 4, 5, 6, 7, 20, 'update'

-- delete 프로시져
create proc deleteEmp
(
	@empno int
)
as
	begin
		delete from emp where empno=@empno
	end

exec deleteEmp 1

select * from emp