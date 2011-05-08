using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Frames.Incoming
{
    public class NavigationInstruction
    {
        public double x, y;
        public int a, b;
        public int line;

        public enum navigation_command
        {
            EMPTY = 0,
            CLIMB = 1,
            FROM_TO_REL = 2,   // x, y, height
            FROM_TO_ABS = 3,
            FLY_TO_REL = 4,
            FLY_TO_ABS = 5,    // x, y, height
            GOTO = 6,	   // line number
            CIRCLE_ABS = 7,    // x, y, radius, height <-- should be inside a while  12 B
            CIRCLE_REL = 8,
            IF_EQ = 9,     // x = c goto n
            IF_SM = 10,     // x < c goto n
            IF_GR = 11,     // x > c goto n
            IF_NE = 12,     // x > c goto n
            UNTIL_EQ = 13,
            UNTIL_NE = 14,
            UNTIL_GR = 15,
            UNTIL_SM = 16,
            SERVO_SET = 17,
            SERVO_TRIGGER = 18,
            BLOCK = 19
        };

        public navigation_command opcode;

        public NavigationInstruction()
        {
            this.opcode = navigation_command.EMPTY;
        }

        public NavigationInstruction(int line, navigation_command opcode, double x, double y, int a, int b)
        {
            this.line = line;
            this.opcode = opcode;
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b;
        }

        public NavigationInstruction(NavigationInstruction ni)
        {
            this.line = ni.line;
            this.opcode = ni.opcode;
            this.x = ni.x;
            this.y = ni.y;
            this.a = ni.a;
            this.b = ni.b;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            NavigationInstruction p = obj as NavigationInstruction;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (x == p.x) && (y == p.y) && (a == p.a) && (b == p.b);  // line??
        }

        public static bool operator ==(NavigationInstruction a, NavigationInstruction b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            return a.Equals(b);
        }

        public static bool operator !=(NavigationInstruction a, NavigationInstruction b)
        {
            return !(a == b);
        }

        private double RAD2DEG(double x)
        {
            return x / 3.14159 * 180.0;
        }
        private double DEG2RAD(double x)
        {
            return x / 180.0 * 3.14159;
        }

        public override string ToString()
        {
            string s = "";
            switch (opcode)
            {
            case navigation_command.EMPTY:
                s += "Empty";
                break;
            case navigation_command.CLIMB:
                s += "Climb(" + x + "m)";
                break;

            case navigation_command.FROM_TO_REL:   // x, y, height
                s += "FromTo[Absolute](lat: " + x.ToString("F0") + "m, lon: " + y.ToString("F0") + "m, alt: " + a + "m)";
                break;
            case navigation_command.FROM_TO_ABS:
                s += "FromTo[Relative](lat: " + RAD2DEG(x).ToString("F5") + "°, lon: " + RAD2DEG(y).ToString("F5") + "°, alt: " + a + "m)";
                break;
            case navigation_command.FLY_TO_REL:
                s += "FlyTo[Relative](lat: " + x.ToString("F0") + "m, lon: " + y.ToString("F0") + "m, alt: " + a + "m)";
                break;
            case navigation_command.FLY_TO_ABS:    // x, y, height
                s += "FlyTo[Absolute](lat: " + RAD2DEG(x).ToString("F5") + "°, lon: " + RAD2DEG(y).ToString("F5") + "°, alt: " + a + "m)";
                break;
            case navigation_command.GOTO:	   // line number
                s += "Goto(" + (a+1) + ")";
                break;
            case navigation_command.CIRCLE_ABS:    // x, y, radius, height <-- should be inside a while  12 B
                s += "Circle[Absolute](lat: " + RAD2DEG(x).ToString("F5") + "°, lon: " + RAD2DEG(y).ToString("F5") + "°, radius: " + a + "m, alt: " + b + "m)";
                break;
            case navigation_command.CIRCLE_REL:
                s += "Circle[Relative](lat: " + x.ToString("F0") + "m, lon: " + y.ToString("F0") + "m, radius: " + a + "m, alt: " + b + " m)";
                break;
            case navigation_command.UNTIL_SM:
                s += "Until(" + GetVariableText(a) + " < " + x + ")";
                break;
            case navigation_command.UNTIL_GR:
                s += "Until(" + GetVariableText(a) + " > " + x + ")";
                break;
            case navigation_command.UNTIL_NE:
                s += "Until(" + GetVariableText(a) + " <> " + x + ")";
                break;
            case navigation_command.UNTIL_EQ:
                s += "Until(" + GetVariableText(a) + " = " + x + ")";
                break;
            case navigation_command.IF_SM:
                s += "If(" + GetVariableText(a) + " < " + x + ")";
                break;
            case navigation_command.IF_GR:
                s += "If(" + GetVariableText(a) + " > " + x + ")";
                break;
            case navigation_command.IF_NE:
                s += "If(" + GetVariableText(a) + " <> " + x + ")";
                break;
            case navigation_command.IF_EQ:
                s += "If(" + GetVariableText(a) + " = " + x + ")";
                break;
            case navigation_command.SERVO_SET:
                s += "ServoSet(channel: " + (a+1) + ", position: " + b + "us)";
                break;
            case navigation_command.SERVO_TRIGGER:
                s += "ServoTrigger(channel: " + (a + 1) + ", position: " + b + "us, hold: " + x + "s)";
                break;
            case navigation_command.BLOCK:
                s += "Block (" + GetStringArgument() + ")";
                break;
            default:
                s += "Unknown/Unsupported (" + (int)opcode + " : " +  x + ", " + y + ", " + a + ", " + b + ")";
                break;
            }

            return s;
        }

        public string GetStringArgument()
        {
            string s = "";
            s = s + Convert.ToChar((int)(a / 256));
            s = s + Convert.ToChar((int)(a % 256));
            s = s + Convert.ToChar((int)(b / 256));
            s = s + Convert.ToChar((int)(b % 256));
            int c = (int)x;
            int d = (int)y;
            s = s + Convert.ToChar((int)(c / 256));
            s = s + Convert.ToChar((int)(c % 256));
            s = s + Convert.ToChar((int)(d / 256));
            s = s + Convert.ToChar((int)(d % 256));
            return s;
        }

        public void StringToArgument(string s)
        {
            char[] c2 = s.ToCharArray();
            char[] c1 = new char[8] { '\n', '\n', '\n', '\n', '\n', '\n', '\n', '\n' };
            for (int i = 0; i < 8; i++)
                if (i < c2.Length)
                    c1[i] = c2[i];
            a = (int)c1[0];
            a *= 256;
            a += (int)c1[1];
            b = (int)c1[2];
            b *= 256;
            b += (int)c1[3];
            int d;
            d = (int)c1[4];
            d *= 256;
            d += (int)c1[5];
            x = d;
            d = (int)c1[6];
            d *= 256;
            d += (int)c1[7];
            y = d;
        }

        public string GetVariableText(int a)
        {
            if (a == 1)
                return "Height (m)";
            else if (a == 2)
                return "Speed (m/s)";
            else if (a == 3)
                return "Heading (deg)";
            else if (a == 4)
                return "Flight time (s)";
            else if (a == 5)
                return "Satellites in view";
            else if (a == 6)
                return "Home distance (m)";
            else if (a == 7)
                return "PPM link alive";
            else if (a == 8)
                return "Channel 1";
            else if (a == 9)
                return "Channel 2";
            else if (a == 10)
                return "Channel 3";
            else if (a == 11)
                return "Channel 4";
            else if (a == 12)
                return "Channel 5";
            else if (a == 13)
                return "Channel 6";
            else if (a == 14)
                return "Channel 7";
            else if (a == 15)
                return "Channel 8";
            else if (a == 16)
                return "Battery voltage (V)";
            else
                return "?";
        }
    }
}
