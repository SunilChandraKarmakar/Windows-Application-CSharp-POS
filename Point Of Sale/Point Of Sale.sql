 create database PointOfSale

create table country
(
	id int identity primary key,
	name varchar(200)
)

create table city
(
	id int identity primary key,
	name varchar(200) unique not null
)

create table ledger
(
	id int identity primary key,
	name varchar(200) not null,
	contact varchar(200) not null unique,
	email varchar(50) unique not null,
	[password] varchar(500) not null,
	gander int not null,
	dateOfBirth date,
	[address] varchar(500),
	cityId int not null,
	createDate dateTime default getdate(),
	[image] image,
	[type] varchar(2),
	foreign key(cityId) references city(id)
)

create table brand
(
	id int identity primary key,
	name varchar(200) not null unique,
	origin varchar(200) 
)

create table category
(
	id int identity primary key,
	name varchar(200) unique not null,
	[description] varchar(500) not null,
	categoryId int,
	foreign key(categoryId) references category(id)
)

create table product
(
	id int identity primary key,
	name varchar(200),
	code varchar(200),
	[description] varchar(500),
	brandId int not null,
	categoryId int not null,
	createDate dateTime default getdate(),
	foreign key(categoryId) references category(id)
)

create table productImage
(
	id int identity primary key,
	productId int not null,
	[image] image not null,
	title varchar(500),
	foreign key(productId) references product(id)
)

create table employee
(
	id int identity primary key,
	name varchar(200),
	contact varchar(200),
	email varchar(200),
	[password] varchar(500),
	[type] int
)

create table pucrchase
(
	id int not null identity primary key,
	number int not null,
	[dateTime] dateTime default getdate(),
	supplierId int not null,
	employeeId int not null,
	total float not null,
	vat float,
	discount float
)

create table pucrchaseDetails
(
	pucrchaseId int not null,
	productId int not null,
	qty int not null,
	rate varchar(200),
	primary key(pucrchaseId, productId)
)

create table unit
(
	id int identity primary key,
	name varchar(200) not null,
	[description] varchar(500) not null,
	primaryQty int
)

create table productPrice
(
	id int identity primary key,
	productId int not null,
	unitId int not null,
	price float
)

create table [transaction]
(
	id int identity primary key,
	number int,
	reference int,
	[dateTime] dateTime default getdate(),
	ledgerId int,
	employeeId int,
	debit int,
	credit int,
	remarks int,
	foreign key(employeeId) references employee(id),
)
