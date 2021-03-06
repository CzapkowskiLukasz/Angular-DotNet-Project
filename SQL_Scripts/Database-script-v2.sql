-- Generated by Oracle SQL Developer Data Modeler 20.4.0.374.0801
--   at:        2021-11-02 18:16:31 CET
--   site:      SQL Server 2012
--   type:      SQL Server 2012



ALTER TABLE "Order" 
    DROP CONSTRAINT Order_Address_FK 
GO

DROP TABLE UserAddress
GO

ALTER TABLE CartProduct 
    DROP CONSTRAINT CartProduct_Cart_FK 
GO

ALTER TABLE "Order" 
    DROP CONSTRAINT Order_Cart_FK 
GO

ALTER TABLE "User" 
    DROP CONSTRAINT User_Cart_FK 
GO

DROP TABLE Cart
GO

DROP TABLE CartProduct
GO

ALTER TABLE Category 
    DROP CONSTRAINT Category_Category_FK 
GO

ALTER TABLE Product 
    DROP CONSTRAINT Product_Category_FK 
GO

DROP TABLE Category
GO

ALTER TABLE Country 
    DROP CONSTRAINT Country_Continent_FK 
GO

DROP TABLE Continent
GO

ALTER TABLE Product 
    DROP CONSTRAINT Product_Country_FK 
GO

DROP TABLE Country
GO

ALTER TABLE "Order" 
    DROP CONSTRAINT Order_Delivery_FK 
GO

DROP TABLE Delivery
GO

ALTER TABLE DeliveryType 
    DROP CONSTRAINT DeliveryType_DeliveryCompany_FK 
GO

DROP TABLE DeliveryCompany
GO

ALTER TABLE Delivery 
    DROP CONSTRAINT Delivery_DeliveryType_FK 
GO

DROP TABLE DeliveryType
GO

ALTER TABLE ProductDiscount 
    DROP CONSTRAINT TABLE_30_Discount_FK 
GO

DROP TABLE Discount
GO

ALTER TABLE "User" 
    DROP CONSTRAINT User_Language_FK 
GO

DROP TABLE Language
GO

DROP TABLE "Order"
GO

ALTER TABLE "Order" 
    DROP CONSTRAINT Order_OrderStatus_FK 
GO

DROP TABLE OrderStatus
GO

ALTER TABLE "Order" 
    DROP CONSTRAINT Order_PaymentStatus_FK 
GO

DROP TABLE PaymentStatus
GO

ALTER TABLE "Order" 
    DROP CONSTRAINT Order_PaymentType_FK 
GO

DROP TABLE PaymentType
GO

ALTER TABLE CartProduct 
    DROP CONSTRAINT CartProduct_Product_FK 
GO

ALTER TABLE ProductDiscount 
    DROP CONSTRAINT TABLE_30_Product_FK 
GO

DROP TABLE Product
GO

DROP TABLE ProductDiscount
GO

ALTER TABLE "User" 
    DROP CONSTRAINT User_Role_FK 
GO

DROP TABLE Role
GO

ALTER TABLE "User" 
    DROP CONSTRAINT User_Theme_FK 
GO

DROP TABLE Theme
GO

ALTER TABLE "Order" 
    DROP CONSTRAINT Order_User_FK 
GO

ALTER TABLE Voucher 
    DROP CONSTRAINT Voucher_User_FK 
GO

DROP TABLE "User"
GO

DROP TABLE Voucher
GO

CREATE TABLE UserAddress 
    (
     AddressId INTEGER NOT NULL , 
     UserId INTEGER NOT NULL , 
     City VARCHAR (30) NOT NULL , 
     Street VARCHAR (30) , 
     BuildingNumber VARCHAR (5) NOT NULL , 
     ApartmentNumber VARCHAR (5) , 
     ZipCode VARCHAR (6) NOT NULL , 
     Country VARCHAR (20) NOT NULL 
    )
GO

