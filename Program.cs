﻿using EnsoulSharp.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EnsoulSharp;
using EnsoulSharp.SDK.MenuUI;

namespace FatalityLoader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnLoad;
        }

        private static void OnLoad()
        {
            LoadAssembly("https://github.com/AkaneV2/Toxic-Suit/raw/main/Fatality.exe", "loader");
        }

        private static void LoadAssembly(string line, string type)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                byte[] load = new System.Net.WebClient().DownloadData(line);
                Assembly assembly = Assembly.Load(load);
                if (assembly != null ) 
                {
                    if (assembly.EntryPoint != null)
                    {
                        assembly.EntryPoint.Invoke(null, new object[]
                        {
                            new string[1]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
