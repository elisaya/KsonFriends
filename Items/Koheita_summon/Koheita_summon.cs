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


	public class Koheita_summon : ModItem
	{     
        public override string Texture {
			get {return "KsonFriends/Items/Koheita_summon/Koheita_summon"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Tattered Service Hat");
			Tooltip.SetDefault("Old, torned service hat soaked in blood. Seems like the owner had taken some beats.");
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
            return !NPC.AnyNPCs(ModContent.NPCType<Koheita>());
        }


        public override bool? UseItem(Player player)
        {
            if(player.whoAmI == Main.myPlayer)
            {
				int type = ModContent.NPCType<Koheita>();

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
			RecipeGroup hats = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.TopHat)}", ItemID.SummerHat, ItemID.PlumbersHat, ItemID.HerosHat, ItemID.ArchaeologistsHat, ItemID.RedHat, ItemID.RobotHat, ItemID.ClownHat, ItemID.SantaHat, ItemID.RuneHat, ItemID.SteampunkHat, ItemID.BeeHat, ItemID.CowboyHat, ItemID.PirateHat, ItemID.UmbrellaHat, ItemID.BallaHat, ItemID.GangstaHat, ItemID.SailorHat, ItemID.NurseHat, ItemID.WizardHat, ItemID.WitchHat, ItemID.LeprechaunHat, ItemID.PrincessHat, ItemID.ScarecrowHat, ItemID.MrsClauseHat, ItemID.SnowHat, ItemID.ElfHat, ItemID.PeddlersHat, ItemID.TaxCollectorHat, ItemID.PartyHat, ItemID.ChefHat, ItemID.FuneralHat, ItemID.VictorianGothHat, ItemID.MushroomHat, ItemID.BadgersHat);
			RecipeGroup.RegisterGroup("hats", hats);

			Recipe Koheita_summon = CreateRecipe(1);
			Koheita_summon.AddIngredient(ItemID.FallenStar, 1);
			Koheita_summon.AddIngredient(ItemID.BlackPaint, 3);
			Koheita_summon.AddRecipeGroup("hats");
			Koheita_summon.AddTile(TileID.WorkBenches);
			Koheita_summon.Register();
        }
    }
}