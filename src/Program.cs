namespace Collections;

class Program
{
    public record Pays(string Nom, decimal Superficie);
    public record Ville(string Nom, int Population, Pays Pays, double Latitude, double Longitude)
    {
        public double CalculerDistance(Ville autre)
        {
            var sindth = Math.Sin((autre.Latitude - Latitude) * Math.PI / 360);
            var sindld = Math.Sin((autre.Longitude - Longitude) * Math.PI / 360);
            var a = sindth * sindth + sindld * sindld *
                    Math.Cos(Latitude * Math.PI / 180.0) * Math.Cos(autre.Latitude * Math.PI / 180.0);
            var km = 6371 * 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            Thread.Sleep((int)km);
            return km;
        }

        public static double CalculerDistance(Ville a, Ville b, Ville c)
        {
            var km = a.CalculerDistance(b);

            km += b.CalculerDistance(c);
            Console.WriteLine($"{a.Nom} > {b.Nom} > {c.Nom} : {km:.00}km");
            return km;
        }
    }
    static void Main(string[] args)
    {
        List<Pays> listePays = new() {
            new Pays("Albanie"           , 28748m),
            new Pays("Allemagne"         , 357578m),
            new Pays("Andorre"           , 468m),
            new Pays("Arménie"           , 29743m),
            new Pays("Autriche"          , 83870m),
            new Pays("Belgique"          , 30528m),
            new Pays("Biélorussie"       , 207600m),
            new Pays("Bosnie-Herzégovine", 51129m),
            new Pays("Bulgarie"          , 110910m),
            new Pays("Chypre"            , 9251m),
            new Pays("Croatie"           , 56542m),
            new Pays("Danemark"          , 43094m),
            new Pays("Espagne"           , 518000m),
            new Pays("Estonie"           , 45226m),
            new Pays("Finlande"          , 338145m),
            new Pays("France"            , 643801m),
            new Pays("Géorgie"           , 69700m),
            new Pays("Grèce"             , 131940m),
            new Pays("Hongrie"           , 93030m),
            new Pays("Irlande"           , 70280m),
            new Pays("Islande"           , 103000m),
            new Pays("Italie"            , 301234m),
            new Pays("Kosovo"            , 10887m),
            new Pays("Lettonie"          , 64589m),
            new Pays("Liechtenstein"     , 160m),
            new Pays("Lituanie"          , 65200m),
            new Pays("Luxembourg"        , 2586m),
            new Pays("Macédoine du Nord" , 25333m),
            new Pays("Malte"             , 316m),
            new Pays("Moldavie"          , 33843m),
            new Pays("Monaco"            , 2m),
            new Pays("Monténégro"        , 13800m),
            new Pays("Norvège"           , 324220m),
            new Pays("Pays-Bas"          , 41526m),
            new Pays("Pologne"           , 312685m),
            new Pays("Portugal"          , 92042m),
            new Pays("Roumanie"          , 237500m),
            new Pays("Royaume-Uni"       , 244820m),
            new Pays("Russie"            , 17075200m),
            new Pays("Saint-Marin"       , 61m),
            new Pays("Serbie"            , 77589m),
            new Pays("Slovaquie"         , 48845m),
            new Pays("Slovénie"          , 20273m),
            new Pays("Suède"             , 450295m),
            new Pays("Suisse"            , 41290m),
            new Pays("Tchéquie"          , 78866m),
            new Pays("Turquie"           , 783562m),
            new Pays("Ukraine"           , 603628m),
            new Pays("Vatican"           , 0.4m)
        };
        var pays = listePays.ToDictionary(p => p.Nom);
        var villes = new List<Ville> {
            new Ville("Athènes"          ,  3495000, pays["Grèce"]      , 37.9842, 23.7281),
            new Ville("Barcelone"        ,  4849691, pays["Espagne"]    , 41.3825,  2.1769),
            new Ville("Berlin"           ,  4666175, pays["Allemagne"]  , 52.5200, 13.4050),
            new Ville("Birmingham"       ,  2570000, pays["Royaume-Uni"], 52.4800, -1.9025),
            new Ville("Bruxelles"        ,  2050000, pays["Belgique"]   , 50.8467,  4.3525),
            new Ville("Kiev"             ,  2957000, pays["Ukraine"]    , 50.4500, 30.5233),
            new Ville("Lisbonne"         ,  2705000, pays["Portugal"]   , 38.7253, -9.1500),
            new Ville("Londres"          ,  9046000, pays["Royaume-Uni"], 51.5072, -0.1275),
            new Ville("Lyon"             ,  2259411, pays["France"]     , 45.7600,  4.8400),
            new Ville("Minsk"            ,  2005000, pays["Biélorussie"], 53.9000, 27.5667),
            new Ville("Madrid"           ,  6497000, pays["Espagne"]    , 40.4169, -3.7033),
            new Ville("Manchester"       ,  2690000, pays["Royaume-Uni"], 53.4794, -2.2453),
            new Ville("Milan"            ,  5270000, pays["Italie"]     , 45.4669,  9.1900),
            new Ville("Moscou"           , 12410000, pays["Russie"]     , 55.7558, 37.6178),
            new Ville("Naples"           ,  2198000, pays["Italie"]     , 40.8333, 14.2500),
            new Ville("Paris"            , 10816000, pays["France"]     , 48.8567,  2.3522),
            new Ville("Rome"             ,  3995000, pays["Italie"]     , 41.8931, 12.4828),
            new Ville("Saint Pétersbourg",  5383000, pays["Russie"]     , 59.9500, 30.3167),
            new Ville("Vienne"           ,  1901000, pays["Autriche"]   , 48.2083, 16.3725)
        };

        Console.WriteLine("Calcul : ");
        double[] dists = {
            Ville.CalculerDistance(villes[2], villes[0], villes[4]),
            Ville.CalculerDistance(villes[0], villes[4], villes[2]),
            Ville.CalculerDistance(villes[0], villes[2], villes[4])
        };
        var min = dists.Min();

        Console.WriteLine(min);
    }
}
