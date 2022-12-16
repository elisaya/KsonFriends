using System;
using Microsoft.Xna.Framework;
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
using KsonFriends.NPCs;

namespace KsonFriends.NPCs
{
	public class GuideGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		int dialog_count = 0;

        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			return npc.type == NPCID.Guide;
		}

        public override void GetChat(NPC npc, ref string chat)
        {
			switch (dialog_count)
			{
				case 0:
					chat = "Oh Gahhhd this is so good.... mmm so good.... emmmmm so good and tasty.... EEMMMM AHHHHHHH AHHH~" + Environment.NewLine + "Sprinkle fresh Life Crystal on a slice of ancient-greece flavor Pizza to bring it back to life, and you have no idea what creature that magical piiza can lure.";
					break;
				case 1:
					chat = "Have you ever heard of a mysterious lantern that burns with bone-chilling icy flame?" + Environment.NewLine + "I heard you can craft a similar one with a Skeleton Statue, 2~3 dozens of Bones, a Bottle and a Frozen Campfire on an underground altar";
					break;
				case 2:
					chat = "Like my sailor hat? Sorry it's out of stock." + Environment.NewLine + "You can make one yourself, just need a some Silk and a Loom";
					break;
				case 3:
					chat = "Horse racing is NOT pure luck, it is science." + Environment.NewLine + "If you wish to master the art of horse racing, you must first read at least a handful of Books, then grab a pair of good Sun Glasses and go field research! Dont forget your Stop Watch!";
                    break;
				case 4:
					chat = "The Gods created this world with a fooking pencil, and in the old days my friend David the painter drew islands on the sky with a paint brush." + Environment.NewLine + " \'Red Paint Blue Paint and Green Paint, and you can draw the world with a Paint Brush.\' he said.";
                    break;
				case 5:
					chat = "Back in the Great War I was a general and now I'm just sitting here talking to you little rrats." + Environment.NewLine + "If you want to look cool like I used to be, grab yourself a Hat any hat, coat it with Black Paint, and finish up with a Star on the front.";
                    break;
				case 6:
					chat = "Silk, Red Paint, Ruby, that's all it takes to make a teddy bear" + Environment.NewLine + "Sadly the Clothier ain't gonna do it for you unless you pay him a plat or something, you might as well get a Loom and do it yourself.";
                    break;
				case 7:
					chat = "Come on, hold this spoon for me .... SNAPPS! Ha, a big \"shock\" isn't it!" + Environment.NewLine + "Get some Mana Crystal and some wood, make yourself a pranking spoon and start pranking!";
                    break;
				case 8:
					chat = "mommy... sorry, mommy...sorry, mommy... sorry, mommy......Excuse me I know what you were thinking but I'm by no mean a pervert. I'm just an average holy water enjoyer! " + Environment.NewLine + "But if you want to join me, Cross Statue, Holy Water, Bottle, that's all.";
                    break;
				case 9:
					chat = "Have you met the travelling merchant yet? He's been selling all sorts for interesting stuffs." + Environment.NewLine + "I saw he once sold the Armsdealer a gigantic pink ribbon and some silk and few buckets of pink paint.......oh GOD";
                    break;
				case 10:
					chat = "Every single supernatural entity in this world was summoned by our ancestors, good or bad. They created a bible, a BLACK BIBLE, a bible that wield both the power of Holy and Evil." + Environment.NewLine + "Legend says they wrote the bible with Book from the dungeon and Black Ink from the furthest seas." + Environment.NewLine + 
						"The Luna Cult was stupid enough to prepare everything but a set of Silver Armor, the only thing that can contain an evil spirit. Idiots purged themselves from the earth.";
                    break;
				case 11:
					chat = "If you want to stop a dinosaur charging at you, ain't no better way than throwing a bola at it; Similarly, if you want to stop someone roaming around looking for targets, cuff 'em ankles and let them pay the price." + Environment.NewLine + "Legcuffs are no more than two Shackles and a Chain, preferably some extra metal to reinforce the whole thing.";
                    break;
				case 12:
					chat = "We don't have any Willy Wonka in this world so I have no idea who created this evil recipe that claims to \"Give your favorite pet bunny personality\" when the ingredient is literally a living rabbit." + Environment.NewLine + "\"Put our favorite Bunny in a cooking pot, add three Bottle of Honey and cook it for roughly three hours. Before serving, sprinkle shattered Life Crystal to give it life, and your favorite bunny will come back talking to you.\"";
                    break;
				case 13:
					chat = "Sieru" + Environment.NewLine + "";
                    break;
				case 14:
					chat = "18go" + Environment.NewLine + "";
                    break;
				case 15:
					chat = "yaman" + Environment.NewLine + "";
                    break;
				case 16:
					chat = "Hana" + Environment.NewLine + "";
                    break;
			}
			if(dialog_count >= 17)
            {
				dialog_count = 0;
            }
            else
            {
				dialog_count++;
            }
		}


    }
}