using Microsoft.VisualBasic;
using System.Text;
using System.Windows.Forms;

namespace MC_Debug_Monitor.utils
{
    static class SNBTLib
    {

        public static void FormatInRichTextBox(string input, RichTextBox rtb)
        {
            StringBuilder strb = new StringBuilder();
            //深さ
            int depth = 0;
            //エスケープされたか
            bool escape = false;
            bool inString = false; //文字列の中か
            bool firstString = false;
            foreach (char c in input)
            {
                if (inString)
                {
                    rtb.Text += c;
                    continue;
                }
                if (c.Equals('{') || c.Equals('['))
                {
                    rtb.Text += indent() + c + div();
                    depth++;
                    continue;
                }
                if (c.Equals('}') || c.Equals(']'))
                {
                    rtb.Text += indent() + c + div();
                    depth--;
                    continue;
                }
                if (c.Equals(':'))
                {
                    rtb.Text += c + " ";
                    continue;
                }
                if (c.Equals('\"') || c.Equals("|'"))
                {
                    inString = !inString;
                    continue;
                }
                if (c.Equals(','))
                {
                    rtb.Text += c + div();
                    continue;
                }
                if (firstString)
                {
                    rtb.Text += indent() + c;
                    firstString = false;
                    continue;
                }
                rtb.Text += c;
            }

            string indent()
            {
                return Strings.Space(depth * 3);
            }

            string div()
            {
                firstString = true;
                return "\n";
            }
        }
    }
}
