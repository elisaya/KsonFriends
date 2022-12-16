using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
using Terraria.DataStructures;
using System.Linq;
using Terraria.GameContent.Creative;
using KsonFriends.Items;
using Terraria.GameContent;

namespace KsonFriends.Items
{
	public class Demonic_Coco_asacoco : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Demonic_Coco_asacoco/Demonic_Coco_asacoco"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Basic+] Breathe-In Type Asacoco");
			Tooltip.SetDefault("\"Updated recipe! Send you and whoever dares come close to you straight to Jesus!\""
				+ Environment.NewLine + "\"Every puff makes you stronger! \""
				+ Environment.NewLine + "Side-effect: May or may not reduce your lifespan. 50/50 worth risking!");
		}

		public override void SetDefaults()
		{
			//item.damage determines the contact damage of the bomb
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.shootSpeed = 10f;
			Item.width = 30;
			Item.height = 34;
			Item.maxStack = 55;
			Item.consumable = true;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.noUseGraphic = false;
			Item.value = 619;
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = false;
			
		}


        public override bool? UseItem(Player player)
        {
			player.AddBuff(BuffID.Swiftness, 3600);
			player.AddBuff(BuffID.Ironskin, 3600);
			player.AddBuff(BuffID.Wrath, 3600);
			player.AddBuff(BuffID.MagicPower, 3600);
			player.AddBuff(BuffID.ManaRegeneration, 3600);
			player.AddBuff(BuffID.Poisoned, 330);
			player.AddBuff(BuffID.Blackout, 90);

			return base.UseItem(player);
        }

        public override void AddRecipes()				//in final version, use Celebration as ingredient, not a consummeble anymore
		{
			Recipe Demonic_Coco_asacoco = CreateRecipe(5);
			Demonic_Coco_asacoco.AddIngredient(ItemID.MagicPowerPotion, 5);                //use explosivebunny in next upgrade
			Demonic_Coco_asacoco.AddIngredient(ItemID.ManaRegenerationPotion, 5);
			Demonic_Coco_asacoco.AddIngredient(ModContent.ItemType<Replica_Coco_asacoco>(), 5);
			Demonic_Coco_asacoco.AddTile(TileID.AlchemyTable);
			Demonic_Coco_asacoco.Register();
		}


	}

}