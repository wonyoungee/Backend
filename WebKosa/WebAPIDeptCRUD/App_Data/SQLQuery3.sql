-- WEBAPIDEPTCRUD
use KosaDB

-- 전체 조회
create proc selectAllDept
as
	begin
		select * from Dept
	end

exec selectAllDept

-- 삭제
create proc deleteDept
@Deptno int
as
	begin
		delete dept where DEPTNO = @Deptno
	end

exec deleteDept 1

-- 추가
create proc insertDept
@Deptno int,
@Dname varchar(14),
@Loc varchar(13)
as
	begin
		insert into DEPT(DEPTNO, DNAME, LOC)
		values(@Deptno, @Dname, @Loc)
	end

exec insertDept 1, 'test', 'test'

-- 갱신
create proc updateDept
@Deptno int,
@Dname varchar(14),
@Loc varchar(13)
as
	begin
		update DEPT 
		set DEPTNO=@Deptno, DNAME=@Dname, LOC=@Loc
		where DEPTNO=@Deptno
	end

exec updateDept 1, 'test1', 'test2'