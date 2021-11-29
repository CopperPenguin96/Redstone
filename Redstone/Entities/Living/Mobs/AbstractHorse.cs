﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using Redstone.Utils;

namespace Redstone.Entities.Living.Mobs
{
    public class AbstractHorse : Animal
    {
        private byte _flags = 0;

        public bool IsTame
        {
            get => FlagsHelper.IsSet(_flags, (byte) HorseFlag.Tame);
            set
            {
                if (value) FlagsHelper.Set(ref _flags, (byte) HorseFlag.Tame);
                else FlagsHelper.Unset(ref _flags, (byte) HorseFlag.Tame);
            }
        }

        public bool IsSaddled
        {
            get => FlagsHelper.IsSet(_flags, (byte) HorseFlag.Saddled);
            set
            {
                if (value) FlagsHelper.Set(ref _flags, (byte) HorseFlag.Saddled);
                else FlagsHelper.Unset(ref _flags, (byte) HorseFlag.Saddled);
            }
        }

        public bool HasBred
        {
            get => FlagsHelper.IsSet(_flags, (byte) HorseFlag.Bred);
            set
            {
                if (value) FlagsHelper.Set(ref _flags, (byte) HorseFlag.Bred);
                else FlagsHelper.Unset(ref _flags, (byte) HorseFlag.Bred);
            }
        }

        public bool IsEating
        {
            get => FlagsHelper.IsSet(_flags, (byte) HorseFlag.Eating);
            set
            {
                if (value) FlagsHelper.Set(ref _flags, (byte) HorseFlag.Eating);
                else FlagsHelper.Unset(ref _flags, (byte) HorseFlag.Eating);
            }
        }

        public bool IsRearingOnHindLegs
        {
            get => FlagsHelper.IsSet(_flags, (byte) HorseFlag.Rearing);
            set
            {
                if (value) FlagsHelper.Set(ref _flags, (byte) HorseFlag.Rearing);
                else FlagsHelper.Unset(ref _flags, (byte) HorseFlag.Rearing);
            }
        }

        public bool IsMouthOpen
        {
            get => FlagsHelper.IsSet(_flags, (byte) HorseFlag.MouthOpen);
            set
            {
                if (value) FlagsHelper.Set(ref _flags, (byte) HorseFlag.MouthOpen);
                else FlagsHelper.Unset(ref _flags, (byte) HorseFlag.MouthOpen);
            }
        }

        public OptObject<JavaUUID> Owner { get; set; }
    }
}
