GO
CREATE PROCEDURE spListaUsuarios
AS
BEGIN 
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY 
    SELECT USU_ID,USU_USUARIO,USU_CLAVE,USU_ESTADO, USU_ADICIONADO_POR,USU_FECHA_ADICION,USU_MODIFICADO_POR,USU_FECHA_MODIFICACION
	FROM VT_USUARIOS
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError=ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;





GO
CREATE PROCEDURE spLogin
(
@pNombreUsuario NVARCHAR(15),
@pContra NVARCHAR(10)
)
AS
BEGIN 
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY 
    -- Verifica si el usuario con la contraseña y estado 'A' (activo) existe
    IF NOT EXISTS (
        SELECT USU_USUARIO FROM VT_USUARIOS
        WHERE USU_USUARIO = @pNombreUsuario AND USU_CLAVE = @pContra AND USU_ESTADO = 'A'
    )
    BEGIN 
        RAISERROR('Usuario no Encontrado',11,1);
        RETURN;
    END;
    
    -- Si existe, lo retorna
    SELECT USU_USUARIO FROM VT_USUARIOS
    WHERE USU_USUARIO = @pNombreUsuario AND USU_CLAVE = @pContra AND USU_ESTADO = 'A';
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError=ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;



GO
-- Procedimiento para crear una hoja clínica para una mascota
CREATE PROCEDURE spCrearHojaClinica
(
@pFechaAdiccion NVARCHAR(150),
@pSintomas Varchar(150),
@pDiagnostico Varchar(150),
@pTratamiento Varchar(150),
@pIdMascota INT,
@pAdicionadoPor Varchar(15)
)
AS
BEGIN
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY 
    -- Inserta una nueva hoja clínica con la fecha indicada como atención y fecha de adición
    INSERT INTO VT_HOJA (
        HOJ_FECHA_ATENCION, HOJ_SINTOMAS, HOJ_DIAGNOSTICO, 
        HOJ_TRATAMIENTO, HOJ_MAS_ID, HOJ_ADICIONADO_POR, HOJ_FECHA_ADICION
    )
    VALUES (
        CONVERT(DATETIME, @pFechaAdiccion, 103), @pSintomas, @pDiagnostico, 
        @pTratamiento, @pIdMascota, @pAdicionadoPor, CONVERT(datetime,@pFechaAdiccion,103)
    );
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(), @SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;



GO
-- Procedimiento para insertar un nuevo propietario
CREATE PROCEDURE spInsertarPropietario
(
@pNumeroIdentificacion Varchar(15),
@pPrimerNombre Varchar(25),
@pSegundoNombre Varchar(25),
@pPrimerApellido Varchar(25),
@pSegundoApellido Varchar(25),
@pTelefonoCelular Varchar(8),
@pCorreoElectronico Varchar(150),
@pAdicionadoPor Varchar(15),
@pFechaAdicion NVARCHAR (50)
)
AS
BEGIN
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica que el propietario no esté ya registrado
    IF EXISTS (SELECT 1 FROM VT_PROPIETARIOS WHERE PRO_IDENTIFICACION = @pNumeroIdentificacion)
    BEGIN 
        RAISERROR('Identificacion Ya Fue Registrada',11,1);
        RETURN;
    END
    -- Inserta el nuevo propietario
    INSERT INTO VT_PROPIETARIOS (
        PRO_IDENTIFICACION, PRO_PRIMER_NOMBRE, PRO_SEGUNDO_NOMBRE, 
        PRO_PRIMER_APELLIDO, PRO_SEGUNDO_APELLIDO, PRO_TELEFONO, 
        PRO_CORREO, PRO_ADICIONADO_POR, PRO_FECHA_ADICION
    )
    VALUES (
        @pNumeroIdentificacion, @pPrimerNombre, @pSegundoNombre, 
        @pPrimerApellido, @pSegundoApellido, @pTelefonoCelular, 
        @pCorreoElectronico, @pAdicionadoPor, CONVERT(datetime, @pFechaAdicion, 103)
    )
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError=ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;




GO
-- Procedimiento para consultar un propietario por identificación
CREATE PROCEDURE spConsultarPopietario
(
@pNumeroIdentificacion Varchar(15)
)
AS
BEGIN 
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica si el propietario existe
    IF NOT EXISTS (SELECT 1 FROM  VT_PROPIETARIOS WHERE PRO_IDENTIFICACION = @pNumeroIdentificacion)
    BEGIN
        RAISERROR('Propietario No Encontrado',11,1);
        RETURN;
    END
    -- Devuelve los datos del propietario
    SELECT PRO_ID, PRO_IDENTIFICACION, 
           PRO_PRIMER_NOMBRE, PRO_PRIMER_APELLIDO, 
           PRO_SEGUNDO_APELLIDO, PRO_TELEFONO, PRO_CORREO 
    FROM VT_PROPIETARIOS
    WHERE PRO_IDENTIFICACION = @pNumeroIdentificacion;
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;


