
namespace TP2_HeroesOfMatane
{
    public class Sorcier : Personnage
    {
        private const byte MAT = 6;
        private const byte ARM = 13;
        private const byte DEF = 15;
        private const byte POW = 12;

        private const string CRI_VICTOIRE = "sorcierwin.wav";
        private const string CRI_DEFAITE = "sorciermort.wav";
        private const string CRI_DEBUT = "sorcierintro.wav";
        private const string CRI_CRITIQUE = "sorciercritique.wav";

        public override string Nom { get => base.Nom + " le sorcier"; }


        public Sorcier(string nom) : base(nom)
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

            this.Ennemi.DiminuerDef();

            this.CoolDownPouvoir = 3;
        }

        public override void FinPouvoir()
        {
            this.Ennemi.RetablirDef();
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
