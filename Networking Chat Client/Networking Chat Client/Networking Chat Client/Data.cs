using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Networking_Chat_Client
{
    class Data
    {
        public string message;
        public Color color;

        public Data(string message, Color color)
        {
            this.message = message;
            this.color = color;
        }
    }
}
