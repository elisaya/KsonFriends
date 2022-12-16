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


	public class Yura_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Yura_summon/Yura_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Mysterious Lantern");
			Tooltip.SetDefault("Freezing Flame Flickering Inside The Lantern." + Environment.NewLine + "You sense a soul hidden inside.");
        }

        public override void SetDefaults()
        {
			Item.noMelee = true;
			Item.height = 32;
			Item.width = 32;
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
			Recipe Yura_summon = CreateRecipe(1);
			Yura_summon.AddIngredient(ItemID.SkeletonStatue, 1);
			Yura_summon.AddIngredient(ItemID.Bone, 30);
			Yura_summon.AddIngredient(ItemID.Bottle);
			Yura_summon.AddIngredient(ItemID.FrozenCampfire);
			Yura_summon.AddTile(TileID.DemonAltar);
			Yura_summon.Register();
        }
    }
}