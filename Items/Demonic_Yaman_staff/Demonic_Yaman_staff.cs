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
	public class Demonic_Yaman_staff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Demonic] Yaman's Stick of Doggo Summoning");
			Tooltip.SetDefault("Feeding the dog with hatred flesh, rush of blood-thirst awakes their wildness."
				+ Environment.NewLine + "\"The God rested in his Jinja, from all the work that he had done.\"" 
				+ Environment.NewLine + "The God knitted a white doggo from his own hair, and brush its coat snow white, and the dog became his vicegerent.\""
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Yaman_staff/Demonic_Yaman_staff"; }
		}


		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.knockBack = 3f;
			Item.mana = 50;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = 503;
			Item.rare = ItemRarityID.Cyan;
			//Item.UseSound = SoundID.Item44;
			Item.noMelee = true; 
			Item.DamageType = DamageClass.Summon;
			Item.buffType = ModContent.BuffType<Demonic_Yaman_staff_buff>();
			Item.shoot = ModContent.ProjectileType<Demonic_Yaman_staff_minion>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
			position = Main.MouseWorld;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);

			// Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;

			// Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
			return false;
		}

		public override void AddRecipes()
		{
			RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

			Recipe Demonic_Yaman_staff = CreateRecipe(1);
			Demonic_Yaman_staff.AddRecipeGroup(demonicbossdrop, 16);
			Demonic_Yaman_staff.AddIngredient(ModContent.ItemType<Replica_Yaman_staff>());
			Demonic_Yaman_staff.AddTile(TileID.WorkBenches);
			Demonic_Yaman_staff.Register();
		}

	}
}