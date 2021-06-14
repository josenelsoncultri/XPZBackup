WITH CTE_TIPOS_DADOS (TipoDado)
AS (
	SELECT DISTINCT ET.EntityTypeName FROM <BANCO_DADOS>.dbo.EntityVersion EV
	INNER JOIN <BANCO_DADOS>.dbo.EntityType ET ON (ET.EntityTypeId = EV.EntityTypeId)
	INNER JOIN <BANCO_DADOS>.dbo.Entity E ON (E.EntityTypeId = EV.EntityTypeId AND E.EntityId = EV.EntityId AND E.EntityLastVersionId = EV.EntityVersionId)
	WHERE SUBSTRING(EntityVersionName, 1, 3) NOT IN ('Audit')
	AND EntityVersionTimestamp BETWEEN 
	DATETIME2FROMPARTS(
		DATEPART(YEAR, GETDATE() - 15), 
		DATEPART(MONTH, GETDATE() - 15),
		DATEPART(DAY, GETDATE() - 15),
		0, 0, 0, 0, 0
	)
	AND 
	DATETIME2FROMPARTS(
		DATEPART(YEAR, GETDATE()), 
		DATEPART(MONTH, GETDATE()),
		DATEPART(DAY, GETDATE()),
		23, 59, 59, 0, 0
	)
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
SELECT STUFF(
(
	SELECT ';' + TipoDado + ':' +  
	(
		SELECT STUFF(
		(
			SELECT ',' + EV.EntityVersionName FROM <BANCO_DADOS>.dbo.EntityVersion EV
			INNER JOIN <BANCO_DADOS>.dbo.EntityType ET ON (ET.EntityTypeId = EV.EntityTypeId)
			INNER JOIN <BANCO_DADOS>.dbo.Entity E ON (E.EntityTypeId = EV.EntityTypeId AND E.EntityId = EV.EntityId AND E.EntityLastVersionId = EV.EntityVersionId)
			WHERE SUBSTRING(EntityVersionName, 1, 3) NOT IN ('Audit')
			AND EntityVersionTimestamp BETWEEN 
			DATETIME2FROMPARTS(
				DATEPART(YEAR, GETDATE() - 15), 
				DATEPART(MONTH, GETDATE() - 15),
				DATEPART(DAY, GETDATE() - 15),
				0, 0, 0, 0, 0
			)
			AND 
			DATETIME2FROMPARTS(
				DATEPART(YEAR, GETDATE()), 
				DATEPART(MONTH, GETDATE()),
				DATEPART(DAY, GETDATE()),
				23, 59, 59, 0, 0
			)
			AND ET.EntityTypeName = TipoDado
			AND EV.EntityVersionName NOT IN 
			(
				'Procedure, Procedure'
			)
			AND EV.EntityVersionName NOT LIKE 'Audit%'
			FOR XML PATH('')	
		)
		, 1, 1, '')						
	)
	FROM CTE_TIPOS_DADOS
	FOR XML PATH('')
), 1, 1, '')