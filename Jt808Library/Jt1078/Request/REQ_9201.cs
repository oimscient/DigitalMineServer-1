﻿using JtLibrary.PacketBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtLibrary.Jt1078.Request
{
    public class REQ_9201
    {
        /// <summary>
        /// 0x9201消息体数据打包
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public byte[] Encode(PB9201 info)
        {
            List<byte> list = new List<byte>
            {
                //ip长度
                info.length
            };
            //ip
            list.AddRange(Encoding.GetEncoding("GBK").GetBytes(info.ip));
            //tcp端口号
            list.AddRange(info.port.ToBytes());
            //udp端口号
            list.AddRange(info.ports.ToBytes());
            //逻辑通道号
            list.Add(info.id);
            //数据类型
            list.Add(info.datatype);
            //码流类型
            list.Add(info.datatypes);
            //存储类型
            list.Add(info.memoryType);
            //回放方式
            list.Add(info.ReviewType);
            //快进或快退倍数
            list.Add(info.FastOrSlow);
            //开始时间
            list.AddRange(info.StartTime);
            //结束时间
            list.AddRange(info.OverTime);

            return list.ToArray();
        }
    }
}
