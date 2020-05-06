﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;
using Xamarin.Forms;

[assembly: Dependency(typeof(CharacterApp.Droid.HashService))]
namespace CharacterApp.Droid
{
    class HashService : IHashService
    {

        public string CreateMd5Hash(string input)
        {
            var md5 = MessageDigest.GetInstance("MD5");
            var inputBytes = new Java.Lang.String(input).GetBytes();
            md5.Update(inputBytes);
            var hashed = md5.Digest();

            var hex = new StringBuilder(hashed.Length * 2);
            foreach (var b in hashed)
                hex.Append($"{b:x2}");

            var result = hex.ToString();

            return result;
        }
    }
}