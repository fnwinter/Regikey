using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REGIKEY
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RegiKey regikey = new RegiKey();
            if (args.Length > 0 && args[0] == "--hide")
            {
                // 폼 없이 시작
                Application.Run();
            }
            else
            {
                // 폼 있이 시작
                Application.Run(regikey);
            }
        }
    }
}