﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MusicforumsSpamer
{
    public class UserInfo2
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    class UserInfoReader2
    {

        private static UserInfo2 userInfo;
        public static UserInfo2 Info
        {
            get
            {
                if (userInfo == null)
                {
                    userInfo = ReadUserInfo("info.txt");
                }
                return userInfo;
            }
        }
        public static UserInfo2 ReadUserInfo(string path)
        {
            string text;
            using (TextReader reader = new StreamReader(path,Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }
            UserInfo2 user = new UserInfo2();

            user.Login = GetValueForName(text, "login");
            user.Password = GetValueForName(text, "password");
            user.Title = GetValueForName(text, "title");
            user.Body = GetValueForName(text, "body");
            return user;
        }

        private static string GetValueForName(string text, string nameField)
        {
            string result = InfoPage.GetDatafromText(text, "" + nameField + "=\"(.+?)\"", 1);
            return result;
        }
    }
}