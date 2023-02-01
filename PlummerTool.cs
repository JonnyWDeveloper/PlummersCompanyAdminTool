using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlummerCompany
{
    /// <summary>
    /// This application creates a real estate customer.
    /// A customer is an owner of a real estate, which mainly breaks down into two parts:
    /// the OWNER and the REAL ESTATE. It saves the customer record in two separate CSV files. 
    /// The information about the real estate is archived in the file. Therefore if the estate gets a new owner
    /// the history of the real estate will still be intact and traceable in the future.
    /// </summary>
    public partial class PlummerTool : Form
    {
        public PlummerTool()
        {
            InitializeComponent();
        }

        //private List<RealEstate> realEstates = new List<RealEstate>();
        private List<string> estate_lines = new List<string>();
        //private List<Invoice> invoices = new List<Invoice>();
        private List<string> invoice_lines = new List<string>();
        private RealEstate estate = new RealEstate();
        private Invoice invoice = new Invoice();
        private bool save = false;
        private PlummerInvoice pi;

        /// <summary>
        /// Saves data of the real estate custumor and invoice details in two CSV files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            invoice_lines.Clear();
            estate_lines.Clear();
            invoice_lines.TrimExcess();
            estate_lines.TrimExcess();

            //Make sure the textboxes contains something.
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    var txt = control as TextBox;

                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        MessageBox.Show("Fyll i samtliga uppgifter innan du sparar.", "Uppgifter saknas.",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDate.Select();
                        save = false;
                        return;
                    }
                    else
                    {
                        save = true;
                    }
                }
            }

            if (save)//Try to save the client and estate data from the textboxes.
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
                string file_invoices = path + "invoices.csv";
                string file_estates = path + "estates.csv";
                string invoice_headers = "Fastighetsägare,Adress,Datum,Arbete,Kostnad";
                string estate_headers = "Fastighetstyp,Beteckning,Datum,Arbete";

                if (File.Exists(file_invoices))
                {
                    invoice_lines = File.ReadAllLines(file_invoices, Encoding.Default).ToList();
                    invoice_lines.RemoveAt(0); //Delete the headers.
                }

                if (File.Exists(file_estates))
                {
                    estate_lines = File.ReadAllLines(file_estates, Encoding.Default).ToList();
                    estate_lines.RemoveAt(0); //Delete the headers.
                }

                //The Invoice data added to its object.
                invoice.Owner = txtClientName.Text;
                invoice.Address = txtClientAddress.Text;

                try
                {
                    string dateString = txtDate.Text.Trim().Replace(" ", "");
                    int year = Int16.Parse(dateString.Substring(0, 4));
                    int month = Int16.Parse(dateString.Substring(4, 2));
                    int day = Int16.Parse(dateString.Substring(6, 2));
                    invoice.Date = new DateTime(year, month, day);
                    invoice.Work = txtWork.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datum - ÅÅÅÅMMDD - Följande fel har inträffat: "
                                   + ex.Message, "Fortsätt", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (!string.IsNullOrEmpty(txtCost.Text))
                    {
                        invoice.Cost = Int32.Parse(txtCost.Text.Trim().Replace(" ", ""), NumberStyles.None);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kostnad - Max 2147483647 - Följande fel har inträffat: "
                                   + ex.Message, "Fortsätt", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }


                //The Real Estate data added to its object.
                estate.Type = txtType.Text;
                estate.Code = txtEstateAddress.Text;
                estate.Date = invoice.Date;
                estate.Work = invoice.Work;

                string invoice_contents = $"{invoice.Owner},{invoice.Address},{invoice.Date},{invoice.Work},{invoice.Cost}";
                string estate_contents = $"{estate.Type},{estate.Code},{estate.Date},{estate.Work}";

                invoice_lines.Insert(0, invoice_headers);//Add headers to invoices.
                invoice_lines.Add(invoice_contents);//Add one invoice to the list.
                estate_lines.Insert(0, estate_headers);//Add headers to estates.        
                estate_lines.Add(estate_contents);//Add one estate to the list.
                File.WriteAllLines(file_invoices, invoice_lines, Encoding.Default);
                File.WriteAllLines(file_estates, estate_lines, Encoding.Default);

                //Everything went well: a message is displayed.
                MessageBox.Show
                    ("Arbete host kunden: " + invoice.Owner
                    + " har registrerats. ", "Fakturaunderlag", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Reset the textboxes.
                //TextBox tb = new TextBox();
                foreach (var cont in this.Controls)
                {
                    if (cont is TextBox)
                    {
                        TextBox tb = (TextBox)cont;
                        tb.Text = "";
                        txtDate.Text = DateTime.Today.ToShortDateString().Replace("-", "");
                        txtDate.Select();
                    }
                }
            }
        }

        /// <summary>
        /// Starts The Plummer´s Invoice application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenInvoice_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms["PlummerInvoice"];

            if (form == null)
            {
                pi = new PlummerInvoice();
            }
            pi.StartPosition = FormStartPosition.Manual;
            pi.Location = new Point(980, 0);
            pi.Show();
            pi.BringToFront();
        }

        private void PlummerTool_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(-10, 0);
            txtDate.Text = DateTime.Today.ToShortDateString().Replace("-", "");
            txtDate.Select();
        }

    }
}

