using System;
using System.Collections.Generic;
using System.Text;

namespace MC_Debug_Monitor.utils
{
    public static class MCCommand
    {

        /// <summary>
        /// ": "の先の文字列を返す
        /// なかった場合null
        /// </summary>
        /// <returns>": "以降の文字列</returns>
        public static string getResultString(string str)
        {
            int index = str.IndexOf(": ");
            if(index != -1)
            {
                return str.Substring(index + 2);
            }
            return str;
        }
    }
}
