using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4.MyForms
{
    public partial class ConfigurationForm : Form
    {
        Network.Safety.Firewall _firewall;

        public ConfigurationForm(Network.Safety.Firewall firewall) {
            InitializeComponent();
            this._firewall = firewall;
        }

        private void filterCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (filterCheckBox.Checked) {
                _firewall.AddFunction(new Network.Safety.FilterCommand());
            }
            else {
                _firewall.DelFunctions(new Network.Safety.FilterCommand());
            }
        }

        private void natCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (natCheckBox.Checked) {
                _firewall.AddFunction(new Network.Safety.NATCommand());
            }
            else {
                _firewall.DelFunctions(new Network.Safety.NATCommand());
            }
        }

        private void statCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (statCheckBox.Checked) {
                _firewall.AddFunction(new Network.Safety.CollectStatCommand());
            }
            else {
                _firewall.DelFunctions(new Network.Safety.CollectStatCommand());
            }
        }

        private void addFilterButton_Click(object sender, EventArgs e) {
            if (filterTextBox.Text.Length == 0) {
                MessageBox.Show("Напишите команду для фильтра.", "Ошибка");
                return;
            }
            try {
                _firewall.Filter.AddFilter(filterTextBox.Text);                
            }
            catch (Network.Safety.InvalidFilterException ex){
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            UpdateFilterInformation();
        }

        private void delFilterButton_Click(object sender, EventArgs e) {
            if (filterTextBox.Text.Length == 0) {
                MessageBox.Show("Напишите команду для фильтра.", "Ошибка");
                return;
            }
            try {
                _firewall.Filter.DelFilter(filterTextBox.Text);                
            }
            catch (Network.Safety.InvalidFilterException ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            UpdateFilterInformation();
        }

        private void clearFilterButton_Click(object sender, EventArgs e) {
            _firewall.Filter.ClearFilter();
            UpdateFilterInformation();
        }

        private void addToTabButton_Click(object sender, EventArgs e) {
            if (natIntraTextBox.Text.Length == 0 ||
                natExternalTextBox.Text.Length == 0) {
                MessageBox.Show("Заполните все поля.", "Ошибка");
                return;
            }
            try {
                _firewall.AddAddrsToTableNAT(new Network.NetworkAddress(natIntraTextBox.Text),
                    new Network.NetworkAddress(natExternalTextBox.Text));
                tabNatListView.Items.Add(natIntraTextBox.Text);
                tabNatListView.Items[tabNatListView.Items.Count - 1].SubItems.Add(
                    natExternalTextBox.Text);
            }
            catch {
                MessageBox.Show("Ошибка");
            }
        }

        private void delFromTabButton_Click(object sender, EventArgs e) {
            if (natIntraTextBox.Text.Length == 0 ||
                natExternalTextBox.Text.Length == 0) {
                MessageBox.Show("Заполните все поля.", "Ошибка");
                return;
            }
            try {
                int ind = _firewall.DelAddrsFromTableNat(new Network.NetworkAddress(natIntraTextBox.Text),
                    new Network.NetworkAddress(natExternalTextBox.Text));
                if (ind != -1) {
                    tabNatListView.Items.RemoveAt(ind);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearTabButton_Click(object sender, EventArgs e) {
            _firewall.ClearTableNat();
            tabNatListView.Items.Clear();
        }

        private void UpdateFilterInformation() {
            ipDstFiltListBox.Items.Clear();
            ipSrcFiltListBox.Items.Clear();
            portsFiltListBox.Items.Clear();
            protoFiltListBox.Items.Clear();
            foreach (Network.NetworkAddress addr in _firewall.Filter.IPAddrsSrc) {
                ipSrcFiltListBox.Items.Add(addr);
            }
            foreach (Network.NetworkAddress addr in _firewall.Filter.IPAddrsDst) {
                ipDstFiltListBox.Items.Add(addr);
            }
            foreach (ushort port in _firewall.Filter.PortsDst) {
                portsFiltListBox.Items.Add(port);
            }
            foreach (string protocol in _firewall.Filter.Protocols) {
                protoFiltListBox.Items.Add(protocol);
            }
        }        
    }
}
