using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Vezba2
{
    class Program
    {
        public static int TipArtikla { get; private set; }

        static void Main(string[] args)
        {
            Secer secer = new Secer();
            Cokolada cokolada = new Cokolada();
            Kafa kafa = new Kafa();

            UnosPodataka(secer);
            UnosPodataka(cokolada);
            UnosPodataka(kafa);

            Console.WriteLine("Podatci o p:\n");

            IspisPodataka(secer);
            IspisPodataka(cokolada);
            IspisPodataka(kafa);

            decimal zarada = secer.ProdataKolicina * secer.ProdajnaCena
                + kafa.ProdataKolicina * kafa.ProdajnaCena
                + cokolada.ProdataKolicina * cokolada.ProdajnaCena;

            Console.WriteLine("Ukupna Zarada je:{0}", zarada);
            Console.ReadKey();
        }
        public static void UnosPodataka(Artikal a)
        {
            Console.WriteLine("Unesite podatke o proizvodu:\n");
            Console.WriteLine("Unesite nabavnu cenu za {0}: \n", a.TipArtikla);
            a.NabavnaCena = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Unesite nabavnu kolicinu za {0}: \n", a.TipArtikla);
            a.ProdataKolicina = (int)decimal.Parse(Console.ReadLine());
            Console.WriteLine("Unesite nabavljaca za {0}: \n", a.TipArtikla);
            a.NazivProizvodjaca = Console.ReadLine();

            a.ProdajnaCena = a.IzracunajProdajnuCenu(a.ProdataKolicina);
        }
        public static void IspisPodataka(Artikal a)
        {
            Console.WriteLine("Artikal: {0}\ncena: {1}\nkolicina: {2}\nprovajder: {3}\nprodato: {4}\ncena: {5}\nmagacin: {6}",
                +TipArtikla, a.NabavnaCena, a.NabavljenaKolicina, a.NazivProizvodjaca, a.ProdataKolicina, a.ProdajnaCena, (a.NabavljenaKolicina - a.ProdataKolicina));
        }
    }
    public abstract class Artikal
    {
        public decimal NabavnaCena { get; set; }
        public int NabavljenaKolicina { get; set; }
        public string NazivProizvodjaca { get; set; }
        public int ProdataKolicina { get; set; }
        public decimal ProdajnaCena { get; set; }
        public string TipArtikla { get; set; }


        public virtual decimal IzracunajProdajnuCenu(int ProdataKolicina)
        {
            return 0m;
        }
    }

        public class Secer : Artikal
        {
            public Secer()
            {
                TipArtikla = "Sece";
            }
            public override decimal IzracunajProdajnuCenu(int ProdataKolicina)
            {
                return ProdataKolicina < 100 ? NabavnaCena * 1.25m : NabavnaCena * 1.2m;
            }
        }
        public class Kafa : Artikal
        {
            public Kafa()
            {
                TipArtikla = "Kafa";
            }
            public override decimal IzracunajProdajnuCenu(int ProdataKolicina)
            {
                return ProdataKolicina < 500 ? NabavnaCena * 1.2m : NabavnaCena * 1.15m;
            }
        }
        public class Cokolada : Artikal
        {
            public Cokolada()
            {
                TipArtikla = "Cokolada";
            }
            public override decimal IzracunajProdajnuCenu(int ProdataKolicina)
            {
                return ProdataKolicina < 200 ? NabavnaCena * 1.2m : NabavnaCena * 1.17m;
            }
        }
    
}