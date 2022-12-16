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


	public class Yaman_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Yaman_summon/Yaman_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Magatama");
			Tooltip.SetDefault("\"In the beginning, God created a Dragon.\"" + Environment.NewLine + "\"Then God said, \'Let there be family\'; and there was a Dullahan.\""
				+ Environment.NewLine + "\" And God saw that the Dullahan was seison't; and God separated the seisoness from the seison't-ness.\""
				 + Environment.NewLine + "\"God called the seison't Yura, and the seiso he called Leto.\""
				  + Environment.NewLine + "\"God created humankind in his image, in the image of God he created Souchou; Delinquent and Idol he created her.\"");
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
            return !NPC.AnyNPCs(ModContent.NPCType<Yaman>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Yaman>();

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
			Recipe Yaman_summon = CreateRecipe(1);
			Yaman_summon.AddIngredient(ItemID.FallenStar, 10);
			Yaman_summon.AddRecipeGroup(RecipeGroupID.IronBar, 20);
			Yaman_summon.AddIngredient(ItemID.IronBow);
			Yaman_summon.AddTile(TileID.WorkBenches);
			Yaman_summon.Register();
        }
    }
}