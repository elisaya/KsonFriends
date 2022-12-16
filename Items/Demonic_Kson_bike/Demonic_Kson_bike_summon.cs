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
    public class Demonic_Kson_bike_summon : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Demonic_Kson_bike/Demonic_Kson_bike_summon"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Demonic] Scarlet Yakuza-style Helmet");
            Tooltip.SetDefault("Aggressiveness fuels the motocycle, wrath burns inside the engine."
                + Environment.NewLine + "\"Keep it to yourself choom, hop on! Boss' calling a raid!\"");
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
            RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
            RecipeGroup.RegisterGroup("demonicore", demonicore);

            RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
            RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

            Recipe Demonic_Kson_bike_summon_Recipe = CreateRecipe(1);
            Demonic_Kson_bike_summon_Recipe.AddRecipeGroup(demonicore, 35);
            Demonic_Kson_bike_summon_Recipe.AddRecipeGroup(demonicbossdrop, 16);
            Demonic_Kson_bike_summon_Recipe.AddIngredient(ModContent.ItemType<Replica_Kson_bike_summon>());
            Demonic_Kson_bike_summon_Recipe.AddTile(TileID.WorkBenches);
            Demonic_Kson_bike_summon_Recipe.Register();
        }
    }
}