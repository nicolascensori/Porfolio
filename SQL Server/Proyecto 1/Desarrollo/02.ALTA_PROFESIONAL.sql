CREATE PROCEDURE alta_profesional
	@nombre varchar(50),
	@direccion varchar(50)
AS
BEGIN
	INSERT INTO Persona (nombre, Direccion) VALUES (@nombre, @direccion)
END