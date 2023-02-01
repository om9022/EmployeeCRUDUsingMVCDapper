using Employeemodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class CryptographyController : Controller
    {
        // GET: Cryptography
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EncryptText(string Submit, string PlainText, string cipherText)
        {
            EnryptDecryptModel md = new EnryptDecryptModel();
          
            if(Submit == "Encrypt")
            {
                md.PlainText = this.Encrypt(PlainText);
                return Json(md.PlainText, JsonRequestBehavior.AllowGet);

            }else if(Submit == "Decrypt")
            {
                md.cipherText = this.Decrypt(cipherText);
                return Json(md.cipherText, JsonRequestBehavior.AllowGet);

            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        private string Encrypt(string PlainText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            //Encoding.Unicode.GetBytes() == Encodes a set of characters into a sequence of bytes.
            byte[] clearBytes = Encoding.Unicode.GetBytes(PlainText);

            //Aes = Represents the abstract base class from which all implementations of the Advanced Encryption Standard (AES) must inherit.
            using (Aes encryptor = Aes.Create())
            {
                //Rfc2898DeriveBytes Implements password-based key derivation functionality, PBKDF2, by using a pseudo-random number generator based on HMACSHA1.
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                
                //Key ==Gets or sets the secret key for the symmetric algorithm.
                // Returns:The secret key to use for the symmetric algorithm.
                encryptor.Key = pdb.GetBytes(32);

                //IV==Gets or sets the initialization vector (System.Security.Cryptography.SymmetricAlgorithm.IV) for the symmetric algorithm.
               // Returns:The initialization vector.

                encryptor.IV = pdb.GetBytes(16);
                encryptor.Padding = PaddingMode.PKCS7;
                encryptor.KeySize = 256;
                using (MemoryStream ms = new MemoryStream())
                {
                    //CryptoStream Defines a stream that links data streams to cryptographic transformations.
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    PlainText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return PlainText;
        }

        //private string Decrypt(string cipherText)
        //{
        //    string encryptionKey = "MAKV2SPBNI99212";
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);

        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

        //        encryptor.Key = pdb.GetBytes(16);
        //        encryptor.IV = pdb.GetBytes(16);
        //        encryptor.Padding = PaddingMode.PKCS7;
        //        encryptor.KeySize = 128;

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);

        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}


        private string Decrypt(string cipherText)
        {

            //byte[] rawPlaintext = Encoding.Unicode.GetBytes(cipherText);
            byte[] rawPlaintext = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("MAKV2SPBNI99212", new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                aes.Key = pdb.GetBytes(16);
                aes.IV = pdb.GetBytes(16);
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;
                aes.Padding = PaddingMode.PKCS7;
                //aes.KeySize = 128;          // in bits
                //aes.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                //aes.IV = new byte[128 / 8];   // AES needs a 16-byte IV
                                              // Should set Key and IV here.  Good approach: derive them from 
                                              // a password via Cryptography.Rfc2898DeriveBytes 
                                              // byte[] cipherTextByte = null;

                byte[] cipherTextByte = null;
                byte[] plainText = null;


                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(rawPlaintext, 0, rawPlaintext.Length);
                    }

                    cipherTextByte = ms.ToArray();
                }




                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherTextByte, 0, cipherTextByte.Length);
                    }

                    plainText = ms.ToArray();
                }
                string s = Encoding.Unicode.GetString(plainText);
                return s;
            }
        }
    }
}