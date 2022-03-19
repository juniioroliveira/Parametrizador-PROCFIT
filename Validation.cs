using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Parametrizador_PROCFIT
{
    internal class Validation
    {
        //Método da API

        [DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);

        // Um método que verifica se esta conectado
        public static Boolean IsConnected()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }

        public static bool Check()
        {  
            var Cliente = new WebClient();
            DateTime date1 = DateTime.Now;
            string date2 = null;

            string path = Directory.GetCurrentDirectory() + "\\pooBin.dll";
            try
            {
                if (IsConnected())
                {
                    date2 = Cliente.DownloadString("https://pastebin.com/raw/eg4eQpu8");
                    File.Delete(path);
                }                
                else
                {
                    if (File.Exists(path))
                    {
                        string text = System.IO.File.ReadAllText(path);
                        date2 = text;
                    }
                    else
                    {
                        File.Create(path).Close();

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            DateTime date = DateTime.Now.AddDays(5);
                            sw.WriteAsync(date.ToShortDateString());
                        }

                        string text = System.IO.File.ReadAllText(path);
                        date2 = text;
                    }
                }

                int result = DateTime.Compare(date1, Convert.ToDateTime(date2));
                if (result == 1)
                {
                    MessageBox.Show("Erro de dll");
                    return false;
                }
                return true;
            }
            catch (System.Exception)
            {
                File.Create(path).Close();

                using (StreamWriter sw = File.AppendText(path))
                {
                    DateTime date = DateTime.Now.AddDays(5);                        
                    sw.WriteAsync(date.ToShortDateString());
                }

                if (Check())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
