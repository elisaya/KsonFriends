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
using KsonFriends.NPCs;

namespace KsonFriends.Items
{
	[AutoloadHead]


	public class Kson_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Kson_summon/Kson_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Strange Pizza Box");
			Tooltip.SetDefault("\"Oh Goood this is so good.....\"" + Environment.NewLine + "EMM... so GUUD and TASTY!");
        }

        public override void SetDefaults()
        {
			Item.noMelee = true;
			Item.height = 35;
			Item.width = 35;
			Item.maxStack = 1;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 14;
			Item.value = 114;
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.GuitarC;
			Item.autoReuse = false;
			Item.useTurn = false;
		}


        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Kson>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Kson>();

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else
				{
					// If the player is in multiplayer, request a spawn
					// This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
					NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
				}
			}

			return true;
		}

        public override void AddRecipes()
        {
			Recipe Kson_summon = CreateRecipe(1);
			Kson_summon.AddIngredient(ItemID.Pizza, 1);
			Kson_summon.AddIngredient(ItemID.LifeCrystal,1);
			Kson_summon.AddTile(TileID.WorkBenches);
			Kson_summon.Register();
        }
    }
}