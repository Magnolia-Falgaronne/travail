
namespace TP2_HeroesOfMatane
{
    public class Paladin : Personnage
    {
        private const byte MAT = 8;
        private const byte ARM = 12;
        private const byte DEF = 16;
        private const byte POW = 12;

        private const string CRI_VICTOIRE = "paladinwin.wav";
        private const string CRI_DEFAITE = "paladinmort.wav";
        private const string CRI_DEBUT = "paladinintro.wav";
        private const string CRI_CRITIQUE = "critiquepaladin.wav";

        public override string Nom { get => base.Nom + " le paladin"; }


        public Paladin(string nom) : base(nom)
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

            this.AugmenterMat();

            this.CoolDownPouvoir = 3;
        }

        public override void FinPouvoir()
        {
            this.RetablirMat();
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
