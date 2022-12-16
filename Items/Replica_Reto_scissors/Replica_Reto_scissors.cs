//TODO: projectile need animation








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
    public class Replica_Reto_scissors : ModItem
    {
		int weapon_level;
		int[] exp_req = { 200, 750, 1350, 2500, 6000, 10000 };

		SlotId? sfxSlot;
		SoundStyle scissors_SFX = new SoundStyle("KsonFriends/Items/Replica_Reto_scissors/Reto_scissors_SFX") { IsLooped = true, SoundLimitBehavior = SoundLimitBehavior.IgnoreNew };

		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Reto_scissors/Replica_Reto_scissors"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Replica] Divine Auto-guided Scissors");
			Tooltip.SetDefault("Infamously called the \"Destroyer of all Achilles' tendons\", never missed once."
				+ Environment.NewLine + "A replica with more than none Goddess power, still divine enough to auto-target every Achilles' tendon in proximity."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");

		}

		public override void SetDefaults()
		{
			Item.channel = true;
			Item.DamageType = DamageClass.Magic;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 1f;
			Item.width = 30;
			Item.height = 10;
			Item.damage = 6;
			Item.crit = -4;
			Item.scale = 0.8f;
			Item.rare = 0;
			Item.value = 605;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Replica_Reto_scissors_Projectile>();
			Item.shootSpeed = 21;
			Item.mana = 60;
			Item.holdStyle = 3;
			Item.noMelee = true;
		}



		public override void HoldItem(Player player)
		{
			if (!player.ItemTimeIsZero && !sfxSlot.HasValue)
			{
				sfxSlot = SoundEngine.PlaySound(scissors_SFX);
			}
			else if (player.ItemTimeIsZero && sfxSlot.HasValue)
			{
				if (SoundEngine.TryGetActiveSound(sfxSlot.Value, out var sound))
					{
						sound.Stop();
						sfxSlot = null;
					}
			}
		}


		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			int display_level = weapon_level + 1;

			string level = "Kill Count : " + MPlayer.Reto_scissors_kill_count + Environment.NewLine + "Weapon Level : " + display_level;
			var line = new TooltipLine(Mod, "KsonFriends", level);
			tooltips.Add(line);
		}


		public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
		{
			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			for (int i = 0; i < 5; i++)
			{
				if (MPlayer.Reto_scissors_kill_count < exp_req[i])
				{
					weapon_level = i;
					break;
				}
			}

			damage *= (weapon_level + 1);

		}


		public override void AddRecipes()
		{
			Recipe Replica_Hana_wings_recipe = CreateRecipe(1);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.IronShortsword, 2);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.GoldBar, 10);
			Replica_Hana_wings_recipe.AddIngredient(ItemID.FallenStar, 5);
			Replica_Hana_wings_recipe.AddTile(TileID.WorkBenches);
			Replica_Hana_wings_recipe.Register();

		}

	}
}