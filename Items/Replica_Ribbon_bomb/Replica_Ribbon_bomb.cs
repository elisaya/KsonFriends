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
	public class Replica_Ribbon_bomb : ModItem
	{
		public override string Texture
		{
			get { return "KsonFriends/Items/Replica_Ribbon_bomb/Replica_Ribbon_bomb"; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("[Replica] Overloaded Drawing Tablet");
			Tooltip.SetDefault("Replica of Ribbon's drawing tablet. Overflowed with colors and sugar, its battery seems a bit swelling and about to burst."
				+ Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
		}

		public override void SetDefaults()
		{
			//item.damage determines the contact damage of the bomb
			Item.damage = 120;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.shootSpeed = 10f;
			Item.shoot = ModContent.ProjectileType<Replica_Ribbon_bomb_Projectile>();
			Item.width = 32;
			Item.height = 32;
			Item.noMelee = true;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.noUseGraphic = true;
			Item.value = 601;
			Item.rare = ItemRarityID.Pink;

		}

		public override void AddRecipes()				//in final version, use Celebration as ingredient, not a consummeble anymore
		{
			Recipe Replica_Ribbon_bomb_recipe = CreateRecipe(15);
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.Grenade, 10);				//use explosivebunny in next upgrade
			Replica_Ribbon_bomb_recipe.AddIngredient(ItemID.Emerald, 3);
			Replica_Ribbon_bomb_recipe.AddTile(TileID.Anvils);
			Replica_Ribbon_bomb_recipe.Register();
		}


	}

}