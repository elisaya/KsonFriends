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


	public class Demonic_Yura_sword : ModItem
	{
		public int damage = 17;
		int weapon_level;
		int debuff_base_dura = 180;
		int[] exp_req = { 100, 500, 1000, 2000, 5000, 10000 };
		       
        public override string Texture {
			get {return "KsonFriends/Items/Demonic_Yura_sword/Demonic_Yura_sword"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("[Demonic] Ancient Rune Blade");
			Tooltip.SetDefault("You carved on this sword the spells you learned from researchng the demons you defeated."
                + Environment.NewLine + "The moment it was done, bone-chilling flame covered the sword."
				+ Environment.NewLine + "Cheap wood replica of a famous weapon from Celtic Mythology. Good at inflicting curses."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");

        }
		
        public override void SetDefaults()
        {
			Item.damage = damage;
			Item.noMelee = false;
			Item.height = 40;
			Item.width = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 608;
			Item.rare = 3;
			Item.crit = 4;
			Item.holdStyle = 5;
			//Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.DamageType = DamageClass.Melee;
		}


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.FireworkFountain_Pink, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
        }

		public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
		{
			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			for (int i = 0; i < 5; i++)
			{
				if (MPlayer.Yura_sword_kill_count < exp_req[i])
				{
					weapon_level = i;
					break;
				}
			}

			damage *= (weapon_level + 1);

		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			KsonFriendsMP MPlayer = player.GetModPlayer<KsonFriendsMP>();

			int debuff_dure_increase = 0;

			switch(weapon_level)
            {
				case 0: 
					debuff_dure_increase = debuff_base_dura + 30;
					break;
				case 1:
					debuff_dure_increase = debuff_base_dura + 60;
					break;
				case 2:
					debuff_dure_increase = debuff_base_dura + 180;
					break;
				case 3:
					debuff_dure_increase = debuff_base_dura + 6000;
					break;
			}

			target.AddBuff(BuffID.Poisoned, debuff_dure_increase);
			target.AddBuff(BuffID.OnFire, debuff_dure_increase);
			target.AddBuff(BuffID.Bleeding, debuff_dure_increase);
			target.AddBuff(BuffID.Confused, 60);
			//target.AddBuff(BuffID.Venom, debuff_dure_increase);
			//target.AddBuff(BuffID.CursedInferno, debuff_dure_increase);

			if (target.life <= 0)
            {
				MPlayer.Yura_sword_kill_count += 1;
			}


	    }

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			int display_level = weapon_level + 1;

			string level = "Kill Count : " + MPlayer.Yura_sword_kill_count + Environment.NewLine + "Weapon Level : " + display_level;
			var line = new TooltipLine(Mod, "KsonFriends", level);
			tooltips.Add(line);
        }


        public override void AddRecipes()
        {
			RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
			RecipeGroup.RegisterGroup("demonicore", demonicore);

			RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
			RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

			Recipe Demonic_Yura_sword_recipe = CreateRecipe(1);
			Demonic_Yura_sword_recipe.AddRecipeGroup(demonicore, 12);
			Demonic_Yura_sword_recipe.AddRecipeGroup(demonicbossdrop, 8);
			Demonic_Yura_sword_recipe.AddIngredient(ModContent.ItemType<Replica_Yura_sword>());
			Demonic_Yura_sword_recipe.AddTile(TileID.WorkBenches);
			Demonic_Yura_sword_recipe.Register();
        }
    }
}