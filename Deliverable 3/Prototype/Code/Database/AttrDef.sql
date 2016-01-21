CREATE TABLE [dbo].[AttrDef] (
    [AttrDefUid] UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Name]       VARCHAR (50)     NULL,
    CONSTRAINT [AttrDef_pk] PRIMARY KEY CLUSTERED ([AttrDefUid] ASC)
);