GO
-- Procedimiento para consultar un propietario por identificación
CREATE PROCEDURE spListarPopietarios
AS
BEGIN 
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Devuelve los datos del propietario
    SELECT  PRO_ID,  
PRO_IDENTIFICACION,  
PRO_PRIMER_NOMBRE,  
PRO_SEGUNDO_NOMBRE,  
PRO_PRIMER_APELLIDO,  
PRO_SEGUNDO_APELLIDO,  
PRO_TELEFONO,  
PRO_CORREO,  
PRO_ADICIONADO_POR,  
PRO_FECHA_ADICION,  
PRO_MODIFICADO_POR,  
PRO_FECHA_MODIFICACION
    FROM VT_PROPIETARIOS
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;




GO
-- Procedimiento para actualizar los datos de un propietario
CREATE PROCEDURE spActualizarPropietario
(
@pNumeroIdentificacion Varchar(15),
@pPrimerNombre Varchar(25),
@pPrimerApellido Varchar(25),
@pSegundoApellido Varchar(25),
@pTelefonoCelular Varchar(8),
@pCorreoElectronico Varchar(150),
@pModificadoPor Varchar(15),
@pFechaModificacion NVARCHAR(50)
)
AS
BEGIN
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica si el propietario existe
    IF NOT EXISTS (SELECT 1 FROM VT_PROPIETARIOS WHERE PRO_IDENTIFICACION = @pNumeroIdentificacion)
    BEGIN 
        RAISERROR('Propietario No encontrado',11,1);
        RETURN;
    END
    -- Actualiza la información del propietario
    UPDATE VT_PROPIETARIOS
    SET
        PRO_PRIMER_NOMBRE = @pPrimerNombre,
        PRO_PRIMER_APELLIDO = @pPrimerApellido,
        PRO_SEGUNDO_APELLIDO = @pSegundoApellido,
        PRO_TELEFONO = @pTelefonoCelular,
        PRO_CORREO = @pCorreoElectronico,
        PRO_MODIFICADO_POR = @pModificadoPor,
        PRO_FECHA_MODIFICACION = CONVERT(datetime, @pFechaModificacion, 103)
    WHERE PRO_IDENTIFICACION = @pNumeroIdentificacion;
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError=ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;





GO
-- Procedimiento para insertar una nueva mascota
CREATE PROCEDURE spInsertarMascota
(
@pNombre Varchar(15),
@pFechaNacimiento NVARCHAR(50),
@pSexo Varchar(1),
@pPeso Numeric(5,2),
@pAlergias Varchar(150),
@pIdentificadorPropietario Int,
@pAdicionadoPor Varchar(15),
@pFechaAdicion NVARCHAR(50)
)
AS
BEGIN 
SET NOCOUNT ON;
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica si el propietario existe
    IF NOT  EXISTS (SELECT 1 FROM VT_PROPIETARIOS WHERE PRO_ID = @pIdentificadorPropietario)
    BEGIN 
        RAISERROR('Propietario No Registrado',11,1);
        RETURN;
    END
    -- Inserta la nueva mascota
    INSERT INTO VT_MASCOTAS (
        MAS_NOMBRE, MAS_FECHA_NACIMIENTO, MAS_SEXO, MAS_PESO, 
        MAS_ALERGIAS, MAS_PRO_ID, MAS_ADICIONADO_POR, MAS_FECHA_ADICION
    )
    VALUES (
        @pNombre, CONVERT(datetime, @pFechaNacimiento, 103), @pSexo, @pPeso, 
        @pAlergias, @pIdentificadorPropietario, @pAdicionadoPor, CONVERT(datetime, @pFechaAdicion, 103)
    );

	SELECT SCOPE_IDENTITY() AS NuevoID;
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError=ERROR_MESSAGE(),@SeveidaError=ERROR_SEVERITY(),@EstadoError=ERROR_STATE();
    RAISERROR(@MessaError,@SeveidaError,@EstadoError);
END CATCH
END;




