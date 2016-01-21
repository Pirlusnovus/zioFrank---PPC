CREATE TABLE [dbo].[Vertex] (
    [VertexUid] UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Name]      VARCHAR (100)    NULL,
    [Tree]      UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [Index]     INT              NOT NULL,
    CONSTRAINT [Vertex_pk] PRIMARY KEY CLUSTERED ([VertexUid] ASC),
    CONSTRAINT [TreeVertex_to_Tree] FOREIGN KEY ([Tree]) REFERENCES [dbo].[Tree] ([TreeUid])
);

