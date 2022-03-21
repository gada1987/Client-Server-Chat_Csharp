using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Server
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
