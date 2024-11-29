USE frenchDev
GO
/****** Object:  StoredProcedure [dbo].[CloseKeys]    Script Date: 03/04/2018 14:43:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CloseKeys]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        CLOSE SYMMETRIC KEY skFrench
    END TRY
    BEGIN CATCH
        -- Nao encontrou
    END CATCH

    SET NOCOUNT OFF;
END

