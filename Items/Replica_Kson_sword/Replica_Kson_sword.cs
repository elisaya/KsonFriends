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


	public class Replica_Kson_sword : ModItem
	{
		int weapon_level;
		int[] exp_req = { 100, 500, 1000, 2000, 5000, 10000 };

		public override string Texture {
			get {return "KsonFriends/Items/Replica_Kson_sword/Replica_Kson_sword"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("[Replica] Delinquent's Bokkutou");
			Tooltip.SetDefault("A replica of the wooden sword once swong by a Legendary DELINQUENT. Potentially lethal, but the sword was never made to kill." + Environment.NewLine +
                "Delinquents usually beat their victoms with their wooden sword before robbing them clean."
				+ Environment.NewLine + "\"This is your sword. There might be many like it, but this one is yours. Your sword is your best friend. It is your life\""
				+ Environment.NewLine + "\"Without a good wielder this sword is useless. You must bonk your enermy before they bonk you.\""
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");

			
        }

        public override void SetDefaults()
        {
			Item.damage = 13;
			Item.noMelee = false;
			Item.height = 40;
			Item.width = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 608;
			Item.rare = 3;
			Item.crit = 8;
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

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			SoundStyle Kson_sword_bonk = new SoundStyle("KsonFriends/Assets/bonk");
			SoundEngine.PlaySound(Kson_sword_bonk, new Vector2(target.position.X, target.position.Y));

			target.AddBuff(BuffID.Confused, 30);
			target.AddBuff(BuffID.Midas, 180);

			KsonFriendsMP MPlayer = player.GetModPlayer<KsonFriendsMP>();

			if (target.life <= 0)
            {
				MPlayer.Kson_sword_kill_count += 1;
			}
	    }

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			int display_level = weapon_level + 1;

			string level = "Kill Count : " + MPlayer.Kson_sword_kill_count + Environment.NewLine + "Weapon Level : " + display_level;
			var line = new TooltipLine(Mod, "KsonFriends", level);
			tooltips.Add(line);
        }


        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
			KsonFriendsMP MPlayer = Main.LocalPlayer.GetModPlayer<KsonFriendsMP>();

			for(int i = 0; i < 5; i++)
            {
				if (MPlayer.Kson_sword_kill_count < exp_req[i])
                {
					weapon_level = i;
					break;
                }
            }

			damage *= (weapon_level + 1);

        }


        public override void AddRecipes()
        {
			Recipe Kson_sword_recipe = CreateRecipe(1);
			Kson_sword_recipe.AddIngredient(ItemID.PinkGel, 2);
			Kson_sword_recipe.AddRecipeGroup(RecipeGroupID.Wood, 10);
			Kson_sword_recipe.AddTile(TileID.WorkBenches);
			Kson_sword_recipe.Register();
        }
    }
}