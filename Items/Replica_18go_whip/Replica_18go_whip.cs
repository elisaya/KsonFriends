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
    public class Replica_18go_whip : ModItem
    {
        public override string Texture
        {
            get { return "KsonFriends/Items/Replica_18go_whip/Replica_18go_whip"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Replica] Princess 18go's Love Whip");
            Tooltip.SetDefault("Princesses command their knights with their whips. Every swing leave a burn on their victims' skin.... sometimes even hearts."
                + Environment.NewLine + "Next upgrade requires: [Ore Bar] Demonite/Crimtane , [Boss Drop] Shadow Scale/Tissue Sample");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            Item.damage = 18;
            Item.knockBack = 6;
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
            Recipe Replica_18go_whip = CreateRecipe(1);
            Replica_18go_whip.AddIngredient(ItemID.HeartLantern, 1);
            Replica_18go_whip.AddIngredient(ItemID.BlandWhip);
            Replica_18go_whip.AddTile(TileID.WorkBenches);
            Replica_18go_whip.Register();
        }
    }
}