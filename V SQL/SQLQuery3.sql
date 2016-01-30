

 

alter procedure SP_USUARIO_VALIDAD
-- SP_USUARIO_VALIDAD 'grodriguez','12345'
@login_user varchar(25) ,  @pass_user varchar(18)
AS
SELECT login_user as ResUsuario,pass_user as ResPass, dni_user as RepDNI, Nom_Rol as RedRol FROM  TB_USUARIO_SISTEMA a , TB_ROLES b
where a.Cod_Rol=b.Cod_Rol AND login_user = @login_user AND pass_user = @pass_user
GO