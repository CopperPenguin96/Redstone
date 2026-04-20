using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.Core.Types
{
    public class Sound(Identifier id): NbtTagProvider
    {
        public Identifier Name { get; private set; } = id;

        private bool RequireAdditionalInformation = false;

        private OptValue<float>? _volume = new(true, 1.0f);
        public OptValue<float>? Volume
        {
            get => _volume;
            set
            {
                if (value != null && value.Enabled && value.Value <= 0.0f)
                {
                    throw new RedstoneException(new IndexOutOfRangeException("Volume must either be null or greater than 0.0"));
                }

                _volume = value;
            }
        }

        private OptValue<float>? _pitch = new(true, 1.0f);
        public OptValue<float>? Pitch
        {
            get => _pitch;
            set
            {
                if (value != null && value.Enabled && value.Value <= 0.0f)
                {
                    throw new RedstoneException(new IndexOutOfRangeException("Pitch must either be null or greater than 0.0"));
                }

                _pitch = value;
            }
        }

        private OptValue<int>? _weight = new(true, 1);
        public OptValue<int>? Weight
        {
            get => _weight;
            set
            {
                if (value != null && value.Enabled && value.Value <= 0)
                {
                    throw new RedstoneException(new IndexOutOfRangeException("Weight must either be null or greater than 0"));
                }

                _weight = value;
            }
        }

        public OptValue<bool> StreamFromFile { get; set; } = new(true, true);

        private OptValue<int>? _attDis = new(true, 16);
        public OptValue<int>? AttenuationDistance
        {
            get => _attDis;
            set
            {
                if (value != null && value.Enabled && value.Value <= 0)
                {
                    throw new RedstoneException(new IndexOutOfRangeException("Attenuation Distance must either be null or greater than 0"));
                }

                _attDis = value;
            }
        }

        public bool Preload { get; set; } = false;

        public OptValue<SoundType> Type { get; set; } = new(true, SoundType.File);

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag tag = new()
                {
                    { "name", Name.ToString() },
                    { "preload", Preload }
                };

                if (Volume != null && Volume.Enabled) tag.Add("volume", Volume.Value);
                if (Pitch != null && Pitch.Enabled) tag.Add("pitch", Pitch.Value);
                if (Weight != null && Weight.Enabled) tag.Add("weight", Weight.Value);
                if (StreamFromFile != null && StreamFromFile.Enabled) tag.Add("stream", StreamFromFile.Value);
                if (AttenuationDistance != null && AttenuationDistance.Enabled) tag.Add("attenuation_distance", AttenuationDistance.Value);

                string type = Type.Value.ToString()!.ToLower();
                if (Type != null && Type.Enabled) tag.Add("type", type);

                return tag;
            }
        }

        public override void Parse(NbtTag tag)
        {
            CompoundTag? cmpTag = tag as CompoundTag;
            Name = cmpTag!["name"].ValueAsString;

            if (cmpTag.Contains("volume"))
                Volume = new(true, cmpTag!["volume"].ValueAsLong);

            if (cmpTag.Contains("pitch"))
                Pitch = new(true, cmpTag!["pitch"].ValueAsLong);

            if (cmpTag.Contains("weight"))
                Weight = new(true, cmpTag!["weight"].ValueAsInt);

            if (cmpTag.Contains("stream"))
                StreamFromFile = new(true, cmpTag!["stream"].ValueAsBool);

            if (cmpTag.Contains("attenuation_distance"))
                AttenuationDistance = new(true, cmpTag!["attenuation_distance"].ValueAsInt);

            if (cmpTag.Contains("preload")) Preload = cmpTag!["preload"].ValueAsBool;
            else Preload = false;

            if (cmpTag.Contains("type"))
            {
                string typeStr = cmpTag!["type"].ValueAsString;
                SoundType ty = SoundType.File;
                if (typeStr == "event") ty = SoundType.Event;
                Type = new(true, ty);
            }
        }
    }

    public enum SoundType
    {
        File, Event
    }
}
