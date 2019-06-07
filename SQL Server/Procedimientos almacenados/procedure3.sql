CREATE PROCEDURE asiento_jubilados
AS
BEGIN 
	DECLARE @var_cursor decimal(10,2),
			@var_nombre varchar(50)
	EXEC calcular_cuotas
	
	DECLARE cursor_jub CURSOR FOR
			SELECT sj.sld_cuota_calculada, a.nombre
			FROM afiliados_abm a INNER JOIN sueldos_jubilados sj ON a.legajo = sj.sld_legajo
	OPEN cursor_jub
	FETCH NEXT FROM cursor_jub INTO @var_cursor, @var_nombre
	WHILE @@fetch_status = 0
		BEGIN
			INSERT INTO Asientos (ast_numero_asiento, cue_numero, cue_numero_subcuenta, cue_descripcion, ast_fecha_hora, ast_debito, ast_eliminado, ast_fecha_actualizacion, ast_usuario_actualizacion, ast_detalle)
							Values (1234, '4104', '00', 'Deudores Cuotas jubilados', GETDATE(), @var_cursor, 0, GETDATE(), '12', 'Pago de cuota de afiliado '+@var_nombre)
							
			INSERT INTO Asientos (ast_numero_asiento, cue_numero, cue_numero_subcuenta, cue_descripcion, ast_fecha_hora, ast_credito, ast_eliminado, ast_fecha_actualizacion, ast_usuario_actualizacion, ast_detalle)
							Values (1234, '1136', '00', 'Aportes Personal Jubilado', GETDATE(), @var_cursor, 0, GETDATE(), '12', 'Pago de cuota de afiliado '+@var_nombre)
		END
	CLOSE cursor_jub
	DEALLOCATE cursor_jub
END