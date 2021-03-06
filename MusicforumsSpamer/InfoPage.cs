﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

public class InfoPage
{

  public static string GetDatafromText(string text, string pattern)
  {
    return Regex.Match(text, pattern).Value;
  }

  public static string GetDatafromText(string text, string pattern, int fGroup)
  {
    return Regex.Match(text, pattern).Groups[fGroup].Value;
  }

  public static string Replace(string text, string pattern, string newValue)
  {
    return Regex.Replace(text, pattern, newValue);
  }
  public static void WriteSerObjectToFile(string path, object obj)
  {
    var formatter = new BinaryFormatter();
    using (var fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
    {
      formatter.Serialize(fStream, obj);
    }
  }
  public static object ReadSerObjectToFile(string path)
  {
    object obj;
    var formatter = new BinaryFormatter();
    using (var fStream = File.OpenRead(path))
    {
      obj = formatter.Deserialize(fStream);
    }
    return obj;
  }

  public static string GetPage(string url)
  {
    using (var wc = new System.Net.WebClient())
    {
      wc.Encoding = Encoding.Default;//UTF8Encoding.UTF8;
      return wc.DownloadString(url); ;
    }
  }

}
