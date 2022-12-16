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

namespace KsonFriends.Items
{
    public class Replica_Kson_bike_summon : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Replica_Kson_bike/Replica_Kson_bike_summon"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Replica] Scarlet Yakuza-style Helmet");
            Tooltip.SetDefault("\"Keep it to yourself choom, hop on! Boss' calling a raid!\""
                + Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 14;
            Item.value = 113;
            Item.rare = 9;
            Item.UseSound = SoundID.Roar;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<Replica_Kson_bike>();
        }


        public override void AddRecipes()
        {
            Recipe Replica_Kson_bike_summon_Recipe = CreateRecipe(1);
            Replica_Kson_bike_summon_Recipe.AddIngredient(ItemID.Minecart, 1);
            Replica_Kson_bike_summon_Recipe.AddIngredient(ItemID.Torch, 2);
            Replica_Kson_bike_summon_Recipe.AddIngredient(ItemID.RedBanner, 1);
            Replica_Kson_bike_summon_Recipe.AddRecipeGroup(RecipeGroupID.IronBar, 20);
            Replica_Kson_bike_summon_Recipe.AddTile(TileID.WorkBenches);
            Replica_Kson_bike_summon_Recipe.Register();
        }
    }
}