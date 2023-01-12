CREATE TABLE [dbo].[Legal_contractor] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
	[biin] VARCHAR(100) NOT NULL,
    [company_name] VARCHAR (100) NOT NULL,
    [created_date]         DATE        NOT NULL,
    [edited_date] DATE NOT NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC)
);

