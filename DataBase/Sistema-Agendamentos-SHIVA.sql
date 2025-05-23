CREATE DATABASE SistemaDeAgendamento;
GO

-- Usar o banco
USE SistemaDeAgendamento;
GO


-- Tabelas
CREATE TABLE Cliente (
	id_cliente INT IDENTITY(1,1) PRIMARY KEY,
	nome_cliente VARCHAR(70) NOT NULL,
	nascimento_cliente DATE NOT NULL,
	rg_cliente CHAR(12) NOT NULL,
	cpf_cliente CHAR(14) NOT NULL,
	logradouro_cliente VARCHAR(60) NOT NULL,
	numero_cliente VARCHAR(8) NOT NULL,
	complemento_cliente VARCHAR(50),
	bairro_cliente VARCHAR(50) NOT NULL,
	cep_cliente CHAR(9) NOT NULL,
	cidade_cliente VARCHAR(60) NOT NULL,
	uf_cliente CHAR(2) NOT NULL,
	estadoCivil_cliente VARCHAR(60) NOT NULL,
	celular1_cliente VARCHAR(60) NOT NULL,
	telefone1_cliente VARCHAR(60),
	email_cliente VARCHAR(60) NOT NULL,
	contatoEmergenciaTel_cliente VARCHAR(60) NULL,
	contatoEmergenciaCel_cliente VARCHAR(60) NOT NULL,
	status_cliente VARCHAR(50) DEFAULT 'ATIVO',
	obs_cliente VARCHAR(255)
);

CREATE TABLE Terapia (
	id_terapia INT IDENTITY(1,1) PRIMARY KEY,
	nome_terapia VARCHAR(70) NOT NULL,
	modalidade_terapia VARCHAR(20) NOT NULL,
	intensidade_terapia VARCHAR(20) NOT NULL,
	materiais_terapia VARCHAR(255),
	duracaoMedia_terapia TIME NOT NULL,
	preco_terapia DECIMAL(10,2) NOT NULL,
	contradicoes_terapia VARCHAR(255),
	status_terapia VARCHAR(255) DEFAULT 'ATIVO',
	obs_terapia VARCHAR(255)
);

CREATE TABLE Consulta (
	id_consulta INT IDENTITY(1,1) PRIMARY KEY,
	id_cliente_consulta INT NOT NULL,
	id_terapia_consulta INT NOT NULL,
	dataHora_consulta DATETIME NOT NULL,
	tipo_consulta VARCHAR(50) NOT NULL,
	descricao_consulta VARCHAR(255) NOT NULL,
	status_consulta VARCHAR(50) DEFAULT 'ATIVO',
	obs_consulta VARCHAR(255),
	FOREIGN KEY (id_cliente_consulta) REFERENCES Cliente(id_cliente),
	FOREIGN KEY (id_terapia_consulta) REFERENCES Terapia(id_terapia)
);

CREATE TABLE Ficha (
	id_ficha INT IDENTITY(1,1) PRIMARY KEY,
	id_cliente_ficha INT NOT NULL,
	atividadeFisica_ficha VARCHAR(255),
	frequenciaAtividade_ficha VARCHAR(20),
	flexibilidade_ficha VARCHAR(20) NOT NULL,
	experienciaMassoterapia_ficha VARCHAR(255) NOT NULL,
	ultimaSessao_ficha VARCHAR(20),
	portadorMarcapasso_ficha CHAR(3) NOT NULL,
	cirurgiasRecentes_ficha VARCHAR(255),
	alergias_ficha VARCHAR(255),
	fumante_ficha CHAR(3) NOT NULL,
	doencaMuscular_ficha VARCHAR(255),
	doencaSistemaNervoso_ficha VARCHAR(255),
	doencaEmocional_ficha VARCHAR(255),
	doencaCirculatoria_ficha VARCHAR(255),
	doencaRespiratoria_ficha VARCHAR(255),
	doencaPele_ficha VARCHAR(255),
	outraDoenca_ficha VARCHAR(255),
	usaMedicamento_ficha VARCHAR(255) NOT NULL,
	objetivoMassagem_ficha VARCHAR(255) NOT NULL,
	status_ficha VARCHAR(50) DEFAULT 'ATIVO',
	obs_ficha VARCHAR(255),
	FOREIGN KEY (id_cliente_ficha) REFERENCES Cliente(id_cliente)
);

