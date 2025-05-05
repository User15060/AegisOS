using AegisOS._02_Modele._03_AnalyzerToolsModele.Interface;
using AegisOS._03_Controller._03_AnalyzerToolsController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AegisOS.Forms
{
    public partial class FileAnalyzer : Form
    {

        private readonly MainAnalyzerController _mainAnalyzer;

        public FileAnalyzer()
        {
            InitializeComponent();
            _mainAnalyzer = new MainAnalyzerController();

        }

        private async void ButtonSearchFile_Click(object sender, EventArgs e)
        {
            if (ComboBoxPreferences.SelectedItem == null) return;

            string selection = ComboBoxPreferences.SelectedItem.ToString();
            string input = TextBoxSelectFile.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Veuillez sélectionner un fichier ou entrer une valeur.");
                return;
            }

            switch (selection)
            {
                case "File Analyzer":
                    var fileResult = await _mainAnalyzer.AnalyzeFileAsync(input);
                    break;

                case "URL Analyzer":
                    var urlResult = await _mainAnalyzer.AnalyzeUrlAsync(input);
                    break;

                case "IP Analyzer":
                    var ipResult = await _mainAnalyzer.AnalyzeIpAsync(input);
                    break;

                case "Domain Analyzer":
                    var domainResult = await _mainAnalyzer.AnalyzeDomainAsync(input);
                    break;

                default:
                    MessageBox.Show("Option invalide.");
                    break;
            }
        }

        private void ButtonBrowseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                TextBoxSelectFile.Text = filePath;
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
