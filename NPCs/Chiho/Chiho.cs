using KsonFriends.Items;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace KsonFriends.NPCs
{
	[AutoloadHead]
	public class Chiho : ModNPC
	{
		public override string Texture {
			get {return "KsonFriends/NPCs/Chiho/Chiho"; }
		}

		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Chiho");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Steampunker];
			
        }

        public override void SetDefaults()
        {
			NPC.friendly = true;
			NPC.townNPC = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 27;
			NPC.defense = 33;
			NPC.lifeMax = 200;
			NPC.HitSound = SoundID.NPCHit1;
			//NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AIType = NPCID.Steampunker;
			AnimationType = NPCID.Steampunker;
			NPC.homeless = false;
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add("Kon-chiho ~");
			//chat.Add("What's your favorite color? My favorite colors are white and black.");
			//chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			//chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			//chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string.
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0f;
        }

/*         public override bool CanTownNPCSpawn(int numTownNPCs, int money)
         {
			bool DMJ_Exist = ( NPC.FindFirstNPC( ModContent.NPCType<DMJ>() ) != -1 );
			if( DMJ_Exist)
            {
				return false;
            }

			for (int i= 0; i < 255; i++)
            {
                   Player player = Main.player[i];
                   if (!player.active)
                   { continue; }

				   if( player.inventory.Any(item => !item.IsAir && item.type == ModContent.ItemType<Replica_Kson_sword>() ) )
					{
					return true;
					}

            }
			return false;
         }

*/         

    }
}