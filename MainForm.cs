#region File Description
//-----------------------------------------------------------------------------
// MainForm.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Windows.Forms;
#endregion

namespace SpaceExplorerXNAWF
{
    // System.Drawing and the XNA Framework both define Color types.
    // To avoid conflicts, we define shortcut names for them both.
    using GdiColor = System.Drawing.Color;
    using XnaColor = Microsoft.Xna.Framework.Graphics.Color;

    
    /// <summary>
    /// Custom form provides the main user interface for the program.
    /// In this sample we used the designer to add a splitter pane to the form,
    /// which contains a SpriteFontControl and a SpinningTriangleControl.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SelectionIcon.RaiseStarSelectedEvent += delegate { ListBoxSelectionReaction(); };
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void buttonGenGalaxy_Click(object sender, System.EventArgs e)
        {
            galaxyControl1.GenerateNewGalaxy();
            starNameListBox.Items.Clear();
            starNameListBox.Items.AddRange(galaxyControl1.GetStarNames().ToArray());
        }

        private void buttonGenColors_Click(object sender, System.EventArgs e)
        {
            galaxyControl1.GenerateNewColors();
        }

        private void starNameListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SelectionIcon.MakeSelection((string)starNameListBox.SelectedItem);
            if (starControl.Visible)
            {
                starControl.SetCurrentStar(ref SelectionIcon.selectedStar);
            }
            
        }

        private void ListBoxSelectionReaction()
        {
            starNameListBox.SelectedItem = SelectionIcon.selectedStar.Name;
        }

        /// <summary>
        /// When clicked, the examine star button swaps between the galaxy map, 
        /// the star system map, and the planet map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExamineStar_Click(object sender, System.EventArgs e)
        {
            if (galaxyControl1.Visible)
            {
                starControl.Visible = true;
                starControl.SetCurrentStar(ref SelectionIcon.selectedStar);
                galaxyControl1.Visible = false;
                planetControl1.Visible = false;
                buttonExamineStar.Text = "Return To Map";
            }
            else
            {
                if (starControl.Visible)
                {
                    galaxyControl1.Visible = true;
                    starControl.ClearCurrentStar();
                    starControl.Visible = false;
                    planetControl1.Visible = false;
                    buttonExamineStar.Text = "Examine Star";
                }
                else
                {
                    starControl.Visible = true;
                    starControl.SetCurrentStar(ref SelectionIcon.selectedStar);
                    planetControl1.Visible = false;
                    galaxyControl1.Visible = false;
                    buttonExamineStar.Text = "Return To Map";
                }
            }
        }
    }
}
