
SET IDENTITY_INSERT MOIS..Gender ON
INSERT INTO MOIS..Gender(Id, Code, Name)
SELECT Id, Code, Name From MoiServicesPROD..Gender
SET IDENTITY_INSERT MOIS..Gender OFF 

SET IDENTITY_INSERT MOIS..PaymentMethod ON
INSERT INTO MOIS..PaymentMethod(Id, Code, Name)
SELECT Id, Code, Name From MoiServicesPROD..PaymentMethod
SET IDENTITY_INSERT MOIS..PaymentMethod OFF 

SET IDENTITY_INSERT MOIS..Issuer ON
INSERT INTO MOIS..Issuer(Id, Code, Name, Phone, ReplyPeriod, PackageExpiryInHours, PackageDescription, HomePageUrl)
SELECT Id, Code, Name, Phone, ReplyPeriod, PackageExpiryInHours, PackageDescription, HomePageUrl From MoiServicesPROD..Issuer
SET IDENTITY_INSERT MOIS..Issuer OFF 

SET IDENTITY_INSERT MOIS..DocumentType ON
INSERT INTO MOIS..DocumentType(Id, Code, Name, MaxCopies, Price, MaxBeneficiaries, CanBeBundled, IsInstantApproval, Agreement, IssuerId)
SELECT Id, Code, Name, MaxCopies, Price, MaxBeneficiaries, CanBeBundled, IsInstantApproval, Agreement, IssuerId From MoiServicesPROD..DocumentType
SET IDENTITY_INSERT MOIS..DocumentType OFF 

SET IDENTITY_INSERT MOIS..Governorate ON
INSERT INTO MOIS..Governorate(Id, Code, Name, PostDeliveryDays)
SELECT Id, Code, Name, PostDeliveryDays From MoiServicesPROD..Governorate
SET IDENTITY_INSERT MOIS..Governorate OFF 

SET IDENTITY_INSERT MOIS..PoliceDepartment ON
INSERT INTO MOIS..PoliceDepartment(Id, Code, Name, GovernorateId)
SELECT Id, Code, Name, GovernorateId From MoiServicesPROD..PoliceDepartment
SET IDENTITY_INSERT MOIS..PoliceDepartment OFF 

SET IDENTITY_INSERT MOIS..PostalCode ON
INSERT INTO MOIS..PostalCode(Id, Code, Name, Address, PoliceDepartmentId, GovernorateId)
SELECT Id, Code, Name, Address, PoliceDepartmentId, GovernorateId From MoiServicesPROD..PostalCode
SET IDENTITY_INSERT MOIS..PostalCode OFF
