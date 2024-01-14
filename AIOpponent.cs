﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.Sarif.Driver;

namespace LazniCardGame
{
    public partial class Game : Form
    {
        // # of pattern the opponent will use when using its secondary card during the game
        public int noOpponentPlay;

        private void OpponentTurn()
        {
#if DEBUG 
            Console.WriteLine("Opponent turn started.");
            Console.WriteLine("-------------------------------");
#endif
            // Which cards each opponent cards will attack
            IList<SecondaryCard> cardChosenByOpponent = p1SecCardsData.Shuffle();

            // Player card
            AttackCardCalculation(p2PlayerCardData, p1PlayerCardData);

            AttackEachCardSeperately(cardChosenByOpponent);
            /*  // Secondary cards (depends of which attack pattern the opponent uses)
              switch (noOpponentPlay)
              {
                  case 0:
                      AttackEachCardSeperately(cardChosenByOpponent);
                      break;
                  case 1:
                      AttachEachCardAtATime(cardChosenByOpponent);
                      break;
                  case 2:
                      AlternateBetweenEach(cardChosenByOpponent);
                      break;
              }*/
            UpdateCards();
        }

        private int HowManyp2CardLeft()
        {
            int count = 0;
            foreach (SecondaryCard card in p2SecCardsData)
                count += card.Hp > 0 ? 1 : 0;
            return count;
        }

        private int[] CardAttackedIndexes(IList<SecondaryCard> p1Cards)
        {
            int[] indexes = new int[3];
            int numberOfCards = HowManyp2CardLeft();
            for (int i = 0; i < numberOfCards; i++)
            {
                if (p1Cards[i].Hp <= 0)
                {
                    for (int j = 0; j < 3; j++)
                        if (p1Cards[j].Hp > 0)
                        {
                            indexes[i] = j;
                            break;
                        }
                }
                else
                    indexes[i] = i;
            }
#if DEBUG
            Console.Write("Opponent cards will attack:");
            for (int i = 0; i < numberOfCards - 1; i++)
                Console.Write($" {indexes[i]}");
            Console.WriteLine($" {indexes[numberOfCards - 1]}");
            Console.WriteLine("-------------------------------");
#endif
            return indexes;
        }

        private void AttackEachCardSeperately(IList<SecondaryCard> p1Cards)
        {
            // Secondary Cards
            int numberOfCards = HowManyp2CardLeft();
            int[] indexes = CardAttackedIndexes(p1Cards);
            for (int i = 0; i < p2SecCardsData.Length; i++)
                AttackCardCalculation(p2SecCardsData[i], p1Cards[indexes[i]]);

        }

        private void AttachEachCardAtATime(IList<SecondaryCard> p1Cards)
        {

        }

        private void AlternateBetweenEach(IList<SecondaryCard> p1Cards) { }
    }
}
