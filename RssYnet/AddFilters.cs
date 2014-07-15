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




        public AddFilters()
        {
            InitializeComponent();
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
                            {
                                locations.YeshovimLocations.Add(key, new List<string>());
                            }
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
            string fullPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPath);
            var json = System.IO.File.ReadAllText(fullPath);
            _locations = SerializeObject.JsonDeserializeToObject<Locations>(json);
            cboCodes.DataSource = _locations.YeshovimLocations.Keys.OrderBy(k=>k).ToList();
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
