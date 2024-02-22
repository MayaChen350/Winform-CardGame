﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LazniCardGame
{
    #region CARDS TYPES
    /// <summary>
    /// Player card original data
    /// </summary>
    internal class PlayerCard
    {
        readonly public string Name;
        readonly public int Hp;
        readonly public int Atk;
        readonly public Bitmap ImageLocation;
        // ability1
        // ability2

        public PlayerCard(string name, int hp, int atk, Bitmap image)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
            ImageLocation = image;
        }
    }

    /// <summary>
    /// Secondary card original data
    /// </summary>
    class SoldierCard
    {
        readonly public string Name;
        readonly public int Hp;
        readonly public int Atk;
        readonly public Bitmap ImageLocation;
        // ability1

        public SoldierCard(string name, int hp, int atk, Bitmap image)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
            ImageLocation = image;
        }
    }

    /// <summary>
    /// Instance of a player card in game
    /// </summary>
    class MainCard
    {
        private int hp;
        private int atk;

        public string Name;
        public int Hp
        {
            get { return hp; }
            // Hp can't go below 0
            set
            {
                hp = value < 0 ? 0 : value;
            }
        }
        public int Atk
        {
            // Even if ATK will be displayed as 0 if below it, ATK nerfs can still stack
            get { return atk < 0 ? 0 : atk; }
            set { atk = value; }
        }
        public Bitmap ImageLocation;
        public PictureBox CardInGame;
        public bool Used;
        public bool Dead;
    }

    /// <summary>
    /// Instance of a secondary card in game
    /// </summary>
    class SecondaryCard
    {
        private int hp;
        private int atk;

        public string Name;
        public int Hp
        {
            get { return hp; }
            // Hp can't go below 0
            set
            {
                hp = value < 0 ? 0 : value;
            }
        }
        public int Atk
        {
            // Even if ATK will be displayed as 0 if below it, ATK nerfs can still stack
            get { return atk < 0 ? 0 : atk; }
            set { atk = value; }
        }
        public Bitmap ImageLocation;
        public PictureBox CardInGame;
        public bool Used;
        public bool Dead;

        public int RandomStats(int hpOrAtk)
        {
            double random = new Random().Next(-20, 20) * 0.01;
            return (int)(hpOrAtk * (random));
        }
    }

    // UNUSED FOR NOW
    /*class SpecialCard
     {
         public int hp;
         public int atk;
         //ability1
         //ability2

         public SpecialCard(int hp, int atk)
         {
             hp = hp;
             atk = atk;
         }
     }

     class ObjectCard
     {
         public int atk;
         //effect
     }*/

    #endregion

    public partial class Game
    {
        // readonly string[] PlayerCards = { "Allemanie", "Allemapon", "Almahad", "Anglestan", "Canalgeria", "Fitalie", "Garulmonie", "Khenaga", "Mulretonie", "Nitralvie", "Qaland", "Slovanoya", "Starvas", "TheLeaf", "Traicere", "Yedesna" };
        // If we ever need it

        #region CARDS (110 CARDS)
        // Player cards (16 cards)

        //RESERVED FOR THE PROOF OF CONCEPT
        readonly PlayerCard Slovanoya = new PlayerCard("Slovanoya", 2850, 350, Properties.Resources.Slovanoya);
        readonly PlayerCard Allemapon = new PlayerCard("Allemapon", 3000, 0, Properties.Resources.Allemapon);
        readonly PlayerCard Anglestan = new PlayerCard("Anglestan", 3450, 100, Properties.Resources.Anglestan);
        readonly PlayerCard Garulmonie = new PlayerCard("Garulmonie", 3400, 150, Properties.Resources.Garulmonie);

        /*PlayerCard Allemanie = new PlayerCard(3500, 250);
        //Allemapon
        PlayerCard Almahad = new PlayerCard(3500, 250);
        //Anglestan
        PlayerCard Canalgeria = new PlayerCard(3500, 200);
        PlayerCard Fitalie = new PlayerCard(4000, 250);
        //Garulmonie
        PlayerCard Khenaga = new PlayerCard(3350, 200);
        PlayerCard Mulretonie = new PlayerCard(3000, 300);
        PlayerCard Nitralvie = new PlayerCard(3250, 250);
        PlayerCard Qaland = new PlayerCard(3500, 225);
        //Slovanoya 
        PlayerCard Starvas = new PlayerCard(3550, 250);
        PlayerCard TheLeaf = new PlayerCard(3750, 150);
        PlayerCard Traicere = new PlayerCard(3600, 100);
        PlayerCard Yedesna = new PlayerCard(3350, 250);*/
        // Soldier cards (64 cards)

        //RESERVED FOR THE PROOF OF CONCEPT
        readonly SoldierCard Allemanie_A = new SoldierCard("Allemanie_A", 200, 75, Properties.Resources.Allemanie_A);
        readonly SoldierCard Allemanie_B = new SoldierCard("Allemanie_B", 150, 45, Properties.Resources.Allemanie_B);
        readonly SoldierCard Allemapon_A = new SoldierCard("Allemapon_A", 150, 25, Properties.Resources.Allemapon_A);
        readonly SoldierCard Allemapon_B = new SoldierCard("Allemapon_B", 175, 75, Properties.Resources.Allemapon_B);
        readonly SoldierCard Almahad_A = new SoldierCard("Almahad_A", 100, 70, Properties.Resources.Almahad_A);
        readonly SoldierCard Almahad_B = new SoldierCard("Almahad_B", 100, 25, Properties.Resources.Almahad_B);
        // SoldierCard Amelandia_A
        // SoldierCard Amelandia_B
        readonly SoldierCard Anglestan_A = new SoldierCard("Anglestan_A", 200, 35, Properties.Resources.Anglestan_A);
        readonly SoldierCard Anglestan_B = new SoldierCard("Anglestan_B", 175, 50, Properties.Resources.Anglestan_B);
        readonly SoldierCard Canalgeria_A = new SoldierCard("Canalgeria_A", 350, 5, Properties.Resources.Canalgerie_A);
        readonly SoldierCard Canalgeria_B = new SoldierCard("Canalgeria_B", 100, 45, Properties.Resources.Canalgerie_B);
        readonly SoldierCard Criota_A = new SoldierCard("Criota_A", 150, 50, Properties.Resources.Criota_A);
        readonly SoldierCard Criota_B = new SoldierCard("Criota_B", 125, 25, Properties.Resources.Criota_B);

        /*SoldierCard Ekota_A = new SoldierCard(200, 15);
        SoldierCard Ekota_B = new SoldierCard(100, 50);
        SoldierCard Finlonie_A = new SoldierCard(125, 25);
        SoldierCard Finlonie_B = new SoldierCard(250, 75);
        SoldierCard Fitalie_A = new SoldierCard(100, 100);
        SoldierCard Fitalie_B = new SoldierCard(150, 25);
        SoldierCard Garulmonie_A = new SoldierCard(300, 10);
        SoldierCard Garulmonie_B = new SoldierCard(150, 35);
        SoldierCard Hongoru_A = new SoldierCard(125, 50);
        SoldierCard Hongoru_B = new SoldierCard(200, 0);
        SoldierCard Huanvana_A = new SoldierCard(75, 0);
        SoldierCard Huanvana_B = new SoldierCard(200, 0);
        SoldierCard Kaenia_A = new SoldierCard(125, 40);
        SoldierCard Kaenia_B = new SoldierCard(180, 60);
        SoldierCard Kalontia_A = new SoldierCard(200, 75);
        SoldierCard Kalontia_B = new SoldierCard(250, 25)
        SoldierCard Khenaga_A = new SoldierCard(175, 25)
        SoldierCard Khenaga_B = new SoldierCard(125, 50)
        SoldierCard Mageria_A = new SoldierCard(100, 50);
        SoldierCard Mageria_B = new SoldierCard(150,50);
        SoldierCard Maréquie_A = new SoldierCard(150, 75)
        SoldierCard Maréquie_B = new SoldierCard(140, 40);
        SoldierCard Mulretonie_A = new SoldierCard(50, 100)
        SoldierCard Mulretonie_B = new SoldierCard(105, 65)
        SoldierCard Neolantis_A = new SoldierCard(80, 0)
        SoldierCard Neolantis_B = new SoldierCard(105, 45)
        SoldierCard Nitralvie_A = new SoldierCard(175, 75)
        SoldierCard Nitralvie_B = new SoldierCard(175, 45)
        SoldierCard Onriance_A = new SoldierCard(250, 0)
        SoldierCard Onriance_B = new SoldierCard(200, 65)
        SoldierCard Qaland_A = new SoldierCard(200, 40)
        SoldierCard Qaland_B = new SoldierCard(200, 75)
        SoldierCard Qetu_A = new SoldierCard(175, 25)
        SoldierCard Qetu_B = new SoldierCard(N/A, 0)
        SoldierCard Slovanoya_A = new SoldierCard(150, 75)
        SoldierCard Slovanoya_B = new SoldierCard(150, 25)
        SoldierCard Starvas_A = new SoldierCard(175, 65)
        SoldierCard Starvas_B = new SoldierCard(140, 50)
        SoldierCard Tekay_A = new SoldierCard(125, 5)
        SoldierCard Tekay_B = new SoldierCard(75, 125)
        SoldierCard TheLeaf_A = new SoldierCard(50, 100)
        SoldierCard TheLeaf_B = new SoldierCard(145, 25)
        SoldierCard Traicere_A = new SoldierCard(175, 25)
        SoldierCard Traicere_B = new SoldierCard(100, 30)
        SoldierCard Tristan_A = new SoldierCard(200, 60)
        SoldierCard Tristan_B = new SoldierCard(140, 45)
        SoldierCard Tujar_A = new SoldierCard(120, 40)
        SoldierCard Tujar_B = new SoldierCard(175, 40)
        SoldierCard Yedesna_A = new SoldierCard(225, 30)
        SoldierCard Yedesna_B = new SoldierCard(150, 50);*/
        // Special cards (16 cards)
        /* SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard
         SpecialCard*/
        // Object cards (14 cards)
        /*ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard
        ObjectCard*/
        #endregion


        #region PASSIVE ABILITIES
        // UNUSED FOR NOW
        /*private void MethodicalPlanning(PlayerCard playerCard)
        {
            //foreach (SoldierCard card in #ALLSoldiersInTheField) 
            // {
            //    playerCard.atk += 50;
            // }

        }
        private void TeaTimeTactician(PlayerCard playerCard) { }
        private void StrategicMentorship() { }
        private void StrategicRetreat() { }
        private void StandUpRoutine() { }*/
        #endregion

        #region ACTIVE ABILITIES
        /*private void StoicResolve() { }
        private void DebatingDynamo() { }
        private void AdaptivePunchline() { }*/
        #endregion
    }
}
