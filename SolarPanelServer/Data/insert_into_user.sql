USE [SolarPanel]
GO

INSERT INTO [dbo].[USER]
           ([user_name]
           ,[password]
           ,[role]
           ,[row_updated])
     VALUES
           ('admin', 'ac9689e2272427085e35b9d3e3e8bed88cb3434828b43b86fc0596cad4c6e270', 1, '2023-02-18 13:49:34'),					--pw: admin1234
		   ('test_user_1', '287ed8f78c711869e5826f55a11f28b5a1ffcd7cb3c3e0bfa0b50641950ea134', 2, '2023-02-18 13:49:34'),			--pw: almafa01
		   ('test_user_2', 'daaad6e5604e8e17bd9f108d91e26afe6281dac8fda0091040a7a6d7bd9b43b5', 3, '2023-02-18 13:49:34'),			--pw: qwerty123
		   ('test_user_3', '404349596e30425504c8f3a17bf707c7dad82919db76460a71bb2f878e84391b', 4, '2023-02-18 13:49:34')			--pw: jelszo99
GO


