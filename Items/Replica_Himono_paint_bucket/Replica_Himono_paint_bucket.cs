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

namespace KsonFriends.Items
{
	public class Replica_Himono_paint_bucket : ModItem
	{
        public override string Texture
        {
            get { return "KsonFriends/Items/Replica_Himono_paint_bucket/Replica_Himono_paint_bucket"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Replica] Goddess Paint Bucket");
            Tooltip.SetDefault("DO NOT PEEK INSIDE THE BUCKET."
                + Environment.NewLine + "Inside the bucket there contains a painfully, breathtakingly beautiful color - a Color Out of Space"
                + Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
        }

        public override void SetDefaults()
        {
            
            Item.DamageType = DamageClass.Magic;
            Item.damage = 26;
            Item.mana = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 10f;
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ModContent.ProjectileType<Replica_Himono_paint_bucket_Projectile>();
            Item.width = 22;
            Item.height = 22;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.holdStyle = ItemHoldStyleID.HoldFront;
            Item.noMelee = true;
            Item.value = 614;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            Recipe Replica_Hana_wings_recipe = CreateRecipe(1);
            Replica_Hana_wings_recipe.AddIngredient(ItemID.EmptyBucket, 1);
            Replica_Hana_wings_recipe.AddIngredient(ItemID.WaterBucket, 1);
            Replica_Hana_wings_recipe.AddIngredient(ItemID.LavaBucket, 1);
            Replica_Hana_wings_recipe.AddIngredient(ItemID.HoneyBucket, 1);
            Replica_Hana_wings_recipe.AddIngredient(ItemID.FallenStar, 10);
            Replica_Hana_wings_recipe.AddTile(TileID.WorkBenches);
            Replica_Hana_wings_recipe.Register();

        }
    }

}