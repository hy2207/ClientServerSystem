CREATE TABLE [dbo].[Departments]
(
	[DepartmentCode] NVARCHAR(10) NOT NULL,
	[DepartmentName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentCode])
)
