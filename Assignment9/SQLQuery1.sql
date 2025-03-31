CREATE TABLE [dbo].[Person] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [fname]      NCHAR (10) NOT NULL,
    [lname]      NCHAR (10) NOT NULL,
    [address]    NCHAR (10) NOT NULL,
    [facepiece1] NCHAR (50) NULL,
    [facepiece2] NCHAR (50) NULL,
    [facepiece3] NCHAR(50) NULL, 
    [facepiece4] NCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);