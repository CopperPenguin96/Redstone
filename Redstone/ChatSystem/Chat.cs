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

            string[] colors =
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "a", "b", "c", "d", "e", "f"
            };

            if (!rawMessage.Contains("&"))
            {
                return "{\"text\": \"" + rawMessage + "\"}";
            }

            string[] splits = rawMessage.Split("&");
            List<int> includeInNext = new();
            string json = "{ ";

            List<string> jsonParts = new();
            for (int x = 0; x < splits.Length; x++)
            {
                string currentSplit = splits[x];
                if (currentSplit.Length == 0) continue;
                if (currentSplit.Length == 1)
                {
                    includeInNext.Add(x);
                    continue;
                }
                else
                {
                    if (colors.Contains("" + currentSplit[0])
                        || currentSplit[0] is 'k' or 'l' or 'm' or 'n' or
                            'o' or 'r')
                    {
                        includeInNext.Add(x);
                        currentSplit = currentSplit[1..];
                    }
                }

                bool alreadyColor = false;
                for (int i = includeInNext.Count - 1; i >= 0; i--) // go backwards
                {
                    if (splits[includeInNext[i]].ToLower() == "r")
                    {
                        jsonParts.Add($"\"text\": \"{currentSplit}\"");
                        break;
                    }
                    else
                    {
                        string codeJson = $"\"text\": \"{currentSplit}\"";
                        string code = splits[includeInNext[i]][0] + "";
                        string name = MinecraftFormatting.CodeToId(code);
                        if (colors.Contains(code))
                        {
                            if (alreadyColor) continue;
                            alreadyColor = true;
                            codeJson += $", \"color\": \"{name}\"";
                        }

                        if (code == "l")
                        {
                            codeJson += ", \"bold\": \"true\"";
                        }

                        if (code == "o")
                        {
                            codeJson += ", \"italic\": \"true\"";
                        }

                        if (code == "n")
                        {
                            codeJson += ", \"underlined\": \"true\"";
                        }

                        if (code == "m")
                        {
                            codeJson += ", \"strikethrough\": \"true\"";
                        }

                        if (code == "k")
                        {
                            codeJson += ", \"obfuscated\": \"true\"";
                        }

                        jsonParts.Add(codeJson);
                    }
                }
            }

            for (int z = 0; z < jsonParts.Count; z++)
            {
                if (z == 0)
                {
                    json += jsonParts[z];
                }
                else if (jsonParts.Count > 1)
                {
                    if (z == 1)
                    {
                        json += ", \"extra\": [{" +
                                jsonParts[z] + "}";
                    }
                    else
                    {
                        json += ",{" + jsonParts[z] + "}";
                    }

                    if (z == jsonParts.Count - 1)
                    {
                        json += "]";
                    }
                }
            }

            json += "}";
            return json;
        }
    }
}
