CREATE PROCEDURE obtenerBalance
	@cue_numero char(4),
	@cue_numero_subcuenta char(2),
	@respuesta decimal(10,2) OUTPUT
	AS
	BEGIN
		DECLARE @credito decimal(10,2)
		DECLARE @debito decimal(10,2)
		
		SET @credito = (SELECT SUM(ISNULL(a.ast_credito, 0)) FROM Asientos a WHERE a.cue_numero = @cue_numero AND a.cue_numero_subcuenta = @cue_numero_subcuenta)
		SET @debito = (SELECT SUM(ISNULL(a.ast_debito, 0)) FROM Asientos a WHERE a.cue_numero = @cue_numero AND a.cue_numero_subcuenta = @cue_numero_subcuenta)
		SET @respuesta = @credito - @debito
	END

DECLARE @balance decimal(10,2)
EXEC obtenerBalance @cue_numero = '1137', @cue_numero_subcuenta = '00',
					@respuesta = @balance OUTPUT
					
SELECT @balance AS 'Cuenta final'