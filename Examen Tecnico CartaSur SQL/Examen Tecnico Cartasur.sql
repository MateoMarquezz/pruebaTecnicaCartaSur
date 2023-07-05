--creacion de base de datos  
create database cartaSurPasantia

use cartaSurPasantia
--paso de parametros para la tabla "ventas" 
create table ventas (
	ID_VENTA int not null primary key,
	Fecha_venta datetime,
	Dni_cliente varchar(10),
	Nombre_empleado varchar(100),
	Nombre_cliente varchar(100),
	Importe_total decimal(10,2),
	Direccion_envio_cliente varchar(100),
	Direccion_sucursal_venta varchar(100),
	Nombre_sucursal_venta varchar(100),
	Producto varchar(20),
Cantidad int
)
--inserto 3 datos de ventas dos iguales 1 dif a forma de ejemplo  
INSERT INTO ventas(ID_VENTA, Fecha_venta, Dni_cliente, Nombre_empleado, Nombre_cliente, Importe_total, Direccion_envio_cliente, Direccion_sucursal_venta, Nombre_sucursal_venta, Producto, Cantidad)
VALUES
    (1, '4/7/2023', '1234567890', 'Mateo Marquez', 'Martina Maselli', 10.00, 'Turdera', 'lomas', 'cartasur 1', 'monitor', 1),
    (2, '3/7/2023', '2345678901', 'Benjamin Marquez', 'Fabian Maselli',10.00, 'Adrogue', 'capital', 'cartasur 2', 'taza', 2),
    (3, '3/7/2023', '3456789012', 'Javier Marquez', 'Gustavo Maselli', 10.00, 'Burzaco', 'cordoba', 'cartasur 3', 'mouse', 3)


CREATE PROCEDURE FechaConMasVentas
AS
BEGIN --creacion de procedure
	WITH VentasPorFecha AS ( -- se crea ventas por fecha para saber la cant por fecha de ventas que hay 
		SELECT Fecha_venta, COUNT(*) as Cantidad_Ventas --contamos la cantidad de ventas x fecha que hay 
			FROM ventas -- desde ventas 
			GROUP BY Fecha_venta --se agrupan los resultados de fecha venta
			)
			
SELECT TOP 1 -- seleccionamos la primera parte del registro 
	Fecha_venta, Cantidad_Ventas --se seleccionas las columnas correspondientes 
		FROM VentasPorFecha --desde ventas por fecha 
			ORDER BY Cantidad_Ventas DESC; -- se ordena cantidad de ventas en orden decendente 
END;

EXEC FechaConMasVentas; --ejecucion del stored procedure