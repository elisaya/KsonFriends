using System;
using Microsoft.Xna.Framework;
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

namespace KsonFriends.Items
{
    public class Demonic_Reto_scissors_Projectile : ModProjectile
    {
		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Reto_scissors/Demonic_Reto_scissors_Projectile"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonic_Reto_scissors");
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 48;
			Projectile.height = 32;
			Projectile.aiStyle = 39;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			SoundStyle Kson_sword_bonk = new SoundStyle("KsonFriends/Assets/bonk");
			SoundEngine.PlaySound(Kson_sword_bonk, new Vector2(target.position.X, target.position.Y));

			target.AddBuff(BuffID.Confused, 30);
			target.AddBuff(BuffID.Midas, 180);

			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			if (target.life <= 0)
			{
				MPlayer.Reto_scissors_kill_count += 1;
			}
		}

    }
}