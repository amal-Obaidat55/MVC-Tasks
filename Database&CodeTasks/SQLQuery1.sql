create database CafeteriaDB;

create table Categories (
Id int primary key,
CName varchar(20) NOT NULL,
CDescription varchar(MAX)
);

create table Suppliers (
Id int primary key,
SName varchar(20) NOT NULL,
Email varchar(50) NOT NULL Unique,
Phone varchar(10)
);

create table Products (
Id int primary key,
PName varchar(20) NOT NULL,
Price decimal(10,2),
Quantity int,
CID int Foreign Key References Categories(Id),
SuppID int Foreign Key References Suppliers(Id)
);

create table PurchaseOrders (
Id int primary key,
OrderDate date,
PStatus varchar(20),
SuppID int Foreign Key References Suppliers(Id)
);

create table PurchaseOrderItems (
Id int primary key,
PurchID int Foreign Key References PurchaseOrders(Id),
ProductID int Foreign Key References Products(Id),
Quantity int,
UnitPrice decimal(10,2)
);