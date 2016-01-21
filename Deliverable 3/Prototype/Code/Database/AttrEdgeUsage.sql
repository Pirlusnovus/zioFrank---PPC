CREATE TABLE [dbo].[AttrEdgeUsage] (
    [AttrUsageUid]   UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [ObjectEdgeUid]  UNIQUEIDENTIFIER NOT NULL,
    [AttrDefEdgeUid] UNIQUEIDENTIFIER NULL,
    [Value]          VARCHAR (1000)   NULL,
    CONSTRAINT [AttrEdgeUsage _pk] PRIMARY KEY CLUSTERED ([AttrUsageUid] ASC, [ObjectEdgeUid] ASC),
    CONSTRAINT [AttrDefEdgeUid_to_AttrDef] FOREIGN KEY ([AttrDefEdgeUid]) REFERENCES [dbo].[AttrDef] ([AttrDefUid]),
    CONSTRAINT [ObjectEdgeUid_to_Edge] FOREIGN KEY ([ObjectEdgeUid]) REFERENCES [dbo].[Edge] ([EdgeUid])
);

