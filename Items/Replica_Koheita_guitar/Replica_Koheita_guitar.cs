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
using Terraria.ID;

namespace KsonFriends.Items
{
    public class Replica_Koheita_guitar : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Replica_Koheita_guitar/Replica_Koheita_guitar"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Replica] Snappy Bluey Karl guitar");
            Tooltip.SetDefault("A replica of the famous Carl guitar, owned and modified by Koheita."
                + Environment.NewLine + "Now it actually shoots lightning. Sick."
                + Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
        }

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 20;
            Item.rare = ItemRarityID.Blue;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.useAnimation = 20;
            Item.useTime = Item.useAnimation;
            Item.width = 12;
            Item.height = 22;
            Item.noMelee = true;
            Item.holdStyle = ItemHoldStyleID.HoldGuitar;
            Item.shootSpeed = 5f;
            Item.value = 225;
            Item.shoot = ModContent.ProjectileType<Replica_Koheita_guitar_Projectile>();
        }

        public override void AddRecipes()
        {
            Recipe Replica_Koheita_guitar_recipe = CreateRecipe(1);
            Replica_Koheita_guitar_recipe.AddIngredient(ItemID.DrumSet, 1);
            Replica_Koheita_guitar_recipe.AddIngredient(ItemID.DrumStick, 1);
            Replica_Koheita_guitar_recipe.AddIngredient(ItemID.SilverBar, 10);
            Replica_Koheita_guitar_recipe.AddTile(TileID.HeavyWorkBench);
            Replica_Koheita_guitar_recipe.Register();

        }
    }
}