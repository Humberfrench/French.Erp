USE frenchDev
GO
/****** Object:  StoredProcedure [dbo].[OpenKeys]    Script Date: 03/04/2018 14:44:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[OpenKeys]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        OPEN SYMMETRIC KEY skFrench
        DECRYPTION BY CERTIFICATE certFrench
    END TRY
    BEGIN CATCH
        -- Nao encontrou
    END CATCH
    
    SET NOCOUNT OFF;
END

