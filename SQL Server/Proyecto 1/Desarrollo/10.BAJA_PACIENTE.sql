CREATE PROCEDURE get_usuario
	@email varchar(50)
AS
BEGIN
	SELECT *
	FROM Usuario
	WHERE @email = Email
END

