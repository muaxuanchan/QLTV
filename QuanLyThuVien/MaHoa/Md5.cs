﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.MaHoa
{
  public class Md5
  {

    static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

    public static string Encrypt(string text)
    {
      using (var md5 = new MD5CryptoServiceProvider())
      {
        using (var tdes = new TripleDESCryptoServiceProvider())
        {
          tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
          tdes.Mode = CipherMode.ECB;
          tdes.Padding = PaddingMode.PKCS7;

          using (var transform = tdes.CreateEncryptor())
          {
            byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
            byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
            return Convert.ToBase64String(bytes, 0, bytes.Length);
          }
        }
      }
    }
  }
}
