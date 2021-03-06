﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMgmtSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Login fLogin = new Login())
            {
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(fLogin.Username, fLogin.IDuser));
                }
                else
                {
                    Application.Exit();
                }
            }
            //Application.Run(new Form1());
            //Application.Run(new Login());
        }
    }
}
