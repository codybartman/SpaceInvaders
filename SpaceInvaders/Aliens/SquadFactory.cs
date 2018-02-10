using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SquadFactory
    {
        Squad[] alienRows;
        Squad[] alienCols;
        SimpleSquad totalAliens;
        int totalIndex = 0;

        public void BuildAliens(ref Squad[] AlienRowsOut, ref Squad[] AlienColumnsOut, ref SimpleSquad TotalAliensOut)
        {
            BuildSquads(ref alienRows, GameSpecs.AlienRowCount, GameSpecs.AlienColCount);
            BuildSquads(ref alienCols, GameSpecs.AlienColCount, GameSpecs.AlienRowCount);
            totalAliens = TotalAliensOut;

            BuildAllRows();

            AlienRowsOut = alienRows;
            AlienColumnsOut = alienCols;
            TotalAliensOut = totalAliens;
        }
        private void BuildSquads(ref Squad[] squadArray, int ArraySize, int squadSize)
        {
            squadArray = new Squad[ArraySize];
            for (int i = 0; i < squadArray.Length; i++)
            {
                squadArray[i] = new Squad(squadSize);
            }
        }
        private void BuildAllRows()
        {
            CharacterEnum typeIn;
            for(int i = 0; i < GameSpecs.AlienRowCount; i++)
            {
                typeIn = GameSpecs.AlienClassOrder[i];
                BuildRow(i, typeIn);
            }
        }
        private void BuildRow(int row, CharacterEnum alienType)
        {
            int currentOffset = GameSpecs.LeftBoundry;
            int latitude = GameSpecs.TopBoundry - (GameSpecs.SpaceBetweenRows * row);

            for (int i = 0; i < GameSpecs.AlienColCount; i++)
            {
                Character AlienToAdd = new Character();
                AlienToAdd.Init(alienType, currentOffset, latitude);
                alienRows[row].AddAlien(AlienToAdd, i);
                alienCols[i].AddAlien(AlienToAdd, row);
                totalAliens.AddAlien(AlienToAdd, totalIndex);
                totalIndex++;
                currentOffset += GameSpecs.SpaceBetweenCols;
            }
        }
    }
}
