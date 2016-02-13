

use  BDGRPNET
GO

drop procedure SP_USUARIO_VALIDAD  

Create procedure SP_USUARIO_VALIDAD
-- SP_USUARIO_VALIDAD 'grodriguez','dcqLJukrS115YND1skWQ8ha0ng/ZNgYhfmTQ5D1ad8Q='
@login_user varchar(25) ,  @pass_user varchar(max)
AS
SELECT login_user as ResUsuario,pass_user as ResPass, dni_user as RepDNI, Nom_Rol as RedRol ,
apap_user +' '+ apam_user +' , '+ nom_user as ResNombre
FROM  TB_USUARIO_SISTEMA a , TB_ROLES b
where a.Cod_Rol=b.Cod_Rol AND login_user = @login_user AND pass_user = @pass_user
GO

drop Procedure  [dbo].[S_Genera_Codigo2]  
Create Procedure  [dbo].[S_Genera_Codigo2]  
 @nomtb varchar(50) ,@nro int output
as
declare @ano varchar(4)
 set @ano =  Convert(Varchar,year(GETDATE()))
 set @nro = 1
 if not exists (select * from Tb_Cod where  [Nombre_Tabla] = @nomtb  )
 begin
	insert into Tb_Cod values(@ano, @nro,@nomtb ) 
 end
 else 
 begin
	if exists (select * from Tb_Cod where year_cod = @ano  and    [Nombre_Tabla] = @nomtb    )
	 begin
		update  Tb_Cod set @nro = nro = nro + 1 , year_cod = @ano where [Nombre_Tabla] = @nomtb
	 end
	 else
	 begin
		update  Tb_Cod set @nro = nro =  1 , year_cod = @ano where  [Nombre_Tabla] = @nomtb
	 end
 end
 GO

  drop PROCEDURE  [dbo].[SP_INSERTAPACIENTE]
  Go
 CREATE PROCEDURE  [dbo].[SP_INSERTAPACIENTE]
/*
execute SP_INSERTAPACIENTE '458555','rodriguez','Pineda' ,'GUILLLERMO','1986-01-20'  
execute SP_INSERTAPACIENTE '','rodriguez','Pineda' ,'GUILLLERMO','1986-01-20'  
*/
@usu_numdoc varchar(250)='',@usu_apepaterno varchar(250), @usu_apematerno varchar(250), @usu_nombres varchar(200),
@usu_fechanac varchar(50)  
as 
SET NOCOUNT ON
set dateformat ymd
BEGIN  
 BEGIN TRY
	BEGIN TRAN 	 

		if(@usu_numdoc='')
		begin
			 goto  InsertaDato  
		end
		else 
		begin
			if exists (select * from TB_USUARIO_SALUD where usu_numdoc = @usu_numdoc      )
			begin
				goto ErrorTexto
 
			end
			else 
			begin
				goto  InsertaDato   	
			end
		end
goto salir  

salir:      
COMMIT TRAN              
 return                  
               
error:                  
 return 


ErrorTexto: 
		select  'Error.--El Nro de DNI '+@usu_numdoc+ ' ya se encuentra registrado' as RespText,'flase' as RespEstado,'error' as RespClass
		--COMMIT TRAN   
				if @@error > 0 goto error                  
				goto Salir 
		 
InsertaDato: 
		DECLARE  @NroCorrelativo int,  @codigo varchar(20)
		exec S_Genera_Codigo2  'TB_USUARIO_SISTEMA',@NroCorrelativo output
		set @codigo =   right(year(getdate()),2)  +  right('00000000000000000'+ LTRIM(RTRIM(@NroCorrelativo))  ,10)

		INSERT INTO [dbo].[TB_USUARIO_SALUD] ([usu_docid_codigo] ,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,[usu_fechanac],[docid_codigo], [feg_reg],usu_estado)
		values(@codigo ,  @usu_numdoc  ,UPPER(@usu_apepaterno),UPPER(@usu_apematerno) , UPPER(@usu_nombres),@usu_fechanac,1,getdate(),'1' )	
		 	  
		select 'Paciente Registrado con Exito ' as RespText,'true' as RespEstado ,'exito' as RespClass
		--DBCC CHECKIDENT ('dbo.tb_documentos', RESEED, 0); 
		--COMMIT TRAN   
  		if @@error > 0 goto error                  
				goto Salir 

 END TRY
 BEGIN CATCH 
	ROLLBACK TRAN
	--select ERROR_MESSAGE() 
	select  'Error.-- No se ha podido Registrar los datos.' as RespText,'flase' as RespEstado,'error' as RespClass
 END CATCH 
END
GO

