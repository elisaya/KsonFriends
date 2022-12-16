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

namespace KsonFriends.Items
{
	public class Replica_Kourin_hook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kourin's Huggy Teddy Bear");
			Tooltip.SetDefault("Traveling with Kourin to this world. Kourin hugs the all the time, so from Kourin, it knows how to cuddle. Nothing special except being huggy."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Kourin_hook/Replica_Kourin_hook"; }
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmethystHook);
			Item.noUseGraphic = true;
			Item.damage = 0;
			Item.noMelee = true;
			Item.width = 18;
			Item.height = 28;
			Item.useTurn = true;
			Item.useAnimation = 20;
			Item.rare = 5;
			Item.value = 216;
			Item.shootSpeed = 18f;
			Item.shoot = ModContent.ProjectileType<Replica_Kourin_Hook_Projectile>(); // Makes the item shoot the hook's projectile when used.
		}

		public override void AddRecipes()
		{
			Recipe Kourin_hook_recipe = CreateRecipe(1);
			Kourin_hook_recipe.AddIngredient(ItemID.LifeCrystal, 1);
			Kourin_hook_recipe.AddIngredient(ItemID.Silk, 25);
			Kourin_hook_recipe.AddIngredient(ItemID.SilkRope, 5);
			Kourin_hook_recipe.AddTile(TileID.Loom);
			Kourin_hook_recipe.Register();

		}
	}

}