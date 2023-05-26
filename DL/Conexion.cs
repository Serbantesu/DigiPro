using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()
        {
            //return "Data Source=LAPTOP-JTC24LU6;Initial Catalog=JCervantesDigiPro;Persist Security Info=True;User ID=sa;Password=pass@word1";
            return ConfigurationManager.ConnectionStrings["JCervantesDigiPro"].ToString();
        }
    }
}
