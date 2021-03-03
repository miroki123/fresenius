CREATE TABLE [dbo].[Tb_CID]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Codigo] VARCHAR(10) NOT NULL,
	[Nome] VARCHAR(100) NOT NULL
)

INSERT INTO Tb_CID (Codigo, Nome) values ('cid001', 'Miopia')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid002', 'Ceborreia')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid003', 'Cirrose')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid004', 'Enfisema Pulmonar')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid005', 'Psoriase')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid006', 'Cancer de Mama')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid007', 'Otite')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid008', 'Anemia Falsiforme')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid009', 'Leucemia')
INSERT INTO Tb_CID (Codigo, Nome) values ('cid010', 'Doenca de Chron')