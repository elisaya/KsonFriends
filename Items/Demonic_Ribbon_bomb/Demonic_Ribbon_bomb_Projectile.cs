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
	public class Demonic_Ribbon_bomb_Projectile : ModProjectile
	{
		int bomb_damage = 160;
		int bomb_dimension = 20;
		int radius = 8;
		bool tile_destruction = false;

		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Ribbon_bomb/Demonic_Ribbon_bomb_Projectile"; }
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = bomb_dimension;
			Projectile.height = bomb_dimension;
			Projectile.aiStyle = 2;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.alpha = 0;
			AIType = ProjectileID.ToxicFlask;
			Projectile.timeLeft = 240;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.localNPCImmunity[target.whoAmI] = 60;
			Projectile.timeLeft = 3;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// Die immediately if ai[1] isn't 0 (We set this to 1 for the 5 extra explosives we spawn in Kill)
			if (Projectile.ai[1] != 0)
			{
				return true;
			}

			// This code makes the Projectile very bouncy.
			if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
			{
				Projectile.velocity.X = oldVelocity.X * -0.4f;
			}
			if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
			{
				Projectile.velocity.Y = oldVelocity.Y * -0.4f;
			}
			return false;
		}

		public override void AI()
		{
			if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
			{
				Projectile.tileCollide = false;
				// Set to transparent. This Projectile technically lives as  transparent for about 3 frames
				Projectile.alpha = 255;
				// change the hitbox size, centered about the original Projectile center. This makes the Projectile damage enemies during the explosion.
				Projectile.position = Projectile.Center;
				//Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
				//Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
				Projectile.width = 250;
				Projectile.height = 250;
				Projectile.Center = Projectile.position;
				//Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
				//Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
				Projectile.damage = bomb_damage;
				Projectile.knockBack = 0f;
			}
			else
			{
				// Smoke and fuse dust spawn.
				if (Main.rand.NextBool())
				{
					int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Water_Hallowed, 0f, 0f, 100, default(Color), 1f);
					Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
					dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.RuneWizard, 0f, 0f, 100, default(Color), 1f);
					Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2 - 6)).RotatedBy((double)Projectile.rotation, default(Vector2)) * 1.1f;
				}
			}
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] > 5f)
			{
				Projectile.ai[0] = 10f;
				// Roll speed dampening.
				if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
				{
					Projectile.velocity.X = Projectile.velocity.X * 0.97f;
					//if (Projectile.type == 29 || Projectile.type == 470 || Projectile.type == 637)
					{
						Projectile.velocity.X = Projectile.velocity.X * 0.99f;
					}
					if ((double)Projectile.velocity.X > -0.01 && (double)Projectile.velocity.X < 0.01)
					{
						Projectile.velocity.X = 0f;
						Projectile.netUpdate = true;
					}
				}
				Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
			}
			// Rotation increased by velocity.X 
			Projectile.rotation += Projectile.velocity.X * 0.1f;
			return;
		}

		public override void Kill(int timeLeft)
		{
			// Fire Dust spawn
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Water_Hallowed, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.RuneWizard, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			// reset size to normal width and height.
			Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
			Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
			Projectile.width = bomb_dimension;
			Projectile.height = bomb_dimension;
			Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
			Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);

			{
				int explosionRadius = radius;
				int minTileX = (int)(Projectile.position.X / 16f - (float)explosionRadius);
				int maxTileX = (int)(Projectile.position.X / 16f + (float)explosionRadius);
				int minTileY = (int)(Projectile.position.Y / 16f - (float)explosionRadius);
				int maxTileY = (int)(Projectile.position.Y / 16f + (float)explosionRadius);
				if (minTileX < 0)
				{
					minTileX = 0;
				}
				if (maxTileX > Main.maxTilesX)
				{
					maxTileX = Main.maxTilesX;
				}
				if (minTileY < 0)
				{
					minTileY = 0;
				}
				if (maxTileY > Main.maxTilesY)
				{
					maxTileY = Main.maxTilesY;
				}
				bool canKillWalls = false;
				for (int x = minTileX; x <= maxTileX; x++)
				{
					for (int y = minTileY; y <= maxTileY; y++)
					{
						float diffX = Math.Abs((float)x - Projectile.position.X / 16f);
						float diffY = Math.Abs((float)y - Projectile.position.Y / 16f);
						double distance = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
						if (distance < (double)explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].WallType == 0)
						{
							canKillWalls = true;
							break;
						}
					}
				}
				for (int i = minTileX; i <= maxTileX; i++)
				{
					for (int j = minTileY; j <= maxTileY; j++)
					{
						float diffX = Math.Abs((float)i - Projectile.position.X / 16f);
						float diffY = Math.Abs((float)j - Projectile.position.Y / 16f);
						double distanceToTile = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
						if (distanceToTile < (double)explosionRadius)
						{
							bool canKillTile = true;
							if (Main.tile[i, j] != null && tile_destruction)
							{
								canKillTile = true;
								if (Main.tileDungeon[(int)Main.tile[i, j].TileType] || Main.tile[i, j].TileType == 88 || Main.tile[i, j].TileType == 21 || Main.tile[i, j].TileType == 26 || Main.tile[i, j].TileType == 107 || Main.tile[i, j].TileType == 108 || Main.tile[i, j].TileType == 111 || Main.tile[i, j].TileType == 226 || Main.tile[i, j].TileType == 237 || Main.tile[i, j].TileType == 221 || Main.tile[i, j].TileType == 222 || Main.tile[i, j].TileType == 223 || Main.tile[i, j].TileType == 211 || Main.tile[i, j].TileType == 404)
								{
									canKillTile = false;
								}
								if (!Main.hardMode && Main.tile[i, j].TileType == 58)
								{
									canKillTile = false;
								}
								if (!TileLoader.CanExplode(i, j))
								{
									canKillTile = false;
								}
								if (canKillTile)
								{
									WorldGen.KillTile(i, j, false, false, false);
									if (Main.netMode != NetmodeID.SinglePlayer)
									{
										NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
									}
								}
							}
							if (canKillTile)
							{
								for (int x = i - 1; x <= i + 1; x++)
								{
									for (int y = j - 1; y <= j + 1; y++)
									{
										if (Main.tile[x, y] != null && Main.tile[x, y].WallType > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].WallType))
										{
											WorldGen.KillWall(x, y, false);
											if (Main.tile[x, y].WallType == 0 && Main.netMode != NetmodeID.SinglePlayer)
											{
												NetMessage.SendData(MessageID.TileChange, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

	}
}