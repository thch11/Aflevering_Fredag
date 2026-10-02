Webshop w = new Webshop();

Console.WriteLine(w.NyKunde(12345678, "Jens Jensen"));
w.NyKunde(23456789, "Christian Christensen");
w.NyKunde(34567891, "Lars Larsen");
w.NyOrdre(12345678, 1);
w.NyOrdre(12345678, 2);
w.NyOrdre(12345678, 3);

Ordre o = w.NyOrdre(12345678, 4); // JEG SYNES NU HELT ÆRLIGT DET HAVDE GIVET MEGET 
Console.WriteLine(o.kunde.navn); // MEGET MERE MENING HVIS KUNDEN MÅTTE HAVE ORDREN, I STEDET FOR DEN ANDEN VEJ RUNDT. 

w.NyOrdre(100, 100);
w.NyOrdre(12345678, 1);

w.SeUbetalte();

class Webshop
{
    List<Kunde> kundeListe = new List<Kunde>();
    List<Ordre> ordreListe = new List<Ordre>();

    public string NyKunde(int telefonnummer, string navn)
    {
        string svar = opretKunde(telefonnummer, navn);
        return svar;
    }

    private string opretKunde(int telefonnummer, string navn)
    {
        Kunde k = new Kunde(telefonnummer, navn);
        kundeListe.Add(k);
        return k.navn;
    }

    private Kunde find(int telefonnummer)
    {
        int i = 0;
        Kunde k = null;
        while (i < kundeListe.Count)
        {
            if (kundeListe[i].telefonnummer == telefonnummer)
            {
                k = kundeListe[i];
            }
            i++;
        }
        return k;
    }

    public List<Ordre> SeUbetalte()
    {
        List<Ordre> oListe = new List<Ordre>();
        int i = 0;
        while (i < ordreListe.Count)
        {
            if (!ordreListe[i].AfventerBetaling)
            {
                oListe.Add(ordreListe[i]);
            }
            i++;
        }
        PrintUbetalte(oListe);
        return oListe;
    }

    private void PrintUbetalte(List<Ordre> oListe)
    {
        int i = 0;
        while (i < oListe.Count)
        {
            Console.WriteLine("Ordren: " + oListe[i].ordrenummer + " er ikke blevet betalt.");
            i++;
        }
    }

    private  bool CheckOrdreExists(int ordrenummer)
    {
        bool svar = false;
        int i = 0;
        while(i  < ordreListe.Count)
        {
            if (ordreListe[i].ordrenummer == ordrenummer)
            {
                svar = true;
            }
            i++;
        }

        return svar;
    }
    public Ordre NyOrdre(int telefonnummer, int ordrenummer)
    {
        Kunde k = find(telefonnummer);
        bool findesOrdre = CheckOrdreExists(ordrenummer);
        Ordre o = null;
        if (k != null && !findesOrdre)
        {
            o = opretOrdre(ordrenummer);
            bindKunde(k, o);
        }
        else
        {
            if(k == null)
                Console.WriteLine("Der findes ingen eksisterende kunde med telefonnummeret: " + telefonnummer);
            else
                Console.WriteLine("Ordrenummeret eksisterer allerede");
        }
        return o;
    }
    private Ordre opretOrdre(int ordrenummer)
    {
        Ordre o = new Ordre(ordrenummer);
        return o;
    }
    private void bindKunde(Kunde k, Ordre o)
    {
        o.kunde = k;
        ordreListe.Add(o);
    }
}

class Kunde
{
    public int telefonnummer;
    public string navn;
    public Kunde(int telefonnummer, string navn)
    {
        this.telefonnummer = telefonnummer;
        this.navn = navn;
    }
}
class Ordre
{
    public int ordrenummer;
    public bool AfventerBetaling;
    public Kunde kunde;
    public Ordre(int ordrenummer)
    {
        this.ordrenummer = ordrenummer;
    }
}
