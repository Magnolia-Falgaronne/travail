using Exercice4_De;
using NetCoreAudio;
using NetCoreAudio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace TP2_HeroesOfMatane
{
    public abstract class Personnage
    {
        public enum TypeAttaque
        {
            Defaut = 0,
            Normale = 1,
            Speciale = 2,
        }

        public enum TypePersonnage
        {
            Defaut = 0,
            Barbare = 1,
            Paladin = 2,
            Sorcier = 3,
            Feticheur = 4,
        }

        public Personnage Ennemi { get; set; }

        public virtual string Nom { get; protected set; }
        
        private const byte PTS_DE_VIES = 20;   
        public byte PtsVies { get; private set; }

        protected byte variable;

        public byte Mat { get; protected set; }
        public byte Def { get; protected set; }
        public byte Pow { get; protected set; }
        public byte Arm { get; protected set; }

        protected string criVictoire;
        protected string criDefaite;
        protected string criCritique;
        protected string criDebut;

        private readonly List<De> desAtt = new List<De>();
        private readonly List<De> desDom = new List<De>();

        public bool PouvoirUtilise { get; protected set; }
        public byte CoolDownPouvoir { get; protected set; }


        public Personnage(string nom)
        {
            this.Nom = nom;
            this.PtsVies = PTS_DE_VIES;

            for (int i = 0; i < 2; i++)
                desAtt.Add(new De());

            for (int i = 0; i < 3; i++)
                desDom.Add(new De());
        }

        public void DiminuerCoolDownPouvoir()
        {
            if (CoolDownPouvoir > 0)
            {
                CoolDownPouvoir--;

                if (CoolDownPouvoir == 0)
                    FinPouvoir();
            }
        }

        public void DiminuerMat()
        {
            this.Mat--;
        }

        public void DiminuerDef()
        {
            this.Def--;
        }

        public void DiminuerArm()
        {
            this.Arm--;
        }

        public void AugmenterMat()
        {
            this.Mat++;
        }

        public int GenererDommage()
        {
            int dommage = 0;

            int nbDes = 2;

            if (AttaqueEstCritique())
            {
                Critique();
                nbDes = 3;
            }

            for (int i = 0; i < nbDes; i++)
            {
                dommage += desDom[i].brasser();
            }

            dommage += Pow;

            return dommage;
        }

        public int Attaquer()
        {
            int attaque = 0;

            foreach (De de in desAtt)
            {
                attaque += de.brasser();
            }

            attaque += Mat;

            return attaque;
        }

        public bool AttaqueEstCritique()
        {
            return desAtt[0].getValeur() == desAtt[1].getValeur();
        }

        public void Souffrir(int dommage)
        {
            if (dommage > Arm)
                EnleverPointsVies(dommage - Arm);
        }

        private void EnleverPointsVies(int ptsViesPerdus)
        {
            if (PtsVies >= ptsViesPerdus)
                PtsVies -= (byte)ptsViesPerdus;
            else
                PtsVies = 0;

            if (PtsVies == 0)
                Mourir();
        }

        public void Gagner()
        {
            JouerSon(criVictoire);
        }

        protected void Mourir()
        {
            JouerSon(criDefaite);
        }

        protected void Critique()
        {
            JouerSon(criCritique);
        }

        protected void DebutCombat()
        {
            JouerSon(criDebut);
        }

        public string Etat
        {
            get => "Mat: " + Mat + "\nArm: " + Arm + "\nDef: " + Def + "\nVies: " + PtsVies;
        }

        private void JouerSon(string fichier)
        {
            IPlayer player = new Player();
            player.Play($@"{Directory.GetCurrentDirectory()}\sons\{fichier}").ConfigureAwait(false);
        }

        public abstract void RetablirDef();
        public abstract void RetablirArm();
        public abstract void RetablirMat();

        public abstract void UtiliserPouvoir();
        public abstract void FinPouvoir();
    }
}
