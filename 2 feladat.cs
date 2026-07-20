using System;
using System.Collections.Generic;
using System.Text;

namespace Feladatok
{
    public class _2_feladat
    {
        private static HashSet<string> szavak;
        private static HashSet<string> szotoredek;
        private static int karakter(char c)
        {
            return c == ' ' ? 26 : c - 'a';
        }
        private static char kod(int n)
        {
            return n == 26 ? ' ' : (char)(n + 'a');
        }
        public static void Beolvasas(string fajlNev)
        {
            string[] sorok = File.ReadAllLines(fajlNev);
            szavak = new HashSet<string>();
            foreach (string s in sorok)
            {
                string szo = s.Trim().ToLower();
                if (szo.Length > 0)
                {
                    szavak.Add(szo);
                }
            }
            szotoredek = new HashSet<string>();
            foreach (string s in sorok)
            {
                for (int i = 1; i <= s.Length; i++)
                {
                    string reszlet = s.Substring(0, i);
                    szotoredek.Add(reszlet);
                }
            }
        }
        public static List<string> Lehetsegeskulcsok(string rejtjelezett1, string rejtjelezett2)
        {
            if (szavak is null || szotoredek is null) throw new ArgumentException("Előbb hívd meg a Beolvasas(fajlNev) függvényt!");
            int L = Math.Min(rejtjelezett1.Length, rejtjelezett2.Length);
            int[] diff = new int[L];
            for(int i = 0; i < L; i++)
            {
                diff[i] = ((karakter(rejtjelezett1[i]) - karakter(rejtjelezett2[i])) % 27 + 27) % 27;
            }
            var eredmenyek = new List<string>();
            var kulcs = new char[L];
            Backtrack(0, L, rejtjelezett1, rejtjelezett2, diff, "", "", kulcs, eredmenyek);
            return eredmenyek.Distinct().ToList();
        }
        private static void Backtrack(int pos, int L, string rejtjelezett1, string rejtjelezett2, int[] diff,
        string szo1Eddig, string szo2Eddig, char[] kulcs, List<string> eredmenyek)
        {
            if (pos == L)
            {
                bool m1Rendben = szo1Eddig == "" || szavak.Contains(szo1Eddig);
                bool m2Rendben = szo2Eddig == "" || szavak.Contains(szo2Eddig);
                bool megfelel = true;
                if (rejtjelezett1.Length == L) megfelel &= m1Rendben;
                if (rejtjelezett2.Length == L) megfelel &= m2Rendben;
                if (megfelel) eredmenyek.Add(new string(kulcs));
                return;
            }
            for (int kod1 = 0; kod1 <= 26; kod1++)
            {
                char ch1 = kod(kod1);
                string ujszo1;
                if (ch1 == ' ')
                {
                    if (szo1Eddig == "" || !szavak.Contains(szo1Eddig)) continue;
                    ujszo1 = "";
                }
                else
                {
                    ujszo1 = szo1Eddig + ch1;
                    if (!szotoredek.Contains(ujszo1)) continue;
                }
                int kod2 = ((kod1 - diff[pos]) % 27 + 27) % 27;
                char ch2 = kod(kod2);
                string ujszo2;
                if (ch2 == ' ')
                {
                    if (szo2Eddig == "" || !szavak.Contains(szo2Eddig)) continue;
                    ujszo2 = "";
                }
                else 
                {
                    ujszo2 = szo2Eddig + ch2;
                    if(!szotoredek.Contains(ujszo2)) continue;
                }
                kulcs[pos] = kod(((karakter(rejtjelezett1[pos]) - kod1) % 27 + 27) % 27);
                Backtrack(pos + 1, L, rejtjelezett1, rejtjelezett2, diff, ujszo1, ujszo2, kulcs, eredmenyek);
            }
        }
    }
}
