using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBC
{
    public class BCMessage
    {
        public string Message {  get; set; }

        public Color Color { get; set; }

        public List<string> Commands { get; set; }

        public BCMessage(string msg, Color color, List<string> commands)
        {
            this.Message = msg;
            this.Color = color;
            this.Commands = commands;
        }

    }

    public class Color
    {
        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
