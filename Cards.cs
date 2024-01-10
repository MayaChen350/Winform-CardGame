﻿using System.Drawing;
using System.Windows.Forms;

namespace LazniCardGame
{
    #region CARDS TYPES
    class PlayerCard
    {
        readonly public int Hp;
        readonly public int Atk;
        readonly public Bitmap ImageLocation;
        // ability1
        // ability2

        public PlayerCard(int hp, int atk, Bitmap image)
        {
            Hp = hp;
            Atk = atk;
            ImageLocation = image;
        }
    }

    class SoldierCard
    {
        readonly public int Hp;
        readonly public int Atk;
        readonly public Bitmap ImageLocation;
        // ability1

        public SoldierCard(int hp, int atk, Bitmap image)
        {
            Hp = hp;
            Atk = atk;
            ImageLocation = image;
        }
    }

    class MainCard
    {
        public int Hp;
        public int Atk;
        public Bitmap ImageLocation;
        public PictureBox CardInGame;
        public bool Used;
    }

    class SecondaryCard
    {
        public int Hp;
        public int Atk;
        public Bitmap ImageLocation;
        public PictureBox CardInGame;
        public bool Used;
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
        readonly PlayerCard Slovanoya = new PlayerCard(2850, 350, Properties.Resources.Slovanoya);
        readonly PlayerCard Allemapon = new PlayerCard(3000, 0, Properties.Resources.Allemapon);
        readonly PlayerCard Anglestan = new PlayerCard(3450, 100, Properties.Resources.Anglestan);
        readonly PlayerCard Garulmonie = new PlayerCard(3400, 150, Properties.Resources.Garulmonie);

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
        readonly SoldierCard Allemanie_A = new SoldierCard(150, 50, Properties.Resources.Allemanie_A);
        readonly SoldierCard Allemanie_B = new SoldierCard(100, 100, Properties.Resources.Allemanie_B);
        readonly SoldierCard Allemapon_A = new SoldierCard(150, 75, Properties.Resources.Allemapon_A);
        readonly SoldierCard Allemapon_B = new SoldierCard(100, 25, Properties.Resources.Allemapon_B);
        readonly SoldierCard Almahad_A = new SoldierCard(100, 70, Properties.Resources.Almahad_A);
        readonly SoldierCard Almahad_B = new SoldierCard(100, 20, Properties.Resources.Almahad_B);
        // SoldierCard Amelandia_A
        // SoldierCard Amelandia_B
        readonly SoldierCard Anglestan_A = new SoldierCard(200, 35, Properties.Resources.Anglestan_A);
        readonly SoldierCard Anglestan_B = new SoldierCard(150, 75, Properties.Resources.Anglestan_B);
        readonly SoldierCard Canalgeria_A = new SoldierCard(350, 0, Properties.Resources.Canalgerie_A);
        readonly SoldierCard Canalgeria_B = new SoldierCard(150, 50, Properties.Resources.Canalgerie_B);
        readonly SoldierCard Criota_A = new SoldierCard(150, 90, Properties.Resources.Criota_A);
        readonly SoldierCard Criota_B = new SoldierCard(200, 30, Properties.Resources.Criota_B);

        /*SoldierCard Ekota_A = new SoldierCard(100,20);
        SoldierCard Ekota_B = new SoldierCard(150, 50);
        SoldierCard Finlonie_A = new SoldierCard(200,30);
        SoldierCard Finlonie_B = new SoldierCard(200, 100);
        SoldierCard Fitalie_A = new SoldierCard(150, 50);
        SoldierCard Fitalie_B = new SoldierCard(150, 70);
        SoldierCard Garulmonie_A = new SoldierCard(300, 10);
        SoldierCard Garulmonie_B = new SoldierCard(150, 75);
        SoldierCard Hongoru_A = new SoldierCard(150, 60);
        SoldierCard Hongoru_B = new SoldierCard(200, 0);
        SoldierCard Huanvana_A
        SoldierCard Huanvana_B
        SoldierCard Kaenia_A = new SoldierCard(100, 40);
        SoldierCard Kaenia_B = new SoldierCard(180, 60);
        SoldierCard Kalontia_A
        SoldierCard Kalontia_B
        SoldierCard Khenaga_A = new SoldierCard(150, 40);
        SoldierCard Khenaga_B = new SoldierCard(150, 75);
        SoldierCard Mageria_A = new SoldierCard(100, 50);
        SoldierCard Mageria_B = new SoldierCard(150,50);
        SoldierCard Maréquie_A = new SoldierCard(150, 50);
        SoldierCard Maréquie_B = new SoldierCard(140, 40);
        SoldierCard Mulretonie_A = new SoldierCard();
        SoldierCard Mulretonie_B = new SoldierCard();
        SoldierCard Neolantis_A = new SoldierCard();
        SoldierCard Neolantis_B = new SoldierCard();
        SoldierCard Nitralvie_A = new SoldierCard();
        SoldierCard Nitralvie_B = new SoldierCard();
        SoldierCard Onriance_A = new SoldierCard();
        SoldierCard Onriance_B = new SoldierCard();
        SoldierCard Qaland_A = new SoldierCard();
        SoldierCard Qaland_B = new SoldierCard();
        SoldierCard Qetu_A
        SoldierCard Qetu_B
        SoldierCard Slovanoya_A = new SoldierCard();
        SoldierCard Slovanoya_B = new SoldierCard();
        SoldierCard Starvas_A = new SoldierCard();
        SoldierCard Starvas_B = new SoldierCard();
        SoldierCard Tekay_A = new SoldierCard();
        SoldierCard Tekay_B = new SoldierCard();
        SoldierCard TheLeaf_A = new SoldierCard();
        SoldierCard TheLeaf_B = new SoldierCard();
        SoldierCard Traicere_A = new SoldierCard();
        SoldierCard Traicere_B = new SoldierCard();
        SoldierCard Tristan_A = new SoldierCard();
        SoldierCard Tristan_B = new SoldierCard();
        SoldierCard Tujar_A = new SoldierCard();
        SoldierCard Tujar_B = new SoldierCard();
        SoldierCard Yedesna_A = new SoldierCard();
        SoldierCard Yedesna_B = new SoldierCard();*/
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
