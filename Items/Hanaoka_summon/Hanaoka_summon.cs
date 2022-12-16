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


	public class Hanaoka_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Hanaoka_summon/Hanaoka_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Betting Ticket");
			Tooltip.SetDefault("A strange betting ticket \"Tokyo [9] Race Win-Win [1] Momo Hanaoka 100Yen\"");
        }

        public override void SetDefaults()
        {
			Item.noMelee = true;
			Item.height = 20;
			Item.width = 20;
			Item.maxStack = 1;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 14;
			Item.value = 314;
			Item.rare = 7;
			Item.UseSound = SoundID.GuitarC;
			Item.autoReuse = false;
			Item.useTurn = false;
		}


        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Hanaoka>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Hanaoka>();

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
			Recipe Hanaoka_summon = CreateRecipe(1);
			Hanaoka_summon.AddIngredient(ItemID.Book, 5);
			Hanaoka_summon.AddIngredient(ItemID.Sunglasses, 1);
			Hanaoka_summon.AddIngredient(ItemID.Stopwatch);
			Hanaoka_summon.AddTile(TileID.WorkBenches);
			Hanaoka_summon.Register();
        }
    }
}