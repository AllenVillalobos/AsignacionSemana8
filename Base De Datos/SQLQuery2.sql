USE VeterinariaSOS;
GO

-- Utilitario de errores
DECLARE @__ignore INT;
-- Usuarios
CREATE OR ALTER PROCEDURE dbo.spListaUsuarios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT USU_ID,USU_USUARIO,USU_CLAVE,USU_ESTADO,USU_ADICIONADO_POR,USU_FECHA_ADICION,USU_MODIFICADO_POR,USU_FECHA_MODIFICACION
    FROM dbo.VT_USUARIOS;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spLogin
(
    @pNombreUsuario NVARCHAR(15),
    @pContra        NVARCHAR(10)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (
        SELECT 1 FROM dbo.VT_USUARIOS
        WHERE USU_USUARIO=@pNombreUsuario AND USU_CLAVE=@pContra AND USU_ESTADO='A'
    )
    BEGIN
        RAISERROR('Usuario no Encontrado',11,1);
        RETURN;
    END;
    SELECT USU_USUARIO
    FROM dbo.VT_USUARIOS
    WHERE USU_USUARIO=@pNombreUsuario AND USU_CLAVE=@pContra AND USU_ESTADO='A';
END;
GO

-- Propietarios
CREATE OR ALTER PROCEDURE dbo.spInsertarPropietario
(
    @pNumeroIdentificacion VARCHAR(15),
    @pPrimerNombre         VARCHAR(25),
    @pSegundoNombre        VARCHAR(25),
    @pPrimerApellido       VARCHAR(25),
    @pSegundoApellido      VARCHAR(25),
    @pTelefonoCelular      VARCHAR(8),
    @pCorreoElectronico    VARCHAR(150),
    @pAdicionadoPor        VARCHAR(15),
    @pFechaAdicion         DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.VT_PROPIETARIOS WHERE PRO_IDENTIFICACION=@pNumeroIdentificacion)
    BEGIN
        RAISERROR('Identificacion Ya Fue Registrada',11,1);
        RETURN;
    END;
    INSERT INTO dbo.VT_PROPIETARIOS
    (PRO_IDENTIFICACION,PRO_PRIMER_NOMBRE,PRO_SEGUNDO_NOMBRE,PRO_PRIMER_APELLIDO,PRO_SEGUNDO_APELLIDO,
     PRO_TELEFONO,PRO_CORREO,PRO_ADICIONADO_POR,PRO_FECHA_ADICION)
    VALUES
    (@pNumeroIdentificacion,@pPrimerNombre,@pSegundoNombre,@pPrimerApellido,@pSegundoApellido,
     @pTelefonoCelular,@pCorreoElectronico,@pAdicionadoPor,@pFechaAdicion);
END;
GO

CREATE OR ALTER PROCEDURE dbo.spConsultarPropietario
(
    @pNumeroIdentificacion VARCHAR(15)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_PROPIETARIOS WHERE PRO_IDENTIFICACION=@pNumeroIdentificacion)
    BEGIN
        RAISERROR('Propietario No Encontrado',11,1);
        RETURN;
    END;
    SELECT PRO_ID, PRO_IDENTIFICACION,
           PRO_PRIMER_NOMBRE, PRO_SEGUNDO_NOMBRE,
           PRO_PRIMER_APELLIDO, PRO_SEGUNDO_APELLIDO,
           PRO_TELEFONO, PRO_CORREO,
           PRO_ADICIONADO_POR, PRO_FECHA_ADICION,
           PRO_MODIFICADO_POR, PRO_FECHA_MODIFICACION
    FROM dbo.VT_PROPIETARIOS
    WHERE PRO_IDENTIFICACION=@pNumeroIdentificacion;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spListarPropietarios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PRO_ID, PRO_IDENTIFICACION, PRO_PRIMER_NOMBRE, PRO_SEGUNDO_NOMBRE,
           PRO_PRIMER_APELLIDO, PRO_SEGUNDO_APELLIDO, PRO_TELEFONO, PRO_CORREO,
           PRO_ADICIONADO_POR, PRO_FECHA_ADICION, PRO_MODIFICADO_POR, PRO_FECHA_MODIFICACION
    FROM dbo.VT_PROPIETARIOS;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spActualizarPropietario
(
    @pNumeroIdentificacion VARCHAR(15),
    @pPrimerNombre         VARCHAR(25),
    @pSegundoNombre        VARCHAR(25),
    @pPrimerApellido       VARCHAR(25),
    @pSegundoApellido      VARCHAR(25),
    @pTelefonoCelular      VARCHAR(8),
    @pCorreoElectronico    VARCHAR(150),
    @pModificadoPor        VARCHAR(15),
    @pFechaModificacion    DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_PROPIETARIOS WHERE PRO_IDENTIFICACION=@pNumeroIdentificacion)
    BEGIN
        RAISERROR('Propietario No encontrado',11,1);
        RETURN;
    END;
    UPDATE dbo.VT_PROPIETARIOS
    SET PRO_PRIMER_NOMBRE=@pPrimerNombre,
        PRO_SEGUNDO_NOMBRE=@pSegundoNombre,
        PRO_PRIMER_APELLIDO=@pPrimerApellido,
        PRO_SEGUNDO_APELLIDO=@pSegundoApellido,
        PRO_TELEFONO=@pTelefonoCelular,
        PRO_CORREO=@pCorreoElectronico,
        PRO_MODIFICADO_POR=@pModificadoPor,
        PRO_FECHA_MODIFICACION=@pFechaModificacion
    WHERE PRO_IDENTIFICACION=@pNumeroIdentificacion;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spEliminarPropietario
(
    @IdPropietario INT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.VT_MASCOTAS WHERE MAS_PRO_ID=@IdPropietario)
    BEGIN
        RAISERROR('No se puede eliminar. Existen mascotas asociadas al propietario', 11, 1);
        RETURN;
    END;
    DELETE FROM dbo.VT_PROPIETARIOS WHERE PRO_ID=@IdPropietario;
    IF @@ROWCOUNT=0 RAISERROR('No existe el IdPropietario indicado',11,1);
END;
GO

-- Mascotas
CREATE OR ALTER PROCEDURE dbo.spInsertarMascota
(
    @pNombre               VARCHAR(15),
    @pFechaNacimiento      DATE,
    @pSexo                 VARCHAR(1),
    @pPeso                 NUMERIC(5,2),
    @pAlergias             VARCHAR(150),
    @pIdentificadorPropietario INT,
    @pAdicionadoPor        VARCHAR(15),
    @pFechaAdicion         DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_PROPIETARIOS WHERE PRO_ID=@pIdentificadorPropietario)
    BEGIN
        RAISERROR('Propietario No Registrado',11,1);
        RETURN;
    END;
    INSERT INTO dbo.VT_MASCOTAS
    (MAS_NOMBRE,MAS_FECHA_NACIMIENTO,MAS_SEXO,MAS_PESO,MAS_ALERGIAS,MAS_PRO_ID,MAS_ADICIONADO_POR,MAS_FECHA_ADICION)
    VALUES
    (@pNombre,@pFechaNacimiento,@pSexo,@pPeso,@pAlergias,@pIdentificadorPropietario,@pAdicionadoPor,@pFechaAdicion);

    SELECT SCOPE_IDENTITY() AS NuevoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spBuscarMascotaPorPropietarioNombre
(
    @pNombre                VARCHAR(15),
    @pIdentificadorPropietario INT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_MASCOTAS WHERE MAS_PRO_ID=@pIdentificadorPropietario AND MAS_NOMBRE=@pNombre)
    BEGIN
        RAISERROR('Mascota No Encontrada',11,1);
        RETURN;
    END;
    SELECT MAS_ID
    FROM dbo.VT_MASCOTAS
    WHERE MAS_PRO_ID=@pIdentificadorPropietario AND MAS_NOMBRE=@pNombre;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spBuscarMascotaPorIdentificador
(
    @pIdentificadorMascota INT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_MASCOTAS WHERE MAS_ID=@pIdentificadorMascota)
    BEGIN
        RAISERROR('Mascota No Encontrada',11,1);
        RETURN;
    END;
    SELECT MAS_ID, MAS_NOMBRE, MAS_PESO, MAS_SEXO,
           CONVERT(DATE, MAS_FECHA_NACIMIENTO) AS MAS_FECHA_NACIMIENTO,
           MAS_ALERGIAS
    FROM dbo.VT_MASCOTAS
    WHERE MAS_ID=@pIdentificadorMascota;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spListarMascotas
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MAS_ID, MAS_NOMBRE, MAS_FECHA_NACIMIENTO, MAS_SEXO, MAS_PESO, MAS_ALERGIAS,
           MAS_PRO_ID, MAS_ADICIONADO_POR, MAS_FECHA_ADICION, MAS_MODIFICADO_POR, MAS_FECHA_MODIFICACION
    FROM dbo.VT_MASCOTAS;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spActualizarMascota
(
    @pIdentificadorMascota INT,
    @pNombre               VARCHAR(15),
    @pPeso                 NUMERIC(5,2),
    @pAlergias             VARCHAR(150),
    @pModificadoPor        VARCHAR(15),
    @pFechaModificacion    DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_MASCOTAS WHERE MAS_ID=@pIdentificadorMascota)
    BEGIN
        RAISERROR('Mascota No encontrada',11,1);
        RETURN;
    END;
    UPDATE dbo.VT_MASCOTAS
    SET MAS_NOMBRE=@pNombre,
        MAS_PESO=@pPeso,
        MAS_ALERGIAS=@pAlergias,
        MAS_MODIFICADO_POR=@pModificadoPor,
        MAS_FECHA_MODIFICACION=@pFechaModificacion
    WHERE MAS_ID=@pIdentificadorMascota;

    SELECT @pIdentificadorMascota AS IdActualizado;
END;
GO

-- Hoja clínica nuevos SPs
CREATE OR ALTER PROCEDURE dbo.spCrearHojaClinica
(
    @pFechaAtencion DATETIME,
    @pSintomas      VARCHAR(150),
    @pDiagnostico   VARCHAR(150),
    @pTratamiento   VARCHAR(150),
    @pIdMascota     INT,
    @pAdicionadoPor VARCHAR(15),
    @IdGenerado     INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_MASCOTAS WHERE MAS_ID=@pIdMascota)
    BEGIN
        RAISERROR('Mascota No Encontrada',11,1);
        RETURN;
    END;
    INSERT INTO dbo.VT_HOJA
    (HOJ_FECHA_ATENCION,HOJ_SINTOMAS,HOJ_DIAGNOSTICO,HOJ_TRATAMIENTO,HOJ_MAS_ID,HOJ_ADICIONADO_POR,HOJ_FECHA_ADICION)
    VALUES
    (@pFechaAtencion,@pSintomas,@pDiagnostico,@pTratamiento,@pIdMascota,@pAdicionadoPor,GETDATE());

    SET @IdGenerado = CAST(SCOPE_IDENTITY() AS INT);
END;
GO

CREATE OR ALTER PROCEDURE dbo.spListarHojaClinicaPorMascota
(
    @pIdMascota INT
)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        HOJ_ID                AS HojaClinicaId,
        HOJ_MAS_ID            AS MascotaId,
        HOJ_FECHA_ATENCION    AS FechaAtencion,
        HOJ_SINTOMAS          AS Sintomas,
        HOJ_DIAGNOSTICO       AS Diagnostico,
        HOJ_TRATAMIENTO       AS Tratamiento,
        HOJ_ADICIONADO_POR    AS AdicionadoPor,
        HOJ_FECHA_ADICION     AS FechaAdicion,
        HOJ_MODIFICADO_POR    AS ModificadoPor,
        HOJ_FECHA_MODIFICACION AS FechaModificacion
    FROM dbo.VT_HOJA
    WHERE HOJ_MAS_ID=@pIdMascota
    ORDER BY HOJ_FECHA_ATENCION DESC, HOJ_ID DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spObtenerHojaClinica
(
    @HojaClinicaId INT
)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        HOJ_ID                AS HojaClinicaId,
        HOJ_MAS_ID            AS MascotaId,
        HOJ_FECHA_ATENCION    AS FechaAtencion,
        HOJ_SINTOMAS          AS Sintomas,
        HOJ_DIAGNOSTICO       AS Diagnostico,
        HOJ_TRATAMIENTO       AS Tratamiento,
        HOJ_ADICIONADO_POR    AS AdicionadoPor,
        HOJ_FECHA_ADICION     AS FechaAdicion,
        HOJ_MODIFICADO_POR    AS ModificadoPor,
        HOJ_FECHA_MODIFICACION AS FechaModificacion
    FROM dbo.VT_HOJA
    WHERE HOJ_ID=@HojaClinicaId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spActualizarHojaClinica
(
    @HojaClinicaId  INT,
    @MascotaId      INT,
    @FechaAtencion  DATETIME,
    @Sintomas       VARCHAR(150),
    @Diagnostico    VARCHAR(150),
    @Tratamiento    VARCHAR(150),
    @ModificadoPor  VARCHAR(15)
)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.VT_HOJA WHERE HOJ_ID=@HojaClinicaId)
    BEGIN
        RAISERROR('No existe el IdAtencion indicado',11,1);
        RETURN;
    END;
    UPDATE dbo.VT_HOJA
    SET HOJ_MAS_ID=@MascotaId,
        HOJ_FECHA_ATENCION=@FechaAtencion,
        HOJ_SINTOMAS=@Sintomas,
        HOJ_DIAGNOSTICO=@Diagnostico,
        HOJ_TRATAMIENTO=@Tratamiento,
        HOJ_MODIFICADO_POR=@ModificadoPor,
        HOJ_FECHA_MODIFICACION=GETDATE()
    WHERE HOJ_ID=@HojaClinicaId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spEliminarHojaClinica
(
    @HojaClinicaId INT
)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.VT_HOJA WHERE HOJ_ID=@HojaClinicaId;
    IF @@ROWCOUNT=0 RAISERROR('No existe el IdAtencion indicado',11,1);
END;
GO
