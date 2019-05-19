﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;
namespace Webshop
{
    public partial class login : System.Web.UI.Page
    {
        /* Dit is een instance van de Controller Class zodat we in deze document gebruik kunnen maken 
           van de methodes die in de Controller Class zitten */

        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            /* Hiermee controleren we of de ingegeven aanmeldgegevens kloppen en als ze kloppen wordt de gebruiker
               doorverwezen naar de catalogus. Kloppen de gegevens niet dan komt er een foutmelding tevoorschijn.*/

            if(_cont.controleerAanmeldgegevens(txtbGebrNaam.Text, txtbWachtwoord.Text))
            {
                int klantid = _cont.haalKlantNrOp(txtbGebrNaam.Text);
                FormsAuthentication.RedirectFromLoginPage(klantid.ToString(), false);
            }
            else
            {
                lblFout.Text = "Geen geldige aanmeldgegevens!";
            }
        }
    }
}