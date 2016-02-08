

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

		INSERT INTO [dbo].[TB_USUARIO_SALUD] ([usu_docid_codigo] ,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,[usu_fechanac],[docid_codigo], [feg_reg])
		values(@codigo ,  @usu_numdoc  ,UPPER(@usu_apepaterno),UPPER(@usu_apematerno) , UPPER(@usu_nombres),@usu_fechanac,1,getdate() )	
		 	  
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
select [usu_docid_codigo] ,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,[usu_fechanac],[docid_codigo], [feg_reg] from TB_USUARIO_SALUD
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