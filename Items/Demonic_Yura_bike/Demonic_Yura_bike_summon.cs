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
    public class Demonic_Yura_bike_summon : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Demonic_Yura_bike/Demonic_Yura_bike_summon"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Demonic] Knight of (Halloween) Night");
            Tooltip.SetDefault("\"The story of a headless rider who roams the lands of Japan looking for victims whose lives she intends to take.\""
                + Environment.NewLine + "Not long after she started her journey, she realized the best way is to collect hearts and get ahead.");
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
            Item.mountType = ModContent.MountType<Replica_Yura_bike>();
        }


        public override void AddRecipes()
        {
            RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
            RecipeGroup.RegisterGroup("demonicore", demonicore);

            RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
            RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

            Recipe Demonic_Yura_bike_summon = CreateRecipe(1);
            Demonic_Yura_bike_summon.AddRecipeGroup(demonicore, 35);
            Demonic_Yura_bike_summon.AddRecipeGroup(demonicbossdrop, 16);
            Demonic_Yura_bike_summon.AddIngredient(ModContent.ItemType<Replica_Yura_bike_summon>());
            Demonic_Yura_bike_summon.AddTile(TileID.HeavyWorkBench);
            Demonic_Yura_bike_summon.Register();
        }
    }
}