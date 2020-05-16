create database RecursosHumanos
use RecursosHumanos
go 

Create table Empresa 
(
  IdEmpresa Int primary key not null,
  Nombre nvarchar (50) not null,
  Telefono nvarchar(20) not null,
  Direccion nvarchar(20) not null 
)


Create table Departamentos
(
IdDepartamentos Int Not null primary key ,
NombreDepartamento Nvarchar (50) not null,
IdEmpresa int Not null 
)


Create table Puestos
(
IdPuesto Int Not null primary key ,
NombrePuesto Nvarchar (50) not null,
IdDepartamentos int Not null ,
Descripcion nVarchar (300)
)


Create table Vacantes
(
IdVacantes Int Not null primary key ,
Cantidad int Not null ,
IdPuesto int 
)


Create table Empleados 
(
IdEmpleado int  Not null primary key ,
Nombre Nvarchar (100)Not null ,
Apellidos Nvarchar (100)Not null ,
Direccion Nvarchar (100)Not null ,
Sexo Nvarchar (100)Not null ,
Telefono Nvarchar (100)Not null ,
Dui Nvarchar (100)Not null , 
Nit Nvarchar (100)Not null ,
Estado Nvarchar (100)Not null ,
Tipo Nvarchar (100)Not null ,
IdPuesto int 
)


Create table Contratos
(
IdContrato int  Not null primary key ,
IdEmpleado int ,
Salario Decimal (13,2)Not null ,
JornadaLAboral Nvarchar (100)Not null ,
DiasdeDescanso Nvarchar (100)Not null ,
Fecha_de_contrato DateTime 
)



Create table Vacaciones
(
IdVacaciones Int not null primary key,
desde date not null,
hasta date not null,
IdContrato int not null
)


create table HorasExtras
(
IdHorasExtras int Not null Primary key,
IdEmpleado int  not null ,
TablaHora int  not null,
PrecioHora Decimal(12,2)  not null
)


create table Rendimiento
(
IdRendimiento int Not null Primary key,
IdEmpleado int  not null ,
Observaciones nVarchar(300),
Rendimiento nvarchar(100)
)

create table Aguinaldo
( IdAguinaldo int not null primary key,
FechaActual Date ,
Total Decimal (12,2),
IdContrato int
)

alter table Departamentos add constraint FK_Departamento_Empresa foreign key (IdEmpresa) references Empresa(IdEmpresa) 
alter table Puestos add constraint FK_Puesto_Departamento foreign key (IdDepartamentos) references Departamentos(IdDepartamentos)
alter table Vacantes add constraint FK_Vacantes_Puesto foreign key (IdPuesto) references Puestos(IdPuesto)
alter table Empleados add constraint FK_Empleados_Puestos foreign key (IdPuesto) references Puestos(IdPuesto)
alter table Vacaciones add constraint FK_Vacaciones_Contratos foreign key (IdContrato) references Contratos(IdContrato)
alter table HorasExtras add constraint FK_HorasExtras_Empleados foreign key (IdEmpleado) references Empleados(IdEmpleado)

alter table Rendimiento add constraint FK_Rendimiento_Empleados foreign key (IdEmpleado) references Empleados(IdEmpleado)
alter table Aguinaldo add constraint FK_Aguinaldo_Contratos foreign key (IdContrato) references Contratos(IdContrato)
alter table Contratos add constraint FK_Contratos_Empleado foreign key (IdEmpleado) references Empleados(IdEmpleado)
