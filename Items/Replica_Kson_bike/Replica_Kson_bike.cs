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

namespace KsonFriends.Items
{
    public class Replica_Kson_bike : ModMount
    {
        // Using something like this for gameplay effects would require ModPlayer syncing, but this example is purely visual.

        public override string Texture
        {
            get { return "KsonFriends/Items/Replica_Kson_bike/Replica_Kson_bike"; }
        }


        public override void SetStaticDefaults()
        {
			MountData.spawnDust = DustID.LastPrism;
			MountData.spawnDustNoGravity = true;
			MountData.heightBoost = 0;
			MountData.fallDamage = 0f;
			MountData.runSpeed = 6.5f;
//			MountData.flightTimeMax = 2;		//unlock after 2rd upgrade
////////	MountData.fatigueMax = 0;
			MountData.constantJump = true;
			MountData.jumpHeight = 15;
			MountData.acceleration = 0.4f;
			MountData.swimSpeed = 3.5f;
			MountData.jumpSpeed = 5f;
			MountData.blockExtraJumps = false;
			MountData.constantJump = true;


			MountData.totalFrames = 16;
			MountData.playerYOffsets = Enumerable.Repeat(28, MountData.totalFrames).ToArray();
			MountData.yOffset = -20;
			MountData.xOffset = 10;
			MountData.playerHeadOffset = 10;


			MountData.standingFrameCount = 1;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;

			MountData.runningFrameCount = 15;
			MountData.runningFrameDelay = 20;
			MountData.runningFrameStart = 0;

			MountData.flyingFrameCount = 15;
			MountData.flyingFrameDelay = 20;
			MountData.flyingFrameStart = 0;

			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 15;

			MountData.idleFrameCount = 15;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;

			MountData.swimFrameCount = 15;
			MountData.swimFrameDelay = 20;
			MountData.swimFrameStart = 0;


			if (Main.netMode != NetmodeID.Server)
			{
				MountData.textureWidth = MountData.frontTexture.Width();
				MountData.textureHeight = MountData.frontTexture.Height();
			}

		}


        public override void UpdateEffects(Player player)
        {
            player.AddBuff(BuffID.Swiftness, 2);
            player.AddBuff(BuffID.WaterWalking, 2);
            //player.AddBuff(BuffID.Featherfall, 2);        //unlock after 1st upgrade
            player.AddBuff(BuffID.WaterCandle, 2);			//disable after 3rd upgrade
            //player.AddBuff(BuffID.Thorns, 2);             //unlock after 4th upgrade
        }



    }
}