CREATE TABLE Produto (
	id_produto INT IDENTITY(1,1) PRIMARY KEY,
	nome_produto VARCHAR(70) NOT NULL,
	tipo_produto VARCHAR(25) NOT NULL,
	validade_produto DATE NOT NULL,
	dataFabricacao_produto DATE NOT NULL,
	qntd_produto INT NOT NULL,
	descricao_produto VARCHAR(255) NOT NULL,
	status_produto VARCHAR(50) DEFAULT 'ATIVO',
	obs_produto VARCHAR(255)
);

-- Produtos para Massagem Relaxante
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES 
('Óleo Essencial de Lavanda', 'Óleo Essencial', '2026-12-31', '2025-05-01', 50, 'Óleo essencial para massagem relaxante', 'ATIVO'),
('Creme Neutro', 'Creme', '2026-12-31', '2025-05-01', 100, 'Creme neutro para massagem', 'ATIVO'),
('Toalhas Descartáveis', 'Toalha', '2027-12-31', '2025-05-01', 200, 'Toalhas descartáveis para uso único', 'ATIVO');

-- Produtos para Massagem com Aromaterapia
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Óleo Essencial de Morango', 'Óleo Essencial', '2026-12-31', '2025-05-01', 50, 'Óleo essencial aromático de morango', 'ATIVO'),
('Difusor de Aromas', 'Difusor', '2030-12-31', '2025-05-01', 10, 'Difusor para aromaterapia', 'ATIVO'),
('Vela Perfumada', 'Vela', '2027-06-30', '2025-05-01', 30, 'Vela perfumada para ambiente', 'ATIVO');

-- Produtos para Massagem com Pedras Quentes
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Pedras Vulcânicas', 'Acessório', '2030-12-31', '2025-05-01', 50, 'Pedras vulcânicas para massagem quente', 'ATIVO'),
('Óleo de Massagem Neutro', 'Óleo de Massagem', '2026-12-31', '2025-05-01', 80, 'Óleo neutro para massagem', 'ATIVO'),
('Toalhas Aquecidas', 'Toalha', '2027-12-31', '2025-05-01', 100, 'Toalhas aquecidas para conforto', 'ATIVO');

-- Produtos para Shiatsu
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Toalha Higienizada', 'Toalha', '2027-12-31', '2025-05-01', 150, 'Toalha higienizada para massagem', 'ATIVO'),
('Lençol Descartável', 'Lençol', '2027-12-31', '2025-05-01', 200, 'Lençol descartável para higiene', 'ATIVO'),
('Álcool 70%', 'Antisséptico', '2025-12-31', '2025-05-01', 100, 'Álcool 70% para higienização', 'ATIVO');

-- Produtos para Reflexologia Podal
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Creme para Pés', 'Creme', '2026-12-31', '2025-05-01', 70, 'Creme hidratante para pés', 'ATIVO'),
('Óleo de Hortelã', 'Óleo Essencial', '2026-12-31', '2025-05-01', 50, 'Óleo essencial de hortelã', 'ATIVO'),
('Toalhas Descartáveis', 'Toalha', '2027-12-31', '2025-05-01', 150, 'Toalhas descartáveis para uso', 'ATIVO');

-- Produtos para Massagem Desportiva
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Gel Anti-inflamatório', 'Gel', '2025-12-31', '2025-05-01', 40, 'Gel para alívio de inflamação muscular', 'ATIVO'),
('Creme de Aquecimento Muscular', 'Creme', '2025-12-31', '2025-05-01', 60, 'Creme para aquecimento muscular', 'ATIVO'),
('Bandagem Elástica', 'Bandagem', '2028-12-31', '2025-05-01', 100, 'Bandagem para suporte muscular', 'ATIVO');

