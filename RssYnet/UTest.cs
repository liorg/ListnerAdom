using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssYnet
{
    public partial class UTest : Form
    {
        string _subPathWav = @"resources\ding.wav";
        public UTest()
        {
            string fullPathWave = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _subPathWav);

            
            InitializeComponent();
            _simpleSound = new SoundPlayer(fullPathWave);
        }
        SoundPlayer _simpleSound;
        private void button1_Click(object sender, EventArgs e)
        {
           
            //for (int i = 0; i < 10; i++)
            //{
          //  simpleSound.Play(
              
            _simpleSound.PlayLooping();
           // }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _simpleSound.Stop();
        }

        private void UTest_Load(object sender, EventArgs e)
        {

        }
    }
}
