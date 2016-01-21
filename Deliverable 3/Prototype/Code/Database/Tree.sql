CREATE TABLE [dbo].[Tree] (
    [TreeUid]   UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Type]      VARCHAR (100)    NULL,
    [Depth]     INT              NOT NULL,
    [Splitsize] INT              NOT NULL,
    CONSTRAINT [Tree_pk] PRIMARY KEY CLUSTERED ([TreeUid] ASC)
);

