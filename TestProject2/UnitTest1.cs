using WpfApp1;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Zakaznik zakaznik = new Zakaznik(18, "petr");
            Film film = new Film("Idk", 400);
            Rezervace rezervace = new Rezervace(zakaznik, film);
            double vysledek = rezervace.Vypocitej();

            Assert.Equal(400, vysledek);
        }
    }
}
