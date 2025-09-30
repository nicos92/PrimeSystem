CREATE DATABASE ComercioBrasesco;
go
USE ComercioBrasesco;
go


--Tabla que almacena los nombres de los roles de los usuarios
CREATE TABLE Usuarios_Tipo(
id_usuario_tipo INT PRIMARY KEY IDENTITY,
descripcion varchar(120)
);
go
CREATE TABLE Usuarios (
id_usuario INT PRIMARY KEY IDENTITY,
id_tipo INT REFERENCES Usuarios_Tipo(id_usuario_tipo),
DNI CHAR(8),
nombre VARCHAR(120),
apellido VARCHAR(120),
tel VARCHAR(30),
mail VARCHAR(120),
clave VARCHAR(50),
estado bit
);
go
CREATE TABLE In_Out_Varios (
id_movimiento INT PRIMARY KEY IDENTITY,
cod_usuario INT REFERENCES Usuarios(id_usuario),
tipo_movimiento VARCHAR(60),
reg_antes VARCHAR(200),
reg_despues VARCHAR(200),
fecha_hora DATETIME DEFAULT GETDATE()
);
go
CREATE TABLE H_Movimientos (
id_historico INT PRIMARY KEY IDENTITY,
id_usuario INT REFERENCES Usuarios(id_usuario),
tipo_movimiento VARCHAR(60),
reg_antes VARCHAR(200),
reg_despues VARCHAR(200),
fecha_hora DATETIME DEFAULT GETDATE()
);
go
CREATE TABLE Categorias (
id_categoria INT PRIMARY KEY IDENTITY,
catgoria VARCHAR(80)
);
CREATE TABLE SubCategoria (
id_subcategoria INT PRIMARY KEY IDENTITY,
subcategoria VARCHAR(80),
id_categoria INT REFERENCES Categorias(id_categoria)
);
go
CREATE TABLE Proveedores(
id_proveedor INT PRIMARY KEY IDENTITY,
CUIT VARCHAR(24),
proveedor VARCHAR(100),
nombre VARCHAR(120),
telefono VARCHAR(30),
mail VARCHAR(120)
);
go
CREATE TABLE Stock (
cod_articulo VARCHAR(80) PRIMARY KEY,
cantidad INT,
costo DECIMAL(10,2),
ganancia DECIMAL(10,2)
);
go
CREATE TABLE Articulos (
id_articulo INT PRIMARY KEY IDENTITY,
cod_articulo VARCHAR(80) REFERENCES Stock(cod_articulo),
art_descripcion VARCHAR(120),
cod_categoria INT REFERENCES Categorias(id_categoria),
cod_subcategoria INT REFERENCES SubCategoria(id_subcategoria),
id_proveedor INT REFERENCES Proveedores(id_proveedor)
);
go

CREATE TABLE H_Compras (
id_remito INT PRIMARY KEY IDENTITY,
cod_usuario INT REFERENCES Usuarios(id_usuario),
fecha_hora DATETIME DEFAULT GETDATE(),
id_proveedor INT REFERENCES Proveedores(id_proveedor),
subtotal DECIMAL(10,2),
descuento DECIMAL(10,2),
total DECIMAL(10,2)
);
go

CREATE TABLE H_Compras_Detalle (
id_det_remito INT PRIMARY KEY IDENTITY,
id_remito INT REFERENCES H_Compras(id_remito),
cod_articulo VARCHAR(80) REFERENCES Stock(cod_articulo),
descripcion VARCHAR(120),
p_unit DECIMAL(10,2),
cantidad INT,
p_x_cantidad DECIMAL(10,2)
);
go
CREATE TABLE Clientes (
id_cliente INT PRIMARY KEY IDENTITY,
CUIT VARCHAR(24),
nombre VARCHAR(120),
entidad VARCHAR(120),
teleforno VARCHAR(30),
mail VARCHAR(120)
);
go
CREATE TABLE H_Ventas (
id_remito INT PRIMARY KEY IDENTITY,
cod_usuario INT REFERENCES Usuarios(id_usuario),
fecha_hora DATETIME DEFAULT GETDATE(),
id_cliente INT REFERENCES Clientes(id_cliente),
sub_total DECIMAL(10,2),
descuento DECIMAL(10,2),
total DECIMAL(10,2)
);
go
CREATE TABLE H_Ventas_Detalle (
id_det_remito INT PRIMARY KEY IDENTITY,
id_remito INT REFERENCES H_Ventas(id_remito),
cod_articulo VARCHAR(80) REFERENCES Stock(cod_articulo),
descripcion VARCHAR(120),
p_unit DECIMAL(10,2),
cantidad INT,
p_x_cantidad DECIMAL(10,2)
);
go

-- CIERRA TODAS LAS CONEXIONES DE LA BASE DE DATOS  Y DEJA LA DEL HILO ACTUAL
ALTER DATABASE ComercioBrasesco SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
go

-- CAMBIA EL NOMBRE DE LA BASE DE DATOS
ALTER DATABASE ComercioBrasesco MODIFY NAME = PrimeSystem;   
go

-- ABRE TODAS LAS CONEXIONES PARA MULTI USUARIOS
ALTER DATABASE PrimeSystem SET MULTI_USER;
go