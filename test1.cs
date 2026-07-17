using Feladatok;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    internal class test1
    {
        [Test]
        public void RejtjelezesPelda()
        {
            string eredmeny = _1_feladat.Rejtjelezes("helloworld", "abcdefgijkl");
            Assert.That(eredmeny, Is.EqualTo("hfnosauzun"));
        }
        [Test] 
        public void VisszafejtesPelda()
        {
            string eredmeny= _1_feladat.Visszafejt("hfnosauzun", "abcdefgijkl");
            Assert.That(eredmeny, Is.EqualTo("helloworld"));
        }
        [TestCase("helloworld", "abcdefgijkl")]
        [TestCase("ab cd", "zzzzz")]
        [TestCase("a", "a")]
        [TestCase("   ", "aaa")]
        [TestCase("", "abc")]
        public void Odavisszatest(string uzenet, string kulcs)
        {
            string titkos = _1_feladat.Rejtjelezes(uzenet, kulcs);
            string vissza = _1_feladat.Visszafejt(titkos, kulcs);
            Assert.That(vissza, Is.EqualTo(uzenet));
        }
        [TestCase("helloworld", "abc")]
        [TestCase("ab", "a")]
        public void RovidebbKulcs(string uzenet, string kulcs)
        {
            Assert.That(() => _1_feladat.Rejtjelezes(uzenet, kulcs),
                        Throws.TypeOf<ArgumentException>());
        }

    }
}
