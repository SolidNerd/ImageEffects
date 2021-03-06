﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageEffectswithGUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Stream loadStream;
           if (openFileDialog1.ShowDialog() == DialogResult.OK) 
           {
               if ((loadStream=openFileDialog1.OpenFile())!= null) 
               {
                  DirectImage.Image = new Bitmap(loadStream);
               }
           }
        }

        private void ButtonGreyscale_Click(object sender, EventArgs e)
        {
            Greyscale.startgreyscale(DirectImage.Image as Bitmap,(manipulatedimage)=>DirectImage.Image=manipulatedimage);
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream savestream;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                if ((savestream = saveFileDialog1.OpenFile()) != null) {
                    DirectImage.Image.Save(savestream, ImageFormat.Png);
                    savestream.Close();
                }
            }
        }
            

        private void ButtonBlackandWhite_Click(object sender, EventArgs e)
        {
            BlackAndWhite.Threshold = 128;
            BlackAndWhite.StartBlackAndWhite(DirectImage.Image as Bitmap, (manipulatedimage) => DirectImage.Image = manipulatedimage);
        }

        private void ButtonHistogram_Click(object sender, EventArgs e)
        {
            HistogramStretch.StartHistogramStretch(DirectImage.Image as Bitmap, (manipulatedimage) => DirectImage.Image = manipulatedimage);
           
        }

        private void Button3x3_Click(object sender, EventArgs e)
        {
            Filteroperation filteroperation = new Filteroperation(DirectImage.Image as Bitmap, FilterOperations.Boost);
            filteroperation.Start((manipulatedimage) => DirectImage.Image = manipulatedimage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawLine drawline = new DrawLine();
            DirectImage.Image = drawline.DrawWhiteBox();   
            
            drawline.From = new Point(150, 100);
            drawline.To = new Point(200, 200);             
            drawline.Draw(DirectImage.Image as Bitmap,(manipulatedimage) => DirectImage.Image = manipulatedimage);

            drawline.From = new Point(50, 50);
            drawline.To = new Point(150, 100);
            drawline.Draw(DirectImage.Image as Bitmap,(manipulatedimage) => DirectImage.Image = manipulatedimage);

            drawline.From = new Point(200, 200);
            drawline.To = new Point(50, 150);
            drawline.Draw(DirectImage.Image as Bitmap, (manipulatedimage) => DirectImage.Image = manipulatedimage);

            drawline.From = new Point(50, 150);
            drawline.To = new Point(50, 50);
            drawline.Draw(DirectImage.Image as Bitmap, (manipulatedimage) => DirectImage.Image = manipulatedimage);
        }
    }
}
