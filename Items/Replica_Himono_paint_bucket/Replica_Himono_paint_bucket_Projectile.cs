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
	public class Replica_Himono_paint_bucket_Projectile : ModProjectile
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Himono_paint_bucket/Replica_Himono_paint_bucket_Projectile"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Replica_Himono_paint_bucket_Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 0;
			AIType = ProjectileID.Grenade;
			Projectile.timeLeft = 240;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Projectile.owner == Main.myPlayer)
				{
					int rand = Main.rand.Next(8, 12);			//number of paint drops spawning
					for (int k = 0; k < rand; k++)
						{
							Vector2 vector27 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
							vector27.Normalize();
							vector27 *= (float)Main.rand.Next(10, 201) * 0.01f;
							Projectile.NewProjectile(Projectile.GetSource_OnHit(target), Projectile.position, vector27, ModContent.ProjectileType<Replica_Himono_paint_bucket_Projectile_1>(), Projectile.damage, 1f, Projectile.owner);
						}
				}
			Projectile.localNPCImmunity[target.whoAmI] = 60;
			Projectile.timeLeft = 0;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.owner == Main.myPlayer)
			{
				int rand = Main.rand.Next(6, 10);               //number of paint drops spawning
				for (int k = 0; k < rand; k++)
				{
					Vector2 vector27 = new Vector2(Main.rand.Next(-200, 201), Main.rand.Next(-200, 201));
					vector27.Normalize();
					vector27 *= (float)Main.rand.Next(10, 201) * 0.01f;
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, vector27, ModContent.ProjectileType<Replica_Himono_paint_bucket_Projectile_1>(), Projectile.damage, 1f, Projectile.owner);
				}
			}

			Projectile.timeLeft = 0;

			return false;
		}


		public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			//SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Main.instance.LoadProjectile(Projectile.type);
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

			// Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}

			return true;
		}


	}


	public class Replica_Himono_paint_bucket_Projectile_1 : ModProjectile
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Himono_paint_bucket/Replica_Himono_paint_bucket_Projectile_1"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Replica_Himono_paint_bucket_Projectile_1");
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 32;
			Projectile.damage = 12;
			Projectile.height = 32;
			Projectile.aiStyle = 92;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 180;
            //Projectile.usesLocalNPCImmunity = true;
			//Projectile.localNPCHitCooldown = 2;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.immune[Projectile.owner] = 20;
		}
    }
}