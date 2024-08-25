-- ***** PRODUCTS ********
INSERT INTO [dbo].[Product] VALUES ('Plano Anual', '1 ano de acesso a plataforma', 'plano-anual',1 , 779.90);
-- ***** CATEGORIES ********

INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Alimenta��o', 'Despesas com alimentos e bebidas', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Sa�de', 'Gastos com sa�de e bem-estar', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Transporte', 'Custos com transporte e ve�culos', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Moradia', 'Despesas relacionadas � casa', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Educa��o', 'Gastos com educa��o e cursos', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Lazer', 'Despesas com atividades de lazer', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Roupas', 'Gastos com vestu�rio', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Investimentos', 'Investimentos e aplica��es financeiras', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Impostos', 'Pagamentos de impostos e taxas', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Viagem', 'Despesas com viagens e turismo', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Presentes', 'Gastos com presentes e doa��es', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Beleza', 'Despesas com beleza e cuidados pessoais', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Pets', 'Gastos com animais de estima��o', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Telefonia', 'Custos com telefonia e internet', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Seguros', 'Pagamentos de seguros diversos', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Sa�de Mental', 'Despesas com psicologia e terapias', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Fitness', 'Gastos com academia e atividades f�sicas', 'teste@balta.io');

-- ***** TRANSACTIONS ********

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Compra de supermercado', '2024-01-05', '2024-01-05', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Alimenta��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Mensalidade Academia', '2024-01-10', '2024-01-10', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Fitness'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Passagem de �nibus', '2024-01-15', '2024-01-15', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transporte'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Livros para curso', '2024-01-20', '2024-01-20', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Educa��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Sal�rio', '2024-01-25', '2024-01-25', 1, 5000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Consulta m�dica', '2024-01-26', '2024-01-26', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Sa�de'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Jantar fora', '2024-01-27', '2024-01-27', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Lazer'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Ra��o para cachorro', '2024-01-28', '2024-01-28', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Pagamento de seguro de vida', '2024-01-29', '2024-01-29', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Seguros'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Mensalidade Netflix', '2024-02-02', '2024-02-02', 2, -45.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Lazer'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Roupa nova', '2024-02-06', '2024-02-06', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Roupas'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Conserto do carro', '2024-02-11', '2024-02-11', 2, -800.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transporte'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Corte de cabelo', '2024-02-15', '2024-02-15', 2, -50.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Beleza'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Compra de livros', '2024-02-18', '2024-02-18', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Educa��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Reembolso de viagem', '2024-02-20', '2024-02-20', 1, 1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Viagem'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Aluguel de fevereiro', '2024-02-25', '2024-02-25', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Moradia'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('IPVA', '2024-02-27', '2024-02-27', 2, -400.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Impostos'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Consulta veterin�ria', '2024-02-28', '2024-02-28', 2, -180.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Jantar de anivers�rio', '2024-02-28', '2024-02-28', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Lazer'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Sal�rio Mensal', '2024-03-01', '2024-03-01', 1, 5000.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Conta de Luz', '2024-03-02', '2024-03-02', 2, -120.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Moradia'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Conta de �gua', '2024-03-05', '2024-03-05', 2, -80.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Moradia'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Mensalidade Escolar', '2024-03-10', '2024-03-10', 2, -600.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Educa��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Compra de Roupas', '2024-03-12', '2024-03-12', 2, -300.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Roupas'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Compra de Suplementos', '2024-03-15', '2024-03-15', 2, -200.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Sa�de'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Restaurante com a Fam�lia', '2024-03-18', '2024-03-18', 2, -250.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Alimenta��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Plano de Telefonia', '2024-03-20', '2024-03-20', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Telefonia'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Viagem de Fim de Semana', '2024-03-22', '2024-03-22', 2, -800.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Viagem'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Pagamento Seguro Carro', '2024-03-24', '2024-03-24', 2, -400.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Seguros'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Material de Arte', '2024-03-26', '2024-03-26', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Lazer'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Receita de Freelance', '2024-05-02', '2024-05-02', 1, 2200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Conta de Internet', '2024-05-05', '2024-05-05', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Telefonia'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Despesa com Transporte', '2024-05-07', '2024-05-07', 2, -160.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transporte'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Compra de Livros', '2024-05-09', '2024-05-09', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Educa��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Sal�rio', '2024-05-10', '2024-05-10', 1, 4000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Pagamento do Aluguel', '2024-05-12', '2024-05-12', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Moradia'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Gastos com Jantar', '2024-05-15', '2024-05-15', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Alimenta��o'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Consulta M�dica', '2024-05-18', '2024-05-18', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Sa�de'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Ra��o para Pet', '2024-05-20', '2024-05-20', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Presente de Anivers�rio', '2024-05-22', '2024-05-22', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Presentes'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Bonifica��o', '2024-05-24', '2024-05-24', 1, 1200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investimentos'), 'teste@balta.io');
