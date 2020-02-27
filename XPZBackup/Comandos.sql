--CREATE PROCEDURE SP_LISTA_OBJETOS
--@DiasParaBackup INT = 15 /*Quantidade de dias para tr�s a partir da data de hoje para realiza��o do backup*/
--AS
--BEGIN
	--DECLARE @DataHoraInicial DATETIME
	--DECLARE @DataHoraFinal DATETIME

	--SET @DataHoraInicial = CONVERT(VARCHAR(10), GETDATE() - @DiasParaBackup, 103) + ' 00:00:00'
	--SET @DataHoraFinal = CONVERT(VARCHAR(10), GETDATE(), 103) + ' 23:59:59';
	
	
WITH CTE_TIPOS_DADOS (TipoDado)
	AS (
		SELECT DISTINCT ET.EntityTypeName FROM <BANCO_DADOS>.dbo.EntityVersion EV
		INNER JOIN <BANCO_DADOS>.dbo.EntityType ET ON (ET.EntityTypeId = EV.EntityTypeId)
		INNER JOIN <BANCO_DADOS>.dbo.Entity E ON (E.EntityTypeId = EV.EntityTypeId AND E.EntityId = EV.EntityId AND E.EntityLastVersionId = EV.EntityVersionId)
		WHERE SUBSTRING(EntityVersionName, 1, 3) NOT IN ('Audit')
		AND EntityVersionTimestamp BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10), GETDATE() - <QUANTIDADE_DIAS_BACKUP>, 103) + ' 00:00:00') AND CONVERT(DATETIME, (CONVERT(VARCHAR(10), GETDATE(), 103) + ' 23:59:59'))
		AND ET.EntityTypeName NOT IN 
			(
				'Environments', 'DataStores', 'TranslationMessage', 'ThemeColor', 'ThemeColors', 'ColorPalette', 'Documentation', 'Help', 'MissingKBObject', 'WikiBlob',
				'Events', 'Conditions', 'EXOStructure', 'FormDesigner', 'Layout', 'LocalizableImage', 'WinForm', 'Variables', 'SDTStructure', 'Structure',
				'Rules', 'WebPanelDesigner', 'PatternInstance', 'PatternSettings', 'ThemeClass', 'SDTItemEntity', 'Module', 'SDTLevelEntity', 'WebForm', 'TableStructure',
				'ModuleContent', 'IndexStructure', 'Root', 'TableIndexes', 'ThemeStyles', 'ThemeFonts', 'LNGStructure', 'DebugData'
			)
		AND ET.EntityTypeName NOT LIKE 'Udm.%'
		AND EV.EntityVersionName NOT IN 
			(
				'Procedure, Procedure'
			)
	)
		SELECT TipoDado + ':' +  
		(
			REPLACE(SUBSTRING
				(
					(
						SELECT EV.EntityVersionName + ',' AS [data()] FROM <BANCO_DADOS>.dbo.EntityVersion EV
						INNER JOIN <BANCO_DADOS>.dbo.EntityType ET ON (ET.EntityTypeId = EV.EntityTypeId)
						INNER JOIN <BANCO_DADOS>.dbo.Entity E ON (E.EntityTypeId = EV.EntityTypeId AND E.EntityId = EV.EntityId AND E.EntityLastVersionId = EV.EntityVersionId)
						WHERE SUBSTRING(EntityVersionName, 1, 3) NOT IN ('Audit')
						AND EntityVersionTimestamp BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10), GETDATE() - <QUANTIDADE_DIAS_BACKUP>, 103) + ' 00:00:00') AND CONVERT(DATETIME, (CONVERT(VARCHAR(10), GETDATE(), 103) + ' 23:59:59'))
						AND ET.EntityTypeName = TipoDado
						AND EV.EntityVersionName NOT IN 
						(
							'Procedure, Procedure'
						)
						FOR XML PATH('')						
					),
					1, 
					LEN
					(
						(
							SELECT EV.EntityVersionName + ',' AS [data()] FROM <BANCO_DADOS>.dbo.EntityVersion EV
							INNER JOIN <BANCO_DADOS>.dbo.EntityType ET ON (ET.EntityTypeId = EV.EntityTypeId)
							INNER JOIN <BANCO_DADOS>.dbo.Entity E ON (E.EntityTypeId = EV.EntityTypeId AND E.EntityId = EV.EntityId AND E.EntityLastVersionId = EV.EntityVersionId)
							WHERE SUBSTRING(EntityVersionName, 1, 3) NOT IN ('Audit')
							AND EntityVersionTimestamp BETWEEN CONVERT(DATETIME, CONVERT(VARCHAR(10), GETDATE() - <QUANTIDADE_DIAS_BACKUP>, 103) + ' 00:00:00') AND CONVERT(DATETIME, (CONVERT(VARCHAR(10), GETDATE(), 103) + ' 23:59:59'))
							AND ET.EntityTypeName = TipoDado
							AND EV.EntityVersionName NOT IN 
							(
								'Procedure, Procedure'
							)
							FOR XML PATH('')							
						)
					) - 1), ', ', ',')
		) + ';' AS [data()]
		FROM CTE_TIPOS_DADOS
		FOR XML PATH('')
--END