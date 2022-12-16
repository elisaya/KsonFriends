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


	public class jyuhachigo_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/18go_summon/18go_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Fashionable Lipstick");
			Tooltip.SetDefault("Wrote on the packet a slogan : \"ICHIBAN! ICHIBAN lipsticks for women! ICHIBAN, Saikou~~~\""
				+ Environment.NewLine + "Did you watch the commercial tape? Don't lie to me!");
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
            return !NPC.AnyNPCs(ModContent.NPCType<jyuhachi_go>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<jyuhachi_go>();

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
			Recipe jyuhachigo_summon = CreateRecipe(1);
			jyuhachigo_summon.AddIngredient(ItemID.Silk, 15);
			jyuhachigo_summon.AddIngredient(ItemID.WhitePaint, 1);
			jyuhachigo_summon.AddIngredient(ItemID.CyanPaint, 1);
			jyuhachigo_summon.AddTile(TileID.Loom);
			jyuhachigo_summon.Register();
        }
    }
}