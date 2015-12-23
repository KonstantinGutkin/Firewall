using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperClasses;
namespace MyForms
{
    public partial class MainForm : Form
    {
        TrafficGenerator _generator;
        Network.Safety.Firewall _firewall;
        Network.VirtualTrafficsSniffer _sniffer;
        Network.Distributor _dbr;
        ConfigurationForm _cfgForm;
        InformationForm _infoForm;
        BindingList<string> _traffic1;
        BindingList<string> _traffic2;
        public MainForm()
        {
            InitializeComponent();
            _traffic1 = new BindingList<string>();
            _traffic2 = new BindingList<string>();
            _traffic1.ListChanged += UpdateListBox1TopIndex;
            _traffic2.ListChanged += UpdateListBox2TopIndex;
            trafficListBox1.DataSource = _traffic1;
            trafficListBox2.DataSource = _traffic2;
            Network.Safety.DistributorToBindingList dbrFirewall =
                new Network.Safety.DistributorToBindingList(_traffic2);
            _firewall = new Network.Safety.Firewall(new Network.Safety.MyFilter(),
                dbrFirewall);
            _generator = new TrafficGenerator(2000,
                new Network.NetworkAddress("192.168.1.0"),
                new Network.NetworkAddress("255.255.255.240"));
            _sniffer = new Network.VirtualTrafficsSniffer(_generator);
            _dbr = new Network.Distributor(_generator, _traffic1);
            _generator.Attach(_sniffer);
            _generator.Attach(_dbr);
            //Подписались на событие
            _sniffer.OnPacket += _firewall.Scan; 
            
            _infoForm = new InformationForm(_firewall);
            _cfgForm = new ConfigurationForm(_firewall);            
        }      

        private void startButton_Click(object sender, EventArgs e) {            
            _generator.Start();            
        }

        private void pauseButton_Click(object sender, EventArgs e) {
            _generator.Pause();
        }

        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            _cfgForm.ShowDialog();   
        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e) {
            _infoForm.ShowDialog();
        }

        private void UpdateListBox1TopIndex(object sender, ListChangedEventArgs e) {
            if (_traffic1.Count > 0) {
                trafficListBox1.TopIndex = _traffic1.Count - 1;
            }
        }

        private void UpdateListBox2TopIndex(object sender, ListChangedEventArgs e) {
            trafficListBox2.TopIndex = trafficListBox2.Items.Count - 1;
        }
    }
}
