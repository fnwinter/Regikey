using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REGIKEY
{
    public partial class KeyChecker : Form
    {
        VKKeyCodes vk = new VKKeyCodes();
        Timer timer = new Timer();

        public KeyChecker()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.label_name.Text = vk.getKeyName(RegiKey.currentPressedKey);
            this.label_value.Text = String.Format("0x{0:X}", RegiKey.currentPressedKey);
            this.label_desc.Text = vk.getKeyDesc(RegiKey.currentPressedKey);
        }

        private void KeyChecker_Load(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 500;
            timer.Start();            
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }
    }
}