﻿using DigitalMineServer.Mysql;
using DigitalMineServer.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalMineServer.implement
{
    public class Util
    {
        delegate void lableShowDelegate(Label lable, string strshow);

        delegate void TextBoxShowDelegate(TextBox TextBox, string strshow);

        delegate void UpdataSourceDelegate(DataGridView view, List<vehicleStateEntity> list);
        /// <summary>
        /// 修改界面提示文字
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="strshow"></param>
        public static void ModifyLable(Label lable, string strshow)
        {
            if (lable.InvokeRequired)
            {
                lable.Invoke(new lableShowDelegate(ModifyLable), new object[] { lable, strshow });
            }
            else
            {
                lable.Text = strshow;
            }
        }
        /// <summary>
        /// 添加文本
        /// </summary>
        /// <param name="TextBox"></param>
        /// <param name="strshow"></param>
        public static void AppendText(TextBox TextBox, string strshow)
        {
            if (TextBox.InvokeRequired)
            {
                TextBox.Invoke(new TextBoxShowDelegate(AppendText), new object[] { TextBox, strshow });
            }
            else
            {
                TextBox.AppendText(strshow + "\r\n");
            }
        }

        public static void UpdataSource(DataGridView view, List<vehicleStateEntity> list)
        {
            if (view.InvokeRequired)
            {
                view.Invoke(new UpdataSourceDelegate(UpdataSource), new object[] { view, list });
            }
            else
            {
                view.DataSource = list;
            }
        }

        /// <summary>
        /// 获取首字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetChsSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";

            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText[i].ToString());
            }
            return myStr;
        }

        private static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];

                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
        /// <summary>
        /// 判断文件夹是否存在
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="IsCreat">若不存在是否创建，创建成功后返回true</param>
        /// <returns></returns>
        public static bool DirExit(string path, bool IsCreat)
        {
            if (!Directory.Exists(path))
            {
                if (IsCreat)
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        return true;
                    }
                    catch (Exception e)
                    {
                        LogHelper.WriteLog("文件夹创建错误", e);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 创建文件，如果存在就覆盖
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileStream FileCreat(string path)
        {
            FileStream fs;
            try
            {
                fs=File.Create(path);
                return fs;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("文件创建错误", e);
                return null;
            }
        }

        public static FileStream GetFileStream(string path) {
            FileStream fs;
            int Count = 0;
            while (true) {
                try
                {
                    fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                    return fs;
                }
                catch (Exception e)
                {
                    if (Count <500)
                    {
                        Count++;
                        Thread.Sleep(20);
                    }
                    else {
                        LogHelper.WriteLog("文件流打开失败", e);
                        return null;
                    }
                }
            }
        }
    }
}
