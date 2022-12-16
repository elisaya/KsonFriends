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
	public class Demonic_Himono_paint_bucket : ModItem
	{
        public override string Texture
        {
            get { return "KsonFriends/Items/Demonic_Himono_paint_bucket/Demonic_Himono_paint_bucket"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Demonic] Goddess Paint Bucket");
            Tooltip.SetDefault("Malice flows inside the paint."
                + Environment.NewLine +"DO NOT PEEK INSIDE THE BUCKET."
                + Environment.NewLine + "Inside the bucket there contains a painfully beautiful color - a Color Out of Space");
        }

        public override void SetDefaults()
        {
            
            Item.DamageType = DamageClass.Magic;
            Item.damage = 26;
            Item.mana = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 10f;
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ModContent.ProjectileType<Demonic_Himono_paint_bucket_Projectile>();
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
            RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
            RecipeGroup.RegisterGroup("demonicore", demonicore);

            RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
            RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

            Recipe Demonic_Himono_paint_bucket_Recipe = CreateRecipe(1);
            Demonic_Himono_paint_bucket_Recipe.AddRecipeGroup(demonicore, 12);
            Demonic_Himono_paint_bucket_Recipe.AddRecipeGroup(demonicbossdrop, 6);
            Demonic_Himono_paint_bucket_Recipe.AddIngredient(ModContent.ItemType<Replica_Himono_paint_bucket>());
            Demonic_Himono_paint_bucket_Recipe.AddTile(TileID.WorkBenches);
            Demonic_Himono_paint_bucket_Recipe.Register();

        }
    }

}