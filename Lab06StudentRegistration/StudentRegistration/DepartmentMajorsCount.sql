CREATE VIEW [dbo].[DepartmentMajorsCount]
	AS SELECT DepartmentName, COUNT(*) AS NumberOfMajors 
	FROM [Departments] 
	INNER JOIN [Students] ON [Students].StudentMajor = [Departments].DepartmentCode
	GROUP BY DepartmentName