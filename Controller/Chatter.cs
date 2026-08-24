using System;
using System.Collections.Generic;
using System.Linq;
using Yugi_Poc_GameShop.Model;

namespace Yugi_Poc_GameShop.Controller
{
    internal static class Chatter
    {
        private static readonly Random _random = new Random();
        private static readonly string[] YugiWinPhrases = new string[] {
            "Defeating my grandson is no small feat! Yugi plays with his whole heart, but today your Heart of the Cards beat even stronger!",
            "Incredible! Even Yugi couldn't find an answer to your strategy. You're truly mastering the art of Dueling!",
            "Ah, I haven't seen Yugi this challenged since the Duelist Kingdom tournament! Fantastic job!",
            "To stand against Yugi's Dark Magician and come out victorious... You've grown into a formidable Duelist.",
            "Another win against Yugi? I'm so proud of you, my friend! Just make sure he doesn't spend all night studying your tactics!"
        };

        private static readonly string[] KaibaWinPhrases = new string[] {
            "You beat Kaiba again?! Haha! I can already hear his Blue-Eyes White Dragons roaring in frustration!",
            "It takes quite a Duel to wipe that confident smile off Kaiba's face! Well played!",
            "Kaiba relies on raw power and technology, but your trust in your deck proved superior today!",
            "I bet Kaiba is already calling his engineers to analyze your victory... Don't let him get to you!",
            "Taming Kaiba's ruthless aggression is something very few Duelists ever achieve. Outstanding victory!"
        };

        private static readonly string[] JoeyWinPhrases = new string[] {
            "Defeating Joey? Good job! He fights with pure grit, but your strategy completely outmatched him.",
            "Poor Joey! He put all his faith in his Red-Eyes, but you didn't give him a single opening!",
            "Joey just stopped by the shop complaining about his luck... but we both know it was your sharp instinct that won!",
            "Joey's passion in a Duel is legendary, but you kept your cool and took the win. Well played!",
            "Ah, Joey never gives up, so expect him to ask for a rematch soon! But for now, enjoy this hard-earned victory!"
        };

        public static readonly string[] YugiCardsPhrases = new string[]
        {
            "Ah, you're taking your first true steps into Yugi's collection! Keep building that foundation, one card at a time.",
            "You've already gathered half of Yugi's cards! I can feel the Heart of the Cards guiding your hands with every duel.",
            "Your collection is growing so fast! Yugi himself told me he's impressed by your dedication.",
            "You're getting so close now... only a handful of Yugi's secret tactics remain to be discovered!",
            "Just a few missing pieces left! I can feel the ancient energy of the Pharaoh surrounding your collection!",
            "Unbelievable! You have acquired every single card from Yugi's collection! You hold the true spirit of the King of Games!"
        };

        public static readonly string[] KaibaCardsPhrases = new string[]
        {
            "You've started diving into the KaibaCorp database! Kaiba might act tough, but he can't ignore your progress.",
            "Halfway through Kaiba's archive! Taming his powerful Dragons and spell cards takes extraordinary skill.",
            "Incredible! You're turning Kaiba's high-tech arsenal into your own personal library!",
            "Kaiba's engineers must be losing their minds trying to figure out how you're finding these ultra-rare cards!",
            "Only a couple of cards left in Kaiba's vault! The summit of high-tech Dueling is right within your grasp!",
            "Magnificent! Kaiba's entire card database is completely unlocked! You've conquered the ultimate test of strength!"
        };

        public static readonly string[] JoeyCardsPhrases = new string[]
        {
            "You're starting to build Joey's collection! He fights with pure heart, and your deck is taking on that same burning spirit!",
            "Halfway through Joey's set! You've proven that you possess both sharp strategy and a bit of his legendary luck!",
            "Joey was just in the shop talking about your progress. He's fired up and can't wait for your next duel!",
            "You've gathered almost every warrior and trick card Joey has to offer. Keep pushing forward!",
            "Down to the absolute last few cards of Joey's set! Don't slow down now, the finish line is right there!",
            "Incredible! You've collected every single card from Joey's set! Your passion for Dueling is second to none!"
        };

