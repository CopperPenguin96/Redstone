using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities
{
	public class Particle<T>
	{
		public ParticleID ID { get; set; }

		public T Data { get; set; }

		/// <summary>
		/// Use if particle has no data
		/// </summary>
		/// <param name="id"></param>
		public Particle(ParticleID id)
		{
			ID = id;
		}

		public Particle(ParticleID id, T data) : this(id)
		{
			Data = data;
		}

		public Particle(int id, T data) : this((ParticleID) id, data)
		{

		}

		public Particle(int id) : this((ParticleID) id)
		{

		}

		#region Particles

		public static Particle<object> AmbientEntityEffect = new Particle<object>(0);
		public static Particle<object> AngryVillager = new Particle<object>(1);
		public static Particle<object> Barrier = new Particle<object>(2);

		/// <summary>
		/// Data is the VarInt ID of the block's state
		/// </summary>
		public static Particle<VarInt> Block = new Particle<VarInt>(3, 0);

		public static Particle<object> Bubble = new Particle<object>(4);
		public static Particle<object> Cloud = new Particle<object>(5);
		public static Particle<object> Crit = new Particle<object>(6); // ?
		public static Particle<object> DamageIndicator = new Particle<object>(7);
		public static Particle<object> DragonBreath = new Particle<object>(8); // Some of y'all
		public static Particle<object> DrippingLava = new Particle<object>(9);
		public static Particle<object> FallingLava = new Particle<object>(10);
		public static Particle<object> LandingLava = new Particle<object>(11);
		public static Particle<object> DrippingWater = new Particle<object>(12);
		public static Particle<object> FallingWater = new Particle<object>(13);
		public static Particle<DustColor> Dust = new Particle<DustColor>(14, new DustColor());
		public static Particle<object> Effect = new Particle<object>(15);
		public static Particle<object> ElderGuardian = new Particle<object>(16);
		public static Particle<object> Enchantedhit = new Particle<object>(17);
		public static Particle<object> Enchant = new Particle<object>(18);
		public static Particle<object> EndRod = new Particle<object>(19);
		public static Particle<object> EntityEffect = new Particle<object>(20);
		public static Particle<object> ExplosionEmitter = new Particle<object>(21);
		public static Particle<object> Explosion = new Particle<object>(22);

		/// <summary>
		/// Data is the VarInt ID of the block's state
		/// </summary>
		public static Particle<VarInt> FallingDust = new Particle<VarInt>(23);

		public static Particle<object> Firework = new Particle<object>(24);
		public static Particle<object> Fishing = new Particle<object>(25);
		public static Particle<object> Flame = new Particle<object>(26);
		public static Particle<object> Flash = new Particle<object>(27); // Zoom
		public static Particle<object> HappyVillager = new Particle<object>(28);
		public static Particle<object> Composter = new Particle<object>(29);
		public static Particle<object> Heart = new Particle<object>(30);
		public static Particle<object> InstantEffect = new Particle<object>(31);
		public static Particle<Slot> Item = new Particle<Slot>(32, new Slot());
		public static Particle<object> ItemSlime = new Particle<object>(33);
		public static Particle<object> ItemSnowball = new Particle<object>(34);
		public static Particle<object> LargeSmoke = new Particle<object>(35);
		public static Particle<object> Lava = new Particle<object>(36);
		public static Particle<object> Mycelium = new Particle<object>(37);
		public static Particle<object> Note = new Particle<object>(38);
		public static Particle<object> Poof = new Particle<object>(39);
		public static Particle<object> Portal = new Particle<object>(40);
		public static Particle<object> Rain = new Particle<object>(41);
		public static Particle<object> Smoke = new Particle<object>(42);
		public static Particle<object> Sneeze = new Particle<object>(43);
		public static Particle<object> Spit = new Particle<object>(44);
		public static Particle<object> SquidInk = new Particle<object>(45); // Aww, you guys made me ink!
		public static Particle<object> SweepAttack = new Particle<object>(46);
		public static Particle<object> TotemOfUndying = new Particle<object>(47);
		public static Particle<object> Underwater = new Particle<object>(48);
		public static Particle<object> Splash = new Particle<object>(49);
		public static Particle<object> Witch = new Particle<object>(50);
		public static Particle<object> BubblePop = new Particle<object>(51);
		public static Particle<object> CurrentDown = new Particle<object>(52);
		public static Particle<object> BubbleColumnUp = new Particle<object>(53);
		public static Particle<object> Nautilus = new Particle<object>(54);
		public static Particle<object> Dolphin = new Particle<object>(55);
		public static Particle<object> CampfireCosySmoke = new Particle<object>(56);
		public static Particle<object> CampfireSignalSmoke = new Particle<object>(57);
		public static Particle<object> DrippingHoney = new Particle<object>(58);
		public static Particle<object> FallingHoney = new Particle<object>(59);
		public static Particle<object> LandingHoney = new Particle<object>(60);
		public static Particle<object> FallingNectar = new Particle<object>(61);
	}

	#endregion

	public enum ParticleID
	{

	}
}
