using System;
using System.Windows.Forms;

namespace OnScreenSearchBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(null))
            {
                string searchString = textBox1.Text.Replace(' ', '+');
                if (searchString.StartsWith("www.") || searchString.StartsWith("http:") ||
                    searchString.StartsWith("https:"))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(searchString);
                        this.Close();
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start("http://www.google.com/search?q=" + searchString);

                        //Alternative search engines: uncomment to use
                        //System.Diagnostics.Process.Start("http://www.yahoo.com/search?q=" + searchString);
                        //System.Diagnostics.Process.Start("http://www.bing.com/search?q=" + searchString);
                        this.Close();
                    }
                    catch (Exception) { }
                }
            }
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            else
                return base.ProcessDialogKey(keyData);
        }
    }
}