-- Produtos para Drenagem Linfática
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Gel Redutor', 'Gel', '2025-12-31', '2025-05-01', 60, 'Gel redutor para drenagem linfática', 'ATIVO'),
('Óleo de Semente de Uva', 'Óleo Vegetal', '2026-12-31', '2025-05-01', 40, 'Óleo vegetal para massagem', 'ATIVO'),
('Luvas Descartáveis', 'Luva', '2027-12-31', '2025-05-01', 300, 'Luvas descartáveis para higiene', 'ATIVO');

-- Produtos para Tui Na
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Bálsamo Chinês', 'Bálsamo', '2026-12-31', '2025-05-01', 30, 'Bálsamo para massagem Tui Na', 'ATIVO'),
('Óleo Herbal', 'Óleo Herbal', '2026-12-31', '2025-05-01', 50, 'Óleo herbal para massagens', 'ATIVO'),
('Toalha Descartável', 'Toalha', '2027-12-31', '2025-05-01', 150, 'Toalhas descartáveis para uso', 'ATIVO');

-- Produtos para Massagem com Bambus
INSERT INTO Produto (nome_produto, tipo_produto, validade_produto, dataFabricacao_produto, qntd_produto, descricao_produto, status_produto)
VALUES
('Bambus de Massagem', 'Acessório', '2030-12-31', '2025-05-01', 25, 'Bambus utilizados na massagem', 'ATIVO'),
('Óleo Vegetal', 'Óleo Vegetal', '2026-12-31', '2025-05-01', 60, 'Óleo vegetal para massagem', 'ATIVO'),
('Creme Neutro', 'Creme', '2026-12-31', '2025-05-01', 100, 'Creme neutro para massagem', 'ATIVO');
GO

INSERT INTO Terapia (nome_terapia, modalidade_terapia, intensidade_terapia, materiais_terapia, duracaoMedia_terapia, preco_terapia, contradicoes_terapia, obs_terapia)
VALUES
('Massagem Relaxante', 'Corporal', 'Média', 'Óleo Essencial de Lavanda, Creme Neutro, Toalhas Descartáveis', '01:00:00', 150.00, 'Febre, infecções de pele, trombose venosa profunda.', NULL),
('Massagem com Aromaterapia', 'Corporal', 'Média', 'Óleo Essencial de Morango, Difusor de Aromas, Vela Perfumada', '01:00:00', 150.00, 'Alergia a óleos essenciais, asma, gravidez (alguns óleos).', NULL),
('Massagem com Pedras Quentes', 'Corporal', 'Média', 'Pedras Vulcânicas, Óleo de Massagem Neutro, Toalhas Aquecidas', '01:00:00', 150.00, 'Varizes, doenças cardiovasculares, pele sensível.', NULL),
('Shiatsu', 'Corporal', 'Média', 'Toalha Higienizada, Lençol Descartável, Álcool 70%', '01:00:00', 150.00, 'Fraturas recentes, osteoporose severa, gravidez avançada.', NULL),
('Reflexologia Podal', 'Corporal', 'Média', 'Creme para Pés, Óleo de Hortelã, Toalhas Descartáveis', '01:00:00', 150.00, 'Diabetes descontrolado, feridas nos pés, trombose.', NULL),
('Massagem Desportiva', 'Corporal', 'Média', 'Gel Anti-inflamatório, Creme de Aquecimento Muscular, Bandagem Elástica', '01:00:00', 150.00, 'Lesões agudas, inflamações severas, pós-cirurgia recente.', NULL),
('Drenagem Linfática', 'Corporal', 'Média', 'Gel Redutor, Óleo de Semente de Uva, Luvas Descartáveis', '01:00:00', 150.00, 'Insuficiência cardíaca, infecções agudas, trombose linfática.', NULL),
('Tui Na', 'Corporal', 'Média', 'Bálsamo Chinês, Óleo Herbal, Toalha Descartável', '01:00:00', 150.00, 'Hipertensão não controlada, fraturas, hérnia de disco.', NULL),
('Massagem com Bambus', 'Corporal', 'Média', 'Bambus de Massagem, Óleo Vegetal, Creme Neutro', '01:00:00', 150.00, 'Problemas circulatórios, pele sensível, lesões musculares.', NULL);

select * from Terapia


