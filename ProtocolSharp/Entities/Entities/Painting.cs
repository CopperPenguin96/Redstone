using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Painting : Entity
	{
		public override EntityType Type => EntityType.Painting;

		public override float BoundingBoxX => 0.7f;

		public override float BoundingBoxY => 0.6f;

		public override Identifier ID => new Identifier("bee");

		public override bool UseWithSpawnObject => false;

		public PaintingDesign Design { get; set; }

		public int DesignPosX { get; set; }

		public int DesignPosY { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }

		public PaintingDirection Direction { get; set; }

		public Painting(PaintingDesign design, int x, int y, int width, int height)
		{
			Design = design;
			DesignPosX = x;
			DesignPosY = y;
			Width = width;
			Height = height;
		}

		#region Painting Definitions

		public static readonly Painting Kebab = new Painting(PaintingDesign.Kebab, 0, 0, 16, 16);
		public static readonly Painting Aztec = new Painting(PaintingDesign.Aztec, 16, 0, 16, 16);
		public static readonly Painting Alban = new Painting(PaintingDesign.Alban, 32, 0, 16, 16);
		public static readonly Painting Aztec2 = new Painting(PaintingDesign.Aztec2, 48, 0, 16, 16);
		public static readonly Painting Bomb = new Painting(PaintingDesign.Bomb, 64, 0, 16, 16);
		public static readonly Painting Plant = new Painting(PaintingDesign.Plant, 80, 0, 16, 16);
		public static readonly Painting Wasteland = new Painting(PaintingDesign.Wasteland, 96, 0, 16, 16);
		public static readonly Painting Pool = new Painting(PaintingDesign.Pool, 0, 32, 32, 16);
		public static readonly Painting Courbet = new Painting(PaintingDesign.Courbet, 32, 32, 32, 16);
		public static readonly Painting Sea = new Painting(PaintingDesign.Sea, 64, 32, 32, 16);
		public static readonly Painting Sunset = new Painting(PaintingDesign.Sunset, 96, 32, 32, 16);
		public static readonly Painting Creebet = new Painting(PaintingDesign.Creebet, 128, 32, 32, 16);
		public static readonly Painting Wanderer = new Painting(PaintingDesign.Wanderer, 0, 64, 16, 32);
		public static readonly Painting Graham = new Painting(PaintingDesign.Graham, 16, 64, 16, 32);
		public static readonly Painting Match = new Painting(PaintingDesign.Match, 0, 128, 32, 32);
		public static readonly Painting Bust = new Painting(PaintingDesign.Bust, 32, 128, 32, 32);
		public static readonly Painting Stage = new Painting(PaintingDesign.Stage, 64, 128, 32, 32);
		public static readonly Painting Void = new Painting(PaintingDesign.Void, 96, 128, 32, 32);
		public static readonly Painting SkullAndRoses = new Painting(PaintingDesign.SkullAndRoses, 128, 128, 32, 32);
		public static readonly Painting Wither = new Painting(PaintingDesign.Wither, 160, 128, 32, 32);
		public static readonly Painting Fighters = new Painting(PaintingDesign.Fighters, 0, 96, 64, 32);
		public static readonly Painting Pointer = new Painting(PaintingDesign.Pointer, 0, 192, 64, 64);
		public static readonly Painting Pigscene = new Painting(PaintingDesign.Pigscene, 64, 192, 64, 64);
		public static readonly Painting BurningSkull = new Painting(PaintingDesign.BurningSkull, 128, 192, 64, 64);
		public static readonly Painting Skeleton = new Painting(PaintingDesign.Skeleton, 192, 64, 64, 48);
		public static readonly Painting DonkeyKong = new Painting(PaintingDesign.DonkeyKong, 192, 112, 64, 48);

		#endregion
	}

	public enum PaintingDesign
	{
		Kebab = 0,
		Aztec = 1,
		Alban = 2,
		Aztec2 = 3,
		Bomb = 4,
		Plant = 5,
		Wasteland = 6,
		Pool = 7,
		Courbet = 8,
		Sea = 9,
		Sunset = 10,
		Creebet = 11,
		Wanderer = 12,
		Graham = 13,
		Match = 14,
		Bust = 15,
		Stage = 16,
		Void = 17,
		SkullAndRoses = 18,
		Wither = 19,
		Fighters = 20,
		Pointer = 21,
		Pigscene = 22,
		BurningSkull = 23,
		Skeleton = 24,
		DonkeyKong = 25
	}
}
