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

	public class Demonic_Taishi_pickaxe : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Taishi_pickaxe/Demonic_Taishi_pickaxe"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Demonic] Angelic power Pickaxe");
			Tooltip.SetDefault("\"Satan, who leads the whole world astray. He was hurled to the earth, and his angels with him.\""
				+ Environment.NewLine + "Replica of the pickaxe baptized and blessed with angelice power"
				+ Environment.NewLine + "Extra diggy, extra grip!");
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
			Item.pick = 75;
			Item.axe = 13;			//in game value will *5. eg 10 axe power will translate to 50 in game
			Item.hammer = 60;
		}

		public override void AddRecipes()
		{
			RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
			RecipeGroup.RegisterGroup("demonicore", demonicore);

			RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

			Recipe Demonic_Taishi_pickaxe_recipe = CreateRecipe(1);
			Demonic_Taishi_pickaxe_recipe.AddRecipeGroup(demonicore, 10);
			Demonic_Taishi_pickaxe_recipe.AddRecipeGroup(demonicbossdrop, 4);
			Demonic_Taishi_pickaxe_recipe.AddIngredient(ModContent.ItemType<Replica_Taishi_pickaxe>());
			Demonic_Taishi_pickaxe_recipe.AddTile(TileID.WorkBenches);
			Demonic_Taishi_pickaxe_recipe.Register();
		}

		//maybe healing beam after 3rd upgrade?


	}
}