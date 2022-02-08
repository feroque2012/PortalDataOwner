using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Criptografia de serviços internos
        /// </summary>
        /// <param name="criptografa">True criptografia / False Descriptografia</param>
        /// <param name="valor">parametro a ser criptografado/descriptografado</param>
        /// <returns></returns>
        public static string CriptografiaInterna(this string value, bool criptografa)
        {
            try
            {
                MemoryStream memory = null;
                string retorno;

                try
                {
                    using (DESCryptoServiceProvider csp = new DESCryptoServiceProvider())
                    {
                        //Chave de 8 bits
                        Byte[] chave = { 42, 16, 93, 156, 78, 4, 218, 34 };
                        Byte[] vetor = { 55, 103, 246, 79, 36, 99, 167, 2 };
                        csp.Key = chave;
                        csp.IV = vetor;

                        if (criptografa)
                        {
                            memory = new MemoryStream();

                            using (CryptoStream crypto = new CryptoStream(memory, csp.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                using (StreamWriter reader = new StreamWriter(crypto))
                                {
                                    reader.WriteLine(value);
                                }
                            }

                            retorno = Convert.ToBase64String(memory.ToArray());
                        }
                        else
                        {
                            value = value.Replace(" ", "+").Replace(".", "").Replace("-", "");
                            memory = new MemoryStream(Convert.FromBase64String(value));

                            using (CryptoStream crypto = new CryptoStream(memory, csp.CreateDecryptor(), CryptoStreamMode.Read))
                            {

                                using (StreamReader reader = new StreamReader(crypto))
                                {
                                    retorno = reader.ReadLine();
                                }
                            }
                        }

                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (memory != null)
                    {
                        memory.Close();
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static string chave = "ED7A533E-5A1E-4656-AADE-A7AFDAF3";
        private static string vetorInicializacao = "D45B938FAB9D43E8";
        private static Rijndael CriarInstanciaRijndael(
           string chave, string vetorInicializacao)
        {
            if (!(chave != null &&
                  (chave.Length == 16 ||
                   chave.Length == 24 ||
                   chave.Length == 32)))
            {
                throw new Exception(
                    "A chave de criptografia deve possuir " +
                    "16, 24 ou 32 caracteres.");
            }

            if (vetorInicializacao == null ||
                vetorInicializacao.Length != 16)
            {
                throw new Exception(
                    "O vetor de inicialização deve possuir " +
                    "16 caracteres.");
            }

            Rijndael algoritmo = Rijndael.Create();
            algoritmo.Key =
                Encoding.ASCII.GetBytes(chave);
            algoritmo.IV =
                Encoding.ASCII.GetBytes(vetorInicializacao);

            return algoritmo;
        }

        public static string Encriptar(this string textoNormal)
        {

            if (String.IsNullOrWhiteSpace(textoNormal) || textoNormal == "0")
                return textoNormal;

            using (Rijndael algoritmo = CriarInstanciaRijndael(
                chave, vetorInicializacao))
            {
                ICryptoTransform encryptor =
                    algoritmo.CreateEncryptor(
                        algoritmo.Key, algoritmo.IV);

                using (MemoryStream streamResultado =
                       new MemoryStream())
                {
                    using (CryptoStream csStream = new CryptoStream(
                        streamResultado, encryptor,
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer =
                            new StreamWriter(csStream))
                        {
                            writer.Write(textoNormal);
                        }
                    }

                    return ArrayBytesToHexString(
                        streamResultado.ToArray());
                }
            }
        }

        private static string ArrayBytesToHexString(byte[] conteudo)
        {
            string[] arrayHex = Array.ConvertAll(
                conteudo, b => b.ToString("X2"));
            return string.Concat(arrayHex);
        }

        public static string Decriptar(this string textoEncriptado)
        {

            if (String.IsNullOrWhiteSpace(textoEncriptado))
            {
                throw new Exception(
                    "O conteúdo a ser decriptado não pode " +
                    "ser uma string vazia.");
            }

            if (textoEncriptado.Length % 2 != 0)
            {
                throw new Exception(
                    "O conteúdo a ser decriptado é inválido.");
            }


            using (Rijndael algoritmo = CriarInstanciaRijndael(
                chave, vetorInicializacao))
            {
                ICryptoTransform decryptor =
                    algoritmo.CreateDecryptor(
                        algoritmo.Key, algoritmo.IV);

                string textoDecriptografado = null;
                using (MemoryStream streamTextoEncriptado =
                    new MemoryStream(
                        HexStringToArrayBytes(textoEncriptado)))
                {
                    using (CryptoStream csStream = new CryptoStream(
                        streamTextoEncriptado, decryptor,
                        CryptoStreamMode.Read))
                    {
                        using (StreamReader reader =
                            new StreamReader(csStream))
                        {
                            textoDecriptografado =
                                reader.ReadToEnd();
                        }
                    }
                }

                return textoDecriptografado;
            }
        }

        private static byte[] HexStringToArrayBytes(string conteudo)
        {
            int qtdeBytesEncriptados =
                conteudo.Length / 2;
            byte[] arrayConteudoEncriptado =
                new byte[qtdeBytesEncriptados];
            for (int i = 0; i < qtdeBytesEncriptados; i++)
            {
                arrayConteudoEncriptado[i] = Convert.ToByte(
                    conteudo.Substring(i * 2, 2), 16);
            }

            return arrayConteudoEncriptado;
        }

        public static string CriptografiaSHA256(this string value)
        {
            try
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
