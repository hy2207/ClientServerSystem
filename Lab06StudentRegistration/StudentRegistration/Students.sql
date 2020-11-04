CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL IDENTITY,
	[StudentFirstName] NVARCHAR(50) NOT NULL,
	[StudentLastName] NVARCHAR(50) NOT NULL,
	[StudentMajor] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_Students] PRIMARY KEY ([StudentId]),
	CONSTRAINT [FK_Students_Departments] FOREIGN KEY ([StudentMajor]) REFERENCES [Departments]([DepartmentCode]) ON UPDATE CASCADE
)