GO
-- Procedimiento para buscar una mascota por nombre y propietario
CREATE PROCEDURE spBuscarMascotaPorPropietarioNombre
(
@pNombre Varchar(15),
@pIdentificadorPropietario Int
)
AS
BEGIN 
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica si la mascota existe
    IF NOT EXISTS (
        SELECT 1 FROM VT_MASCOTAS 
        WHERE MAS_PRO_ID = @pIdentificadorPropietario AND MAS_NOMBRE = @pNombre
    )
    BEGIN
        RAISERROR('Mascota No Encontrada',11,1);
        RETURN;
    END
    -- Devuelve el ID de la mascota
    SELECT MAS_ID
    FROM VT_MASCOTAS
    WHERE MAS_PRO_ID = @pIdentificadorPropietario AND MAS_NOMBRE = @pNombre;
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(), @SeveidaError = ERROR_SEVERITY(), @EstadoError = ERROR_STATE();
    RAISERROR(@MessaError, @SeveidaError, @EstadoError);
END CATCH
END;

select * from VT_MASCOTAS;





GO
-- Procedimiento para buscar una mascota por su identificador
CREATE PROCEDURE spBuscarMascotaPorIdentificador
(
@pIdentificadorMascota INT
)
AS
BEGIN
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica si la mascota existe
    IF NOT EXISTS (SELECT 1 FROM VT_MASCOTAS WHERE MAS_ID = @pIdentificadorMascota)
    BEGIN
        RAISERROR('Mascota No Encontrada',11,1);
        RETURN;
    END
    -- Devuelve los datos principales de la mascota
    SELECT 
        MAS_ID, MAS_NOMBRE, MAS_PESO, MAS_SEXO, 
        CONVERT(DATE, MAS_FECHA_NACIMIENTO) as "MAS_FECHA_NACIMIENTO"
		, MAS_ALERGIAS
    FROM VT_MASCOTAS
    WHERE MAS_ID = @pIdentificadorMascota;
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(), @SeveidaError = ERROR_SEVERITY(), @EstadoError = ERROR_STATE();
    RAISERROR(@MessaError, @SeveidaError, @EstadoError);
END CATCH
END;



GO
-- Procedimiento para buscar una mascota por su identificador
CREATE PROCEDURE spListarMascotas
AS
BEGIN
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    SELECT MAS_ID, MAS_NOMBRE, MAS_FECHA_NACIMIENTO, MAS_SEXO, MAS_PESO, MAS_ALERGIAS, MAS_PRO_ID, MAS_ADICIONADO_POR, MAS_FECHA_ADICION, MAS_MODIFICADO_POR, MAS_FECHA_MODIFICACION
    FROM VT_MASCOTAS
END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(), @SeveidaError = ERROR_SEVERITY(), @EstadoError = ERROR_STATE();
    RAISERROR(@MessaError, @SeveidaError, @EstadoError);
END CATCH
END;



GO
-- Procedimiento para actualizar los datos de una mascota
CREATE PROCEDURE spActualizarMascota
(
@pIdentificadorMascota INT,
@pNombre Varchar(15),
@pPeso Numeric(5,2),
@pAlergias Varchar(150),
@pModificadoPor Varchar(15),
@pFechaModificacion NVARCHAR(50)
)
AS
BEGIN 
SET NOCOUNT ON;
DECLARE @MessaError  VARCHAR(100);
DECLARE @SeveidaError INT;
DECLARE @EstadoError INT;
BEGIN TRY
    -- Verifica si la mascota existe
    IF NOT EXISTS (SELECT 1 FROM VT_MASCOTAS WHERE MAS_ID = @pIdentificadorMascota)
    BEGIN 
        RAISERROR('Mascota No encontrada',11,1);
        RETURN;
    END
    -- Actualiza los datos de la mascota
    UPDATE VT_MASCOTAS
    SET
        MAS_NOMBRE = @pNombre,
        MAS_PESO = @pPeso,
        MAS_ALERGIAS = @pAlergias,
        MAS_MODIFICADO_POR = @pModificadoPor,
        MAS_FECHA_MODIFICACION = CONVERT(datetime, @pFechaModificacion, 103)
    WHERE MAS_ID = @pIdentificadorMascota;

	SELECT @pIdentificadorMascota AS IdActualizado;

END TRY
BEGIN CATCH
    -- Manejo de errores
    SELECT @MessaError = ERROR_MESSAGE(), @SeveidaError = ERROR_SEVERITY(), @EstadoError = ERROR_STATE();
    RAISERROR(@MessaError, @SeveidaError, @EstadoError);
END CATCH
END;