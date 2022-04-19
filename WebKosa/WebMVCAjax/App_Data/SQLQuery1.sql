use KosaDB

create table employee(
	employeeID int identity(1,1) not null,
	Name nvarchar(50),
	Age int,
	State nvarchar(50),
	Country nvarchar(50),
	constraint pk_employee_id primary key(employeeID)
)


-- ��ü ������ select ���ν���
create proc selectEmployee
as
	begin
		select * from employee
	end

exec selectEmployee

-- insert / update ���ν���
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

-- delete ���ν���
create proc deleteEmployee
(
	@id int
)
as
	begin
		delete from employee where employeeID=@id
	end
