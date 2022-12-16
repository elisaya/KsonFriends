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
	public class Replica_Coco_asacoco : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Coco_asacoco/Replica_Coco_asacoco"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Basic] Breathe-In Type Asacoco");
			Tooltip.SetDefault("\"Every puff makes you stronger! \"" + Environment.NewLine + "Side-effect: May or maynot reduce your lifespan. 50/50 worth risking no?"
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override void SetDefaults()
		{
			//item.damage determines the contact damage of the bomb
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.shootSpeed = 10f;
			Item.width = 30;
			Item.height = 34;
			Item.maxStack = 55;
			Item.consumable = true;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.noUseGraphic = false;
			Item.value = 619;
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = false;
			
		}


        public override bool? UseItem(Player player)
        {
			player.AddBuff(BuffID.Swiftness, 3600);
			player.AddBuff(BuffID.Ironskin, 3600);
			player.AddBuff(BuffID.Wrath, 3600);
			player.AddBuff(BuffID.Poisoned, 300);

			return base.UseItem(player);
        }

        public override void AddRecipes()				//in final version, use Celebration as ingredient, not a consummeble anymore
		{
			Recipe Replica_Ribbon_bomb_recipe = CreateRecipe(5);
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.SwiftnessPotion, 5);				//use explosivebunny in next upgrade
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.IronskinPotion, 5);
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.WrathPotion, 5);
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.Bone, 50);
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.GlowingMushroom, 25);
			Replica_Ribbon_bomb_recipe.AddTile(TileID.AlchemyTable);
			Replica_Ribbon_bomb_recipe.Register();
		}


	}

}