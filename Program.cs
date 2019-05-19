using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppStarter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    try
                    {
                        Application.Run(new FrmStarter());
                    }
                    catch(System.ObjectDisposedException e)
                    {

                    }
                    
                }
                else
                {
                    MessageBox.Show("应用启动器已经运行中");
                }
            }
        }
    }
}
