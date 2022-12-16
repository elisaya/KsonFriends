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


	public class Ribbon_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Ribbon_summon/Ribbon_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Pretty Pink Dress with extra large ribbon");
			Tooltip.SetDefault("If you look closely, the ribbon is slightly larger than the dress itself....");
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
			Item.UseSound = SoundID.Thunder;
			Item.autoReuse = false;
			Item.useTurn = false;
		}


        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Ribbon>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Ribbon>();

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else if(!NPC.AnyNPCs(ModContent.NPCType<Ribbon>()))
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
			Recipe Ribbon_summon = CreateRecipe(1);
			Ribbon_summon.AddIngredient(ItemID.Silk, 30);
			Ribbon_summon.AddIngredient(ItemID.PrettyPinkRibbon, 1);
			Ribbon_summon.AddIngredient(ItemID.PinkPaint, 5);
			Ribbon_summon.AddTile(TileID.WorkBenches);
			Ribbon_summon.Register();
        }
    }
}