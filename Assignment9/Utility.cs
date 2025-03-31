using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Assignment9
{  /// <summary>
   /// Based on https://msdn.microsoft.com/en-us/library/jj943772.aspx
   /// 
   /// Store connection string in project, access via this utility.
   /// 
   /// </summary>
    internal class Utility
    {

        //Get the connection string from App config file.  
        internal static string GetConnectionString()
        {
            //Util-2 Assume failure.  
            string returnValue = null;

            // Need to add reference to System.Configuration for next 2 lines
            //Util-3 Look for the name in the connectionStrings section.  
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["Assignment9.Properties.Settings.DB_BindConnectionString"];

            //If found, return the connection string.  
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
