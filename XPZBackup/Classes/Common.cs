using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace XPZBackup.Classes
{
    public class Common
    {
        public static string CaminhoRede 
        { 
            get 
            {
                return @"\\sqlserver\Desenvolvimento\BKPGX\";
            } 
        }

        public static string CaminhoProcedure 
        {
            get
            {
                return "";
            }
        }
    }
}
