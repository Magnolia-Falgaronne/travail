using System;

namespace TP2_HeroesOfMatane
{
    public class HeroesOfMatane
    {
        private Personnage joueur1, joueur2;
        private Personnage joueurActif;


        public HeroesOfMatane()
        {
            GererChoixHeros();
            DemarrerPartie();
        }

        private void DemarrerPartie()
        {
            joueur1.Ennemi = joueur2;
            joueur2.Ennemi = joueur1;

            joueurActif = joueur1;

            while (!EstPartieTerminee())
            {
                GererTourJeu();
            }

            joueurActif.Ennemi.Gagner();
        }

        private void GererTourJeu()
        {
            Console.Clear();
            AfficherJoueurActif();

            Personnage.TypeAttaque choixAtt = LireChoixAtt();

            switch (choixAtt)
            {
                case Personnage.TypeAttaque.Normale:
                    GererAttaqueJoueurActif();
                    break;
                case Personnage.TypeAttaque.Speciale:
                    GererAttaqueSpecialJoueurActif();
                    break;
            }

            AfficherEtatHeros();
            Console.ReadKey();

            joueurActif.DiminuerCoolDownPouvoir();

            ChangerJoueurActif();
        }

        private void AfficherJoueurActif()
        {
            Console.WriteLine("C'est le tour de " + joueurActif.Nom);
        }

        private void AfficherEtatHeros()
        {
            Console.WriteLine(joueur1.Nom);
            Console.WriteLine(joueur1.Etat);
            Console.WriteLine();
            Console.WriteLine(joueur2.Nom);
            Console.WriteLine(joueur2.Etat);
        }

        private void GererAttaqueJoueurActif()
        {
            int attaque = joueurActif.Attaquer();

            if (attaque >= joueurActif.Ennemi.Def)
            {
                int dommage = joueurActif.GenererDommage();

                Console.WriteLine("Attaque : " + attaque + "\nDef : " + joueurActif.Ennemi.Def + "\nDommage : " + dommage);

                joueurActif.Ennemi.Souffrir(dommage);
            }
            else
            {
                Console.WriteLine("Attaque manquée : " + attaque + "\nDef : " + joueurActif.Ennemi.Def);
            }
        }

        private void GererAttaqueSpecialJoueurActif()
        {
            Console.WriteLine("Méga Power activated!");

            joueurActif.UtiliserPouvoir();
        }

        private bool EstPartieTerminee()
        {
            return joueur1.PtsVies == 0 || joueur2.PtsVies == 0;
        }

        private Personnage.TypeAttaque LireChoixAtt()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("**** Choisissez votre attaque ****");
            Console.WriteLine();

            foreach (Personnage.TypeAttaque type in Enum.GetValues(typeof(Personnage.TypeAttaque)))
            {
                // Ne pas afficher defaut pour l'instant
                if (type == Personnage.TypeAttaque.Defaut)
                    continue;

                if (type != Personnage.TypeAttaque.Speciale || !joueurActif.PouvoirUtilise)
                    Console.WriteLine(type + "\t:" + (byte)type);
            }

            Console.Write("\nVotre choix : ");

            Personnage.TypeAttaque choix = (Personnage.TypeAttaque)Enum.Parse(typeof(Personnage.TypeAttaque), Console.ReadLine());

            return choix;
        }

        private void ChangerJoueurActif()
        {
            joueurActif = joueurActif.Ennemi;
        }

        private void GererChoixHeros()
        {
            for (int i = 1; i <= 2; i++)
            {
                string nomPerso = LireNomPerso();
                Personnage.TypePersonnage choixHero = LireChoixHeros();

                if (i == 1)
                    joueur1 = CreerPerso(choixHero, nomPerso);
                else
                    joueur2 = CreerPerso(choixHero, nomPerso);
            }
        }

        private Personnage CreerPerso(Personnage.TypePersonnage choixPerso, string nomPerso)
        {
            Personnage perso = null;

            switch (choixPerso)
            {
                case Personnage.TypePersonnage.Barbare:
                    perso = new Barbare(nomPerso);
                    break;
                case Personnage.TypePersonnage.Paladin:
                    perso = new Paladin(nomPerso);
                    break;
                case Personnage.TypePersonnage.Sorcier:
                    perso = new Sorcier(nomPerso);
                    break;
                case Personnage.TypePersonnage.Feticheur:
                    perso = new Feticheur(nomPerso);
                    break;
            }

            return perso;
        }

        private string LireNomPerso()
        {
            Console.Clear();

            Console.Write("Quel sera le nom de votre personnage : ");

            return Console.ReadLine();
        }

        private Personnage.TypePersonnage LireChoixHeros()
        {
            Console.Clear();

            Console.WriteLine("********************************");
            Console.WriteLine("**** Choisissez votre Héros ****");
            Console.WriteLine();
            foreach (Personnage.TypePersonnage type in Enum.GetValues(typeof(Personnage.TypePersonnage)))
            {
                // Ne pas afficher defaut pour l'instant
                if (type == Personnage.TypePersonnage.Defaut)
                    continue;

                Console.WriteLine(type + "\t:" + (byte)type);
            }

            Console.Write("\nVotre choix:");

            Personnage.TypePersonnage choix = (Personnage.TypePersonnage)Enum.Parse(typeof(Personnage.TypePersonnage), Console.ReadLine());

            return choix;
        }
    }
}