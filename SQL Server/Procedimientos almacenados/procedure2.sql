CREATE PROCEDURE esquema
	@legajo varchar(8)
	
	AS
	BEGIN
		SELECT a.cue_numero, a.cue_numero_subcuenta, SUM(ISNULL(a.ast_credito, 0))-SUM(ISNULL(a.ast_debito, 0)) AS 'balance' INTO #temp
		FROM Asientos a INNER JOIN afiliados_abm f ON a.ast_legajo_afectado = f.legajo
		WHERE @legajo = f.legajo
		GROUP BY a.cue_numero, a.cue_numero_subcuenta
		
		Select t.cue_numero as 'Numero de cuenta', t.cue_numero_subcuenta as 'Numero de subcuenta', t.Balance
		FROM #temp t
		
		DROP TABLE #temp
	END
	
EXEC esquema @legajo = '3'