using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ChatClientUWP.Models
{
    public class clsMensaje 
    {
        //Constructor por defecto
        public clsMensaje()
        {
            this.name = "";
            this.message = "";
        }

        public clsMensaje(string name, string message)
        {
            this.name = name;
            this.message = message;
        }

        public string name { get; set; }
        public string message { get; set; }
    }
}
