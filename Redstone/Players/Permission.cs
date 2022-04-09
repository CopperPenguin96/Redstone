using MinecraftTypes;

namespace Redstone.Players
{
    public sealed class Permission
    {
        /// <summary>
        /// Does not include plugin-related permissions.
        /// Note, permissions here always overwrite plugin permissions
        /// in the case of duplicate naming.
        /// </summary>
        public static List<Permission> All = new();

        public static List<Permission> PluginPerms = new();

        public int Index { get; set; }

        public string Name { get; set; }

        public string Plugin { get; set; }

        public Identifier Identifier
            => new("Plugin", "permission{" + Index + "}");

        private Permission()
        {
        }

        /// <summary>
        /// Only use if creating new permissiond
        /// </summary>
        private Permission(int index, string name)
        {
            Permission p = new()
            {
                Plugin = "redstone",
                Name = name,
                Index = index
            };

            All.Add(p);
        }

        /// <summary>
        /// Only use if calling existing permission
        /// </summary>
        private Permission(string plugin, int index)
        {
            bool stop = false;
            foreach (var p in All.Where(p => p.Index == index && !stop))
            {
                stop = true;
                Index = index;
                Name = p.Name;
            }

            foreach (var p in PluginPerms.Where(p 
                         => p.Index == index 
                            && !stop
                            && plugin.ToLower() == p.Plugin.ToLower()))
            {

                stop = true;
                Index = index;
                Name = p.Name;
            }

            if (!stop)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Only to be used when creating plugin defined permissions.
        /// </summary>
        /// <param name="plugin"></param>
        /// <param name="name"></param>
        /// <param name="index"></param>
        private Permission(string plugin, string name, int index)
        {
            Add(plugin, index, name);
        }

        public static Permission Get(int index, string plugin = "redstone")
        {
            return new(plugin, index);
        }

        public static void Add(string pluginName, int index, string name)
        {
            PluginPerms.Add(new(pluginName, name, index));
        }

        /// <summary>
        /// Ability to chat and to PM players.
        /// Note that players without this permission can still
        /// type in commands, receive PMs, and read chat.
        /// </summary>
        public static readonly Permission Chat = new(0, "Chat");

        /// <summary>
        /// Ability to place blocks on maps.
        /// This is a baseline permission that can be overridden by
        /// world-specific and zone-specific permissions.
        /// </summary>
        public static readonly Permission Build = new(1, "Build");

        /// <summary>
        /// Ability to delete or replace blocks on maps.
        /// This is a baseline permission that can be overriden by
        /// world-specific and zone-specific permissions.
        /// </summary>
        public static readonly Permission Delete = new(2, "Delete");

        /// <summary>
        /// Ability to set own exit message.
        /// </summary>

        public static readonly Permission ExitMessage = new(3, "ExitMessage");

        /// <summary>
        /// Ability to set other exit message.
        /// </summary>

        public static Permission SetOtherExitMessae = new(4, "SetOtherExitMessage");
    }
}
