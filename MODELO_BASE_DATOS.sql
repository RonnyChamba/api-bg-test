DROP DATABASE IF EXISTSPRUEBA_INTEGRITY_BG;

CREATE DATABASE PRUEBA_INTEGRITY_BG;


-- registrar formas de pago
INSERT INTO [PRUEBA_INTEGRITY_BG].[dbo].[pay_forms] ([Description])
VALUES 
('Efectivo'),
('Cheque'),
('Transferencia Bancaria'),
('Crédito');