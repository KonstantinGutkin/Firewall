using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForms
{
    public partial class InformationForm : Form
    {
        public InformationForm(Network.Safety.Firewall firewall) {
            InitializeComponent();
            firewall.OnUpdateStatistics += UpdateStatLabel;
        }

        
        private void UpdateStatLabel(Dictionary<string, int> stat) {
            ipCountLabel.Text = stat["ip"].ToString();
            tcpCountLabel.Text = stat["tcp"].ToString();
            udpCountLabel.Text = stat["udp"].ToString();
            icmpCountLabel.Text = stat["icmp"].ToString();
            totalCountLabel.Text = stat["total"].ToString();
        }

        
    }
}
