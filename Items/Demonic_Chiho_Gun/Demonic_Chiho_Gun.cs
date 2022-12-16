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
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Audio;
using ReLogic.Utilities;

namespace KsonFriends.Items
{
	public class Demonic_Chiho_Gun : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Chiho_Gun/Demonic_Chiho_Gun"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Demonic] 46 cm Battleship Gun Type CHIHO");
			Tooltip.SetDefault("A replica weapon infused with demonic power. Now has SLIGHTLY better blast protection and SLIGHTLY higher fire rate."
				+ Environment.NewLine + "Replica of the main artillery installed on battleships back in WorldWar2. This specific model is invented and only used by Captain Chiho."
				+ Environment.NewLine + "WARNING: This replica lacks blast protection component, may cause conflagation when fired."
				+ Environment.NewLine + "Require special shell to fire."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 70;
			Item.useTime = 70;
			Item.knockBack = 17f;
			Item.width = 84;
			Item.height = 76;
			Item.damage = 88;
			Item.rare = ItemRarityID.Pink;
			Item.value = 605;
			Item.autoReuse = false;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Chiho_Gun_Ammo_Regular_Projectile>();
			Item.shootSpeed = 21;
			Item.holdStyle = 3;
			Item.useAmmo = ModContent.ItemType<Chiho_Gun_Ammo_Regular>();
		}

        public override void HoldItem(Player player)
        {
			player.AddBuff(BuffID.Dazed, 2);

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			player.AddBuff(BuffID.OnFire, 150);


			return true;
        }

		public override void AddRecipes()
		{
			RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
			RecipeGroup.RegisterGroup("demonicore", demonicore);

			RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

			Recipe Demonic_Chiho_Gun = CreateRecipe(1);
			Demonic_Chiho_Gun.AddRecipeGroup(demonicore, 50);
			Demonic_Chiho_Gun.AddRecipeGroup(demonicbossdrop, 20);
            Demonic_Chiho_Gun.AddIngredient(ModContent.ItemType<Replica_Chiho_Gun>());
			Demonic_Chiho_Gun.AddTile(TileID.HeavyWorkBench);
			Demonic_Chiho_Gun.Register();
		}
	}
}