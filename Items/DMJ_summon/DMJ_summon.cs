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


	public class DMJ_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/DMJ_summon/DMJ_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Mysterious Dragon Scale");
			Tooltip.SetDefault("Holding this green scale, you sense a rush of Earth element from the glowing yellow star");
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
			Recipe DMJ_summon = CreateRecipe(1);
			DMJ_summon.AddIngredient(ItemID.FallenStar, 10);
			DMJ_summon.AddIngredient(ItemID.DirtBomb, 10);
			DMJ_summon.AddIngredient(ItemID.Vine, 5);
			DMJ_summon.AddTile(TileID.WorkBenches);
			DMJ_summon.Register();
        }
    }
}