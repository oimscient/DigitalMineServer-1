﻿/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/22 16:45:50
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: fef49e3e-6c65-4934-a6a8-ed05cdb0eff2
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtLibrary.PacketBody.Reponse
{
    /// <summary>
    /// (0x0805消息指令)摄像头立即拍摄命令应答
    /// </summary>
    public class REP_0805
    {
        public REP_0805()
        {
        }
        /// <summary>
        /// 摄像头立即拍摄消息体解析
        /// </summary>
        /// <param name="msgBody"></param>
        /// <returns></returns>
        public PB0805 Decode(byte[] msgBody)
        {
            PB0805 item = new PB0805()
            {
                SerialNumber = msgBody.ToUInt16(0),
                Result = msgBody[2]
            };

            if (item.Result == 0)
            {
                UInt16 count = msgBody.ToUInt16(3);
                item.MultimediaIdItems = new List<uint>(count);
                for (int i = 0; i < count; ++i)
                {
                    item.MultimediaIdItems.Add(msgBody.ToUInt32((5 + (i << 2))));
                }
            }

            return item;
        }
    }
}
