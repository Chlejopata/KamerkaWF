using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Video.VFW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamerkaWF
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Bitmap currentFrame;
        private Thread captureThread;
        private AVIWriter writer;
        private bool recordVideo;
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
            captureThread = null;
            recordVideo = false;

            CaptureButton.Enabled = false;
            SnapshotButton.Enabled = false;
            RecordButton.Enabled = false;
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
                SnapshotButton.Enabled = videoSource.IsRunning;
                RecordButton.Enabled = videoSource.IsRunning;
            }
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            currentFrame = (Bitmap)eventArgs.Frame.Clone();
            if ((captureThread == null || !captureThread.IsAlive) && recordVideo)
            {
                Bitmap threadFrame = (Bitmap)currentFrame.Clone();
                captureThread = new Thread(
                        new ThreadStart(
                            delegate
                            {
                                writer.AddFrame(threadFrame);
                            }));
                captureThread.Start();
            }

            CaptureBox.Invoke(
                new Action(
                    delegate
                    {
                        CaptureBox.Image = currentFrame;
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
                }

                if (videoSource.IsRunning)
                {
                    videoSource.Stop();
                }

                CaptureBox.Invoke(
                    new Action(
                        delegate
                        {
                            CaptureBox.Image = null;
                            CaptureBox.Invalidate();
                        }));

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

                SnapshotButton.Enabled = videoSource.IsRunning;
                RecordButton.Enabled = videoSource.IsRunning;

                CaptureBox.Invoke(
                    new Action(
                        delegate
                        {
                            CaptureBox.Image = null;
                            CaptureBox.Invalidate();
                        }));
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.Start();

                SnapshotButton.Enabled = videoSource.IsRunning;
                RecordButton.Enabled = videoSource.IsRunning;
            }

            CaptureButton.Enabled = true;
        }

        private void SnapshotButton_Click(object sender, EventArgs e)
        {
            Bitmap snapshot = (Bitmap)currentFrame.Clone();
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Mapa bitowa BMP (*.bmp)|*.bmp|Plik JPEG (*.jpg)|*.jpg|Plik PNG (*.png)|*.png";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream;
                ImageFormat format;
                if ((fileStream = dialog.OpenFile()) != null)
                {
                    switch (dialog.FilterIndex)
                    {
                        default:
                        case 1:
                            format = ImageFormat.Bmp;
                            break;
                        case 2:
                            format = ImageFormat.Jpeg;
                            break;
                        case 3:
                            format = ImageFormat.Png;
                            break;
                    }
                    snapshot.Save(fileStream, format);
                    fileStream.Close();
                }
            }
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            if (!recordVideo)
            {
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "Plik AVI (*.avi)|*.avi";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    writer = new AVIWriter("cvid");
                    writer.FrameRate = videoSource.VideoResolution.AverageFrameRate;
                    var width = videoSource.VideoResolution.FrameSize.Width;
                    var height = videoSource.VideoResolution.FrameSize.Height;

                    writer.Open(dialog.FileName, width, height);
                    recordVideo = true;
                }
            }
            else
            {
                recordVideo = false;
                captureThread.Join();
                writer.Close();
            }
        }
    }
}
