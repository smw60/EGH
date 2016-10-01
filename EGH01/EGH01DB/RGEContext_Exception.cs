using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;



namespace EGH01DB
{
   
    public partial class RGEContext
    {

        public class Exception:System.Exception
        {
            private int code_exception = -1;
            private string messageformat = "RGE-{0}: {1}";
            public string message { get { return String.Format(this.messageformat, this.code_exception, "ERROR"); } }
            
            public Exception(int code_exception)
            {
                this.code_exception = code_exception;
            }
            
            
        }
        
    }
    

 }

