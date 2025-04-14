using System.Collections.Generic;

namespace Pancakes
{
    public class Pancake
    {
        public static int BasePrice = 100;
        public static Dictionary<string, double> DoughTypes = new Dictionary<string, double>
        {
            ["normál"] = 1,
            ["nem normál"] = 1.2
        };
        public static Dictionary<string, double> FillingTypes = new Dictionary<string, double>
        {
            ["kakaós"] = 1,
            ["túrós"] = 1,
            ["lekváros"] = 1
        };
        public int N { get; set; }
        public string Dough { get; set; }
        public string Filling { get; set; }
        public int Price => (int)(BasePrice * N * FillingTypes[Filling] * DoughTypes[Dough]);
        public Pancake(int n, string dough, string filling)
        {
            N = n;
            Dough = dough;
            Filling = filling;
        }
        public override string ToString() => $"{N} db {Dough} tésztás {Filling} palacsinta\t{Price} Ft";
        public string ToCSV() => $"{N},{Dough},{Filling},{Price}";
    }
}
