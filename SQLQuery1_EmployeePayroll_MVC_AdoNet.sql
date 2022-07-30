create database EmployeePayroll_MVC_AdoNet
use EmployeePayroll_MVC_AdoNet

create table Employee(
  Emp_Id  int NOT NULL Primary key Identity,
  EmployeeName varchar(30) Not Null,
  Department varchar(30),
  Gender varchar(6),
  Salary money,
  JoiningDate date,
  ProfileImage varchar(Max)
)
select * from Employee

--------------------------------------------------------------------------

--Created Stored Procedure for AddEmployee
create procedure spAddEmployee(
  @EmployeeName varchar(30),
  @Department varchar(30),
  @Gender varchar(6),
  @Salary money,
  @JoiningDate date,
  @ProfileImage varchar(Max)
)
As
Begin try
insert into Employee(EmployeeName,Department,Gender,Salary,JoiningDate,ProfileImage) values(@EmployeeName,@Department,@Gender,@Salary,@JoiningDate,@ProfileImage)
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--executing the spAddUser stored procedure
exec spAddEmployee 'Ganesh Potdar','IT','Male',50000,'2022-07-05','~/Assets/Male1.png'
select * from Employee

----------------------------------------------------------------------------------------------

--creating stored Procedure for Fetching User info from DB
create procedure spGetAllEmployee
As
Begin try
select * from Employee
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spGetAllEmployee

-----------------------------------------------------------------------------------------------
-- StoredProcedure to Update Employee Details
create procedure spUpdateEmployee(
  @Emp_Id int,
  @EmployeeName varchar(30),
  @Department varchar(30),
  @Gender varchar(6),
  @Salary money,
  @JoiningDate date,
  @ProfileImage varchar(Max)
)
As
Begin try
Update Employee Set EmployeeName=@EmployeeName,Department=@Department,Gender=@Gender,Salary=@Salary,JoiningDate=@JoiningDate,ProfileImage=@ProfileImage where Emp_Id=@Emp_Id
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spUpdateEmployee '1','Ganesh Potdar','IT Services','Male',50000,'2022-07-05','~/Assets/Male1.png'
drop procedure spUpdateEmployee

---------------------------------------------------------------------------------

--StoredProcedure to Delete EMployee from DB
create procedure spDeleteEmployee(
  @Emp_Id int
)
As
Begin try
delete from Employee where Emp_Id=@Emp_Id
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH
select * from Employee

