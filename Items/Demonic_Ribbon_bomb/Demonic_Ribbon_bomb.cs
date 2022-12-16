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
	public class Demonic_Ribbon_bomb : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Ribbon_bomb/Demonic_Ribbon_bomb"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Demonic] Overloaded Drawing Tablet");
			Tooltip.SetDefault("Color from the space replaced the terrestrial color flowing in the circuit. The color spreads way faster."
				+ Environment.NewLine + "Replica of Ribbon's drawing tablet. Overflowed with colors and sugar, its battery seems a bit swelling and about to burst.");
		}

		public override void SetDefaults()
		{
			//item.damage determines the contact damage of the bomb
			Item.damage = 160;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.shootSpeed = 10f;
			Item.shoot = ModContent.ProjectileType<Demonic_Ribbon_bomb_Projectile>();
			Item.width = 32;
			Item.height = 32;
			Item.noMelee = true;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.noUseGraphic = true;
			Item.value = 601;
			Item.rare = ItemRarityID.Pink;

		}

		public override void AddRecipes()				//in final version, use Celebration as ingredient, not a consummeble anymore
		{
			RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
			RecipeGroup.RegisterGroup("demonicore", demonicore);

			RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

			Recipe Demonic_Ribbon_bomb_recipe = CreateRecipe(15);
			Demonic_Ribbon_bomb_recipe.AddRecipeGroup(demonicore, 10);
			Demonic_Ribbon_bomb_recipe.AddRecipeGroup(demonicbossdrop, 5);
			Demonic_Ribbon_bomb_recipe.AddIngredient(ModContent.ItemType<Replica_Ribbon_bomb>(), 15);
			Demonic_Ribbon_bomb_recipe.AddTile(TileID.Anvils);
			Demonic_Ribbon_bomb_recipe.Register();
		}


	}

}