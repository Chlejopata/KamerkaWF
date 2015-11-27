using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamerkaWF
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo fi in videoDevices)
            {
                CamerasCB.Items.Add(fi.Name);
            }
            videoSource = null;
        }

        private void CamerasCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CamerasCB.SelectedIndex >= 0)
            {
                ResolutionCB.Items.Clear();
                videoSource = new VideoCaptureDevice(videoDevices[CamerasCB.SelectedIndex].MonikerString);
                foreach (VideoCapabilities vc in videoSource.VideoCapabilities)
                {
                    ResolutionCB.Items.Add("Resolution: " + vc.FrameSize + ", frame rate: " + vc.MaximumFrameRate);
                }
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                    CaptureBox.Invoke(
                        new Action(
                            delegate
                            {
                                CaptureBox.Image = null;
                                CaptureBox.Invalidate();
                            }));
                }
                else
                {

                    videoSource.NewFrame += videoSource_NewFrame;
                    videoSource.Start();
                }
            }
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            CaptureBox.Invoke(
                new Action(
                    delegate
                    {
                        CaptureBox.Image = image;
                    }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();

                for (int i = 0; i < 30; i++)
                {
                    if (!videoSource.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                    MessageBox.Show(i + "");
                }

                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                }

                videoSource = null;
            }
        }

        private void ResolutionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            videoSource.VideoResolution = videoSource.VideoCapabilities[ResolutionCB.SelectedIndex];
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                CaptureBox.Invoke(
                    new Action(
                        delegate
                        {
                            CaptureBox.Image = null;
                            CaptureBox.Invalidate();
                        }));
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.Start();
            }
        }

    }
}
