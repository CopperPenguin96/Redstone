﻿using System.Security.Cryptography;
using MinecraftTypes;
using Redstone.Security;

namespace Redstone.Network.Packets.Login
{
    internal class EncryptionRequest : ISendingPacket
    {
        public Packet Packet => Packet.EncryptionRequest;
        public string Name => "Encryption Request";

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            byte[] verifyToken = new byte[4];
            byte[] publicKey = AsnKeyBuilder.PublicKeyToX509(
                Protocol.Key).GetBytes();

            var crypto = RandomNumberGenerator.Create();
            crypto.GetBytes(verifyToken);
            client.VerifyToken = verifyToken;
            Protocol.Send(ref client, stream, Packet,
                Protocol.ServerID,
                (VarInt) publicKey.Length, publicKey,
                (VarInt) verifyToken.Length, verifyToken);
        }
    }
}
