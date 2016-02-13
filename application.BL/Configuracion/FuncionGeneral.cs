using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Security.Cryptography;
using System.Configuration;
 
using System.IO;
using application.Entity;
using application.BL;

namespace application.BL.Configuracion
{
    public class FuncionGeneral : IFuncionGeneral
    {
        private string HASKEY = null;
        public FuncionGeneral()
        {
            this.HASKEY = ConfigurationManager.AppSettings["HASH_KEY"].ToString();
        }
        #region Funciones
        

        public string Encrypt(string clearText)
        {
            string EncryptionKey = HASKEY ;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        public string Decrypt(string cipherText)
        {
            string EncryptionKey = HASKEY;
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }



        //--------------------------------------------------------------------------


        public   string Encriptar_V1(  string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public   string DesEncriptar_V1(  string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


        #endregion Funciones

        public IList<RespuestaUsuario> Isvalida(Usuario ModeloUsuario)
        {
            application.BL.IUsuariosService UsuarioService = new application.BL.UsuariosService();
            ModeloUsuario.pass = this.Encrypt(ModeloUsuario.pass);
            string pass = this.Encrypt(ModeloUsuario.pass);
            IList<RespuestaUsuario> respuesta =  UsuarioService.BL_ValidaAcceso(ModeloUsuario);
            if (respuesta.Count() > 0)
            {
                string pass2 = respuesta[0].ResPass.ToString().Trim();
                if (ModeloUsuario.pass == pass2)
                {
                    return  respuesta;
                }
            }
            return null;
        }

    }
}
