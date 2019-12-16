create database T_Quiron;

use T_Quiron;

create table Doutores (
IdDoutores    int primary key identity,
Nome          varchar (200) not null,
Crm           varchar (200) not null unique,
CrmUf         varchar (200) not null,
);

create table Pacientes (
IdPacientes   int primary key identity,
Nome          varchar (200) not null,
DataNascimento   datetime,
Cpf             varchar (200)not null unique
);
