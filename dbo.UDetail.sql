CREATE TABLE [dbo].[UDetail] (
    [FirstName] VARCHAR (50)  NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [UserId]    VARCHAR (50)  NOT NULL,
    [Pwd]       VARCHAR (50)  NOT NULL,
    [Adress]    VARCHAR (MAX) NOT NULL,
    [Mob]       NUMERIC (18)  NOT NULL,
    [Email]     VARCHAR (50)  NOT NULL, 
    [RationCardNo] NUMERIC NOT NULL
);


GO
CREATE TRIGGER Trigger3
ON dbo.UDetail
AFTER INSERT
AS
	print 'in the after trigger'
GO
CREATE TRIGGER xyz
ON dbo.UDetail
after insert 
as
insert dbo.login
(UserName,Pwd)
select UserId,Pwd
from inserted;