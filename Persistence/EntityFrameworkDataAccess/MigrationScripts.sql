
--script-migration -idempotent
USE MOIS
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [ClearanceReason] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ClearanceReason] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Currencies] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Currencies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [EligibleNID] (
        [Id] int NOT NULL IDENTITY,
        [HashedNID] nvarchar(64) NOT NULL,
        [InsertedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_EligibleNID] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [ForeignContractorType] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ForeignContractorType] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [ForeignContractType] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ForeignContractType] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Gender] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Gender] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [GovernmentalEstablishmentType] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_GovernmentalEstablishmentType] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Governorate] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [PostDeliveryDays] int NULL,
        CONSTRAINT [PK_Governorate] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Issuer] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [PackageExpiryInHours] int NOT NULL,
        [PackageDescription] nvarchar(500) NOT NULL,
        [Phone] nvarchar(20) NOT NULL,
        [ReplyPeriod] int NOT NULL,
        [HomePageUrl] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Issuer] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Job] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Job] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [JobTypeNID] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_JobTypeNID] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [JobTypeWorkPermit] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_JobTypeWorkPermit] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Ministry] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Ministry] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [NidIssueReason] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_NidIssueReason] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [OrderStatus] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_OrderStatus] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PassportIssuer] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_PassportIssuer] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PaymentMethod] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_PaymentMethod] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [QualificationType] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_QualificationType] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Region] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Region] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [RejectionReason] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_RejectionReason] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Relation] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Relation] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [RequestEFinance] (
        [Id] int NOT NULL IDENTITY,
        [SenderId] nvarchar(50) NULL,
        [SenderName] nvarchar(50) NULL,
        [SenderRandomValue] nvarchar(100) NULL,
        [SenderPassword] nvarchar(100) NULL,
        [SenderRequestNumber] nvarchar(50) NULL,
        [PaymentRequestNumber] nvarchar(50) NULL,
        [PaymentRequestTotalAmount] DECIMAL(15, 5) NULL,
        [CollectionFeesAmount] DECIMAL(15, 5) NULL,
        [CustomerAuthorizationAmount] DECIMAL(15, 5) NULL,
        [AuthorizingMechanism] nvarchar(20) NULL,
        [AuthoriztionDateTime] datetime2 NULL,
        [ReconciliationDate] datetime2 NULL,
        [IsConfirmed] bit NULL,
        CONSTRAINT [PK_RequestEFinance] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [RequestPostal] (
        [Id] int NOT NULL IDENTITY,
        [Message] nvarchar(100) NOT NULL,
        [ItemCode] nvarchar(20) NOT NULL,
        [ErrorCode] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_RequestPostal] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [ReturnReason] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ReturnReason] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [State] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(100) NOT NULL,
        [Name] nvarchar(2048) NOT NULL,
        CONSTRAINT [PK_State] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(255) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [VacationType] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_VacationType] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [WorkPermitIssueReason] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_WorkPermitIssueReason] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [GovernmentalEstablishment] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [GovernmentalEstablishmentTypeId] int NULL,
        CONSTRAINT [PK_GovernmentalEstablishment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GovernmentalEstablishment_GovernmentalEstablishmentType_GovernmentalEstablishmentTypeId] FOREIGN KEY ([GovernmentalEstablishmentTypeId]) REFERENCES [GovernmentalEstablishmentType] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PoliceDepartment] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [GovernorateId] int NOT NULL,
        CONSTRAINT [PK_PoliceDepartment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PoliceDepartment_Governorate_GovernorateId] FOREIGN KEY ([GovernorateId]) REFERENCES [Governorate] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Unit] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Address] nvarchar(200) NOT NULL,
        [GovernorateId] int NOT NULL,
        CONSTRAINT [PK_Unit] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Unit_Governorate_GovernorateId] FOREIGN KEY ([GovernorateId]) REFERENCES [Governorate] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [DocumentType] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [MaxCopies] int NOT NULL,
        [Price] DECIMAL(15, 5) NOT NULL,
        [MaxBeneficiaries] int NOT NULL,
        [CanBeBundled] bit NOT NULL,
        [IsInstantApproval] bit NOT NULL,
        [Agreement] nvarchar(max) NOT NULL,
        [IssuerId] int NOT NULL,
        CONSTRAINT [PK_DocumentType] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DocumentType_Issuer_IssuerId] FOREIGN KEY ([IssuerId]) REFERENCES [Issuer] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [RequestFawry] (
        [Id] int NOT NULL IDENTITY,
        [FawryRefNo] nvarchar(20) NULL,
        [FawryPaymentMethod] nvarchar(20) NULL,
        [OrderStatusId] int NULL,
        [OrderAmount] DECIMAL(15, 5) NULL,
        [MessageSignature] nvarchar(64) NULL,
        [Notes] nvarchar(500) NULL,
        CONSTRAINT [PK_RequestFawry] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RequestFawry_OrderStatus_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatus] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Qualification] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [QualificationTypeId] int NULL,
        CONSTRAINT [PK_Qualification] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Qualification_QualificationType_QualificationTypeId] FOREIGN KEY ([QualificationTypeId]) REFERENCES [QualificationType] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Country] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [RegionId] int NULL,
        [SortOrder] int NOT NULL,
        CONSTRAINT [PK_Country] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Country_Region_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Region] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [UserRoles] (
        [UserId] int NOT NULL,
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_UserRoles] PRIMARY KEY ([RoleId], [UserId]),
        CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PublicSector] (
        [Id] int NOT NULL IDENTITY,
        [GovernmentalEstablishmentId] int NULL,
        [VacationTypeId] int NOT NULL,
        [VacationStart] datetime2 NOT NULL,
        [VacationEnd] datetime2 NOT NULL,
        [VacationApprovedYears] int NOT NULL,
        CONSTRAINT [PK_PublicSector] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PublicSector_GovernmentalEstablishment_GovernmentalEstablishmentId] FOREIGN KEY ([GovernmentalEstablishmentId]) REFERENCES [GovernmentalEstablishment] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PublicSector_VacationType_VacationTypeId] FOREIGN KEY ([VacationTypeId]) REFERENCES [VacationType] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PostalCode] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Address] nvarchar(200) NOT NULL,
        [PoliceDepartmentId] int NULL,
        [GovernorateId] int NOT NULL,
        CONSTRAINT [PK_PostalCode] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PostalCode_Governorate_GovernorateId] FOREIGN KEY ([GovernorateId]) REFERENCES [Governorate] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PostalCode_PoliceDepartment_PoliceDepartmentId] FOREIGN KEY ([PoliceDepartmentId]) REFERENCES [PoliceDepartment] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [DocumentTypeRelations] (
        [DocumentTypeId] int NOT NULL,
        [RelationId] int NOT NULL,
        [GenderId] int NOT NULL,
        CONSTRAINT [PK_DocumentTypeRelations] PRIMARY KEY ([DocumentTypeId], [RelationId], [GenderId]),
        CONSTRAINT [FK_DocumentTypeRelations_DocumentType_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentType] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DocumentTypeRelations_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DocumentTypeRelations_Relation_RelationId] FOREIGN KEY ([RelationId]) REFERENCES [Relation] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Regulation] (
        [DocumentTypeId] int NOT NULL,
        [JobTypeNIDId] int NOT NULL,
        [Regulations] nvarchar(max) NULL,
        CONSTRAINT [PK_Regulation] PRIMARY KEY ([DocumentTypeId], [JobTypeNIDId]),
        CONSTRAINT [FK_Regulation_DocumentType_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentType] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Regulation_JobTypeNID_JobTypeNIDId] FOREIGN KEY ([JobTypeNIDId]) REFERENCES [JobTypeNID] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [ForeignContractor] (
        [Id] int NOT NULL IDENTITY,
        [ContractorCountryId] int NOT NULL,
        [ContractorName] nvarchar(100) NOT NULL,
        [ContractorTypeId] int NOT NULL,
        [ContractorActivity] nvarchar(100) NOT NULL,
        [ContractorJobName] nvarchar(100) NOT NULL,
        [ContractTypeId] int NOT NULL,
        [YearsToRenew] int NOT NULL,
        [WorkPlaceIsOnShips] bit NOT NULL,
        [VisaNoOrAccomodationNo] nvarchar(max) NULL,
        [CurrencyId] int NOT NULL,
        [Salary] DECIMAL(15, 5) NOT NULL,
        [AddressCountryId] int NOT NULL,
        [AddressCity] nvarchar(100) NOT NULL,
        [AddressDistrict] nvarchar(100) NOT NULL,
        [AddressStreet] nvarchar(100) NOT NULL,
        [AddressBuilding] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_ForeignContractor] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ForeignContractor_Country_AddressCountryId] FOREIGN KEY ([AddressCountryId]) REFERENCES [Country] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ForeignContractor_ForeignContractType_ContractTypeId] FOREIGN KEY ([ContractTypeId]) REFERENCES [ForeignContractType] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ForeignContractor_Country_ContractorCountryId] FOREIGN KEY ([ContractorCountryId]) REFERENCES [Country] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ForeignContractor_ForeignContractorType_ContractorTypeId] FOREIGN KEY ([ContractorTypeId]) REFERENCES [ForeignContractorType] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ForeignContractor_Currencies_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [Currencies] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Passport] (
        [Id] int NOT NULL IDENTITY,
        [PassportNumber] nvarchar(50) NOT NULL,
        [PassportIssueDate] datetime2 NOT NULL,
        [PassportIssueCountryId] int NOT NULL,
        [JobInPassportId] int NOT NULL,
        [LastLeaveDate] datetime2 NOT NULL,
        [LastReturnDate] datetime2 NOT NULL,
        [PassportIssuerId] int NULL,
        CONSTRAINT [PK_Passport] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Passport_Job_JobInPassportId] FOREIGN KEY ([JobInPassportId]) REFERENCES [Job] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Passport_Country_PassportIssueCountryId] FOREIGN KEY ([PassportIssueCountryId]) REFERENCES [Country] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Passport_PassportIssuer_PassportIssuerId] FOREIGN KEY ([PassportIssuerId]) REFERENCES [PassportIssuer] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Address] (
        [Id] int NOT NULL IDENTITY,
        [FlatNumber] int NOT NULL,
        [FloorNumber] int NOT NULL,
        [BuildingNumber] nvarchar(20) NOT NULL,
        [StreetName] nvarchar(50) NOT NULL,
        [DistrictName] nvarchar(50) NOT NULL,
        [GovernorateId] int NOT NULL,
        [PoliceDepartmentId] int NOT NULL,
        [PostalCodeId] int NOT NULL,
        CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Address_Governorate_GovernorateId] FOREIGN KEY ([GovernorateId]) REFERENCES [Governorate] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Address_PoliceDepartment_PoliceDepartmentId] FOREIGN KEY ([PoliceDepartmentId]) REFERENCES [PoliceDepartment] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Address_PostalCode_PostalCodeId] FOREIGN KEY ([PostalCodeId]) REFERENCES [PostalCode] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [Requests] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(20) NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [MotherFullName] nvarchar(100) NOT NULL,
        [GenderId] int NOT NULL,
        [NID] nvarchar(14) NOT NULL,
        [ContactDetails_Mobile1] nvarchar(20) NOT NULL,
        [ContactDetails_Mobile2] nvarchar(20) NULL,
        [ContactDetails_PhoneHome] nvarchar(20) NULL,
        [ContactDetails_PhoneWork] nvarchar(20) NULL,
        [ContactDetails_Email] nvarchar(50) NOT NULL,
        [ResidencyAddressId] int NOT NULL,
        [DeliveryAddressId] int NOT NULL,
        [PaymentMethodId] int NULL,
        [IssuerId] int NOT NULL,
        CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Requests_Address_DeliveryAddressId] FOREIGN KEY ([DeliveryAddressId]) REFERENCES [Address] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Requests_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Requests_Issuer_IssuerId] FOREIGN KEY ([IssuerId]) REFERENCES [Issuer] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Requests_PaymentMethod_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethod] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Requests_Address_ResidencyAddressId] FOREIGN KEY ([ResidencyAddressId]) REFERENCES [Address] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [BirthDocs] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [GenderId] int NOT NULL,
        [NID] nchar(14) NOT NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [MotherFullName] nvarchar(100) NOT NULL,
        [RelationId] int NOT NULL,
        [IsFirstTime] bit NOT NULL,
        CONSTRAINT [PK_BirthDocs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BirthDocs_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BirthDocs_Relation_RelationId] FOREIGN KEY ([RelationId]) REFERENCES [Relation] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BirthDocs_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BirthDocs_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [CriminalStateRecords] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [IssueDestination] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_CriminalStateRecords] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CriminalStateRecords_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_CriminalStateRecords_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [DeathDocs] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [GenderId] int NOT NULL,
        [NID] nchar(14) NOT NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [MotherFullName] nvarchar(100) NOT NULL,
        [RelationId] int NOT NULL,
        CONSTRAINT [PK_DeathDocs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DeathDocs_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DeathDocs_Relation_RelationId] FOREIGN KEY ([RelationId]) REFERENCES [Relation] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DeathDocs_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DeathDocs_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [DivorceDocs] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [NID] nchar(14) NOT NULL,
        [SpouseFullName] nvarchar(100) NOT NULL,
        [RelationId] int NOT NULL,
        CONSTRAINT [PK_DivorceDocs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DivorceDocs_Relation_RelationId] FOREIGN KEY ([RelationId]) REFERENCES [Relation] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DivorceDocs_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DivorceDocs_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [FamilyRecords] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [GenderId] int NOT NULL,
        [NID] nvarchar(14) NOT NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [MotherFullName] nvarchar(100) NOT NULL,
        [RelationId] int NOT NULL,
        CONSTRAINT [PK_FamilyRecords] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FamilyRecords_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_FamilyRecords_Relation_RelationId] FOREIGN KEY ([RelationId]) REFERENCES [Relation] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_FamilyRecords_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_FamilyRecords_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [MarriageDocs] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [NID] nchar(14) NOT NULL,
        [SpouseFullName] nvarchar(100) NOT NULL,
        [RelationId] int NOT NULL,
        CONSTRAINT [PK_MarriageDocs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MarriageDocs_Relation_RelationId] FOREIGN KEY ([RelationId]) REFERENCES [Relation] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_MarriageDocs_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_MarriageDocs_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [NidDocs] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [FirstName] nvarchar(20) NOT NULL,
        [FatherName] nvarchar(20) NOT NULL,
        [GrandFatherName] nvarchar(20) NOT NULL,
        [FamilyName] nvarchar(20) NOT NULL,
        [NidIssueReasonId] int NOT NULL,
        [JobTypeNIDId] int NOT NULL,
        [JobName] nvarchar(100) NOT NULL,
        [IsFirstTime] bit NOT NULL,
        CONSTRAINT [PK_NidDocs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NidDocs_JobTypeNID_JobTypeNIDId] FOREIGN KEY ([JobTypeNIDId]) REFERENCES [JobTypeNID] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_NidDocs_NidIssueReason_NidIssueReasonId] FOREIGN KEY ([NidIssueReasonId]) REFERENCES [NidIssueReason] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_NidDocs_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_NidDocs_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PaymentDetails] (
        [Id] int NOT NULL IDENTITY,
        [RequestId] int NOT NULL,
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Quantity] int NOT NULL,
        [Price] DECIMAL(15, 5) NOT NULL,
        [Notes] nvarchar(500) NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_PaymentDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PaymentDetails_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [PersonalRecords] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        CONSTRAINT [PK_PersonalRecords] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PersonalRecords_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PersonalRecords_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [RequestState] (
        [Id] int NOT NULL IDENTITY,
        [RequestId] int NOT NULL,
        [StateId] int NOT NULL,
        [RejectionReasonId] int NULL,
        [ReturnReasonId] int NULL,
        [RequestFawryId] int NULL,
        [RequestEFinanceId] int NULL,
        [RequestPostalId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        CONSTRAINT [PK_RequestState] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RequestState_RejectionReason_RejectionReasonId] FOREIGN KEY ([RejectionReasonId]) REFERENCES [RejectionReason] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RequestState_RequestEFinance_RequestEFinanceId] FOREIGN KEY ([RequestEFinanceId]) REFERENCES [RequestEFinance] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RequestState_RequestFawry_RequestFawryId] FOREIGN KEY ([RequestFawryId]) REFERENCES [RequestFawry] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RequestState_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RequestState_RequestPostal_RequestPostalId] FOREIGN KEY ([RequestPostalId]) REFERENCES [RequestPostal] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RequestState_ReturnReason_ReturnReasonId] FOREIGN KEY ([ReturnReasonId]) REFERENCES [ReturnReason] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_RequestState_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [WorkPermitClearanceaa] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [PassportId] int NOT NULL,
        [LastPermitFinishDate] datetime2 NOT NULL,
        [ClearanceDestination] nvarchar(100) NOT NULL,
        [ClearanceReasonId] int NOT NULL,
        [NidFileName] nvarchar(100) NOT NULL,
        [PassportFileName] nvarchar(100) NOT NULL,
        [PreviousPermitFileName] nvarchar(100) NOT NULL,
        [VisaFileName] nvarchar(100) NOT NULL,
        [RenewDirectedLetterFileName] nvarchar(100) NULL,
        [NavyAgentCertFileName] nvarchar(100) NULL,
        CONSTRAINT [PK_WorkPermitClearanceaa] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_WorkPermitClearanceaa_ClearanceReason_ClearanceReasonId] FOREIGN KEY ([ClearanceReasonId]) REFERENCES [ClearanceReason] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitClearanceaa_Passport_PassportId] FOREIGN KEY ([PassportId]) REFERENCES [Passport] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitClearanceaa_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitClearanceaa_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [WorkPermitRenews] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [BirthPlaceId] int NOT NULL,
        [QualificationId] int NOT NULL,
        [QualificationDate] datetime2 NOT NULL,
        [JobTypeWorkPermitId] int NOT NULL,
        [JobNameInEgypt] nvarchar(100) NOT NULL,
        [WorkPermitIssueReasonId] int NOT NULL,
        [PassportId] int NOT NULL,
        [ForeignContractorId] int NULL,
        [PublicSectorId] int NULL,
        [NidFileName] nvarchar(100) NOT NULL,
        [PassportFileName] nvarchar(100) NOT NULL,
        [PreviousPermitFileName] nvarchar(100) NULL,
        [VisaFileName] nvarchar(100) NOT NULL,
        [VacationPermitFileName] nvarchar(100) NULL,
        [NavyAgentCertFileName] nvarchar(100) NULL,
        [NavyPassportFileName] nvarchar(100) NULL,
        CONSTRAINT [PK_WorkPermitRenews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_WorkPermitRenews_Country_BirthPlaceId] FOREIGN KEY ([BirthPlaceId]) REFERENCES [Country] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_ForeignContractor_ForeignContractorId] FOREIGN KEY ([ForeignContractorId]) REFERENCES [ForeignContractor] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_JobTypeWorkPermit_JobTypeWorkPermitId] FOREIGN KEY ([JobTypeWorkPermitId]) REFERENCES [JobTypeWorkPermit] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_Passport_PassportId] FOREIGN KEY ([PassportId]) REFERENCES [Passport] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_PublicSector_PublicSectorId] FOREIGN KEY ([PublicSectorId]) REFERENCES [PublicSector] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_Qualification_QualificationId] FOREIGN KEY ([QualificationId]) REFERENCES [Qualification] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitRenews_WorkPermitIssueReason_WorkPermitIssueReasonId] FOREIGN KEY ([WorkPermitIssueReasonId]) REFERENCES [WorkPermitIssueReason] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE TABLE [WorkPermitReplaces] (
        [Id] int NOT NULL IDENTITY,
        [NumberOfCopies] int NOT NULL,
        [RequestId] int NOT NULL,
        [StateId] int NULL,
        [IPAddress] nvarchar(max) NULL,
        [InsertedDate] datetime2 NOT NULL,
        [LastEditDate] datetime2 NULL,
        [BirthPlaceId] int NOT NULL,
        [QualificationId] int NOT NULL,
        [QualificationDate] datetime2 NOT NULL,
        [JobTypeWorkPermitId] int NOT NULL,
        [JobNameInEgypt] nvarchar(100) NOT NULL,
        [WorkPermitIssueReasonId] int NOT NULL,
        [PassportId] int NOT NULL,
        [ForeignContractorId] int NULL,
        [PublicSectorId] int NULL,
        [NidFileName] nvarchar(100) NOT NULL,
        [PassportFileName] nvarchar(100) NOT NULL,
        [PreviousPermitFileName] nvarchar(100) NULL,
        [VisaFileName] nvarchar(100) NOT NULL,
        [VacationPermitFileName] nvarchar(100) NULL,
        [NavyAgentCertFileName] nvarchar(100) NULL,
        [NavyPassportFileName] nvarchar(100) NULL,
        [IssuingGovernorateId] int NULL,
        [IssuingUnitId] int NULL,
        CONSTRAINT [PK_WorkPermitReplaces] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_WorkPermitReplaces_Country_BirthPlaceId] FOREIGN KEY ([BirthPlaceId]) REFERENCES [Country] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_ForeignContractor_ForeignContractorId] FOREIGN KEY ([ForeignContractorId]) REFERENCES [ForeignContractor] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_Governorate_IssuingGovernorateId] FOREIGN KEY ([IssuingGovernorateId]) REFERENCES [Governorate] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_Unit_IssuingUnitId] FOREIGN KEY ([IssuingUnitId]) REFERENCES [Unit] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_JobTypeWorkPermit_JobTypeWorkPermitId] FOREIGN KEY ([JobTypeWorkPermitId]) REFERENCES [JobTypeWorkPermit] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_Passport_PassportId] FOREIGN KEY ([PassportId]) REFERENCES [Passport] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_PublicSector_PublicSectorId] FOREIGN KEY ([PublicSectorId]) REFERENCES [PublicSector] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_Qualification_QualificationId] FOREIGN KEY ([QualificationId]) REFERENCES [Qualification] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_WorkPermitReplaces_WorkPermitIssueReason_WorkPermitIssueReasonId] FOREIGN KEY ([WorkPermitIssueReasonId]) REFERENCES [WorkPermitIssueReason] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Address_GovernorateId] ON [Address] ([GovernorateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Address_PoliceDepartmentId] ON [Address] ([PoliceDepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Address_PostalCodeId] ON [Address] ([PostalCodeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_BirthDocs_GenderId] ON [BirthDocs] ([GenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_BirthDocs_RelationId] ON [BirthDocs] ([RelationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_BirthDocs_RequestId] ON [BirthDocs] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_BirthDocs_StateId] ON [BirthDocs] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Country_RegionId] ON [Country] ([RegionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_CriminalStateRecords_RequestId] ON [CriminalStateRecords] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_CriminalStateRecords_StateId] ON [CriminalStateRecords] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DeathDocs_GenderId] ON [DeathDocs] ([GenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DeathDocs_RelationId] ON [DeathDocs] ([RelationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DeathDocs_RequestId] ON [DeathDocs] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DeathDocs_StateId] ON [DeathDocs] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DivorceDocs_RelationId] ON [DivorceDocs] ([RelationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DivorceDocs_RequestId] ON [DivorceDocs] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DivorceDocs_StateId] ON [DivorceDocs] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DocumentType_IssuerId] ON [DocumentType] ([IssuerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DocumentTypeRelations_GenderId] ON [DocumentTypeRelations] ([GenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_DocumentTypeRelations_RelationId] ON [DocumentTypeRelations] ([RelationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_FamilyRecords_GenderId] ON [FamilyRecords] ([GenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_FamilyRecords_RelationId] ON [FamilyRecords] ([RelationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_FamilyRecords_RequestId] ON [FamilyRecords] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_FamilyRecords_StateId] ON [FamilyRecords] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_ForeignContractor_AddressCountryId] ON [ForeignContractor] ([AddressCountryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_ForeignContractor_ContractTypeId] ON [ForeignContractor] ([ContractTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_ForeignContractor_ContractorCountryId] ON [ForeignContractor] ([ContractorCountryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_ForeignContractor_ContractorTypeId] ON [ForeignContractor] ([ContractorTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_ForeignContractor_CurrencyId] ON [ForeignContractor] ([CurrencyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_GovernmentalEstablishment_GovernmentalEstablishmentTypeId] ON [GovernmentalEstablishment] ([GovernmentalEstablishmentTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_MarriageDocs_RelationId] ON [MarriageDocs] ([RelationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_MarriageDocs_RequestId] ON [MarriageDocs] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_MarriageDocs_StateId] ON [MarriageDocs] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_NidDocs_JobTypeNIDId] ON [NidDocs] ([JobTypeNIDId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_NidDocs_NidIssueReasonId] ON [NidDocs] ([NidIssueReasonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_NidDocs_RequestId] ON [NidDocs] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_NidDocs_StateId] ON [NidDocs] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Passport_JobInPassportId] ON [Passport] ([JobInPassportId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Passport_PassportIssueCountryId] ON [Passport] ([PassportIssueCountryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Passport_PassportIssuerId] ON [Passport] ([PassportIssuerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PaymentDetails_RequestId] ON [PaymentDetails] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PersonalRecords_RequestId] ON [PersonalRecords] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PersonalRecords_StateId] ON [PersonalRecords] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PoliceDepartment_GovernorateId] ON [PoliceDepartment] ([GovernorateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PostalCode_GovernorateId] ON [PostalCode] ([GovernorateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PostalCode_PoliceDepartmentId] ON [PostalCode] ([PoliceDepartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PublicSector_GovernmentalEstablishmentId] ON [PublicSector] ([GovernmentalEstablishmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_PublicSector_VacationTypeId] ON [PublicSector] ([VacationTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Qualification_QualificationTypeId] ON [Qualification] ([QualificationTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Regulation_JobTypeNIDId] ON [Regulation] ([JobTypeNIDId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_RequestFawry_OrderStatusId] ON [RequestFawry] ([OrderStatusId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Requests_DeliveryAddressId] ON [Requests] ([DeliveryAddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Requests_GenderId] ON [Requests] ([GenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Requests_IssuerId] ON [Requests] ([IssuerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Requests_PaymentMethodId] ON [Requests] ([PaymentMethodId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Requests_ResidencyAddressId] ON [Requests] ([ResidencyAddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_RequestState_RejectionReasonId] ON [RequestState] ([RejectionReasonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_RequestState_RequestEFinanceId] ON [RequestState] ([RequestEFinanceId]) WHERE [RequestEFinanceId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_RequestState_RequestFawryId] ON [RequestState] ([RequestFawryId]) WHERE [RequestFawryId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_RequestState_RequestId] ON [RequestState] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_RequestState_RequestPostalId] ON [RequestState] ([RequestPostalId]) WHERE [RequestPostalId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_RequestState_ReturnReasonId] ON [RequestState] ([ReturnReasonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_RequestState_StateId] ON [RequestState] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_Unit_GovernorateId] ON [Unit] ([GovernorateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_UserRoles_UserId] ON [UserRoles] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitClearanceaa_ClearanceReasonId] ON [WorkPermitClearanceaa] ([ClearanceReasonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitClearanceaa_PassportId] ON [WorkPermitClearanceaa] ([PassportId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitClearanceaa_RequestId] ON [WorkPermitClearanceaa] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitClearanceaa_StateId] ON [WorkPermitClearanceaa] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_BirthPlaceId] ON [WorkPermitRenews] ([BirthPlaceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_ForeignContractorId] ON [WorkPermitRenews] ([ForeignContractorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_JobTypeWorkPermitId] ON [WorkPermitRenews] ([JobTypeWorkPermitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_PassportId] ON [WorkPermitRenews] ([PassportId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_PublicSectorId] ON [WorkPermitRenews] ([PublicSectorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_QualificationId] ON [WorkPermitRenews] ([QualificationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_RequestId] ON [WorkPermitRenews] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_StateId] ON [WorkPermitRenews] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitRenews_WorkPermitIssueReasonId] ON [WorkPermitRenews] ([WorkPermitIssueReasonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_BirthPlaceId] ON [WorkPermitReplaces] ([BirthPlaceId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_ForeignContractorId] ON [WorkPermitReplaces] ([ForeignContractorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_IssuingGovernorateId] ON [WorkPermitReplaces] ([IssuingGovernorateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_IssuingUnitId] ON [WorkPermitReplaces] ([IssuingUnitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_JobTypeWorkPermitId] ON [WorkPermitReplaces] ([JobTypeWorkPermitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_PassportId] ON [WorkPermitReplaces] ([PassportId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_PublicSectorId] ON [WorkPermitReplaces] ([PublicSectorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_QualificationId] ON [WorkPermitReplaces] ([QualificationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_RequestId] ON [WorkPermitReplaces] ([RequestId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_StateId] ON [WorkPermitReplaces] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    CREATE INDEX [IX_WorkPermitReplaces_WorkPermitIssueReasonId] ON [WorkPermitReplaces] ([WorkPermitIssueReasonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627135019_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190627135019_Initial', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[NidDocs]') AND [c].[name] = N'NumberOfCopies');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [NidDocs] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [NidDocs] ALTER COLUMN [NumberOfCopies] int NOT NULL;
    ALTER TABLE [NidDocs] ADD DEFAULT 1 FOR [NumberOfCopies];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MarriageDocs]') AND [c].[name] = N'NumberOfCopies');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [MarriageDocs] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [MarriageDocs] ALTER COLUMN [NumberOfCopies] int NOT NULL;
    ALTER TABLE [MarriageDocs] ADD DEFAULT 1 FOR [NumberOfCopies];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DivorceDocs]') AND [c].[name] = N'NumberOfCopies');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [DivorceDocs] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [DivorceDocs] ALTER COLUMN [NumberOfCopies] int NOT NULL;
    ALTER TABLE [DivorceDocs] ADD DEFAULT 1 FOR [NumberOfCopies];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DeathDocs]') AND [c].[name] = N'NumberOfCopies');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [DeathDocs] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [DeathDocs] ALTER COLUMN [NumberOfCopies] int NOT NULL;
    ALTER TABLE [DeathDocs] ADD DEFAULT 1 FOR [NumberOfCopies];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BirthDocs]') AND [c].[name] = N'NumberOfCopies');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [BirthDocs] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [BirthDocs] ALTER COLUMN [NumberOfCopies] int NOT NULL;
    ALTER TABLE [BirthDocs] ADD DEFAULT 1 FOR [NumberOfCopies];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190627140119_MakingNumberOfCopiesDefaultValueEqualOne', N'2.2.4-servicing-10062');
END;

GO

