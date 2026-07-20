using Feladatok;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    internal class test2
    {
        [OneTimeSetUp]
        public void Betoltes()
        {
            _2_feladat.Beolvasas("words.txt");
        }
        [Test]
        public void LehetsegesKulcsokTeszt()
        {
            string kulcs = "thisisasamplerandomkeyforencoding";
            string c1 = _1_feladat.Rejtjelezes("curiosity killed the cat", kulcs);
            string c2 = _1_feladat.Rejtjelezes("early bird catches the worm", kulcs);
            var eredmenyek = _2_feladat.Lehetsegeskulcsok(c1, c2);
            Assert.That(eredmenyek, Does.Contain(kulcs.Substring(0, Math.Min(c1.Length, c2.Length))));
        }
        [Test]
        public void ervenyes_szavak()
        {
            string kulcs = "thisisasamplerandomkeyforencoding";
            string c1 = _1_feladat.Rejtjelezes("curiosity killed the cat", kulcs);
            string c2 = _1_feladat.Rejtjelezes("early bird catches the worm", kulcs);
            var eredmenyek = _2_feladat.Lehetsegeskulcsok(c1, c2);
            foreach (var k in eredmenyek)
            {
                string m1 = _1_feladat.Visszafejt(c1.Substring(0, k.Length), k);
                string m2 = _1_feladat.Visszafejt(c2.Substring(0, k.Length), k);

                Assert.That(m1.Split(' ').Where(sz => sz.Length > 0), Is.All.Matches<string>(sz => true));
                Assert.That(m1.Split(' '), Is.All.Not.Null);
            }
        }
        [Test]
        public void nincsmegold()
        {
            var eredmenyek = _2_feladat.Lehetsegeskulcsok("qxzjv", "wkpfm");
            Assert.That(eredmenyek, Is.Empty);
        }
    }
}
