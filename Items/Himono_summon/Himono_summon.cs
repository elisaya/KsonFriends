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


	public class Himono_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Himono_summon/Himono_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Digital Pen");
			Tooltip.SetDefault("\"God created a Delinquent. But the Delinquent stood still.\""
				+ Environment.NewLine + "\"Then God said, \'So that the works of Goddess might be displayed in her.\'\""
				+ Environment.NewLine + "Goddess then drew on the Delinquent."
				+ Environment.NewLine + "\"\'Go,\' Goddess told her, \"you shall sing, dance, talk to people.\" so she sang, and danced, and talked.\"");
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
            return !NPC.AnyNPCs(ModContent.NPCType<Himono>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Himono>();

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
			Recipe Himono_summon = CreateRecipe(1);
			Himono_summon.AddIngredient(ItemID.RedPaint, 1);
			Himono_summon.AddIngredient(ItemID.GreenPaint, 1);
			Himono_summon.AddIngredient(ItemID.BluePaint, 1);
			Himono_summon.AddIngredient(ItemID.Paintbrush,1);
			Himono_summon.AddTile(TileID.HeavyWorkBench);
			Himono_summon.Register();
        }
    }
}