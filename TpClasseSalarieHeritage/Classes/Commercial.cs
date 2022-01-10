// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace TpClasseSalarieHeritage.Classes;

    internal class Commercial : Salarie
    {
        double chiffreAffaire;
        double commission;

        public Commercial():base()
        {

        }
        public Commercial(string matricule, string categorie, string service, string nom, double salaire,double chiffreAffaire, double commission):base(matricule, categorie, service,nom,salaire)
        {
            this.chiffreAffaire = chiffreAffaire;
            this.commission = commission;
        }

        public double ChiffreAffaire { get => chiffreAffaire; set => chiffreAffaire = value; }
        public double Commission { get => commission; set => commission = value; }

        public override void CalculerSalaire()
        {
            base.CalculerSalaire();
            double salaireReel = Salaire + (ChiffreAffaire * Commission / 100);
            Console.WriteLine($"Le salaire avec commission de {Nom} est de {salaireReel} euros");
        }

        public void AfficherCommercial()
        {
            Console.WriteLine($"Je suis un super commercial");
        }

        public override string ToString()
        {
            return $"Je suis commercial";
        }
    }
