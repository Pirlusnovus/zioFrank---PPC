CREATE TABLE [dbo].[AttrVertexUsage] (
    [AttrUsageUid]     UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [ObjectVertexUid]  UNIQUEIDENTIFIER NOT NULL,
    [AttrDefVertexUid] UNIQUEIDENTIFIER NULL,
    [Value]            VARCHAR (1000)   NULL,
    CONSTRAINT [AttrVertexUsage _pk] PRIMARY KEY CLUSTERED ([AttrUsageUid] ASC, [ObjectVertexUid] ASC),
    CONSTRAINT [AttrDefVertexUid_to_AttrDef] FOREIGN KEY ([AttrDefVertexUid]) REFERENCES [dbo].[AttrDef] ([AttrDefUid]),
    CONSTRAINT [ObjectVertexUid_to_Vertex] FOREIGN KEY ([ObjectVertexUid]) REFERENCES [dbo].[Vertex] ([VertexUid])
);

