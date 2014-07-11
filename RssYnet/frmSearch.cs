using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssYnet
{
    public partial class frmSearch : Form
    {
        public List<string> Items
        {
            get
            {
                List<string> l = new List<string>();

                foreach (var item in lstItems.Items)
                {
                    l.Add(item.ToString());
                }
                return l;
            }
        
        }
        public frmSearch(string[] search)
        {
            InitializeComponent();
            if (search!=null && search.Any())
            {
                foreach (var item in search)
                {
                    lstItems.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtName.Text))
            {
                lstItems.Items.Add(txtName.Text);
            }
            
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            while (lstItems.SelectedItems.Count > 0)
            {
                lstItems.Items.Remove(lstItems.SelectedItems[0]);
            }
        }
    }
}