drop Procedure [dbo].[SP_LISTA_PACIENTE]
Create Procedure [dbo].[SP_LISTA_PACIENTE]
@busqueda varchar(250) =''
as
select [usu_docid_codigo] ,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,[usu_fechanac],[docid_codigo], [feg_reg]
, [usu_docid_codigo] as CodPac ,
CASE usu_estado 
     WHEN '1' THEN 'HABILITADO'
      ELSE 'DESHABILITADO'
END 
as usu_estado

 from TB_USUARIO_SALUD
where [usu_nombres] like '%'+@busqueda+'%'
ORDER BY feg_reg DESC
GO
 
/*
USE [BDDEMO]
GO
DELETE FROM [dbo].[TB_COD]
DELETE FROM [dbo].[TB_USUARIO_SALUD]
*/
 
CREATE PROC SP_ACTUALIZAR_PWD
@login_user VARCHAR(25), @pass_user varchar(max)
AS

	if exists (select * from TB_USUARIO_SISTEMA where login_user = @login_user      )
			begin
				update TB_USUARIO_SISTEMA set pass_user = @pass_user where login_user = @login_user
				select 'Contraseña Actualizada con Exito ' as RespText,'true' as RespEstado ,'exito' as RespClass
			end
			else 
			begin
				select  'Error al Actualizar clave' as RespText,'flase' as RespEstado,'error' as RespClass	
			end


GO
 
drop Procedure [dbo].[SP_DETALLEPACIENTE] go
--- [SP_DETALLEPACIENTE] '160000000001'
Create Procedure [dbo].[SP_DETALLEPACIENTE]
@usu_numdoc varchar(250) =''
as
	select [usu_docid_codigo] as CodPac,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,
	CONVERT(VARCHAR(10),[usu_fechanac],103) as [usu_fechanac],[docid_codigo], [feg_reg],usu_estado from TB_USUARIO_SALUD
	where usu_docid_codigo  = @usu_numdoc 
	ORDER BY feg_reg DESC
GO

--- [SP_ACTUALIZAR_PACIENTE] '160000000001','14253678','vera','ramos','carlos','01/01/1950','1'
create PROC SP_ACTUALIZAR_PACIENTE
@usu_docid_codigo varchar(20)='', @usu_numdoc varchar(250)='',@usu_apepaterno varchar(250), 
@usu_apematerno varchar(250), @usu_nombres varchar(200),
@usu_fechanac varchar(50) ,@usu_estado VARCHAR(3) 
AS

	if exists (select * from TB_USUARIO_SALUD where usu_docid_codigo  = @usu_docid_codigo     )
			begin
 
			UPDATE [BDGRPNET].[dbo].[TB_USUARIO_SALUD]
		   SET [usu_docid_codigo] = @usu_docid_codigo
			  ,[usu_numdoc] = @usu_numdoc
			  ,[usu_apepaterno] = UPPER(@usu_apepaterno)
			  ,[usu_apematerno] = UPPER(@usu_apematerno)
			  ,[usu_nombres] = UPPER(@usu_nombres)
			  ,[usu_fechanac] = @usu_fechanac
			  ,[usu_estado] = @usu_estado
			where  usu_docid_codigo  = @usu_docid_codigo 
 
				
				select 'Registro Actualizada con Exito ' as RespText,'true' as RespEstado ,'exito' as RespClass
			end
			else 
			begin
				select  'Error al Actualizar clave' as RespText,'flase' as RespEstado,'error' as RespClass	
			end


GO

 
 Create View Tv_TipoEstado
 as
     select '1' as mvalor,  'HABILITADO' as mtexto
     union all
     select '0' as mvalor,  'DESHABILITADO' as mtexto
go      
Create proc SP_ListaTipoEstado
as      
select * from Tv_TipoEstado      
GO




 -- [SP_CONSULTAJSON_PACIENTE] 'gui'
alter Procedure [dbo].[SP_CONSULTAJSON_PACIENTE]
@busqueda varchar(250) =''
as
select top 15  [usu_apepaterno] +' '+[usu_apematerno] +' , '+[usu_nombres] AS nomcompleto
, [usu_docid_codigo] as Codigo  
 

 from TB_USUARIO_SALUD
where [usu_nombres] like '%'+@busqueda+'%' AND usu_estado = '1' 
ORDER BY feg_reg DESC
GO

Create Procedure [dbo].[SP_CONSULTAJSON_Producto]
@busqueda varchar(250) =''
as
select top 15  prod_descri AS nomcompleto
, cod_prod as Codigo  
 

 from dbo.TB_PRODUCTO_SERVICIO
where prod_descri like '%'+@busqueda+'%'  
 
GO