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
        Locations _locations;
        string _subPath = @"resources\data.json";




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

            locations.YeshovimLocations.Add("נגב 296", new string[] { "א נבאר", 
                "סייד" ,"עטאונה" ,"אעצם" ,"חורה" ,
                "כרמים" ,"כרמית" ,"מולדה" ,"מיתר" ,
                "סנסנה" ,"עוקבי"             
            });
            locations.YeshovimLocations.Add("נגב 297", new string[] { 
                
                "אבו קוידר", "אבו תלול","אל חמידי", "אל עת'אמין","ביר אבו אל חמאם", "נבטים","שגב שלום"
            
            });


            locations.YeshovimLocations.Add("באר שבע 292", new string[] { "מסעודין אל עזאזמה", "באר שבע" });

            // locations.YeshovimLocations.Add("", new string[] { "x", "x" });
            var json = SerializeObject.JsonSerializeObject(locations);

            string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPath);

            System.IO.File.WriteAllText(fullPath, json);

        }


        private void AddFilters_Load(object sender, EventArgs e)
        {
            string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPath);
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
                lstDsec.DataSource = new string[] { "" };

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var data = cboCodes.DataSource as List<string>;
            if (cboCodes.SelectedValue != null)
            {
                var selectedValue = cboCodes.SelectedValue.ToString();
                lstFilters.Items.Add(cboCodes.SelectedValue.ToString());
                lstDsec.DataSource = new string[] { "" };
                cboCodes.DataSource = data.Where(d => d.GetHashCode() != selectedValue.GetHashCode()).ToList();
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var data = cboCodes.DataSource as List<string>;
            while (lstFilters.SelectedItems.Count > 0)
            {
                if (data != null)
                    data.Add(lstFilters.SelectedItems[0].ToString());
                lstFilters.Items.Remove(lstFilters.SelectedItems[0]);

            }
            cboCodes.DataSource = data.ToList();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = new List<string>();
            foreach (var item in lstFilters.Items)
            {
                data.Add(item.ToString());
            }
            var json = SerializeObject.JsonSerializeObject(data);
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dic = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(dic, json);
            }
        }
    }
}
