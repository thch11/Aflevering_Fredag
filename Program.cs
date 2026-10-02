Webshop w = new Webshop();

Console.WriteLine(w.NyKunde(12345678, "Jens Jensen"));


class Webshop
{
    public List<Kunde> kundeListe = new List<Kunde>();
    public string NyKunde(int telefonnummer, string navn)
    {
        string svar = opret(telefonnummer, navn);
        return svar;
    }

    private string opret(int telefonnummer, string navn)
    {
        Kunde k = new Kunde(telefonnummer, navn);
        kundeListe.Add(k);
        return k.navn;
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
