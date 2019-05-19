using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;
namespace Webshop
{
    public partial class _default : System.Web.UI.Page
    {
        /* Dit is een instance van de Controller Class zodat we in deze document gebruik kunnen maken 
           van de methodes die in de Controller Class zitten.*/
        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvProducten.DataSource = _cont.haalProductenOp();
            gvProducten.DataBind();

            for(int i = 0; i<gvProducten.Rows.Count; i++)
            {
                
                    if (Convert.ToInt32(gvProducten.Rows[i].Cells[4].Text) == 0)
                    {
                        gvProducten.Rows[i].Cells[5].Text = "Niet op voorraad";
                        gvProducten.Rows[i].Cells[5].Enabled = false;
                    }
            }
        }

        /*Wanneer er een product geselecteerd wordt steken we hiermee de arikelnummer in een sessie zodat we deze kunnen gebruiken bij het ophalen 
          van de gegevens van de betreffende artikel in toevoegen.aspx (vb. zie lijn 20 in toevoegen.aspx.cs)*/

        protected void gvProducten_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["ArtNr"] = gvProducten.SelectedRow.Cells[0].Text;

            Response.Redirect("toevoegen.aspx");
        }

        /* Bij het klikken van deze knop wordt de gebruiker naar zijn winkelmandje doorgestuurd
           Als deze leeg is wordt hij doorgestuurd naar WinkelmandjeLeeg.aspx*/

        protected void btnWinkelmandje_Click(object sender, EventArgs e)
        {
            if (_cont.mandjeChecken(Convert.ToInt32(Context.User.Identity.Name)) == false)
            {
                Response.Redirect("winkelmandje.aspx");
            }
            else
            {
                Response.Redirect("WinkelmandjeLeeg.aspx");
            }
        }
    }
}