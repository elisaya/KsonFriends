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
    public class Demonic_18go_whip : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Demonic_18go_whip/Demonic_18go_whip"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Demonic] Princess 18go's Love Whip");
            Tooltip.SetDefault("A replica weapon infused with demonic power. Every swing no longer cause just pain, but also a breath of demon's curse."
                + Environment.NewLine + "Princesses command their knights with their whips. Every swing leave a burn on their victims' skin.... sometimes even hearts."
                + Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            Item.damage = 27;
            Item.knockBack = 8;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<Replica_18go_whip_Projectile>();
            Item.shootSpeed = 4;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 24;
            Item.useTime = Item.useAnimation;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.DamageType = DamageClass.Melee;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.Regeneration, 60);

        }

        public override void AddRecipes()
        {
            RecipeGroup demonicore = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}", ItemID.CrimtaneBar, ItemID.DemoniteBar);
            RecipeGroup.RegisterGroup("demonicore", demonicore);

            RecipeGroup demonicbossdrop = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}", ItemID.TissueSample, ItemID.ShadowScale);
            RecipeGroup.RegisterGroup("demonicbossdrop", demonicbossdrop);

            Recipe Demonic_18go_whip = CreateRecipe(1);
            Demonic_18go_whip.AddRecipeGroup(demonicore, 3);
            Demonic_18go_whip.AddRecipeGroup(demonicbossdrop, 10);
            Demonic_18go_whip.AddIngredient(ModContent.ItemType<Replica_18go_whip>());
            Demonic_18go_whip.AddTile(TileID.WorkBenches);
            Demonic_18go_whip.Register();
        }
    }
}