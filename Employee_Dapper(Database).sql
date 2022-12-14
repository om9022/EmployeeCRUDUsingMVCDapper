USE [master]
GO
/****** Object:  Database [Employee_Dapper]    Script Date: 14-12-2022 19:14:50 ******/
CREATE DATABASE [Employee_Dapper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employee_Dapper', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Employee_Dapper.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Employee_Dapper_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Employee_Dapper_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Employee_Dapper] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employee_Dapper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employee_Dapper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employee_Dapper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employee_Dapper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employee_Dapper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employee_Dapper] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employee_Dapper] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employee_Dapper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employee_Dapper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employee_Dapper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employee_Dapper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employee_Dapper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employee_Dapper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employee_Dapper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employee_Dapper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employee_Dapper] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Employee_Dapper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employee_Dapper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employee_Dapper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employee_Dapper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employee_Dapper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employee_Dapper] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employee_Dapper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employee_Dapper] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Employee_Dapper] SET  MULTI_USER 
GO
ALTER DATABASE [Employee_Dapper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employee_Dapper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employee_Dapper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employee_Dapper] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Employee_Dapper] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Employee_Dapper] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Employee_Dapper] SET QUERY_STORE = OFF
GO
USE [Employee_Dapper]
GO
/****** Object:  Table [dbo].[Emp_Table]    Script Date: 14-12-2022 19:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp_Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Active] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Emp_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 14-12-2022 19:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEmployee]
@Name varchar(50)=null,
@Contact varchar(50)=null,
@Location varchar(50)= null
AS
BEGIN
if exists(select top(1)1 from Emp_Table Where Active=1 and Name=@Name )
Begin
Select 'Person Name Already Exists ' as Msg,0 as n,'failed ' as Status
End
else 
begin
insert into Emp_Table(
Name,
Contact,
Location,
Active )
values
(
@Name,
@Contact,
@Location,
1)
Select 'Employee Name Added Sucessfully' as Msg,1 as n,'success ' as Status
End
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeList]    Script Date: 14-12-2022 19:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeeList]
AS
BEGIN
 select row_number () over (order by Id desc) As SrNo , * from Emp_Table where Active=1
 select 'Location List Display Successfully' as Msg, 1 as n , 'Success' as Status
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveEmployee]    Script Date: 14-12-2022 19:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveEmployee]
@Id int=null	
AS
BEGIN
if exists(select top(1)1 from Emp_Table Where Id=@Id and Active=1 )
Begin
update Emp_Table set Active=0 where Id=@Id ;
Select 'Employee Deleted Sucessfully' as Msg,1 as n,'success ' as Status
End
else
begin
Select 'Employee does not exists ' as Msg,0 as n,'failed ' as Status
End	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 14-12-2022 19:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
@Id int=null,
@Name varchar(50)=null,
@Contact varchar(max)=null,
@Location Varchar(50)=null
AS
BEGIN	
if exists(select top(1)1 from Emp_Table Where Id=@Id and Active=1)
begin
  update Emp_Table set
  Name=@Name,
  Contact=@Contact,
  Location=@Location
  where Id=@Id
  Select 'Employee Updated Sucessfully' as Msg,1 as n,'Success ' as Status
End
  else
begin
  Select 'Employee Updated Failed ' as Msg,0 as n,'Failed ' as Status
End
end
GO
/****** Object:  StoredProcedure [dbo].[ViewEmployee]    Script Date: 14-12-2022 19:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[ViewEmployee] 
@Id int= null
AS
BEGIN
if exists(select top(1)1 from Emp_Table Where Active=1 and Id=@Id )
Begin
select *
	from Emp_Table where Id=@Id and Active=1
	Select 'Employee Details Display Successfully.' as Msg,1 as n,'success ' as Status
End
else
	begin
		select ''
		Select 'Emploee Details Display Failed' as Msg,0 as n,'failed ' as Status
	END
END
GO
USE [master]
GO
ALTER DATABASE [Employee_Dapper] SET  READ_WRITE 
GO
