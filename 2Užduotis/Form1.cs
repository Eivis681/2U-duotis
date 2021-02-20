using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _2Užduotis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateInterface();
        }

        public void UpdateInterface()
        {
            GetData getData = new GetData();
            List<Player> results = getData.GetDataFromDb();
            listViewZaidejai.Items.Clear();
            listViewIeskomiZaidejai.Items.Clear();
            for (int i = 0; i < results.Count; i++)
            {
                listViewZaidejai.Items.Add(results[i].name);
                listViewZaidejai.Items[i].SubItems.Add(results[i].ugis);
                listViewZaidejai.Items[i].SubItems.Add(results[i].svoris);
                listViewZaidejai.Items[i].SubItems.Add(results[i].sportoSaka);
                listViewZaidejai.Items[i].SubItems.Add(results[i].pozicija);
                listViewZaidejai.Items[i].SubItems.Add(results[i].amzius);
            }
            List<Player> playerResults = getData.GetPlayerData();
            for (int i = 0; i < playerResults.Count; i++)
            {
                listViewIeskomiZaidejai.Items.Add(playerResults[i].name);
                listViewIeskomiZaidejai.Items[i].SubItems.Add(playerResults[i].ugis);
                listViewIeskomiZaidejai.Items[i].SubItems.Add(playerResults[i].svoris);
                listViewIeskomiZaidejai.Items[i].SubItems.Add(playerResults[i].sportoSaka);
                listViewIeskomiZaidejai.Items[i].SubItems.Add(playerResults[i].pozicija);
                listViewIeskomiZaidejai.Items[i].SubItems.Add(playerResults[i].amzius);
            }
        }

        private void Skaiciuoti_Click(object sender, EventArgs e)
        {
            listBoxAmzius.Items.Clear();
            listBoxSvoris.Items.Clear();
            listBoxUgis.Items.Clear();
            listViewFinal.Items.Clear();
            GetData getData = new GetData();
            List<Player> zaidejas = new List<Player>();
            if (textBoxSportoSaka.Text == string.Empty && textBoxPozicija.Text == string.Empty)
            {
                zaidejas = getData.GetDataFromDb();
            }
            else if (textBoxSportoSaka.Text !=string.Empty)
            {
                zaidejas = getData.GetPlayerDataBySport(textBoxSportoSaka.Text);
            }
            List<Player> results = new List<Player>();
            for (int i =0; i< zaidejas.Count;i++)
            {
                double ugisCal = Math.Round((double.Parse(textBoxUgis.Text) / double.Parse(zaidejas[i].ugis)) * 100, 2);
                double svorisCal = Math.Round((double.Parse(textBoxSvoris.Text) / double.Parse(zaidejas[i].svoris)) * 100, 2);
                double amziusCal = Math.Round((double.Parse(textBoxAmzius.Text) / double.Parse(zaidejas[i].amzius)) * 100, 2);
                listBoxUgis.Items.Add(zaidejas[i].name + " " +ugisCal+"%");
                listBoxSvoris.Items.Add(zaidejas[i].name + " " + svorisCal + "%");
                listBoxAmzius.Items.Add(zaidejas[i].name + " " + amziusCal + "%");
                double finalCal = (ugisCal + svorisCal + amziusCal) / 3;
                results.Add(new Player { sportoSaka = zaidejas[i].sportoSaka, pozicija = zaidejas[i].pozicija, result = finalCal });
            }
            var nearest = results.OrderBy(x=> Math.Abs((long) x.result - 100)).First();
            listViewFinal.Items.Add(textBoxVardas.Text);
            listViewFinal.Items[0].SubItems.Add(textBoxUgis.Text);
            listViewFinal.Items[0].SubItems.Add(textBoxSvoris.Text);
            listViewFinal.Items[0].SubItems.Add(nearest.sportoSaka);
            listViewFinal.Items[0].SubItems.Add(nearest.pozicija);
            listViewFinal.Items[0].SubItems.Add(textBoxAmzius.Text);
        }

        private void Pakeisti_Click(object sender, EventArgs e)
        {
            List<Player> zaidejas = new List<Player>();
            string vardas = textBoxVardas.Text;
            var ugis = textBoxUgis.Text != string.Empty ? textBoxUgis.Text : "null";
            var svoris = textBoxSvoris.Text != string.Empty ? textBoxSvoris.Text : "null";
            var sportoSaka = textBoxSportoSaka.Text != string.Empty ? textBoxSportoSaka.Text : "null";
            var pozicija = textBoxPozicija.Text != string.Empty ? textBoxPozicija.Text : "null";
            var amzius = textBoxAmzius.Text != string.Empty ? textBoxAmzius.Text : "null";
            zaidejas.Add(new Player { name = vardas, ugis = ugis, svoris = svoris, sportoSaka = sportoSaka, pozicija = pozicija, amzius = amzius });
            UpdateDatabase updateDatabase = new UpdateDatabase();
            updateDatabase.UpdatePlayerData(zaidejas);
            UpdateInterface();
        }

        private void Pasirinkti_Click(object sender, EventArgs e)
        {
            if (listViewIeskomiZaidejai.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pasirinkite žaidėja");
                return;
            }
            var index = listViewIeskomiZaidejai.SelectedIndices;
            var vardas = listViewIeskomiZaidejai.Items[index[0]].SubItems[0].Text;
            var ugis = listViewIeskomiZaidejai.Items[index[0]].SubItems[1].Text;
            var svoris = listViewIeskomiZaidejai.Items[index[0]].SubItems[2].Text;
            var sportoSaka = listViewIeskomiZaidejai.Items[index[0]].SubItems[3].Text;
            var pozicija = listViewIeskomiZaidejai.Items[index[0]].SubItems[4].Text;
            var amzius = listViewIeskomiZaidejai.Items[index[0]].SubItems[5].Text;

            if (vardas != "null")
            {
                textBoxVardas.Text = vardas;
                textBoxVardas.ReadOnly = true;
            }
            if (ugis != "null")
            {
                textBoxUgis.Text = ugis;
            }
            if (svoris != "null")
            {
                textBoxSvoris.Text = svoris;
            }
            if (sportoSaka != "null")
            {
                textBoxSportoSaka.Text = sportoSaka;
            }
            if (pozicija != "null")
            {
                textBoxPozicija.Text = pozicija;
            }
            if (amzius != "null")
            {
                textBoxAmzius.Text = amzius;
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            if(listViewFinal.SelectedItems.Count==0)
            {
                MessageBox.Show("Pasirinkite žaidėja kuri norite išsaugoti");
                return;
            }
            var index = listViewFinal.SelectedIndices;
            var vardas = listViewFinal.SelectedItems[index[0]].SubItems[0].Text;
            var ugis = listViewFinal.SelectedItems[index[0]].SubItems[1].Text;
            var svoris = listViewFinal.SelectedItems[index[0]].SubItems[2].Text;
            var sportoSaka = listViewFinal.SelectedItems[index[0]].SubItems[3].Text;
            var pozicija = listViewFinal.SelectedItems[index[0]].SubItems[4].Text;
            var amzius = listViewFinal.SelectedItems[index[0]].SubItems[5].Text;
            List<Player> players = new List<Player>();
            players.Add(new Player { name = vardas, amzius = amzius, pozicija = pozicija, sportoSaka = sportoSaka, svoris = svoris, ugis = ugis });
            DeleteFromDb deleteFromDb = new DeleteFromDb();
            deleteFromDb.DeletePlayer(vardas);
            AddData addData = new AddData();
            addData.AddPlayerData(players);
            listBoxAmzius.Items.Clear();
            listBoxSvoris.Items.Clear();
            listBoxUgis.Items.Clear();
            listViewFinal.Items.Clear();
            UpdateInterface();
        }
    }
}
