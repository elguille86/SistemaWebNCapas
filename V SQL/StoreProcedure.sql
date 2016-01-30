

use  BDDEMO
GO

drop procedure SP_USUARIO_VALIDAD  

Create procedure SP_USUARIO_VALIDAD
-- SP_USUARIO_VALIDAD 'grodriguez','12345'
@login_user varchar(25) ,  @pass_user varchar(18)
AS
SELECT login_user as ResUsuario,pass_user as ResPass, dni_user as RepDNI, Nom_Rol as RedRol FROM  TB_USUARIO_SISTEMA a , TB_ROLES b
where a.Cod_Rol=b.Cod_Rol AND login_user = @login_user AND pass_user = @pass_user
GO


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
		select  'Error.--El Nro de DNI '+@usu_numdoc+ ' ya se encuentra registrado' as RespText,'flase' as RespEstado,'_error' as RespClass
		--COMMIT TRAN   
				if @@error > 0 goto error                  
				goto Salir 
		 
InsertaDato: 
		DECLARE  @NroCorrelativo int,  @codigo varchar(20)
		exec S_Genera_Codigo2  'TB_USUARIO_SISTEMA',@NroCorrelativo output
		set @codigo =   right(year(getdate()),2)  +  right('00000000000000000'+ LTRIM(RTRIM(@NroCorrelativo))  ,10)

		INSERT INTO [dbo].[TB_USUARIO_SALUD] ([usu_docid_codigo] ,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,[usu_fechanac],[docid_codigo], [feg_reg])
		values(@codigo , @usu_numdoc ,@usu_apepaterno,@usu_apematerno , @usu_nombres,@usu_fechanac,1,getdate() )	
		 	  
		select 'Paciente Registrado con Exito ' as RespText,'true' as RespEstado ,'_mensaje' as RespClass
		--DBCC CHECKIDENT ('dbo.tb_documentos', RESEED, 0); 
		--COMMIT TRAN   
  		if @@error > 0 goto error                  
				goto Salir 

		 


 END TRY
 BEGIN CATCH 
	ROLLBACK TRAN
	--select ERROR_MESSAGE() 
	select  'Error.-- No se ha podido Registrar los datos.' as RespText,'flase' as RespEstado,'_error' as RespClass
 END CATCH 
END
GO

 
Create Procedure [dbo].[SP_LISTA_PACIENTE]
as
select [usu_docid_codigo] ,[usu_numdoc] ,[usu_apepaterno] ,[usu_apematerno]  ,[usu_nombres] ,[usu_fechanac],[docid_codigo], [feg_reg] from TB_USUARIO_SALUD
ORDER BY feg_reg DESC
GO

/*
USE [BDDEMO]
GO
DELETE FROM [dbo].[TB_COD]
DELETE FROM [dbo].[TB_USUARIO_SALUD]
*/