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


	public class Pikamee_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Pikamee_summon/Pikamee_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Gigantic Prank Spoon");
			Tooltip.SetDefault("A gigantic spoon that you can't actually use -- not because it's too big, but because it snaps when you hold onto it.");
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
			Item.value = 314;
			Item.rare = 7;
			Item.UseSound = SoundID.Thunder;
			Item.autoReuse = false;
			Item.useTurn = false;
		}


        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Pikamee>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Pikamee>();

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else if(!NPC.AnyNPCs(ModContent.NPCType<Pikamee>()))
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
			Recipe Pikamee_summon = CreateRecipe(1);
			Pikamee_summon.AddIngredient(ItemID.ManaCrystal, 5);
			Pikamee_summon.AddRecipeGroup(RecipeGroupID.Wood, 20);
			Pikamee_summon.AddTile(TileID.WorkBenches);
			Pikamee_summon.Register();
        }
    }
}