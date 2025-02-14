﻿/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/21 15:28:57
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: 85978d91-56e6-4e4b-b561-f051c58d474c
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtLibrary.PacketBody.Request
{
    /// <summary>
    /// 临时位置跟踪控制
    /// </summary>
    public class REQ_8202
    {
        public REQ_8202()
        {
        }

        public byte[] Encode(PB8202 info)
        {
            byte[] buffer = new byte[(info.tInterval == 0 ? 2 : 6)];
            buffer[0] = (byte)(info.tInterval >> 8);
            buffer[1] = (byte)info.tInterval;

            if (info.tInterval != 0)
            {
                buffer[2] = (byte)(info.tValidTime >> 24);
                buffer[3] = (byte)(info.tValidTime >> 16);
                buffer[4] = (byte)(info.tValidTime >> 8);
                buffer[5] = (byte)info.tValidTime;
            }
            return buffer;
        }
    }
}
