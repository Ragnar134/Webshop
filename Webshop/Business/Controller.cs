using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Persistence;
namespace Webshop.Business
{
    public class Controller
    {
        //

        PersistenceCode persistence = new PersistenceCode();
        Winkelmandje winkelmandje = new Winkelmandje();
        Bestelling bestelling = new Bestelling();
        Bestellijn bestellijn = new Bestellijn();

        /*Lijst van alle aanwezige producten in de databank ophalen.*/

       public List<Product> haalProductenOp()
        {
            return persistence.loadProducts();
        }

        /*Een artikel toevoegen aan het winkelmandje*/

        public void voegProductAanMandjeToe(int klantnr, int artnr, int aantal )
        {
            winkelmandje.KlantNr = klantnr;
            winkelmandje.ArtNr = artnr;
            winkelmandje.Aantal = aantal;

            persistence.insertCart(winkelmandje);
           
            
        }

        /*Alle artikelen in het winkelmandje ophalen.*/

        public List<Winkelmandje> haalMandjeOp(int KN)
        {
            return persistence.loadCart(KN);
        }

        /*En bepaald artikel laden op basis van zijn artikelnummer (vb. zie toevoegen.aspx.cs, lijn:20 t.e.m 24)*/

        public Product laadArtikel(int id )
        {
            return persistence.getProduct(id);
        }

        /*Een bepaald product verwijderen uit het winkelmandje op basis van de
          artikelnummer van de artikel en de klantnummer van het winkelmandje.*/

        public void verwijderProduct(int id , int klantnr)
        {
            persistence.deleteProduct(id, klantnr);
        }

        /* Deze methode wordt gebruikt om de voorraad van een bepaald artikel aan te passen
            bij het toevoegen aan en het verwijderen uit het winkelmandje.*/

        public void PasVoorraadAan(int id, int voorraad)
        {
            persistence.UpdateVoorraad(id, voorraad);
        }

        /*Hiermee wordt gecontroleerd of het winkelmandje leeg is of niet.*/

        public bool mandjeChecken(int klantnr)
        {
            return persistence.CheckMandje(klantnr);
        }

        /*Hiermee worden de gegeven van een bepaalde klant geladen op basis van zijn klantnummer.*/

        public Klant laadKlant(int id)
        {
            return persistence.loadClient(id);
        }

        /*Hiermee slaan we een bestelling op.*/

        public void slaBestellingOp( DateTime datum, int klantnr )
        {
          
            bestelling.Datum = datum;
            bestelling.KlantNr = klantnr;
           

            persistence.insertOrder(bestelling);
        }

        /*Hiermee wordt per ordernummer,alle orderinformatie zoals welke artikelen er in die order zitten en zowel
         * de aantalen als de huidige prijzen opgeslagen.*/

        public void slaBestellijnOp(int ordernr, int artnr, int aantal, double histprijs)
        {
            bestellijn.OrderNr = ordernr;
            bestellijn.ArtikelNr = artnr;
            bestellijn.Aantal = aantal;
            bestellijn.HistPrijs = histprijs;

            persistence.insertOrderline(bestellijn);
        }

        //

        public double haalPrijsOp(int artnr)
        {
            return persistence.getHistprice(artnr);
        }

        //

        public Totalen Haaltotalenop(int klnr)
            {
            return persistence.getTotals(klnr);
        }

        //

        public int haalOrderNrOp(DateTime datum)
        {
            return persistence.getOrderNumber(datum);

        }

        //

        public int Haalvoorraadop(int id)
        {
            return persistence.getVoorraad(id);
        }

        //

        public string haalMailOp(int klantnr)
        {
            return persistence.getEmail(klantnr);
        }

        //

        public bool controleerAanmeldgegevens(string gebrnaam, string ww)
        {
            return persistence.checkCredentials(gebrnaam, ww);
        }

        //

        public int haalKlantNrOp(string gebrnaam)
        {
            return persistence.getClientId(gebrnaam);
        }

    }
}