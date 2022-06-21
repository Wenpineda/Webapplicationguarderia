create database BDDguarderia

use BDDguarderia

create table niños(
idniños int identity(1,1) NOT NULL PRIMARY KEY,
nombre varchar(50) not null,
apellido varchar(50) null,
edad int not null,
sexo varchar (50),
);

insert into niños values ('Juanito','Lopez',5, 'masculino');
insert into niños values ('Marta','Ramos',5, 'femenino');

select *from niños
