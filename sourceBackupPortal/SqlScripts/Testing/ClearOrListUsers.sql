use ProjectSourceBackupToolPortal
go

-- comment to just list users
--delete from AspNetUsers;

go



/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[UserName]
      ,[NormalizedUserName]
      ,[Email]
      ,[NormalizedEmail]
      ,[EmailConfirmed]
      ,[PasswordHash]
      ,[SecurityStamp]
      ,[ConcurrencyStamp]
      ,[PhoneNumber]
      ,[PhoneNumberConfirmed]
      ,[TwoFactorEnabled]
      ,[LockoutEnd]
      ,[LockoutEnabled]
      ,[AccessFailedCount]
  FROM [ProjectSourceBackupToolPortal].[dbo].[AspNetUsers]