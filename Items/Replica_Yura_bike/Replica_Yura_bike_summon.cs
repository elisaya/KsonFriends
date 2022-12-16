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
    public class Replica_Yura_bike_summon : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Replica_Yura_bike/Replica_Yura_bike_summon"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Replica] Knight of (Halloween) Night");
            Tooltip.SetDefault("\"The story of a headless rider who roams the lands of Japan looking for victims whose lives she intends to take.\""
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
            Item.mountType = ModContent.MountType<Replica_Yura_bike>();
        }


        public override void AddRecipes()
        {
            Recipe Replica_Yura_bike_summon = CreateRecipe(1);
            Replica_Yura_bike_summon.AddIngredient(ItemID.CorruptCampfire, 3);
            Replica_Yura_bike_summon.AddIngredient(ItemID.FrozenCampfire, 3);
            Replica_Yura_bike_summon.AddIngredient(ItemID.Campfire, 3);
            Replica_Yura_bike_summon.AddIngredient(ItemID.Amethyst, 3);
            Replica_Yura_bike_summon.AddIngredient(ItemID.Sapphire, 3);
            Replica_Yura_bike_summon.AddTile(TileID.HeavyWorkBench);
            Replica_Yura_bike_summon.Register();
        }
    }
}