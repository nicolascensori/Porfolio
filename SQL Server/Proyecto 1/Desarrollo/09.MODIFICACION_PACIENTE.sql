CREATE PROCEDURE modificacion_persona
	@nombre varchar(50),
	@nombre_nuevo varchar(50) = NULL,
	@direccion_nueva varchar(80) = NULL
AS
BEGIN
	UPDATE Persona
	SET Nombre = ISNULL(@nombre_nuevo, Persona.nombre), Direccion = ISNULL(@direccion_nueva, Persona.Direccion)
	WHERE Nombre = @nombre
END
