﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets
{
    internal class Request : IReceivingPacket
    {
        public Packet Packet => Packet.Request;
        public string Name => "Request";

        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            // todo send response
            new Response().Send(ref client, stream);
        }
    }
}