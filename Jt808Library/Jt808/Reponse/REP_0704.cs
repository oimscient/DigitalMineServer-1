﻿/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/22 16:41:34
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: cfe81542-b810-4828-920a-e661523d5bff
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtLibrary.PacketBody.Reponse
{
    /// <summary>
    /// 消息指令0x0704(定位数据批量上传)
    /// </summary>
    public class REP_0704
    {
        public REP_0704()
        {
        }
        /// <summary>
        /// 定位数据批量上传解析
        /// </summary>
        /// <param name="msgBody"></param>
        /// <returns></returns>
        public PB0704 Decode(byte[] msgBody)
        {
            REP_0200 body0200 = new REP_0200();
            int indexOffset = 3;
            UInt16 dlen = 0;
            UInt16 itemCount = msgBody.ToUInt16(0);

            PB0704 item = new PB0704()
            {
                LocationDataTypes = msgBody[2]
            };
            item.PositionInformationItems = new List<PB0200>(itemCount);

            for (int i = 0; i < itemCount; ++i)
            {
                //位置汇报数据长度
                dlen = msgBody.ToUInt16(indexOffset);
                //解析位置汇报数据
                item.PositionInformationItems.Add(body0200.Decode(msgBody.Copy(indexOffset += 2, dlen)));

                indexOffset += dlen;
            }

            return item;
        }
    }
}