        private static readonly string FirstPhrase = "Welcome to my shop, young Duelist! I see the passion in your eyes.\n" +
            "Take your time, build your deck, and let the Heart of the Cards guide your way!";
        private static readonly string AlmostCompleted = "Incredible! You've completely mastered two out of the three legendary card sets! You are so close to true perfection!";
        private static readonly string CompletedPhrase = "Unbelievable... 771 cards! You have gathered every single card in existence!\n" +
            "You are no longer just a collector; you are a true Grandmaster of Duel Monsters.\n" +
            "My shop is deeply honored to have served you on this legendary journey!";

        public static readonly string[] GreetingPhrases = new string[]
        {
            "Welcome back, young Duelist! Let's see how your collection is coming along.",
            "Ah, good to see you! The Heart of the Cards must have guided you here today.",
            "Greetings! Step inside, I've been organizing some rare sets all morning.",
            "Hello there! Ready to check your progress and see what new cards you've found?",
            "Ah, one of my favorite customers! Let me take a quick look at your card binder..."
        };

        public static string[] GetChat(Context context, bool justUpdate)
        {
            var toReturn = new List<string>();
            var first = false;
            var ownedCardsList = context.GetCardListCopy().Where(x => x.Value > 0).ToList();
            var yugiCards = context.GetCardListIndex(CardFilter.Only_Yugi);
            var kaibaCards = context.GetCardListIndex(CardFilter.Only_Kaiba);
            var joeyCards = context.GetCardListIndex(CardFilter.Only_Joey);
            var yugiHashSet = new HashSet<int>(yugiCards);
            var yugiSaveCards = ownedCardsList.Count(x => yugiHashSet.Contains(x.Key));
            var kaibaHashSet = new HashSet<int>(kaibaCards);
            var kaibaSaveCards = ownedCardsList.Count(x => kaibaHashSet.Contains(x.Key));
            var joeyHashSet = new HashSet<int>(joeyCards);
            var joeySaveCards = ownedCardsList.Count(x => joeyHashSet.Contains(x.Key));
            var yugiTotalSaveCards = ownedCardsList.Where(x => yugiHashSet.Contains(x.Key)).Sum(x => x.Value);
            var kaibaTotalSaveCards = ownedCardsList.Where(x => kaibaHashSet.Contains(x.Key)).Sum(x => x.Value);
            var joeyTotalSaveCards = ownedCardsList.Where(x => joeyHashSet.Contains(x.Key)).Sum(x => x.Value);
            var chatterState = context.GetChatterState();
            var phrasesState = UnpackPhrasesState(chatterState.SpeechState);
            var milestonesState = UnpackPhrasesState(chatterState.MilestonesState);
            if (chatterState.YugiCards == 0 &&
                chatterState.KaibaCards == 0 &&
                chatterState.JoeyCards == 0)
            {
                toReturn.Add(FirstPhrase);
                chatterState.YugiCards = yugiSaveCards;
                chatterState.KaibaCards = kaibaSaveCards;
                chatterState.JoeyCards = joeySaveCards;
                chatterState.YugiTotalCards = yugiTotalSaveCards;
                chatterState.KaibaTotalCards = kaibaTotalSaveCards;
                chatterState.JoeyTotalCards = joeyTotalSaveCards;
                first = true;
            }
            else
            {
                if (yugiSaveCards != chatterState.YugiCards)
                {
                    if (yugiSaveCards > 154)
                    {
                        toReturn.Add(YugiCardsPhrases[5]);
                    }
                    else if (yugiSaveCards > 149 && !milestonesState.YugiPhrases[4])
                    {
                        toReturn.Add(YugiCardsPhrases[4]);
                        for (int i = 0; i < 5; i++)
                        {
                            milestonesState.YugiPhrases[i] = true;
                        }
                    }
                    else if (yugiSaveCards > 134 && !milestonesState.YugiPhrases[3])
                    {
                        toReturn.Add(YugiCardsPhrases[3]);
                        for (int i = 0; i < 4; i++)
                        {
                            milestonesState.YugiPhrases[i] = true;
                        }
                    }
                    else if (yugiSaveCards > 109 && !milestonesState.YugiPhrases[2])
                    {
                        toReturn.Add(YugiCardsPhrases[2]);
                        for (int i = 0; i < 3; i++)
                        {
                            milestonesState.YugiPhrases[i] = true;
                        }
                    }
                    else if (yugiSaveCards > 79 && !milestonesState.YugiPhrases[1])
                    {
                        toReturn.Add(YugiCardsPhrases[1]);
                        for (int i = 0; i < 2; i++)
                        {
                            milestonesState.YugiPhrases[i] = true;
                        }
                    }
                    else if (yugiSaveCards > 49 && !milestonesState.YugiPhrases[0])
                    {
                        toReturn.Add(YugiCardsPhrases[0]);
                        milestonesState.YugiPhrases[0] = true;
                    }

                    chatterState.YugiCards = yugiSaveCards;
                }

                if (kaibaSaveCards != chatterState.KaibaCards)
                {
                    if (kaibaSaveCards > 314)
                    {
                        toReturn.Add(KaibaCardsPhrases[5]);
                    }
                    else if (kaibaSaveCards > 304 && !milestonesState.KaibaPhrases[4])
                    {
                        toReturn.Add(KaibaCardsPhrases[4]);
                        for (int i = 0; i < 5; i++)
                        {
                            milestonesState.KaibaPhrases[i] = true;
                        }
                    }
                    else if (kaibaSaveCards > 274 && !milestonesState.KaibaPhrases[3])
                    {
                        toReturn.Add(KaibaCardsPhrases[3]);
                        for (int i = 0; i < 4; i++)
                        {
                            milestonesState.KaibaPhrases[i] = true;
                        }
                    }
                    else if (kaibaSaveCards > 219 && !milestonesState.KaibaPhrases[2])
                    {
                        toReturn.Add(KaibaCardsPhrases[2]);
                        for (int i = 0; i < 3; i++)
                        {
                            milestonesState.KaibaPhrases[i] = true;
                        }
                    }
                    else if (kaibaSaveCards > 159 && !milestonesState.KaibaPhrases[1])
                    {
                        toReturn.Add(KaibaCardsPhrases[1]);
                        for (int i = 0; i < 2; i++)
                        {
                            milestonesState.KaibaPhrases[i] = true;
                        }
                    }
                    else if (kaibaSaveCards > 79 && !milestonesState.KaibaPhrases[0])
                    {
                        toReturn.Add(KaibaCardsPhrases[0]);
                        milestonesState.KaibaPhrases[0] = true;
                    }

                    chatterState.KaibaCards = kaibaSaveCards;
                }

                if (joeySaveCards != chatterState.JoeyCards)
                {
                    if (joeySaveCards > 349)
                    {
                        toReturn.Add(JoeyCardsPhrases[5]);
                    }
                    else if (joeySaveCards > 339 && !milestonesState.JoeyPhrases[4])
                    {
                        toReturn.Add(JoeyCardsPhrases[4]);
                        for (int i = 0; i < 5; i++)
                        {
                            milestonesState.JoeyPhrases[i] = true;
                        }
                    }
                    else if (joeySaveCards > 304 && !milestonesState.JoeyPhrases[3])
                    {
                        toReturn.Add(JoeyCardsPhrases[3]);
                        for (int i = 0; i < 4; i++)
                        {
                            milestonesState.JoeyPhrases[i] = true;
                        }
                    }
                    else if (joeySaveCards > 244 && !milestonesState.JoeyPhrases[2])
                    {
                        toReturn.Add(JoeyCardsPhrases[2]);
                        for (int i = 0; i < 3; i++)
                        {
                            milestonesState.JoeyPhrases[i] = true;
                        }
                    }
                    else if (joeySaveCards > 174 && !milestonesState.JoeyPhrases[1])
                    {
                        toReturn.Add(JoeyCardsPhrases[1]);
                        for (int i = 0; i < 2; i++)
                        {
                            milestonesState.JoeyPhrases[i] = true;
                        }
                    }
                    else if (joeySaveCards > 89 && !milestonesState.JoeyPhrases[0])
                    {
                        toReturn.Add(JoeyCardsPhrases[0]);
                        milestonesState.JoeyPhrases[0] = true;
                    }

                    chatterState.JoeyCards = joeySaveCards;
                }
            }

            var yugiDifference = yugiTotalSaveCards - chatterState.YugiTotalCards;
            var kaibaDifference = kaibaTotalSaveCards - chatterState.KaibaTotalCards;
            var joeyDifference = joeyTotalSaveCards - chatterState.JoeyTotalCards;

            chatterState.YugiTotalCards = yugiTotalSaveCards;
            chatterState.KaibaTotalCards = kaibaTotalSaveCards;
            chatterState.JoeyTotalCards = joeyTotalSaveCards;

            if (!justUpdate)
            {
                chatterState.YugiCardsToWin -= yugiDifference;
                chatterState.KaibaCardsToWin -= kaibaDifference;
                chatterState.JoeyCardsToWin -= joeyDifference;
            }

            if (chatterState.YugiCardsToWin < 1)
            {
                toReturn.Add(GetPhrase(YugiWinPhrases, phrasesState.YugiPhrases));
                chatterState.YugiCardsToWin = 25;
            }
            if (chatterState.KaibaCardsToWin < 1)
            {
                toReturn.Add(GetPhrase(KaibaWinPhrases, phrasesState.KaibaPhrases));
                chatterState.KaibaCardsToWin = 25;
            }
            if (chatterState.JoeyCardsToWin < 1)
            {
                toReturn.Add(GetPhrase(JoeyWinPhrases, phrasesState.JoeyPhrases));
                chatterState.JoeyCardsToWin = 25;
            }

            var yugiDone = yugiSaveCards == yugiCards.Count();
            var kaibaDone = kaibaSaveCards == kaibaCards.Count();
            var joeyDone = joeySaveCards == joeyCards.Count();

            if (yugiDone &&
                kaibaDone &&
                joeyDone &&
                !phrasesState.Completed)
            {
                toReturn.Add(CompletedPhrase);
                phrasesState.Completed = true;
                milestonesState.Completed = true;
            }
            else if (((yugiDone && kaibaDone) || (yugiDone && joeyDone) || (kaibaDone && joeyDone)) && !milestonesState.Completed)
            {
                toReturn.Add(AlmostCompleted);
                milestonesState.Completed = true;
            }

            chatterState.SpeechState = PackPhrasesState(phrasesState);
            chatterState.MilestonesState = PackPhrasesState(milestonesState);
            context.SetChatterState(chatterState);

            if (!first && toReturn.Count > 0)
            {
                toReturn.Insert(0, GreetingPhrases[_random.Next(GreetingPhrases.Length)]);
            }

            return toReturn.ToArray();
        }

