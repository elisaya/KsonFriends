using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ModLoader.Utilities;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using KsonFriends.ModPlayers;
using Terraria.DataStructures;
using System.Linq;
using Terraria.GameContent.Creative;
using KsonFriends.Items;
using Terraria.GameContent;

namespace KsonFriends.Items
{
	public class Replica_Koheita_guitar_Projectile : ModProjectile
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Koheita_guitar/Replica_Koheita_guitar_Projectile"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Replica_Koheita_guitar_Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 21;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 0;
			AIType = ProjectileID.TiedEighthNote;
			Projectile.timeLeft = 240;
			Projectile.light = 0.4f;
		}
	}
}