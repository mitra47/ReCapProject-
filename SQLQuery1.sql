CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT            IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT            IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);


CREATE TABLE [dbo].[Cars] (
    [CarId]       INT            IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT            NULL,
    [ColorId]     INT            NULL,
    [CarName]     NVARCHAR (MAX) NULL,
    [ModelYear]   NVARCHAR (50)  NULL,
    [DailyPrice]  MONEY          NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([CarId] ASC),
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE [dbo].[Users] (
    [UserId]       INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX)  NULL,
    [LastName]     NVARCHAR (MAX)  NULL,
    [Email]        NVARCHAR (MAX)  NULL,
    [PasswordSalt] VARBINARY (MAX) NULL,
    [PasswordHash] VARBINARY (MAX) NULL,
    [Status]       BIT             NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT  IDENTITY (1, 1) NOT NULL,
    [CarId]      INT  NOT NULL,
    [CustomerId] INT  NOT NULL,
    [RentDate]   DATE NOT NULL,
    [ReturnDate] DATE NULL,
    CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [FK_Cars_Rentals] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rentals_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[CarImages] (
    [CarImageId] INT            IDENTITY (1, 1) NOT NULL,
    [CarId]      INT            NULL,
    [ImagePath]  NVARCHAR (MAX) NULL,
    [Date]       DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([CarImageId] ASC),
    CONSTRAINT [FK_CarImages_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]) ON DELETE CASCADE ON UPDATE CASCADE
);
