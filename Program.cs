Webshop w = new Webshop();

Console.WriteLine(w.NyKunde(12345678, "Jens Jensen"));
Ordre o = w.NyOrdre(12345678, 6969420); // JEG SYNES NU HELT ÆRLIGT DET HAVDE GIVET MEGET 
int i = 0; // MEGET MERE MENING HVIS KUNDEN MÅTTE HAVE ORDREN, I STEDET FOR DEN ANDEN VEJ RUNDT. 
while (i < o.kundeList.Count)
{
    Console.WriteLine(o.kundeList[i].navn);
    i++;
}

w.NyOrdre(100, 100);

class Webshop
{
    List<Kunde> kundeListe = new List<Kunde>(); 
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
    public Ordre NyOrdre(int telefonnummer, int ordrenummer)
    {
        Kunde k = find(telefonnummer);
        Ordre o = null;
        if (k != null)
        {
            o = opretOrdre(ordrenummer);
            bindKunde(k, o);
        }
        else
        {
            Console.WriteLine("Der findes ingen eksisterende kunde med telefonnummeret: " + telefonnummer);
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
        o.kundeList.Add(k);
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
    public List<Kunde> kundeList;
    public Ordre(int ordrenummer)
    {
        this.ordrenummer = ordrenummer;
        this.kundeList = new List<Kunde>();
    }
}
