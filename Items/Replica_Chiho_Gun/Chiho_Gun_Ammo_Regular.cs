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
	public class Chiho_Gun_Ammo_Regular : ModItem
	{
		
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Chiho_Gun/Chiho_Gun_Ammo_Regular"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Basic Kinetic Strike Shell");
			Tooltip.SetDefault("The most simple form of shell designed specifically for kinetic strikes. In short, its a bulk of metal.");
		}

		public override void SetDefaults()
		{
			Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shootSpeed = 16f; // The speed of the projectile.
			Item.ammo = this.Type;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Chiho_Gun_Ammo_Regular_Projectile>();
		}


		/*public override void AI()
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
				Projectile.width = bullet_dimension * 2;
				Projectile.height = bullet_dimension * 2;
				Projectile.Center = Projectile.position;
				//Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
				//Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
				Projectile.damage = bullet_damage;
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
		}*/

		public override void AddRecipes()
		{
			Recipe Chiho_Gun_Ammo_Regular = CreateRecipe(1);
			Chiho_Gun_Ammo_Regular.AddRecipeGroup(RecipeGroupID.IronBar, 3);
			Chiho_Gun_Ammo_Regular.AddIngredient(ItemID.Grenade, 1);
			Chiho_Gun_Ammo_Regular.AddTile(TileID.Anvils);
			Chiho_Gun_Ammo_Regular.Register();
		}
	}
}