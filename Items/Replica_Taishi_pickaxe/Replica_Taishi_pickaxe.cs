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
	[AutoloadHead]

	public class Replica_Taishi_pickaxe : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Taishi_pickaxe/Replica_Taishi_pickaxe"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Replica] Angelic power Pickaxe");
			Tooltip.SetDefault("Replica of the pickaxe baptized and blessed with angelice power"
				+ Environment.NewLine + "Extra diggy, extra grip!"
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.noMelee = false;
			Item.height = 50;
			Item.width = 36;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 104;
			Item.rare = 3;
			Item.crit = 8;
			Item.holdStyle = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.pick = 45;
			Item.axe = 13;			//in game value will *5. eg 10 axe power will translate to 50 in game
			Item.hammer = 60;
		}

		public override void AddRecipes()
		{
			Recipe Kson_sword_recipe = CreateRecipe(1);
			Kson_sword_recipe.AddIngredient(ItemID.IronPickaxe);
			Kson_sword_recipe.AddIngredient(ItemID.WaterBucket);
			Kson_sword_recipe.AddTile(TileID.WorkBenches);
			Kson_sword_recipe.Register();
		}

		//maybe healing beam after 3rd upgrade?


	}
}