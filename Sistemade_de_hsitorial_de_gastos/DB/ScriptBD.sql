-- =============================================
-- Script: Crear Base de Datos y Stored Procedures
-- Sistema de Historial de Gastos
-- =============================================

-- Crear la base de datos
CREATE DATABASE DB_HistorialGastos;
GO

USE DB_HistorialGastos;
GO

-- Crear la tabla Gastos
CREATE TABLE Gastos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(200) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATE NOT NULL DEFAULT GETDATE(),
    Categoria NVARCHAR(100) NOT NULL
);
GO

-- =============================================
-- SP: Obtener todos los gastos
-- =============================================
CREATE PROCEDURE SP_ObtenerGastos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Descripcion, Monto, Fecha, Categoria
    FROM Gastos
    ORDER BY Fecha DESC;
END
GO

-- =============================================
-- SP: Obtener un gasto por Id
-- =============================================
CREATE PROCEDURE SP_ObtenerGastoPorId
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Descripcion, Monto, Fecha, Categoria
    FROM Gastos
    WHERE Id = @Id;
END
GO

-- =============================================
-- SP: Insertar un nuevo gasto
-- =============================================
CREATE PROCEDURE SP_InsertarGasto
    @Descripcion NVARCHAR(200),
    @Monto DECIMAL(10,2),
    @Fecha DATE,
    @Categoria NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Gastos (Descripcion, Monto, Fecha, Categoria)
    VALUES (@Descripcion, @Monto, @Fecha, @Categoria);
END
GO

-- =============================================
-- SP: Actualizar un gasto existente
-- =============================================
CREATE PROCEDURE SP_ActualizarGasto
    @Id INT,
    @Descripcion NVARCHAR(200),
    @Monto DECIMAL(10,2),
    @Fecha DATE,
    @Categoria NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Gastos
    SET Descripcion = @Descripcion,
        Monto = @Monto,
        Fecha = @Fecha,
        Categoria = @Categoria
    WHERE Id = @Id;
END
GO

-- =============================================
-- SP: Eliminar un gasto
-- =============================================
CREATE PROCEDURE SP_EliminarGasto
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Gastos
    WHERE Id = @Id;
END
GO

-- =============================================
-- Insertar datos de prueba
-- =============================================
INSERT INTO Gastos (Descripcion, Monto, Fecha, Categoria) VALUES
('Almuerzo en restaurante', 450.00, '2026-04-01', 'Alimentación'),
('Gasolina del vehículo', 1200.00, '2026-04-02', 'Transporte'),
('Factura de internet', 1500.00, '2026-03-28', 'Servicios'),
('Compra de libros', 800.00, '2026-03-25', 'Educación'),
('Medicamentos', 350.00, '2026-03-30', 'Salud');
GO