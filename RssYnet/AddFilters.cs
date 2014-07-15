using rssYnet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public AddFilters(Locations locations,string[] searchItems)
        {
            InitializeComponent();
            _locations = locations;
            if(searchItems!=null && searchItems.Any())
             Search = searchItems.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Locations locations = new Locations();
            locations.YeshovimLocations = new Dictionary<string, List<string>>();
            using (var reader = new StreamReader(@"F:\temp\pp.csv",Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Any())
                    {
                        var key =values[2];
                        var value = values[0];
                        if (!String.IsNullOrEmpty(key))
                        {
                            if (!locations.YeshovimLocations.ContainsKey(key))
                               locations.YeshovimLocations.Add(key, new List<string>());
                            
                            var data = locations.YeshovimLocations[key];
                            data.Add(value);
                        }
                    }
                }
            }

            var json = SerializeObject.JsonSerializeObject(locations);

            string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPath);

            System.IO.File.WriteAllText(fullPath, json);

        }

        private void AddFilters_Load(object sender, EventArgs e)
        {
            //string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPath);
            //var json = System.IO.File.ReadAllText(fullPath);
            //_locations = SerializeObject.JsonDeserializeToObject<Locations>(json);
            cboCodes.DataSource = _locations.YeshovimLocations.Keys.OrderBy(k=>k).ToList();

            var source = new AutoCompleteStringCollection();
            foreach (var itemsValue in _locations.YeshovimLocations.Values)
            {
                foreach (var item in itemsValue)
                    source.Add(item);
            }    
            txtYeshuv.AutoCompleteCustomSource = source;
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
               // lstDsec.DataSource = new string[] { "" };
               // cboCodes.DataSource = data.Where(d => d.GetHashCode() != selectedValue.GetHashCode()).ToList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var data = cboCodes.DataSource as List<string>;
            while (lstFilters.SelectedItems.Count > 0)
            {
               // if (data != null)
                   // data.Add(lstFilters.SelectedItems[0].ToString());
                lstFilters.Items.Remove(lstFilters.SelectedItems[0]);

            }
           // cboCodes.DataSource = data.ToList();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblFind.Text = "לא נמצא";
            var find = _locations.YeshovimLocations.Where(v => v.Value.Contains(txtYeshuv.Text.Trim())).Select(k=>k.Key).ToList();

            if (find.Any())
            {
                lblFind.Text = string.Join(",", find.ToArray());
                if (find.Count == 1)
                {
                    cboCodes.SelectedItem = find.First();
                }
            }
        }

        public List<string> Search
        {
            get
            {
                List<string> searchItems = new List<string>();
                foreach (var item in lstFilters.Items)
                {
                    searchItems.Add(item.ToString().Trim());
                }
                return searchItems;
            }
            set
            {
                if (value != null)
                {
                    foreach (var itemS in value)
                    {
                        lstFilters.Items.Add(itemS);
                    }
                }
            }
        }

        private void lblFind_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
