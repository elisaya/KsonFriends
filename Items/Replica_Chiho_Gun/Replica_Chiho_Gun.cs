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
	public class Replica_Chiho_Gun : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Chiho_Gun/Replica_Chiho_Gun"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Replica] 46 cm Battleship Gun Type CHIHO");
			Tooltip.SetDefault("Replica of the main artillery installed on battleships back in WorldWar2. This specific model is invented and only used by Captain Chiho."
				+ Environment.NewLine + "WARNING: This replica lacks blast protection component, may cause conflagation when fired."
				+ Environment.NewLine + "Require special shell to fire."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 80;
			Item.useTime = 80;
			Item.knockBack = 15f;
			Item.width = 84;
			Item.height = 76;
			Item.damage = 64;
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
			player.AddBuff(BuffID.OnFire, 180);


			return true;
        }

		public override void AddRecipes()
		{
			Recipe Replica_Chiho_Gun = CreateRecipe(1);
			Replica_Chiho_Gun.AddRecipeGroup(RecipeGroupID.IronBar, 80);
			Replica_Chiho_Gun.AddIngredient(ItemID.IllegalGunParts, 3);
			Replica_Chiho_Gun.AddIngredient(ItemID.FlareGun, 1);
			Replica_Chiho_Gun.AddTile(TileID.HeavyWorkBench);
			Replica_Chiho_Gun.Register();
		}
	}
}