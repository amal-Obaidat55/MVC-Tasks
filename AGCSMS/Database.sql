Create Database AcademyGraduationPreparationDB

Create Table GraduationCertificates
(
Id int Primary Key,
SupplierName varchar(10) Unique,
OfferName varchar(50),
Quantity int ,
UnitPrice decimal(10,2) 
);

Insert into GraduationCertificates
values (1,'Supplier A' , 'Premium Certificate Package',35 ,2 ),
(2,'Supplier B' , 'Standard Certificate Package',35 ,1.5 ),
(3,'Supplier C' , 'Luxury Certificate Package',35 ,2.5 );

Create Table Hospitality
(
Id int Primary Key,
SupplierName varchar(10) Unique,
OfferName varchar(50),
Quantity int ,
UnitPrice decimal(10,2) 
);

Insert into Hospitality
values (1,'Supplier D' , 'Coffee & Drinks Package',100 ,2 ),
(2,'Supplier E' , 'Sandwiches & Snacks Package',100 ,3 ),
(3,'Supplier F' , 'Full Hospitality Package',100 ,4 );

Create Table GraduationGifts
(
Id int Primary Key,
SupplierName varchar(10) Unique,
OfferName varchar(50),
Quantity int ,
UnitPrice decimal(10,2) 
);

Insert into GraduationGifts
values (1,'Supplier G' , 'Customized Mugs Package',35 ,2 ),
(2,'Supplier H' , 'Graduation Bags Package',35 ,3 ),
(3,'Supplier I' , 'Premium Gift Boxes Package',35 ,4 );