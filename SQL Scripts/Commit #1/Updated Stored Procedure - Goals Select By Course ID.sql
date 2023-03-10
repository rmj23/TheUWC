/****** Object:  StoredProcedure [dbo].[GoalsSelectByCourseID]    Script Date: 2/5/2019 7:20:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DeVante Pickering
-- Create date: 06/13/2016
-- Description:	Select student goals for a particular course

--modified by Ruben Morales Jr
--date: feb 4, 2019
--description: query rewriting because it was passing wrong data to instruction model
-- =============================================
ALTER PROCEDURE [dbo].[GoalsSelectByCourseID]
	-- Add the parameters for the stored procedure here
	@studentID int,
	@courseID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT GoalsIndividualStudent.id as 'GoalID', GoalsIndividualStudent.goalPaperTitle,  GoalsIndividualStudent.description as 'Goal', 
	   GoalsIndividualStudent.goalPaperID,    GoalsIndividualStudent.studentCourseID, GoalsIndividualStudent.teacherID,
	   GoalsIndividualStudent.dateAdded,      GoalsIndividualStudent.deadlineDate,    GoalsIndividualStudent.dateFinished, 
	   [User].firstName,                      [User].lastName,                        ValidEvaluationType.Title as 'writingElement'

FROM   GoalsIndividualStudent

INNER JOIN StudentCourse       ON GoalsIndividualStudent.studentCourseID = StudentCourse.ID
INNER JOIN Course	           ON StudentCourse.CourseID = Course.ID 
INNER JOIN Student		       ON StudentCourse.studentID = Student.ID 
INNER JOIN [User]		       ON Student.userID = [User].ID 
INNER JOIN Teacher		       ON GoalsIndividualStudent.teacherID = Teacher.ID 
INNER JOIN [User] AS User_1    ON Teacher.userID = User_1.ID
INNER JOIN ValidEvaluationType ON GoalsIndividualStudent.goalTypeID = ValidEvaluationType.ID

WHERE StudentCourse.studentID = @studentID  AND Course.ID = @courseID  
END
