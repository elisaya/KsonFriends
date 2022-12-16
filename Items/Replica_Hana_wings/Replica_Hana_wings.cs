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
	[AutoloadEquip(EquipType.Wings)]
	public class Replica_Hana_wings : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Hana_wings/Replica_Hana_wings"; }
		}


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Replica] Flower Fairy's Wings");
			Tooltip.SetDefault("Every flower fairy was born with a pair of wings that have the magical power of wild wielding."
				+ Environment.NewLine + "Obviously not a pair of REAL fairy wings freshly ripped off from a poor fella."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");

			// These wings use the same values as the solar wings
			// Fly time: 180 ticks = 3 seconds
			// Fly speed: 9
			// Acceleration multiplier: 2.5
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(90, 5f, 1.2f);
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = 115;
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.wingTimeMax = 30;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.8f; // Falling glide speed
			ascentWhenRising = 0.10f; // Rising speed
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2.5f;
			constantAscend = 0.135f;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe Replica_Hana_wings_recipe = CreateRecipe(1);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.LifeCrystal);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.Sunflower);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.Cloud, 10);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.Vine, 10);
			Replica_Hana_wings_recipe.AddTile(TileID.WorkBenches);
			Replica_Hana_wings_recipe.Register();

		}
		
	}




}