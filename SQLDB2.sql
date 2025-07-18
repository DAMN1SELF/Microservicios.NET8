CREATE SCHEMA COMPRAS;
GO
CREATE SCHEMA VENTAS;
GO
CREATE SCHEMA INVENTARIO;
GO

CREATE TABLE VENTAS.VentaCab (
    Id_VentaCab    INT IDENTITY(1,1) PRIMARY KEY,
    FecRegistro    DATETIME NOT NULL DEFAULT GETDATE(),
    SubTotal       DECIMAL(18,2) NOT NULL,
    Igv            DECIMAL(18,2) NOT NULL,
    Total          DECIMAL(18,2) NOT NULL
);

CREATE TABLE VENTAS.VentaDet (
    Id_VentaDet    INT IDENTITY(1,1) PRIMARY KEY,
    Id_VentaCab    INT NOT NULL,
    Id_Producto    INT NOT NULL,
    Cantidad       DECIMAL(18,2) NOT NULL,
    Precio         DECIMAL(18,2) NOT NULL,
    SubTotal       DECIMAL(18,2) NOT NULL,
    Igv            DECIMAL(18,2) NOT NULL,
    Total          DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (Id_VentaCab) REFERENCES VENTAS.VentaCab(Id_VentaCab)
);


CREATE TABLE INVENTARIO.MovimientoCab (
    Id_MovimientoCab      INT IDENTITY(1,1) PRIMARY KEY,
    FecRegistro           DATETIME NOT NULL DEFAULT GETDATE(),
    Id_TipoMovimiento     INT NOT NULL,
    Id_DocumentoOrigen    INT NOT NULL
);

CREATE TABLE INVENTARIO.MovimientoDet (
    Id_MovimientoDet      INT IDENTITY(1,1) PRIMARY KEY,
    Id_MovimientoCab      INT NOT NULL,
    Id_Producto           INT NOT NULL,
    Cantidad              DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (Id_MovimientoCab) REFERENCES INVENTARIO.MovimientoCab(Id_MovimientoCab)
);
