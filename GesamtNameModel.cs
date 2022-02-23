using System;

public class GesamtName
{
	public GesamtName()
	{
    public string Vorname { get; set; }
    public string Nachname { get; set; }

    public GesamtName(string gegebenerVorname, string gegebenerNachname)
        {
            Vorname = gegebenerVorname;
            Nachname = gegebenerNachname;
        }
    }
}
