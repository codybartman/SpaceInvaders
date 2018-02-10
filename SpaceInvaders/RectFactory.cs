using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public enum iconType
    {
        Octopus,
        Crab,
        Squid,
        CoreCannon
    }

    class RectFactory
    {
        private enum RectType
        {
            Octopus1,
            Octopus2,
            Crab1,
            Crab2,
            Squid1,
            Squid2,
            CoreCannon1,
            CoreCannon2,
            CoreCannon3,
            UFO,
            blob1,
            explosion,
            blob2,
        }

        static readonly int[] bx = { 15, 285, 550 };
        static readonly int[] by = { 15, 170, 320 };

        public static Azul.Rect[] GetRects(CharacterEnum typeIn)
        {
            Azul.Rect[] arrayOut = new Azul.Rect[2];
            switch (typeIn)
            {
                case CharacterEnum.octopus:
                    arrayOut[0] = GetRect(RectType.Octopus1);
                    arrayOut[1] = GetRect(RectType.Octopus2);
                    break;
                case CharacterEnum.crab:
                    arrayOut[0] = GetRect(RectType.Crab1);
                    arrayOut[1] = GetRect(RectType.Crab2);
                    break;
                case CharacterEnum.squid:
                    arrayOut[0] = GetRect(RectType.Squid1);
                    arrayOut[1] = GetRect(RectType.Squid2);
                    break;
                case CharacterEnum.corecannon:
                    arrayOut[0] = GetRect(RectType.CoreCannon1);
                    break;
                case CharacterEnum.missle:
                    arrayOut = GetCCMissles();
                    break;
                default:
                    break;

            }
            return arrayOut;
        }
        private static Azul.Rect GetRect(RectType typeIn)
        {
            int cordX = bx[0];
            int cordY = by[0];
            const int width = 240;
            const int height = 130;

            switch (typeIn)
            {
                case RectType.Octopus1:
                    break;
                case RectType.Octopus2:
                    cordY = by[1];
                    break;
                case RectType.Crab1:
                    cordX = bx[1];
                    break;
                case RectType.Crab2:
                    cordX = bx[1];
                    cordY = by[1];
                    break;
                case RectType.Squid1:
                    cordX = bx[2];
                    break;
                case RectType.Squid2:
                    cordX = bx[2];
                    cordY = by[1];
                    break;
                case RectType.CoreCannon1:
                    cordY = by[2];
                    break;
                default:
                    break;

                    
            }
            Azul.Rect returnRect =  new Azul.Rect(cordX, cordY, width, height);
            return returnRect;
        }
        private static Azul.Rect[] GetCCMissles()
        {
            const int width = 70;
            const int height = 140;
            const int states = 8;

            int startingoffset = bx[0];
            const int amountToAdd = 84;
            int xValue = startingoffset;

            Azul.Rect[] returnArray = new Azul.Rect[states];
            for (int i = 0; i < states; i++)
            {
                xValue += amountToAdd;
                returnArray[i] = new Azul.Rect(xValue, 784, width, height);
            }
            return returnArray;
        }
    }
}
