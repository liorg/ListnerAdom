using rssYnet.Util;
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
    public partial class AddFilters : Form
    {
        public AddFilters()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Locations locations = new Locations();
            locations.YeshovimLocations = new Dictionary<string, string[]>();
            locations.YeshovimLocations.Add("עוטף עזה 217", new string[] { "זיקים", "כרמיה" });
            locations.YeshovimLocations.Add("עוטף עזה 218", new string[] { "נתיב העשרה", "יד מרדכי" });
            locations.YeshovimLocations.Add("עוטף עזה 231", new string[] { "נירים", "עין השלושה" });
            var d=SerializeObject.JsonSerializeObject(locations);

        }
        Locations _locations; Locations _dataRepo;
        private void AddFilters_Load(object sender, EventArgs e)
        { 
            var subPath=@"resources\data.json";
            string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), subPath);
      
            var json = System.IO.File.ReadAllText(fullPath);
    
            _locations = SerializeObject.JsonDeserializeToObject<Locations>(json);
           
            cboCodes.DataSource = _locations.YeshovimLocations.Keys.ToList();
        }

        private void cboCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valuesSelected = _locations.YeshovimLocations.Where(k => k.Key == cboCodes.SelectedValue.ToString()).Select(s => s.Value).FirstOrDefault();
            if (valuesSelected != null && valuesSelected.Any())
                lstDsec.DataSource = valuesSelected.ToArray();
            else
                lstDsec.DataSource = new string[]{""};
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var data = cboCodes.DataSource as List<string>;
            if (cboCodes.SelectedValue != null)
            {
                var selectedValue = cboCodes.SelectedValue.ToString();
                lstFilters.Items.Add(cboCodes.SelectedValue.ToString());
                lstDsec.DataSource = new string[] { "" };
                cboCodes.DataSource =data.Where(d=>d.GetHashCode()!= selectedValue.GetHashCode()).ToList();
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var data=cboCodes.DataSource as List<string>;
            while (lstFilters.SelectedItems.Count > 0)
            {
                if(data!=null)
                     data.Add(lstFilters.SelectedItems[0].ToString());
                lstFilters.Items.Remove(lstFilters.SelectedItems[0]);
                
            }
            cboCodes.DataSource = data.ToList();

            
        }
    }
}