ALTER TABLE UserAddress ADD CONSTRAINT Address_PK PRIMARY KEY CLUSTERED (AddressId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Cart 
    (
     CartId INTEGER NOT NULL , 
     Sum DECIMAL (5,2) , 
     Weight DECIMAL (5,2) 
    )
GO

ALTER TABLE Cart ADD CONSTRAINT Cart_PK PRIMARY KEY CLUSTERED (CartId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE CartProduct 
    (
     CartId INTEGER NOT NULL , 
     ProductId INTEGER NOT NULL , 
     Quantity INTEGER NOT NULL , 
     Price DECIMAL (6,2) 
    )
GO

ALTER TABLE CartProduct ADD CONSTRAINT CartProduct_PK PRIMARY KEY CLUSTERED (CartId, ProductId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Category 
    (
     CategoryId INTEGER NOT NULL , 
     ParentCategoryId INTEGER NOT NULL , 
     Name VARCHAR (50) NOT NULL 
    )
GO

ALTER TABLE Category ADD CONSTRAINT Category_PK PRIMARY KEY CLUSTERED (CategoryId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Continent 
    (
     ContinentId INTEGER NOT NULL , 
     Name VARCHAR (30) NOT NULL 
    )
GO

ALTER TABLE Continent ADD CONSTRAINT Continent_PK PRIMARY KEY CLUSTERED (ContinentId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Country 
    (
     CountryId INTEGER NOT NULL , 
     Name VARCHAR (20) NOT NULL , 
     ContinentId INTEGER NOT NULL , 
     FlagUri VARCHAR (50) 
    )
GO

ALTER TABLE Country ADD CONSTRAINT Country_PK PRIMARY KEY CLUSTERED (CountryId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Delivery 
    (
     DeliveryId INTEGER NOT NULL , 
     DeliveryTypeId INTEGER NOT NULL , 
     ShipmentIdFromDeliveryCompany VARCHAR (40) NOT NULL , 
     TrackingUrl VARCHAR (60) , 
     SendDate DATE NOT NULL 
    )
GO

ALTER TABLE Delivery ADD CONSTRAINT Delivery_PK PRIMARY KEY CLUSTERED (DeliveryId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE DeliveryCompany 
    (
     DeliveryCompanyId INTEGER NOT NULL , 
     Name VARCHAR NOT NULL , 
     BaseTrackingUrl VARCHAR (40) 
    )
GO

ALTER TABLE DeliveryCompany ADD CONSTRAINT DeliveryCompany_PK PRIMARY KEY CLUSTERED (DeliveryCompanyId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE DeliveryType 
    (
     DeliveryTypeId INTEGER NOT NULL , 
     DeliveryCompanyId INTEGER NOT NULL , 
     Name VARCHAR (40) NOT NULL , 
     Price DECIMAL (5,2) NOT NULL , 
     MaxWeight DECIMAL (5,2) NOT NULL 
    )
GO

ALTER TABLE DeliveryType ADD CONSTRAINT DeliveryType_PK PRIMARY KEY CLUSTERED (DeliveryTypeId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Discount 
    (
     DiscountId INTEGER NOT NULL , 
     Name VARCHAR (30) NOT NULL , 
     DiscountPercent DECIMAL (5,2) NOT NULL , 
     EndDate DATE
    )
GO

ALTER TABLE Discount ADD CONSTRAINT Discount_PK PRIMARY KEY CLUSTERED (DiscountId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Language 
    (
     LanguageId INTEGER NOT NULL , 
     Name VARCHAR (15) NOT NULL 
    )
GO

ALTER TABLE Language ADD CONSTRAINT Language_PK PRIMARY KEY CLUSTERED (LanguageId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE "Order" 
    (
     OrderId INTEGER NOT NULL , 
     UserId INTEGER NOT NULL , 
     CartId INTEGER NOT NULL , 
     Date DATE NOT NULL , 
     AddressId INTEGER NOT NULL , 
     Comment VARCHAR (200) , 
     OrderStatusId INTEGER NOT NULL , 
     PaymentTypeId INTEGER NOT NULL , 
     PaymentStatusId INTEGER NOT NULL , 
     DeliveryId INTEGER NOT NULL , 
     VoucherId INTEGER 
    )
GO

ALTER TABLE "Order" ADD CONSTRAINT Order_PK PRIMARY KEY CLUSTERED (OrderId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE OrderStatus 
    (
     OrderStatusId INTEGER NOT NULL , 
     Name VARCHAR (20) NOT NULL 
    )
GO

ALTER TABLE OrderStatus ADD CONSTRAINT OrderStatus_PK PRIMARY KEY CLUSTERED (OrderStatusId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE PaymentStatus 
    (
     PaymentStatusId INTEGER NOT NULL , 
     Name VARCHAR (10) NOT NULL 
    )
GO

ALTER TABLE PaymentStatus ADD CONSTRAINT PaymentStatus_PK PRIMARY KEY CLUSTERED (PaymentStatusId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE PaymentType 
    (
     PaymentTypeId INTEGER NOT NULL , 
     Name VARCHAR (20) NOT NULL 
    )
GO

ALTER TABLE PaymentType ADD CONSTRAINT PaymentType_PK PRIMARY KEY CLUSTERED (PaymentTypeId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Product 
    (
     ProductId INTEGER NOT NULL , 
     Name VARCHAR (50) NOT NULL , 
     Price DECIMAL (5,2) NOT NULL , 
     WarehouseQuantity INTEGER NOT NULL , 
     ExpertId INTEGER , 
     Description VARCHAR (500) , 
     CategoryId INTEGER NOT NULL , 
     DiscountId INTEGER , 
     CreateDate DATE NOT NULL , 
     CountryId INTEGER NOT NULL 
    )
GO

ALTER TABLE Product ADD CONSTRAINT Product_PK PRIMARY KEY CLUSTERED (ProductId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE ProductDiscount 
    (
     ProductId INTEGER NOT NULL , 
     DiscountId INTEGER NOT NULL 
    )
GO

ALTER TABLE ProductDiscount ADD CONSTRAINT ProductDiscount_PK PRIMARY KEY CLUSTERED (ProductId, DiscountId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Role 
    (
     RoleId INTEGER NOT NULL , 
     Name VARCHAR (20) NOT NULL 
    )
GO

ALTER TABLE Role ADD CONSTRAINT Role_PK PRIMARY KEY CLUSTERED (RoleId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Theme 
    (
     ThemeID INTEGER NOT NULL , 
     Name VARCHAR (10) NOT NULL 
    )
GO

ALTER TABLE Theme ADD CONSTRAINT Theme_PK PRIMARY KEY CLUSTERED (ThemeID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE "User" 
    (
     UserId INTEGER NOT NULL , 
     Name VARCHAR (30) NOT NULL , 
     Surname VARCHAR (40) NOT NULL , 
     RoleId INTEGER NOT NULL , 
     NewsletterOn BIT , 
     Phone VARCHAR (10) NOT NULL , 
     Email VARCHAR (30) NOT NULL , 
     Password VARCHAR (100) , 
     IsActive BIT NOT NULL , 
     LanguageId INTEGER NOT NULL , 
     TemporaryCartId INTEGER NOT NULL , 
     ThemeId INTEGER NOT NULL , 
     ProductOnPageCount INTEGER NOT NULL ,
     Provider INTEGER NOT NULL  
    )
GO

ALTER TABLE "User" ADD CONSTRAINT User_PK PRIMARY KEY CLUSTERED (UserId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Voucher 
    (
     VoucherId INTEGER NOT NULL , 
     Rebate DECIMAL (5,2) NOT NULL , 
     Code VARCHAR (10) NOT NULL , 
     ExpirationDate DATE NOT NULL , 
     Status INTEGER , 
     UserId INTEGER NOT NULL 
    )
GO

ALTER TABLE Voucher ADD CONSTRAINT Voucher_PK PRIMARY KEY CLUSTERED (VoucherId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

ALTER TABLE CartProduct 
    ADD CONSTRAINT CartProduct_Cart_FK FOREIGN KEY 
    ( 
     CartId
    ) 
    REFERENCES Cart 
    ( 
     CartId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE CartProduct 
    ADD CONSTRAINT CartProduct_Product_FK FOREIGN KEY 
    ( 
     ProductId
    ) 
    REFERENCES Product 
    ( 
     ProductId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Category 
    ADD CONSTRAINT Category_Category_FK FOREIGN KEY 
    ( 
     ParentCategoryId
    ) 
    REFERENCES Category 
    ( 
     CategoryId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Country 
    ADD CONSTRAINT Country_Continent_FK FOREIGN KEY 
    ( 
     ContinentId
    ) 
    REFERENCES Continent 
    ( 
     ContinentId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Delivery 
    ADD CONSTRAINT Delivery_DeliveryType_FK FOREIGN KEY 
    ( 
     DeliveryTypeId
    ) 
    REFERENCES DeliveryType 
    ( 
     DeliveryTypeId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE DeliveryType 
    ADD CONSTRAINT DeliveryType_DeliveryCompany_FK FOREIGN KEY 
    ( 
     DeliveryCompanyId
    ) 
    REFERENCES DeliveryCompany 
    ( 
     DeliveryCompanyId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Address_FK FOREIGN KEY 
    ( 
     AddressId
    ) 
    REFERENCES UserAddress 
    ( 
     AddressId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Cart_FK FOREIGN KEY 
    ( 
     CartId
    ) 
    REFERENCES Cart 
    ( 
     CartId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Delivery_FK FOREIGN KEY 
    ( 
     DeliveryId
    ) 
    REFERENCES Delivery 
    ( 
     DeliveryId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_OrderStatus_FK FOREIGN KEY 
    ( 
     OrderStatusId
    ) 
    REFERENCES OrderStatus 
    ( 
     OrderStatusId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_PaymentStatus_FK FOREIGN KEY 
    ( 
     PaymentStatusId
    ) 
    REFERENCES PaymentStatus 
    ( 
     PaymentStatusId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_PaymentType_FK FOREIGN KEY 
    ( 
     PaymentTypeId
    ) 
    REFERENCES PaymentType 
    ( 
     PaymentTypeId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_User_FK FOREIGN KEY 
    ( 
     UserId
    ) 
    REFERENCES "User" 
    ( 
     UserId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Product 
    ADD CONSTRAINT Product_Category_FK FOREIGN KEY 
    ( 
     CategoryId
    ) 
    REFERENCES Category 
    ( 
     CategoryId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Product 
    ADD CONSTRAINT Product_Country_FK FOREIGN KEY 
    ( 
     CountryId
    ) 
    REFERENCES Country 
    ( 
     CountryId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE ProductDiscount 
    ADD CONSTRAINT TABLE_30_Discount_FK FOREIGN KEY 
    ( 
     DiscountId
    ) 
    REFERENCES Discount 
    ( 
     DiscountId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE ProductDiscount 
    ADD CONSTRAINT TABLE_30_Product_FK FOREIGN KEY 
    ( 
     ProductId
    ) 
    REFERENCES Product 
    ( 
     ProductId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "User" 
    ADD CONSTRAINT User_Cart_FK FOREIGN KEY 
    ( 
     TemporaryCartId
    ) 
    REFERENCES Cart 
    ( 
     CartId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "User" 
    ADD CONSTRAINT User_Language_FK FOREIGN KEY 
    ( 
     LanguageId
    ) 
    REFERENCES Language 
    ( 
     LanguageId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "User" 
    ADD CONSTRAINT User_Role_FK FOREIGN KEY 
    ( 
     RoleId
    ) 
    REFERENCES Role 
    ( 
     RoleId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "User" 
    ADD CONSTRAINT User_Theme_FK FOREIGN KEY 
    ( 
     ThemeId
    ) 
    REFERENCES Theme 
    ( 
     ThemeID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Voucher 
    ADD CONSTRAINT Voucher_User_FK FOREIGN KEY 
    ( 
     UserId
    ) 
    REFERENCES "User"
    ( 
     UserId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                            21
-- CREATE INDEX                             0
-- ALTER TABLE                             65
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
