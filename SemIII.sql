CREATE DATABASE OnlineShoppingCart
GO
USE OnlineShoppingCart
GO

-- CREATE administrative_regions TABLE
CREATE TABLE administrative_regions (
	id integer NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NOT NULL,
	code_name nvarchar(255) NULL,
	code_name_en nvarchar(255) NULL,
	CONSTRAINT administrative_regions_pkey PRIMARY KEY (id)
);


-- CREATE administrative_units TABLE
CREATE TABLE administrative_units (
	id integer NOT NULL,
	full_name nvarchar(255) NULL,
	full_name_en nvarchar(255) NULL,
	short_name nvarchar(255) NULL,
	short_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	code_name_en nvarchar(255) NULL,
	CONSTRAINT administrative_units_pkey PRIMARY KEY (id)
);


-- CREATE provinces TABLE
CREATE TABLE provinces (
	code nvarchar(20) NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NULL,
	full_name nvarchar(255) NOT NULL,
	full_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	administrative_unit_id integer NULL,
	administrative_region_id integer NULL,
	CONSTRAINT provinces_pkey PRIMARY KEY (code)
);


-- provinces foreign keys

ALTER TABLE provinces ADD CONSTRAINT provinces_administrative_region_id_fkey FOREIGN KEY (administrative_region_id) REFERENCES administrative_regions(id);
ALTER TABLE provinces ADD CONSTRAINT provinces_administrative_unit_id_fkey FOREIGN KEY (administrative_unit_id) REFERENCES administrative_units(id);


-- CREATE districts TABLE
CREATE TABLE districts (
	code nvarchar(20) NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NULL,
	full_name nvarchar(255) NULL,
	full_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	province_code nvarchar(20) NULL,
	administrative_unit_id integer NULL,
	CONSTRAINT districts_pkey PRIMARY KEY (code)
);


-- districts foreign keys

ALTER TABLE districts ADD CONSTRAINT districts_administrative_unit_id_fkey FOREIGN KEY (administrative_unit_id) REFERENCES administrative_units(id);
ALTER TABLE districts ADD CONSTRAINT districts_province_code_fkey FOREIGN KEY (province_code) REFERENCES provinces(code);



-- CREATE wards TABLE
CREATE TABLE wards (
	code nvarchar(20) NOT NULL,
	name nvarchar(255) NOT NULL,
	name_en nvarchar(255) NULL,
	full_name nvarchar(255) NULL,
	full_name_en nvarchar(255) NULL,
	code_name nvarchar(255) NULL,
	district_code nvarchar(20) NULL,
	administrative_unit_id integer NULL,
	CONSTRAINT wards_pkey PRIMARY KEY (code)
);


-- wards foreign keys

ALTER TABLE wards ADD CONSTRAINT wards_administrative_unit_id_fkey FOREIGN KEY (administrative_unit_id) REFERENCES administrative_units(id);
ALTER TABLE wards ADD CONSTRAINT wards_district_code_fkey FOREIGN KEY (district_code) REFERENCES districts(code);
go
CREATE TABLE Users(
	UserID varchar(36) primary key not null,
	FullName varchar(100) not null,
	UserName varchar(50) not null,
    Password varchar(max) not null,
	Birthday datetime not null,
	Gender bit,
	Email varchar(max),
	Phone varchar(20),
	provinces_code nvarchar(20) foreign key (provinces_code) references provinces(code) not null,
	Role int,
	Created_at datetime not null,
	Update_at datetime null,
)
CREATE TABLE FeedBack(
	FeedBackID int primary key identity(10001,1),
	UserID varchar(36) foreign key (UserID) references Users(UserID) not null,
	DateSend datetime,
	Title ntext,
	Created_at timestamp not null,
)

CREATE TABLE Category(
	CategoryID varchar(36) primary key,
	CategoryName varchar(50) not null,
	Descripton text,
    Image varchar(max) not null,
	Status bit,
	Created_at datetime not null,
)
CREATE TABLE Discount(
	DiscountID int primary key identity(1001,1),
	DiscountName varchar(50),
	Description text,
	DiscountPercent decimal,
	Active bit,
	Created_at datetime not null,
	Deleted_at datetime null
)
CREATE TABLE Products(
	ProductID varchar(36) primary key,
	ProductName varchar(200) not null,
	Image varchar(max),
	Price float not null,
	Quantity int not null,
	CategoryID varchar(20) foreign key (CategoryID) references Category(CategoryID),
	DiscountID int foreign key (DiscountID) references Discount(DiscountID),
	Status bit,
	Created_at datetime not null,
	Deleted_at datetime null
)
CREATE TABLE Orders(
	OrderDetailID int primary key identity(10001,1),
	UserID varchar(20) foreign key (UserID) references Users(UserID),
	Created_at datetime not null,
)
CREATE TABLE PaymentDetails(
	PaymentID int primary key identity(10001,1),
	OrderDetailID int foreign key (OrderDetailID) references OrderDetail(OrderDetailID),
	Amount int not null,
	Provider varchar(50) not null,
	Status varchar(20),
	Created_at datetime not null,
)

CREATE TABLE OrderItems(
	OrderItems int primary key identity(10001,1),
	OrderDetailID int foreign key (OrderDetailID) references OrderDetail(OrderDetailID),
	ProductID varchar(20) foreign key (ProductID) references Products(ProductID),
	Created_at datetime not null,
)
