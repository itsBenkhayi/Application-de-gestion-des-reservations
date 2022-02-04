create database Riad
use Riad

create table Region(
	CodeRegion varchar(50) primary key,
	LibelleRegion varchar(50) not null,
)

create table TypeHebergement(
	NumeroType int primary key,
	LibelleType varchar(50) not null,
)

create table Riad(
	NumeroR int primary key,
	NomR varchar(50) not null,
	AdresseRueR varchar(100) not null,
	CodePostaleR varchar(20) not null,
	VilleR varchar(50) not null,
	TelephoneR varchar(50) not null,
	NomContactR varchar(100) not null,
	CodeReg varchar(50) not null foreign key references Region(CodeRegion),
	NombreDePlaces int not null,
)

create table Client(
	CodeClient int primary key,
	Nom varchar(50) not null,
	Prenom varchar(50) not null,
	GSM varchar(50) not null,
	Mail varchar(100) not null,
	Adresse varchar(50) not null,
	Pays varchar(50) not null,
)

create table Negocier(
	NumeroR int not null foreign key references Riad(NumeroR),
	NumeroType int not null foreign key references TypeHebergement(NumeroType),
	CodeClient int not null foreign key references Client(CodeClient),
	DateNego date not null,
	Prix_Nuite float not null,
)

create table Reservation(
	NumRes int primary key,
	NumeroType int not null foreign key references TypeHebergement(NumeroType),
	CodeClient int not null foreign key references Client(CodeClient),
	DateDebut date not null,
	DateFin date not null,
)

