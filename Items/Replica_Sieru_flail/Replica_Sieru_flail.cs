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
	public class Replica_Sieru_flail : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Sieru_flail/Replica_Sieru_flail"; }
		}
			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("[Replica] A maid's choice kitchen knife");
				Tooltip.SetDefault("「冥土 於武 女以止」"
					+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
				SacrificeTotal = 1;

				// This line will make the damage shown in the tooltip twice the actual Item.damage. This multiplier is used to adjust for the dynamic damage capabilities of the projectile.
				// When thrown directly at enemies, the flail projectile will deal double Item.damage, matching the tooltip, but deals normal damage in other modes.
				//ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
			}

			public override void SetDefaults()
			{
				Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
				Item.useAnimation = 30; // The item's use time in ticks (60 ticks == 1 second.)
				Item.useTime = 30; // The item's use time in ticks (60 ticks == 1 second.)
				Item.knockBack = 6f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
				Item.width = 32; // Hitbox width of the item.
				Item.height = 32; // Hitbox height of the item.
				Item.damage = 14; // The damage of your flail, this is dynamically adjusted in the projectile code.
				Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
				Item.shoot = ModContent.ProjectileType<Replica_Sieru_flail_Projectile>(); // The flail projectile
				Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
				//Item.UseSound = SoundID.Item1; // The sound that this item makes when used
				Item.rare = ItemRarityID.Green; // The color of the name of your item
				Item.value = Item.sellPrice(gold: 1, silver: 50); // Sells for 1 gold 50 silver
				Item.DamageType = DamageClass.MeleeNoSpeed; // Deals melee damage
				Item.channel = true;
				Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation
				Item.consumable = false;
			}

		public override void AddRecipes()               //in final version, use Celebration as ingredient, not a consummeble anymore
		{
			Recipe Replica_Sieru_flail_Recipe = CreateRecipe(1);
			Replica_Sieru_flail_Recipe.AddIngredient(ItemID.ThrowingKnife, 50);              //use explosivebunny in next upgrade
			Replica_Sieru_flail_Recipe.AddIngredient(ItemID.Chain, 3);
			Replica_Sieru_flail_Recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			Replica_Sieru_flail_Recipe.AddTile(TileID.Anvils);
			Replica_Sieru_flail_Recipe.Register();
		}


	}

}