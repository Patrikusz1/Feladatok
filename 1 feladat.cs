using System;
using System.Collections.Generic;
using System.Text;

namespace Feladatok
{
    public class _1_feladat
    {
        public static int karakter(char c)
        {
            return c == ' ' ? 26 : c - 'a';
        }
        public static char kod (int n)
        {
            return n == 26 ? ' ' : (char)(n + 'a'); 
        }
        public static string Rejtjelezes (string uzenet, string kulcs)
        {
            if (kulcs.Length < uzenet.Length) throw new ArgumentException("A kulcs rövidebb mint az üzenet");
            StringBuilder eredmeny = new StringBuilder();
            for (int i = 0; i < uzenet.Length; i++)
            {
                int uzentkod = karakter(uzenet[i]);
                int kulcskod = karakter(kulcs[i]);
                int titkoskod = (uzentkod + kulcskod) % 27;
                eredmeny.Append(kod(titkoskod));
            }
            return eredmeny.ToString();
        }
        public static string Visszafejt(string rejtetuzenet, string kulcs)
        {
            if (kulcs.Length < rejtetuzenet.Length) throw new ArgumentException("A kulcs rövidebb mint az üzenet");
            StringBuilder eredmeny = new StringBuilder();
            for(int i = 0;i < rejtetuzenet.Length;i++)
            {
                int rejtetuzenetkod = karakter(rejtetuzenet[i]);
                int kulcskod = karakter(kulcs[i]);
                int eredetikod = ((rejtetuzenetkod -kulcskod) % 27 + 27) % 27;
                eredmeny.Append(kod(eredetikod));
            }
            return eredmeny.ToString() ;
        }
    }
}
