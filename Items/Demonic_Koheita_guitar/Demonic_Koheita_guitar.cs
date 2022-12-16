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
    public class Demonic_Koheita_guitar : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Demonic_Koheita_guitar/Demonic_Koheita_guitar"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Demonic] Snappy Bluey Karl guitar");
            Tooltip.SetDefault("Strings now reforged with flesh from demons you slayed. Every note you play, demon mumble echos in your ears."
                + Environment.NewLine + "A replica of the famous Carl guitar, owned and modified by Koheita."
                + Environment.NewLine + "Now it actually shoots lightning. Sick.");
        }

        public override void SetDefaults()
        {
            Item.damage = 32;
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
            Item.shoot = ModContent.ProjectileType<Demonic_Koheita_guitar_Projectile>();
        }

        public override void AddRecipes()
        {
            RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
            RecipeGroup.RegisterGroup("demonicore", demonicore);

            RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
            RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

            Recipe Demonic_Koheita_guitar_recipe = CreateRecipe(1);
            Demonic_Koheita_guitar_recipe.AddRecipeGroup(demonicore, 8);
            Demonic_Koheita_guitar_recipe.AddRecipeGroup(demonicbossdrop, 10);
            Demonic_Koheita_guitar_recipe.AddIngredient(ModContent.ItemType<Replica_Koheita_guitar>());
            Demonic_Koheita_guitar_recipe.AddTile(TileID.HeavyWorkBench);
            Demonic_Koheita_guitar_recipe.Register();

        }
    }
}