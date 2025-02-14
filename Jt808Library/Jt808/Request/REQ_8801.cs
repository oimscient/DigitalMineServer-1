﻿/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/21 19:46:39
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *   guid: 97de9863-4caf-4cd4-85aa-b965926c9b4f
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtLibrary.PacketBody.Request
{
   public class REQ_8801
    {
        /// <summary>
        /// 封装消息体数据
        /// </summary>
        /// <param name="info">立即拍摄消息结构</param>
        /// <returns></returns>
        public byte[] Encode(PB8801 info)
        {
            byte[] data = new byte[12];

            data[0] = info.channelId;
            data[1] = (byte)(info.photoCmd >> 8);
            data[2] = (byte)info.photoCmd;

            data[3] = (byte)(info.photoInterval >> 8);
            data[4] = (byte)info.photoInterval;

            data[5] = info.photoSaveFlag;
            data[6] = info.photoResolution;
            data[7] = info.photoQuality;
            data[8] = info.photoBrightness;
            data[9] = info.photoContrast;
            data[10] = info.photoSaturation;
            data[11] = info.photoColor;

            return data;
        }
    }
}
