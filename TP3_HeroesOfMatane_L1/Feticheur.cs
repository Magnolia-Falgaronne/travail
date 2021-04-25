
namespace TP2_HeroesOfMatane
{
    public class Feticheur : Personnage
    {
        private const byte MAT = 7;
        private const byte ARM = 14;
        private const byte DEF = 14;
        private const byte POW = 12;

        private const string CRI_VICTOIRE = "feticheurwin.wav";
        private const string CRI_DEFAITE = "feticheurMort.wav";
        private const string CRI_DEBUT = "feticheurintro.wav";
        private const string CRI_CRITIQUE = "critiquefeticheur.wav";

        public override string Nom { get => base.Nom + " le féticheur"; }


        public Feticheur(string nom) : base(nom)
        {
            this.Arm = ARM;
            this.Pow = POW;
            this.Def = DEF;
            this.Mat = MAT;

            this.criCritique = CRI_CRITIQUE;
            this.criDebut = CRI_DEBUT;
            this.criDefaite = CRI_DEFAITE;
            this.criVictoire = CRI_VICTOIRE;

            DebutCombat();
        }

        public override void UtiliserPouvoir()
        {
            this.PouvoirUtilise = true;

            this.Ennemi.DiminuerArm();

            this.CoolDownPouvoir = 3;
        }

        public override void FinPouvoir()
        {
            this.Ennemi.RetablirArm();
        }
        public override void RetablirMat()
        {
            this.Mat = MAT;
        }

        public override void RetablirArm()
        {
            this.Arm = ARM;
        }

        public override void RetablirDef()
        {
            this.Def = DEF;
        }  
    }
}