        private static string GetPhrase(string[] phrases, bool[] used)
        {
            var availableIndices = new List<int>();
            for (int i = 0; i < phrases.Length; i++)
            {
                if (!used[i])
                {
                    availableIndices.Add(i);
                }
            }

            if (availableIndices.Count == 0)
            {
                return string.Empty;
            }

            int selectedIndex = availableIndices[_random.Next(availableIndices.Count)];

            used[selectedIndex] = true;

            return phrases[selectedIndex];
        }

        public static PhrasesState UnpackPhrasesState(ushort rawValue)
        {
            bool mainFlag = (rawValue & 0x01) != 0;

            byte group1Val = (byte)((rawValue >> 1) & 0x1F);

            byte group2Val = (byte)((rawValue >> 6) & 0x1F);

            byte group3Val = (byte)((rawValue >> 11) & 0x1F);

            return new PhrasesState
            {
                Completed = mainFlag,
                JoeyPhrases = ToBoolArray5(group1Val),
                KaibaPhrases = ToBoolArray5(group2Val),
                YugiPhrases = ToBoolArray5(group3Val)
            };
        }

        public static ushort PackPhrasesState(PhrasesState flags)
        {
            ushort result = 0;

            if (flags.Completed)
            {
                result |= 0x01;
            }

            ushort group1Val = FromBoolArray5(flags.JoeyPhrases);
            result |= (ushort)(group1Val << 1);

            ushort group2Val = FromBoolArray5(flags.KaibaPhrases);
            result |= (ushort)(group2Val << 6);

            ushort group3Val = FromBoolArray5(flags.YugiPhrases);
            result |= (ushort)(group3Val << 11);

            return result;
        }

        private static bool[] ToBoolArray5(byte value5Bit)
        {
            bool[] result = new bool[5];
            for (int i = 0; i < 5; i++)
            {
                result[i] = (value5Bit & (1 << i)) != 0;
            }
            return result;
        }

        private static ushort FromBoolArray5(bool[] bools)
        {
            if (bools == null) return 0;

            ushort value = 0;
            int limit = bools.Length < 5 ? bools.Length : 5;

            for (int i = 0; i < limit; i++)
            {
                if (bools[i])
                {
                    value |= (ushort)(1 << i);
                }
            }

            return value;
        }
    }
}
