
namespace TP2_HeroesOfMatane
{
    public class Barbare : Personnage
    {
        private const byte MAT = 9;
        private const byte ARM = 16;
        private const byte DEF = 12;
        private const byte POW = 12;

        private const string CRI_VICTOIRE = "barbarewin.wav";
        private const string CRI_DEFAITE = "barbareMort.wav";
        private const string CRI_DEBUT = "barbareintro.wav";
        private const string CRI_CRITIQUE = "critiqueBarbare.wav";

        // base. est important ici, sinon on crée une boucle infinie
        public override string Nom { get => base.Nom + " le barbare"; }

        public Barbare(string nom) : base(nom)
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

        public override void UtiliserPouvoir()
        {
            this.PouvoirUtilise = true;

            this.Ennemi.DiminuerMat();

            this.CoolDownPouvoir = 3;
        }

        public override void FinPouvoir()
        {
            this.Ennemi.RetablirMat();   
        } 
    }
}
