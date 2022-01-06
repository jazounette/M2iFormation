// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

using TpLePendu.Interfaces;

namespace TpLePendu.Classes;

internal class LePendu
{
    IGénérator motGenere;
    private string motATrouver;
    private int nbreEssai;
    private string masque;

    public LePendu(IGénérator g)
    {
        motGenere = g;
        MotATrouver = g.Generer();
        GenerateurMasque();
        nbreEssai = 10;
    }
    public LePendu(IGénérator g, int nbreEssai)
    {
        motGenere = g;
        MotATrouver = g.Generer();
        GenerateurMasque();
        NbreEssai = nbreEssai;
    }


    public string MotATrouver { get => motATrouver; set => motATrouver=value; }
    public int NbreEssai { get => nbreEssai; set => nbreEssai=value; }
    public string Masque { get => masque; set => masque=value; }

    public bool TestChar(char c)
    {
        // Console.WriteLine(c);
        bool found= false;
        string masqueTmp="";
        for (int i = 0; i < MotATrouver.Length; i++)
        {
            //Console.WriteLine(MotATrouver[i]);
            if (MotATrouver[i] == c)
            {
                found = true;
                masqueTmp += c;
            }
            else
            {
                masqueTmp += masque[i];
            }
            //Console.WriteLine(masqueTmp);
        }
        masque = masqueTmp;
        //Console.WriteLine(masque);

        if (found == false)
        {
            NbreEssai--;
        }
        return found;
    }

    public bool TestWin()
    {
        if (MotATrouver == Masque && NbreEssai >0)
            return true;            
        else
            return false;            
    }

    public void GenerateurMasque()
    {
        masque = "";

        //Console.WriteLine(motATrouver);

        for (int i = 0; i < motATrouver.Length; i++)
        {
            masque += "*";
        }

        //Console.WriteLine(masque);

    }
}
