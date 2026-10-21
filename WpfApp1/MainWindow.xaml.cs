using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object sender, RoutedEventArgs e)
    {
        bool jeVekPlatny = int.TryParse(txtInput2.Text, out int novyVek);
        bool jeCenaPlatna = double.TryParse(txtInput3.Text, out double vyslednaCena);

        if (jeVekPlatny && jeCenaPlatna)
        {
            string nacteneJmeno = txtInput1.Text;
            string nazevfilmu = txtInput4.Text;

            Zakaznik novyZakaznik = new Zakaznik(novyVek, nacteneJmeno);

            Rezervace rezervace = new Rezervace(novyZakaznik, new Film(nazevfilmu, (int)vyslednaCena));
            vyslednaCena = rezervace.Vypocitej();

            txtBlockVysledek.Text = $"Zákazník: {novyZakaznik.jmeno}, {novyZakaznik.vek} let, jde na film {nazevfilmu} a bude platit: {vyslednaCena} Kč";
        }
        else
        {
            txtBlockVysledek.Text = "Zadejte prosím platná čísla pro věk a cenu.";
        }
    }
}

public class Zakaznik
{
    public int vek { get; set; }
    public string jmeno { get; set; }

    public Zakaznik(int vek, string jmeno)
    {
        this.vek = vek;
        this.jmeno = jmeno;
    }
}

public class Film
{
    public string nazev { get; set; }
    public int cena { get; set; }

    public Film(string nazev, int cena)
    {
        this.nazev = nazev;
        this.cena = cena;
    }
}

public class Rezervace
{
    public Zakaznik zakaznik { get; set; }
    public Film film { get; set; }

    public Rezervace(Zakaznik zakaznik, Film film)
    {

        this.zakaznik = zakaznik;
        this.film = film;

    }

    public int Vypocitej()
    {
        if (zakaznik.vek <= 15)
        {
            film.cena = (int)(film.cena * 0.5);
        }
        return film.cena;

    }
}