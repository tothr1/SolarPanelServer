/****** Script for SelectTopNRows command from SSMS  ******/

  INSERT INTO Materials VALUES
  ('Panel 2x1m 120W', 16, 170, CURRENT_TIMESTAMP),
  ('Panel 3x4m 260W', 10, 300, CURRENT_TIMESTAMP),
  ('Panel 1x0.5m 75W', 32, 100, CURRENT_TIMESTAMP),
  ('Cable 10m', 20, 30, CURRENT_TIMESTAMP),
  ('Cable 20m', 15, 45, CURRENT_TIMESTAMP),
  ('Inverter 920W 230V', 8, 360, CURRENT_TIMESTAMP),
  ('Inverter 1240W 110V', 5, 500, CURRENT_TIMESTAMP),
  ('Inverter 4000W 230V', 4, 950, CURRENT_TIMESTAMP),
  ('Battery 3kWh', 8, 1900, CURRENT_TIMESTAMP),
  ('Battery 1,8kWh', 12, 1450, CURRENT_TIMESTAMP),
  ('Mount 2x3m', 16, 160, CURRENT_TIMESTAMP),
  ('Mount 1x1.5m', 22, 125, CURRENT_TIMESTAMP),
  ('Mount 1x3m', 12, 150, CURRENT_TIMESTAMP)



SELECT TOP (1000) [material_id]
      ,[material_name]
      ,[shelf_limit]
      ,[price]
      ,[row_updated]
  FROM [SolarPanel].[dbo].[Materials]

