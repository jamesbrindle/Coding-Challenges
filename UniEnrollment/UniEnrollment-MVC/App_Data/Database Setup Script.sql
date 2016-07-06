-- Database Setup Script

CREATE TABLE [dbo].[UserType] (
    [ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[User] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [UserTypeID] INT           NOT NULL,
    [Username]   VARCHAR (50)  NOT NULL,
    [Password]   VARCHAR (MAX) NOT NULL,
    [Name]       VARCHAR (100) NOT NULL,
    [Active]     BIT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserType] ([ID])
);

CREATE TABLE [dbo].[Course] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [ProfessorID] INT           NOT NULL,
    [CourseCode]  VARCHAR (20)  NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ProfessorID]) REFERENCES [dbo].[User] ([ID])
);

CREATE TABLE [dbo].[Enrollment] (
    [StudentID]      INT      NOT NULL,
    [CourseID]       INT      NOT NULL,
    [EnrollmentDate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC, [CourseID] ASC),
    FOREIGN KEY ([StudentID]) REFERENCES [dbo].[User] ([ID]),
    FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course] ([ID])
);

INSERT INTO [dbo].UserType ([Name])
VALUES ('Administrator')

INSERT INTO [dbo].UserType ([Name])
VALUES ('Professor')

INSERT INTO [dbo].UserType ([Name])
VALUES ('Student')

INSERT INTO [dbo].[User] (UserTypeID, Username, [Password], Name, Active)
VALUES (1, 'admin', 'VUuEirvL/q/m0xttrhkmSyhhwG34A5jJgCybHIDcQLxGPEc/ewPTqpBOrnoGBsgdMzms/mGZ28sbp5oGHGENRtAJ94ejSuIWdMmOea6KB1eVLiWwwNuAQ/9N1YF/2s2L', 'Administrator', 1)

