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
            return "";
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

            List<string> componentList = new();
            bool nextChanged = false;

            string color = "reset";
            bool bold = false;
            bool italic = false;
            bool underlined = false;
            bool strikethrough = false;
            bool obfuscated = false;
            Dictionary<char, string> colorCodes = new()
            {
                {'0', "black"},
                {'1', "dark_blue"},
                {'2', "dark_green"},
                {'3', "dark_cyan"},
                {'4', "dark_red"},
                {'5', "dark_purple"},
                {'6', "dark_purple"},
                {'7', "gray"},
                {'8', "dark_gray"},
                {'9', "blue"},
                {'a', "green"},
                {'b', "aqua"},
                {'c', "red"},
                {'d', "light_purple"},
                {'e', "yellow"},
                {'f', "white"},
                {'k', "obfuscated"},
                {'l', "bold"},
                {'m', "strikethrough"},
                {'n', "underlined"},
                {'o', "italic"},
                {'r', "reset"},
                {'&', "&"}
            };
            string text = "";
            while (rawMessage != "")
            {
                char currentChar = rawMessage[0];
                if (nextChanged)
                {
                    bool val = colorCodes.TryGetValue(currentChar, out string newColor);

                    if (val)
                    {
                        if (newColor == "bold") bold = true;

                        if (newColor == "strikethrough") strikethrough = true;
                        if (newColor == "underlined") underlined = true;
                        if (newColor == "italic") italic = true;
                        if (newColor == "obfuscated") obfuscated = true;
                        if (newColor == "&") text += "&";

                        if (newColor == "reset")
                        {
                            strikethrough = false;
                            bold = false;
                            underlined = false;
                            obfuscated = false;
                            italic = false;
                            color = "reset";
                        }
                        else
                        {
                            color = newColor;
                        }
                    }
                    else if (currentChar == '&')
                    {
                        if (nextChanged)
                        {
                            text += "&";
                            nextChanged = false;
                        }
                        else
                        {
                            nextChanged = true;
                            // createJsonComponent todo
                        }
                    }
                    else
                    {
                        text += currentChar;
                    }
                }
            }
        }
    }
}
