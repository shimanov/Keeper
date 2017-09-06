﻿using ConsoleApp1.Classes.Base;
using System;
using System.Threading;

namespace ConsoleApp1.Classes
{
    public class ProcessBar : IProcessBar
    {
        public void PBar()
        {
            Console.WriteLine("Службы будут перезапущены через 5 минут");
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 1);
            string symbol = "█";
            Console.Write(symbol);

            for (int i = 0; i <= 8; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    Console.Write(symbol);
                }
                Thread.Sleep(60000);
            }
        }
    }
}