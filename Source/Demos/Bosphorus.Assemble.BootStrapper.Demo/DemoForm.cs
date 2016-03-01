using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bosphorus.Assemble.BootStrapper.Demo
{
    public partial class DemoForm : Form
    {
        private readonly DemoService demoService;

        public DemoForm(DemoService demoService)
        {
            this.demoService = demoService;
            InitializeComponent();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            int sum = demoService.Sum(3, 5);
            MessageBox.Show(sum.ToString());
        }
    }
}
