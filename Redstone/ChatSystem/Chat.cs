using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Redstone.Configuration;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone.ChatSystem
{
    public class Chat
    {
        public static string Format(string rawMessage, Player? player)
        {
            if (player != null)
            {
                rawMessage = rawMessage.Replace("$name", player.DisplayName);
                // todo kicks
                // todo bans
                // todo Money
            }

            rawMessage =
                rawMessage.Replace(
                    "$awesome", "It is my professional opinion, that "
                                + Config.ServerName + " is the best server on Minecraft!");
            rawMessage = rawMessage.Replace("$server", Config.ServerName);
            rawMessage = rawMessage.Replace("$motd", Config.MessageOfTheDay);
            rawMessage = rawMessage.Replace("$date", DateTime.Now.ToShortDateString());
            rawMessage = rawMessage.Replace("$time", DateTime.Now.ToString());
            rawMessage = rawMessage.Replace("$mad", "U &cmad&r, bro?");
            rawMessage = rawMessage.Replace("$welcome", "Welcome to " + Config.ServerName);
            rawMessage = rawMessage.Replace("$clap", "A round of applause might be appropriate, *claps*.");
            // todo website & ws
            rawMessage = rawMessage.Replace("$redstone", "Running Redstone v" + Server.Version);
            rawMessage = rawMessage.Replace("$rs", "Running Redstone v" + Server.Version);
            // todo moron randomizer (complete and total moron)
            rawMessage = rawMessage.Replace("$players", "Currently " + PlayerList.Online + " people online.");
            // todo discord

            if (player == null /* todo || if player has perm */)
            {
                rawMessage = rawMessage.Replace("$lime", "&a");     //alternate color codes for ease if you can't remember the codes
                rawMessage = rawMessage.Replace("$aqua", "&b");
                rawMessage = rawMessage.Replace("$cyan", "&b");
                rawMessage = rawMessage.Replace("$red", "&c");
                rawMessage = rawMessage.Replace("$magenta", "&d");
                rawMessage = rawMessage.Replace("$pink", "&d");
                rawMessage = rawMessage.Replace("$yellow", "&e");
                rawMessage = rawMessage.Replace("$white", "&f");
                rawMessage = rawMessage.Replace("$navy", "&1");
                rawMessage = rawMessage.Replace("$darkblue", "&1");
                rawMessage = rawMessage.Replace("$green", "&2");
                rawMessage = rawMessage.Replace("$teal", "&3");
                rawMessage = rawMessage.Replace("$maroon", "&4");
                rawMessage = rawMessage.Replace("$purple", "&5");
                rawMessage = rawMessage.Replace("$olive", "&6");
                rawMessage = rawMessage.Replace("$gold", "&6");
                rawMessage = rawMessage.Replace("$silver", "&7");
                rawMessage = rawMessage.Replace("$grey", "&8");
                rawMessage = rawMessage.Replace("$gray", "&8");
                rawMessage = rawMessage.Replace("$blue", "&9");
                rawMessage = rawMessage.Replace("$black", "&0");
            }

            // todo caps
            // todo swears
            string[] split = rawMessage.Split("&");
            ChatBuilder chatBuilder = new();
            char[] availableChars =
            {
                'a', 'b', 'c', 'd', 'e', 'f', '1', '2', '3', '4', '5',
                '6', '7', '8', '9', '0', 'l', 'n', 'o', 'k', 'm', 'r'
            };

            string currentList = "";
            foreach (string str in split)
            {
                ChatPart part = new() {Text = str.Substring(1)};
                char first = str.ToCharArray()[0];
                if (availableChars.Contains(first))
                {
                    if (str.Length < 2)
                    {
                        currentList += first;
                        continue;
                    }

                    foreach (char c in currentList)
                    {
                        part.Formatting = c;
                        switch (c)
                        {
                            case 'l':
                                part.IsBold = true;
                                break;
                            case 'n':
                                part.IsUnderlined = true;
                                break;
                            case 'o':
                                part.IsItalics = true;
                                break;
                            case 'k':
                                part.IsObfuscated = true;
                                break;
                            case 'm':
                                part.IsStriked = true;
                                break;
                            case 'r':
                                part.IsBold = false;
                                part.IsUnderlined = false;
                                part.IsItalics = false;
                                part.IsObfuscated = false;
                                part.IsStriked = false;
                                part.Formatting = MinecraftFormatting.Reset;
                                break;
                        }
                        chatBuilder.Add(part);
                        currentList = "";
                    }
                }
                else
                {
                    part.Text = "&" + str; // Code is invalid. Represent as typed
                    currentList = "";
                }
                
            }

            return rawMessage;
        }
    }
}
