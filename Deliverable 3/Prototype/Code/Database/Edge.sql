CREATE TABLE [dbo].[Edge] (
    [EdgeUid] UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Index]   INT              NOT NULL,
    [Tree]    UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    CONSTRAINT [Edge_pk] PRIMARY KEY CLUSTERED ([EdgeUid] ASC),
    CONSTRAINT [TreeEdge_to_Tree] FOREIGN KEY ([Tree]) REFERENCES [dbo].[Tree] ([TreeUid])
);

