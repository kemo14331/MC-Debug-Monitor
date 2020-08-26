using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MC_Debug_Monitor.utils
{
    static class SNBTLib
    {

        public static Dictionary<string, Color> highlightColor = new Dictionary<string, Color>() {
            { "Normal", Color.White },
            { "Key",  Color.LightSkyBlue},
            { "Number", Color.LightGreen },
            { "Int", Color.LightBlue },
            { "Byte", Color.IndianRed},
            { "Double", Color.PaleVioletRed },
            { "Short", Color.Yellow},
            { "Float", Color.Aqua },
            { "String", Color.Orange }
        };

        public static string SpaceRemove(string input)
        {
            StringBuilder stb = new StringBuilder();
            int escape = 0;
            bool inString = false;
            foreach(char c in input)
            {
                if (inString)
                {
                    stb.Append(c);
                    if (c.Equals('\\'))
                    {
                        escape++;
                        continue;
                    }
                    if (c.Equals('"') || c.Equals("'"))
                    {
                        if(escape == 0)
                        {
                            inString = false;
                            continue;
                        }
                        escape--;
                    }
                    continue;
                }
                if (c.Equals(' '))
                {
                    continue;
                }
                if (c.Equals('\'') || c.Equals('"'))
                {
                    stb.Append(c);
                    inString = true;
                    continue;
                }
                stb.Append(c);
            }
            return stb.ToString();
        }

        public static void FormatInRichTextBox(string input, RichTextBox rtb)
        {
            StringBuilder stb = new StringBuilder();
            int indent = 3;
            int depth = 0;
            int v = 1; //0: key, 1: value
            List<int> tree = new List<int>(); //0: compound, 1:List
            bool inString = false; // inString ["...
            int escape = 0; //escape

            if (!input[0].Equals('{') && !input[0].Equals('['))
            {
                rtb.Clear();
                rtb.AppendText(input, Color.OrangeRed);
                return;
            }

            input = SpaceRemove(input);

            rtb.Clear();
            for (int index = 0; index < input.Length; index++)
            {
                char c = input[index];
                //key
                if (v == 0)
                {
                    if (!c.Equals(' '))
                    {
                        if (c.Equals(':'))
                        {
                            rtb.AppendText(':', highlightColor["Normal"]);
                            rtb.AppendText(' ', highlightColor["Normal"]);
                            v = 1;
                        }
                        else
                        {
                            rtb.AppendText(c, highlightColor["Key"]);
                        }
                    }
                }
                else //value
                {
                    // instring
                    if (inString)
                    {
                        rtb.AppendText(c, highlightColor["String"]);
                        if (c.Equals('"') || c.Equals('\''))
                        {
                            if(escape == 0)
                            {
                                inString = false;
                                goto Skip;
                            }
                            escape--;
                            goto Skip;
                        }
                        if (c.Equals('\\'))
                        {
                            escape++;
                            goto Skip;
                        }
                        goto Skip;
                    }
                    switch (c)
                    {
                        case ' ':
                            break;
                        case '\'':
                        case '"':
                            inString = true;
                            rtb.AppendText(c + " ", highlightColor["String"]);
                            break;
                        //start compound
                        case '{':
                            rtb.AppendText(c, highlightColor["Normal"]);
                            depth++;
                            //empty compound
                            if (input[index + 1].Equals('}'))
                            {
                                depth--;
                                rtb.AppendText("}", highlightColor["Normal"]);
                                if (index + 1 < input.Length)
                                {
                                    if (!input[index + 2].Equals(','))
                                    {
                                        rtb.AppendText("\n" + Strings.Space(indent * (depth - 1)));
                                    }
                                }
                                index++;
                            }
                            else
                            {
                                v = 0;
                                rtb.AppendText("\n" + Strings.Space(indent * depth));
                            }
                            tree.Add(0);
                            break;
                        //end compound
                        case '}':
                            depth--;
                            if (!input[index - 1].Equals('}')) rtb.AppendText("\n" + Strings.Space(indent * depth));
                            tree.RemoveAt(tree.Count - 1);
                            rtb.AppendText(c, highlightColor["Normal"]);
                            if (index + 1 < input.Length)
                            {
                                if (!input[index + 1].Equals(','))
                                {
                                    rtb.AppendText("\n" + Strings.Space(indent * (depth - 1)));
                                }
                            }
                            break;
                        case '[':
                            rtb.AppendText(c, highlightColor["Normal"]);
                            depth++;
                            // []
                            if (input[index + 1].Equals(']'))
                            {
                                depth--;
                                rtb.AppendText(']', highlightColor["Normal"]);
                                index++;
                            }else if (input[index + 1].Equals('{')) //[{
                            {
                                rtb.AppendText("\n" + Strings.Space(indent * depth));
                            }
                            tree.Add(1);
                            break;
                        case ']':
                            depth--;
                            rtb.AppendText(c, highlightColor["Normal"]);
                            tree.RemoveAt(tree.Count - 1);
                            break;
                        case ',':
                            char nc = input[index + 1];
                            char n2c = input[index + 2];
                            rtb.AppendText(c + " ", highlightColor["Normal"]);
                            // ..,{ or ..[..
                            if (nc.Equals('{') || nc.Equals('['))
                            {
                                // ..,{}.. or ...,[]...
                                if(n2c.Equals('}') || n2c.Equals(']'))
                                {
                                    break;
                                }
                                rtb.AppendText("\n" + Strings.Space(indent * depth));
                            }
                            if (tree.Last() == 0)
                            {
                                v = 0;
                                rtb.AppendText("\n" + Strings.Space(indent * depth));
                            } else
                            {

                            }
                            break;
                        case 'I':
                            rtb.AppendText(c, highlightColor["Int"]);
                            break;
                        case 'b':
                            rtb.AppendText(c, highlightColor["Byte"]);
                            break;
                        case 's':
                            rtb.AppendText(c, highlightColor["Short"]);
                            break;
                        case 'f':
                            rtb.AppendText(c, highlightColor["Float"]);
                            break;
                        case 'd':
                            rtb.AppendText(c, highlightColor["Double"]);
                            break;
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            rtb.AppendText(c, highlightColor["Number"]);
                            break;
                        default:
                            rtb.AppendText(c, highlightColor["Normal"]);
                            break;
                    }
                Skip:
                    ;
                }
            }
        }

    }
}
