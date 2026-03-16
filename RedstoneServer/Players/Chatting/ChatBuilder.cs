namespace Redstone.Players.Chatting
{
    public abstract class ChatBuilder
    {
        public string RawText { get; }

        public abstract string Output { get; }

        protected ChatBuilder(string raw)
        {
            RawText = raw;
        }

        public static ChatBuilder Parse(string snbt)
        {
            Redstone.Core.RedstoneException.ThrowIfNull(snbt);

            // Parse into a ChatComponent when possible and wrap into a builder that can
            // produce a JSON output suitable for Java edition text components.
            var component = ChatComponent.Parse(snbt);
            return new ComponentChatBuilder(snbt, component);
        }

        private sealed class ComponentChatBuilder : ChatBuilder
        {
            private readonly ChatComponent _component;

            public ComponentChatBuilder(string raw, ChatComponent component) : base(raw)
            {
                _component = component;
            }

            public override string Output
            {
                get
                {
                    try
                    {
                        // Minimal JSON serialization for supported component types.
                        if (_component is PlainText pt)
                        {
                            return System.Text.Json.JsonSerializer.Serialize(new { text = pt.Text });
                        }

                        if (_component is TranslatedText tt)
                        {
                            var dict = new Dictionary<string, object?> { ["translate"] = tt.Translate };
                            if (tt.Fallback != null && tt.Fallback.Enabled) dict["fallback"] = tt.Fallback.Value;
                            // 'with' not serialized in this minimal implementation
                            return System.Text.Json.JsonSerializer.Serialize(dict);
                        }

                        if (_component is ScoreboardValue sv)
                        {
                            var scoreObj = new Dictionary<string, object>
                            {
                                ["score"] = new { name = sv.Name, objective = sv.Objective }
                            };
                            return System.Text.Json.JsonSerializer.Serialize(scoreObj);
                        }

                        // For unknown component types return the raw input - it's expected to be
                        // valid JSON/SNBT already in many of the caller locations.
                        return RawText;
                    }
                    catch
                    {
                        return RawText;
                    }
                }
            }
        }
    }
}
