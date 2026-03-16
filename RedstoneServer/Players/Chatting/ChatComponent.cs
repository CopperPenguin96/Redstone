using Redstone.Core;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace Redstone.Players.Chatting
{
    public abstract class ChatComponent : ITagProvider
    {
        public abstract string Type { get; }

        public abstract NbtTag Nbt { get; }

        public static ChatComponent Parse(string snbt)
        {
            RedstoneException.ThrowIfNull(snbt);

            string raw = snbt.Trim();

            // If the value is a plain string (quoted or unquoted) return PlainText
            if ((raw.StartsWith('"') && raw.EndsWith('"')) || (raw.StartsWith('\'') && raw.EndsWith('\'')))
            {
                var unquoted = raw.Trim('"').Trim('\'');
                return new PlainText(unquoted);
            }

            // Try to parse as JSON. Many places use a relaxed "SNBT-like" syntax with unquoted keys
            // so if standard JSON parsing fails, attempt to quote keys first.
            JsonDocument doc = null!;
            try
            {
                doc = JsonDocument.Parse(raw);
            }
            catch (JsonException)
            {
                // Quote unquoted keys: turn {key: into {"key":
                try
                {
                    string fixedJson = Regex.Replace(raw, "(?<=[{,])\\s*([A-Za-z0-9_]+)\\s*:", m => $"\"{m.Groups[1].Value}\":");
                    doc = JsonDocument.Parse(fixedJson);
                }
                catch (Exception)
                {
                    // Give up and return the raw text as PlainText
                    return new PlainText(raw.Trim('{', '}', ' '));
                }
            }

            using (doc)
            {
                var root = doc.RootElement;
                if (root.ValueKind == JsonValueKind.String)
                {
                    return new PlainText(root.GetString() ?? string.Empty);
                }

                if (root.ValueKind == JsonValueKind.Object)
                {
                    if (root.TryGetProperty("text", out var textProp))
                    {
                        return new PlainText(textProp.GetString() ?? string.Empty);
                    }

                    if (root.TryGetProperty("translate", out var transProp))
                    {
                        string translate = transProp.GetString() ?? string.Empty;
                        string? fallback = null;
                        if (root.TryGetProperty("fallback", out var fb) && fb.ValueKind == JsonValueKind.String)
                        {
                            fallback = fb.GetString();
                        }

                        // 'with' may be present but parsing nested translated components is beyond the minimal
                        // implementation required here. Provide an empty list for now.
                        return new TranslatedText(translate, fallback, new List<TranslatedText>());
                    }

                    if (root.TryGetProperty("score", out var scoreProp) && scoreProp.ValueKind == JsonValueKind.Object)
                    {
                        string name = scoreProp.GetProperty("name").GetString() ?? string.Empty;
                        string objective = scoreProp.GetProperty("objective").GetString() ?? string.Empty;
                        return new ScoreboardValue(name, objective);
                    }

                    if (root.TryGetProperty("text", out _)) // already handled but keep structure
                    {
                        var t = root.GetProperty("text");
                        return new PlainText(t.GetString() ?? string.Empty);
                    }

                    // Fallback: return the object as plain text content (not ideal but safe)
                    return new PlainText(root.ToString());
                }

                // Other kinds: return as plain text
                return new PlainText(root.ToString());
            }
        }
    }
}
