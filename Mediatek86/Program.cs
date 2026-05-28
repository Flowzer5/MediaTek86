using System;
using System.Windows.Forms;
using Mediatek86.vue;

namespace Mediatek86
{
    /// <summary>
    /// Point d'entrée de l'application MediaTek86.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmConnexion());
        }
    }
}
