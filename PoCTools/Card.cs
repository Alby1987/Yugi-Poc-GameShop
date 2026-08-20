namespace Yugi_Poc_GameShop.PoCTools
{
    public class Card
    {
        public ushort ID { get; set; } = 0x0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public uint PropertyBinary { get; set; } = 0x0;
        public ushort VersionBinary { get; set; } = 0x0;
        public CardType Type
        {
            get
            {
                int type = (int)((this.PropertyBinary >> 20) & 0x1F);

                switch (type)
                {
                    case 1:
                        return CardType.Dragon;
                    case 2:
                        return CardType.Zombie;
                    case 3:
                        return CardType.Fiend;
                    case 4:
                        return CardType.Pyro;
                    case 5:
                        return CardType.SeaSerpent;
                    case 6:
                        return CardType.Rock;
                    case 7:
                        return CardType.Machine;
                    case 8:
                        return CardType.Fish;
                    case 9:
                        return CardType.Dinosaur;
                    case 10:
                        return CardType.Insect;
                    case 11:
                        return CardType.Beast;
                    case 12:
                        return CardType.BeastWarrior;
                    case 13:
                        return CardType.Plant;
                    case 14:
                        return CardType.Aqua;
                    case 15:
                        return CardType.Warrior;
                    case 16:
                        return CardType.WingedBeast;
                    case 17:
                        return CardType.Fairy;
                    case 18:
                        return CardType.SpellCaster;
                    case 19:
                        return CardType.Thunder;
                    case 20:
                        return CardType.Reptile;
                    case 21:
                        return CardType.Trap;
                    case 22:
                        return CardType.Spell;
                    case 24:
                        return CardType.Divine;
                    default:
                        return CardType.Unkown;
                }
            }
            set
            {
                int type;

                switch (value)
                {
                    case CardType.Dragon:
                        type = 1;
                        break;
                    case CardType.Zombie:
                        type = 2;
                        break;
                    case CardType.Fiend:
                        type = 3;
                        break;
                    case CardType.Pyro:
                        type = 4;
                        break;
                    case CardType.SeaSerpent:
                        type = 5;
                        break;
                    case CardType.Rock:
                        type = 6;
                        break;
                    case CardType.Machine:
                        type = 7;
                        break;
                    case CardType.Fish:
                        type = 8;
                        break;
                    case CardType.Dinosaur:
                        type = 9;
                        break;
                    case CardType.Insect:
                        type = 10;
                        break;
                    case CardType.Beast:
                        type = 11;
                        break;
                    case CardType.BeastWarrior:
                        type = 12;
                        break;
                    case CardType.Plant:
                        type = 13;
                        break;
                    case CardType.Aqua:
                        type = 14;
                        break;
                    case CardType.Warrior:
                        type = 15;
                        break;
                    case CardType.WingedBeast:
                        type = 16;
                        break;
                    case CardType.Fairy:
                        type = 17;
                        break;
                    case CardType.SpellCaster:
                        type = 18;
                        break;
                    case CardType.Thunder:
                        type = 19;
                        break;
                    case CardType.Reptile:
                        type = 20;
                        break;
                    case CardType.Trap:
                        type = 21;
                        break;
                    case CardType.Spell:
                        type = 22;
                        break;
                    case CardType.Divine:
                        type = 24;
                        break;
                    default:
                        type = 0;
                        break;
                }
                PropertyBinary &= ~(0x1Fu << 20);
                PropertyBinary |= (uint)(type & 0x1F) << 20;
            }
        }
        public CardAttribute Attribute
        {
            get
            {
                int attr;

                switch (this.Type)
                {
                    case CardType.Trap:
                        attr = 9;
                        break;

                    case CardType.Spell:
                        attr = 8;
                        break;

                    default:
                        attr = (int)(this.PropertyBinary >> 29);
                        break;
                }

                switch (attr)
                {
                    case 0:
                        return CardAttribute.Divine;
                    case 1:
                        return CardAttribute.Light;
                    case 2:
                        return CardAttribute.Dark;
                    case 3:
                        return CardAttribute.Water;
                    case 4:
                        return CardAttribute.Fire;
                    case 5:
                        return CardAttribute.Earth;
                    case 6:
                        return CardAttribute.Wind;
                    case 8:
                        return CardAttribute.Spell;
                    case 9:
                        return CardAttribute.Trap;
                    default:
                        return CardAttribute.Unkown;
                }
            }

            set
            {
                int attr;

                switch (value)
                {
                    case CardAttribute.Divine:
                        attr = 0;
                        break;
                    case CardAttribute.Light:
                        attr = 1;
                        break;
                    case CardAttribute.Dark:
                        attr = 2;
                        break;
                    case CardAttribute.Water:
                        attr = 3;
                        break;
                    case CardAttribute.Fire:
                        attr = 4;
                        break;
                    case CardAttribute.Earth:
                        attr = 5;
                        break;
                    case CardAttribute.Wind:
                        attr = 6;
                        break;
                    case CardAttribute.Spell:
                        attr = 0;
                        break;
                    case CardAttribute.Trap:
                        attr = 1;
                        break;
                    default:
                        attr = 0;
                        break;
                }

                PropertyBinary &= ~(0x7u << 29);
                PropertyBinary |= (uint)(attr & 0x7) << 29;
            }
        }
        public int Level
        {
            get
            {
                int lvl;

                switch (this.Type)
                {
                    case CardType.Spell:
                    case CardType.Trap:
                        lvl = 0;
                        break;

                    default:
                        lvl = (int)((this.PropertyBinary >> 25) & 0x0F);
                        break;
                }

                //if (this.Type == CardType.Divine) lvl = 10;
                return lvl;
            }

            set
            {
                PropertyBinary &= ~(0xFu << 25);
                PropertyBinary |= (uint)(value & 0x0F) << 25;
            }
        }
        public SpellTrapType SpellTrapType
        {
            get
            {
                int st;

                switch (this.Type)
                {
                    case CardType.Trap:
                    case CardType.Spell:
                        st = (int)((this.PropertyBinary >> 17) & 0x07);
                        break;

                    default:
                        st = 0;
                        break;
                }

                switch (st)
                {
                    case 0:
                        return SpellTrapType.Normal;
                    case 1:
                        return SpellTrapType.Counter;
                    case 2:
                        return SpellTrapType.Field;
                    case 3:
                        return SpellTrapType.Equip;
                    case 4:
                        return SpellTrapType.Continuous;
                    case 5:
                        return SpellTrapType.Quickplay;
                    case 6:
                        return SpellTrapType.Ritual;
                    default:
                        return SpellTrapType.Unkown;
                }
            }
            set
            {
                int st;

                switch (value)
                {
                    case SpellTrapType.Normal:
                        st = 0;
                        break;
                    case SpellTrapType.Counter:
                        st = 1;
                        break;
                    case SpellTrapType.Field:
                        st = 2;
                        break;
                    case SpellTrapType.Equip:
                        st = 3;
                        break;
                    case SpellTrapType.Continuous:
                        st = 4;
                        break;
                    case SpellTrapType.Quickplay:
                        st = 5;
                        break;
                    case SpellTrapType.Ritual:
                        st = 6;
                        break;
                    default:
                        st = 0;
                        break;
                }

                PropertyBinary &= ~(0x7u << 17);
                PropertyBinary |= (uint)(st & 0x7) << 17;
            }
        }

        public CardSubType SubType
        {
            get
            {
                int sub;

                switch (this.Type)
                {
                    case CardType.Trap:
                        sub = 8;
                        break;

                    case CardType.Spell:
                        sub = 7;
                        break;

                    default:
                        sub = (int)((this.PropertyBinary >> 18) & 0x03);
                        break;
                }

                //if (this.ID == 0x776) sub = 3;
                //if (this.ID > 0x776 && this.ID < 0x779) sub = 1;

                switch (sub)
                {
                    case 0:
                        return CardSubType.Normal;
                    case 1:
                        return CardSubType.Effect;
                    case 2:
                        return CardSubType.Fusion;
                    case 3:
                        return CardSubType.Ritual;
                    case 7:
                        return CardSubType.Spell;
                    case 8:
                        return CardSubType.Trap;
                    default:
                        return CardSubType.Unkown;
                }
            }
            set
            {
                int sub;

                switch (value)
                {
                    case CardSubType.Normal:
                        sub = 0;
                        break;
                    case CardSubType.Effect:
                        sub = 1;
                        break;
                    case CardSubType.Fusion:
                        sub = 2;
                        break;
                    case CardSubType.Ritual:
                        sub = 3;
                        break;
                    case CardSubType.Spell:
                        sub = 0;
                        break;
                    case CardSubType.Trap:
                        sub = 0;
                        break;
                    default:
                        sub = 0;
                        break;
                }

                PropertyBinary &= ~(0x3u << 18);
                PropertyBinary |= (uint)(sub & 0x3) << 18;
            }
        }

        public int ATK
        {
            get
            {
                int atk;

                switch (this.Type)
                {
                    case CardType.Spell:
                    case CardType.Trap:
                        atk = 0;
                        break;

                    default:
                        atk = (int)(((this.PropertyBinary >> 9) & 0x1FF) * 10);
                        break;
                }

                //if (this.Type == CardType.Divine) atk = 4000;
                return atk;
            }
            set
            {
                if (value >= 5120) return;

                PropertyBinary &= ~(0x1FFu << 9);
                PropertyBinary |= (uint)((value / 10) & 0x1FF) << 9;
            }
        }

        public int DEF
        {
            get
            {
                int def;

                switch (this.Type)
                {
                    case CardType.Spell:
                    case CardType.Trap:
                        def = 0;
                        break;

                    default:
                        def = (int)((this.PropertyBinary & 0x1FF) * 10);
                        break;
                }

                //if (this.Type == CardType.Divine) def = 4000;
                return def;
            }
            set
            {
                if (value >= 5120) return;

                PropertyBinary &= ~0x1FFu;
                PropertyBinary |= (uint)((value / 10) & 0x1FF);
            }
        }
        public bool VersionYugi
        {
            get
            {
                return (this.VersionBinary & 0x1) != 0;
            }
            set
            {
                if (value) VersionBinary |= 0x1;
                else VersionBinary &= 0x6;
            }
        }
        public bool VersionKaiba
        {
            get
            {
                return (this.VersionBinary & 0x2) != 0;
            }
            set
            {
                if (value) VersionBinary |= 0x2;
                else VersionBinary &= 0x5;
            }
        }
        public bool VersionJoey
        {
            get
            {
                return (this.VersionBinary & 0x4) != 0;
            }
            set
            {
                if (value) VersionBinary |= 0x4;
                else VersionBinary &= 0x3;
            }
        }
    }
}
