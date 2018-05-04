using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Common
{
    public static class StringHelper
    {
        /// <summary>
        /// 输入字符串，判断是否都是整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(string str)
        {
            bool re = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str[i]))
                {
                    re = false;
                    break;
                }
            }
            return re;
        }
    }
}
