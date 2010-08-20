
begin transaction
save transaction schema_generator
	-- statement #1
	if exists (select 1
				from   sys.objects
				where  object_id = OBJECT_ID(N'[FK436E233072081177]')
						AND parent_object_id = OBJECT_ID('[Child]'))
	alter table [Child]
	drop constraint FK436E233072081177
	
	-- statement #2
	if exists (select 1
			   from   sys.objects
			   where  object_id = OBJECT_ID(N'[FK436E233072081177]')
					  AND parent_object_id = OBJECT_ID('[Child]'))
	  alter table [Child]
	  drop constraint FK436E233072081177
	-- statement #3
	if exists (select *
			   from   dbo.sysobjects
			   where  id = object_id(N'[Child]')
					  and OBJECTPROPERTY(id,
										 N'IsUserTable') = 1)
	  drop table [Child]

	-- statement #4
	if exists (select *
			   from   dbo.sysobjects
			   where  id = object_id(N'[Child]')
					  and OBJECTPROPERTY(id,
										 N'IsUserTable') = 1)
	  drop table [Child]

	-- statement #5
	if exists (select *
			   from   dbo.sysobjects
			   where  id = object_id(N'[MySagaData]')
					  and OBJECTPROPERTY(id,
										 N'IsUserTable') = 1)
	  drop table [MySagaData]

	-- statement #6
	if exists (select *
			   from   dbo.sysobjects
			   where  id = object_id(N'[MySagaData]')
					  and OBJECTPROPERTY(id,
										 N'IsUserTable') = 1)
	  drop table [MySagaData]

	-- statement #7
	create table [Child] (
	  InternalId    INT   IDENTITY   NOT NULL,
	  Foo           INT   null,
	  Bar           NVARCHAR(255)   null,
	  SomeProcessId UNIQUEIDENTIFIER   null,
		primary key ( InternalId ))

	-- statement #8
	create table [Child] (
	  InternalId    INT   IDENTITY   NOT NULL,
	  Foo           INT   null,
	  Bar           NVARCHAR(255)   null,
	  SomeProcessId UNIQUEIDENTIFIER   null,
		primary key ( InternalId ))

	-- statement #9
	create table [MySagaData] (
	  Id                UNIQUEIDENTIFIER   not null,
	  OriginalMessageId NVARCHAR(255)   null,
	  Originator        NVARCHAR(255)   null,
	  SomeProcessId     INT   null,
	  BeginDate         DATETIME   null,
	  CompletionMessage NVARCHAR(255)   null,
		primary key ( Id ))

	-- statement #10
	create table [MySagaData] (
	  Id                UNIQUEIDENTIFIER   not null,
	  OriginalMessageId NVARCHAR(255)   null,
	  Originator        NVARCHAR(255)   null,
	  SomeProcessId     INT   null,
	  BeginDate         DATETIME   null,
	  CompletionMessage NVARCHAR(255)   null,
		primary key ( Id ))

	-- statement #11
	alter table [Child]
	 add constraint FK436E233072081177 foreign key ( SomeProcessId ) references [MySagaData]

	-- statement #12
	alter table [Child]
	 add constraint FK436E233072081177 foreign key ( SomeProcessId ) references [MySagaData]

commit transaction