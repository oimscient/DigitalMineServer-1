﻿/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/22 16:28:59
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: 54960864-b8a4-4942-8df9-5201008e75c1
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtLibrary.PacketBody.Reponse
{
    /// <summary>
    /// 消息指令0x0104 查询终端参数应答
    /// </summary>
    public class REP_0104
    {
        public REP_0104()
        {
        }
        /// <summary>
        /// 消息指令数据体解析
        /// </summary>
        /// <param name="msgBody"></param>
        /// <returns></returns>
        public PB0104 Decode(byte[] msgBody)
        {
            PB0104 item = new PB0104();
            int index = 3;
            byte len = 0;
            byte count = msgBody[2];

            item.SerialNumber = msgBody.ToUInt16(0);

            item.Items = new List<UInt32Bytes>(count);

            for (int i = 0; i < count; ++i)
            {
                if (index >= msgBody.Length) break;

                len = msgBody[index += 4];

                item.Items.Add(new UInt32Bytes()
                {
                    Value = msgBody.ToUInt32(index),
                    BytesValue = msgBody.Copy(index + 1, len)
                });

                index += len + 1;
            }
            return item;
        }
    }
}
