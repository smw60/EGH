----------------- �������� ������ ���� ������ -------------------------------
----			����� ������� ������� ��������
---- ������������� �����
---- ����������� ������  
---- ��������������� ������
---- 
---- �������� + ������     

------------------------------------------------------------------------------
USE EGH;
GO

DROP TABLE dbo.������������������;
DROP TABLE dbo.�����������������;
DROP TABLE dbo.���������������������;
DROP TABLE dbo.��������;

--- �������� ������� -- ������������� �����
------------------------------------------------------------------------------------------------------
---------------------- �������� ����� ������ ��� �����!!!! ����������!!!!!
------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[������������������](
	[���������������������] [int] NOT NULL,
	[����������] [float] NOT NULL,
	[�����������] [float] NOT NULL,
	[���������] [int] NOT NULL,
	[�������������������] [float] NOT NULL,
	[�����������������] [float] NOT NULL,
 CONSTRAINT [PK_������������������] PRIMARY KEY CLUSTERED ([���������������������]));
GO

ALTER TABLE [dbo].[������������������]  WITH CHECK ADD CONSTRAINT [FK_������������������_���������] FOREIGN KEY([���������])
REFERENCES [dbo].[���������] ([�������������]);
GO

ALTER TABLE [dbo].[������������������] CHECK CONSTRAINT [FK_������������������_���������];
GO

---- ������� �������������� ������ � ������� -- ������� ������������� �����
INSERT INTO [dbo].[������������������](
	[���������������������],
	[����������],
	[�����������],
	[���������],
	[�������������������],
	[�����������������])
     VALUES (1, 0.7, 16.9, 1, 1.2, 12.7);
GO


--- �������� ������� -- ����������� ������
------------------------------------------------------------------------------------------------------
---------------------- �������� ����� ������ ��� ������������ �������!!!!
------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[�����������������](
	[����������������������] [int] NOT NULL,
	[���������������] [int] NOT NULL,
	[��������������������������] [int] NOT NULL,
	[�����������������������] [int] NOT NULL,
	[�������������������������������] [nvarchar](max) NOT NULL,
	[������������������������] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_�����������������] PRIMARY KEY CLUSTERED 
(
	[����������������������] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[�����������������]  WITH CHECK ADD  CONSTRAINT [FK_�����������������_������������������] FOREIGN KEY([���������������])
REFERENCES [dbo].[������������������] ([���������������������])
GO

ALTER TABLE [dbo].[�����������������] CHECK CONSTRAINT [FK_�����������������_������������������]
GO

ALTER TABLE [dbo].[�����������������]  WITH CHECK ADD  CONSTRAINT [FK_�����������������_����������������] FOREIGN KEY([�����������������������])
REFERENCES [dbo].[����������������] ([�������������������])
GO

ALTER TABLE [dbo].[�����������������] CHECK CONSTRAINT [FK_�����������������_����������������]
GO

ALTER TABLE [dbo].[�����������������]  WITH CHECK ADD  CONSTRAINT [FK_�����������������_����������������������] FOREIGN KEY([��������������������������])
REFERENCES [dbo].[����������������������] ([��������������������������]);
GO

ALTER TABLE [dbo].[�����������������] CHECK CONSTRAINT [FK_�����������������_����������������������];
GO

---- ������� �������������� ������ � ������� -- ����������� ������
INSERT INTO	[dbo].[�����������������](
					[����������������������],
					[���������������],
					[��������������������������],
					[�����������������������],
					[�������������������������������],
					[������������������������]) 
		VALUES(1, 1, 1, 2, '���-28', '�. �����, ��. ����������, 27');
GO

---- �������� ������� -- ��������������� ������ 
------------------------------------------------------------------------------------------------------
---------------------- �������� ����� ������ ��� ���������������� �������!!!!
------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[���������������������](
	[��������������������������] [int] NOT NULL,
	[�����������������������������������] [nvarchar](50) NOT NULL,
	[������������������������������] [int] NOT NULL,
 CONSTRAINT [PK_��������������������������] PRIMARY KEY ([��������������������������]))
GO

---- ������� �������������� ������ � ������� -- ��������������� �������
INSERT INTO [dbo].[���������������������] ([��������������������������],[�����������������������������������],[������������������������������]) VALUES(1,'����������� ����', 3);
GO

---- �������� ������� -- ��������
CREATE TABLE [dbo].[��������](
	[������������] [int] NOT NULL,
	[�������] [int] NULL,
	[����] [datetime] NULL,
	[�������������] [datetime] NULL,
	CONSTRAINT [PK_������������] PRIMARY KEY ([������������]));
GO

------------------------------------------------------------------------------------------------------
----- �������� ��������� ��������� ������� -----------------------------------------------------------
	--[������������] [int] NOT NULL,
	--[������������������������] [datetime2](7) NOT NULL,
	--[�������] [int] NOT NULL,
	--[����������] [int] NULL,
	--[��������] [int] NOT NULL,
	--[��������������������������] [int] NULL,
	--[����������] [nvarchar](max) NULL
------------------------------------------------------------------------------------------------------

---- ������� �������������� ������ � ������� -- �������� 
---------------------- �������� ������ ��� �������!!!!
INSERT INTO [dbo].[��������]([�������],[����],[�������������]) VALUES ();
GO

