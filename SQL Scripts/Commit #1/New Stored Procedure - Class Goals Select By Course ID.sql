/****** Object:  StoredProcedure [dbo].[ClassGoalsSelectByCourseID]    Script Date: 2/5/2019 7:36:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Ruben Morales Jr
-- Create Date: February 4, 2019
-- Description: Select all class goals by courseID
-- =============================================
ALTER PROCEDURE [dbo].[ClassGoalsSelectByCourseID]

    -- Add the parameters for the stored procedure here
    @courseID int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT GoalsByClass.ID,        GoalsByClass.shortDescription, GoalsByClass.fullDescription, 
		   GoalsByClass.dateAdded, GoalsByClass.deadlineDate,     GoalsByClass.dateFinished,
		   Course.courseTitle
	
	FROM  GoalsByClass
	INNER JOIN Course ON GoalsByClass.courseID = Course.ID

	WHERE GoalsByClass.courseID = @courseID
END
