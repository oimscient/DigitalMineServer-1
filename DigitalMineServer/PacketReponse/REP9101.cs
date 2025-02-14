﻿using JtLibrary;
using JtLibrary.Jt1078.Request;
using JtLibrary.PacketBody;
using JtLibrary.Structures;

namespace DigitalMineServer.PacketReponse
{
    class REP9101
    {
        public byte[] R9101(string[] data)
        {
            ushort ports = 8087;
            byte id =byte.Parse(data[3]);
            if (data[2] == "2")
           {
                ports = 8086;
            }
            byte[] body_9101 = new REQ_9101().Encode(new PB9101()
            {
                length = 12,
                ip = "120.27.8.104",
                port = ports,
                ports = 0000,
                id = id,
                datatype = byte.Parse(data[2]),
                datatypes = 0
            });
            byte[] buffer = PacketProvider.CreateProvider().Encode(new PacketFrom()
            {
                msgBody = body_9101,
                msgId = JT1078Cmd.REQ_9101,
                msgSerialnumber = 0,
                pEncryptFlag = 0,
                pSerialnumber = 1,
                pSubFlag = 0,
                pTotal = 1,
                simNumber = Extension.ToBCD(data[1]),
            });
            return buffer;
        }
    }
}
