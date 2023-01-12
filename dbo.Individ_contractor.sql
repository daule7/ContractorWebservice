CREATE TABLE [dbo].[Individ_contractor] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [iin]       VARCHAR (100) NOT NULL,
    [name]    VARCHAR (100) NOT NULL,
    [age] VARCHAR (10) NOT NULL,
    [created_date]       DATE        NOT NULL,
    [edited_date] DATE NULL, 
    [gender] VARCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC)
);

