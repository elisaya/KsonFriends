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
	public class Demonic_Kourin_hook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kourin's Extra Huggy Teddy Bear");
			Tooltip.SetDefault("Travelling through cursed lands, the teddy was stained with cursed."
				+ Environment.NewLine + "Traveling with Kourin to this world. Kourin hugs the all the time, so from Kourin, it knows how to cuddle. Nothing special except being extra huggy.");
		}

		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Kourin_hook/Demonic_Kourin_hook"; }
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
			Item.shoot = ModContent.ProjectileType<Demonic_Kourin_Hook_Projectile>(); // Makes the item shoot the hook's projectile when used.
		}

		public override void AddRecipes()
		{
			RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
			RecipeGroup.RegisterGroup("demonicore", demonicore);

			RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

			Recipe Demonic_Kourin_hook_recipe = CreateRecipe(1);
			Demonic_Kourin_hook_recipe.AddRecipeGroup(demonicore, 10);
			Demonic_Kourin_hook_recipe.AddRecipeGroup(demonicbossdrop, 4);
			Demonic_Kourin_hook_recipe.AddIngredient(ModContent.ItemType<Replica_Kourin_hook>());
			Demonic_Kourin_hook_recipe.AddTile(TileID.Loom);
			Demonic_Kourin_hook_recipe.Register();

		}
	}

}