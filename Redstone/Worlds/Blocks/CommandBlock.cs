using Redstone.Types;
using Redstone.Utils;
using SmartNbt.Tags;

namespace Redstone.Worlds.Blocks
{
    public class CommandBlock : Block
    {
        public override string Name => "Command Block";

        public override Identifier Id => "command_block";

        public override int Type => 137;

        public override int Meta => 0;

        public bool Auto { get; set; }

        public string Command { get; set; }

        public bool ConditionMet { get; set; }

        public string CustomName { get; set; }

        public long LastExecution { get; set; }

        public string LastOutput { get; set; }

        public bool Powered { get; set; }

        public int SuccessCount { get; set; }

        public bool TrackOutput { get; set; }

        public bool UpdateLastExecution { get; set; }

        public override NbtCompound? NBT
        {
            get
            {
                NbtCompound nbt = new()
                {
                    new NbtByte(AutoName, Auto.ToByte()),
                    new NbtString(CmdName, Command),
                    new NbtByte(CondMetName, ConditionMet.ToByte()),
                    new NbtString(CustName, CustomName),
                    new NbtLong(LastExecName, LastExecution),
                    new NbtString(LastOutputName, LastOutput),
                    new NbtByte(PoweredName, Powered.ToByte()),
                    new NbtInt(SuccCountName, SuccessCount),
                    new NbtByte(TrackOutputName, TrackOutput.ToByte()),
                    new NbtByte(UpdLastExec, UpdateLastExecution.ToByte())
                };

                return nbt;
            }
        }

        private const string AutoName = "auto";
        private const string CmdName = "Command";
        private const string CondMetName = "ConditionMet";
        private const string CustName = "CustomName";
        private const string LastExecName = "LastExecution";
        private const string LastOutputName = "LastOutput";
        private const string PoweredName = "powered";
        private const string SuccCountName = "SuccessCount";
        private const string TrackOutputName = "TrackOutput";
        private const string UpdLastExec = "UpdateLastExecution";
    }
}
