using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PlummerCompany
{
    /// <summary>
    /// This is the Invoice Administration Application which is part of The Plummer´s Tool application.
    /// </summary>
    public partial  class PlummerInvoice : Form
    {
        public  PlummerInvoice()
        {
            InitializeComponent();
        }

        private string customer = "";
        private List<Invoice> invoices = new List<Invoice>();
        private List<string> invoice_lines = new List<string>();
        private Invoice invoice;
        private Invoice invoice_print = new Invoice();
        private List<string> invoice_print_content = new List<string>();
 

        /// <summary>
        /// Searches the List of invoices to see if there is an estate owner 
        /// that matches the search term. If so an invoice is created
        /// and it is shown i Notepad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClientInvoice_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                customer = txtSearch.Text;
                PlummerInvoice_Load(sender, e);
                bool print = FindCustomer(customer);

                if (print)
                {
                    CreateInvoiceToPrint();
                }
                else
                {
                    MessageBox.Show("Sök igen!", "Kunden saknas: ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                txtSearch.Text ="";
            }
        }

        /// <summary>
        /// Reads all posts from the file: invoice.csv 
        /// </summary>
        /// <param name="customer"></param>
        private bool FindCustomer(string customer)
        {
            bool exists = false;

            foreach (Invoice invoice in invoices)
            {
                if (invoice.Owner.ToLower().Contains(customer.ToLower()))
                {
                    invoice_print = new Invoice();
                    invoice_print = invoice;
                    exists = true;
                }
            }
            return exists;
        }

        /// <summary>
        /// Creates the invoice in text format as a comma separated values file: InvoicePrint.csv. 
        /// Which is saved on disk for later use (to be printed).
        /// </summary>
        private void CreateInvoiceToPrint()
        {
            invoice_print_content.Clear();
            invoice_print_content.TrimExcess();

            invoice_print_content.Add("\n");
            invoice_print_content.Add("\n");
            invoice_print_content.Add("----------");
            invoice_print_content.Add("VVS Akuten");
            invoice_print_content.Add("----------");
            invoice_print_content.Add("\n");
            invoice_print_content.Add($"Kundens namn: {invoice_print.Owner}      Kundens adress: {invoice_print.Address}");
            invoice_print_content.Add("\n");
            // invoice_print_content.Add(estate.type);
            invoice_print_content.Add("\n");
            invoice_print_content.Add($"Utfört arbete:  { invoice_print.Work}");
            invoice_print_content.Add("\n");
            invoice_print_content.Add($"Kostnad i SEK: {invoice_print.Cost.ToString()}");
            invoice_print_content.Add("\n");

            invoice_print_content.Add($"Fakturan skall betalas senast:  {DateTime.Today.AddMonths(1).ToShortDateString()}");
            //DateTime.Today + 1 month.
            invoice_print_content.Add("\n");

            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
            string file = path + "InvoicePrint.csv";
            File.WriteAllLines(file, invoice_print_content, Encoding.Default);

            Process.Start("notepad.exe", file);
        }


        /// <summary>
        /// Opens the file invoices.csv that holds the data för creating invoices.
        /// Each line represents a job, which in turn will become an invoice.
        /// E.g. there is only one job on each invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlummerInvoice_Load(object sender, EventArgs e)
        {

            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
            string file = path + "invoices.csv";

            if (File.Exists(file))
            {


                invoice_lines = File.ReadAllLines(file, Encoding.Default).Skip(1).ToList();

                foreach (string line in invoice_lines)
                {
                    try
                    {
                        string[] entries = line.Split(',');//Split each post at the commas. 

                        invoice = new Invoice();
                        invoice.Owner = entries[0];
                        invoice.Address = entries[1];

                        string date_string = entries[2].Replace("-", "").Trim();
                        int year = Int16.Parse(date_string.Substring(0, 4));
                        int month = Int16.Parse(date_string.Substring(4, 2));
                        int day = Int16.Parse(date_string.Substring(6, 2));

                        invoice.Date = new DateTime(year, month, day).ToLocalTime();
                        invoice.Work = entries[3];
                        invoice.Cost = Int32.Parse(entries[4], NumberStyles.None);

                        invoices.Add(invoice);

                    }
                    catch (NullReferenceException ne)
                    {
                        MessageBox.Show("Följande fel har inträffat: "
                                  + ne.Message, "Fortsätt", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Det finns ingen kund eller arbeten sparade \n" +
                    "Vänligen lägg till kunden först! ", "Fortsätt!"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                Close();
                Dispose();
            }
        }
    }
}
