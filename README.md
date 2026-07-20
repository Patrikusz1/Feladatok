# Feladatok
1. feladat
A megoldás két fő függvényből áll:
●	Rejtjelezes(uzenet, kulcs) – karakterenként összeadja az üzenet és a kulcs kódjait, majd mod 27 műveletet alkalmaz.
●	Visszafejt(rejtetuzenet, kulcs) – karakterenként kivonja a kulcs kódját a rejtjelezett kódból, majd mod 27 műveletet alkalmaz (a negatív eredmények elkerülése végett +27-tel korrigálva a kivonás után).
2.feladat
A megoldás egy visszalépéses (backtracking) keresést valósít meg, amely karakterenként, a két üzenetet egyszerre építve próbálja ki a lehetséges betűket:
●	Egy adott pozícióban végigpróbálja mind a 27 lehetséges karaktert az első üzenetre.
●	Minden próbált karakterhez a két rejtjelezett szöveg különbsége alapján kiszámolja, milyen karakter adódna a második üzeneten.
●	Egy szótár (a mellékelt szólista) segítségével ellenőrzi, hogy mindkét oldalon érvényes szó-prefixum (vagy szóhatár esetén teljes, létező szó) épül-e fel.
●	Ha mindkét oldal érvényes, a keresés a következő pozícióra lép; ha egyik oldal sem érvényes egyetlen karakterre sem, a keresés visszalép, és más korábbi döntést próbál.
