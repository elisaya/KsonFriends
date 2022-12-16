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


	public class Reto_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Reto_summon/Reto_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Feeding Bottle");
			Tooltip.SetDefault("Contains holy water. Pure holy water.");
        }

        public override void SetDefaults()
        {
			Item.noMelee = false;
			Item.height = 35;
			Item.width = 35;
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
            return !NPC.AnyNPCs(ModContent.NPCType<Reto>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Reto>();

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else if(!NPC.AnyNPCs(ModContent.NPCType<Reto>()))
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
			Recipe Reto_summon = CreateRecipe(1);
			Reto_summon.AddIngredient(ItemID.CrossStatue, 1);
			Reto_summon.AddIngredient(ItemID.HolyWater, 5);
			Reto_summon.AddIngredient(ItemID.Bottle, 1);
			Reto_summon.AddTile(TileID.WorkBenches);
			Reto_summon.Register();
        }
    }
}