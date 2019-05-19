using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop
{
    public partial class bestelbevestiging : System.Web.UI.Page
    {
        /*De tekst voor de bestelbevestiging hebben we vastgecodeerd in bestelbevestiging.aspx
       Hier halen we de Sessie variabelen voor de ordernummer en de totaal prijs.*/

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOrderNr.Text = Convert.ToInt32(Session["ordernr"]).ToString();
            lblTotaal.Text = "€ " + Convert.ToDouble(Session["totaal"]);

        }

        /* Bij het klikken van deze knop wordt de gebruiker terug naar de catalogus doorverwezen.*/
        protected void btnTerugNaarCath_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}