using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace EmguCVDemoJmalino
{
    public partial class Form1 : Form
    {
        Dictionary<string, Image<Bgr, byte>> IMGDict;
        public Form1()
        {
            InitializeComponent();
            IMGDict = new Dictionary<string, Image<Bgr, byte>>();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg;*.png;*.bmp;)|*.jpg;*.png;*.bmp;|All Files (*.*)|*.*;";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var img = new Image<Bgr, byte>(dialog.FileName);
                    pictureBox1.Image = img.ToBitmap();
                    if (IMGDict.ContainsKey("input"))
                    {
                        IMGDict.Remove("input");
                    }
                    IMGDict.Add("input",img);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItemShapeMatching_Click(object sender, EventArgs e)
        {
            try
            {
                // reads stop sign file from computer, default template to match uploaded images to
                // will be replaced in future update to custom uploaded form
                // Replaced in Update Image<Bgr, byte> imgTemplate = new Image<Bgr, byte>(@"C:\Users\jessa\Documents\Graduate Classes\Systems Analysis and Design\STOP-sign.jpg");
                // Replaced in Update ApplyShapeMatching(imgTemplate);

                FormShapeMatchParameters form = new FormShapeMatchParameters();
                form.OnShapeMatching += ApplyShapeMatching;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //default threshold for match
        private void ApplyShapeMatching(Image<Bgr, byte> imgTemplate, double threshold = 0.0001, double area=1000, ContoursMatchType matchType = ContoursMatchType.I2)
        {
            try
            {
                if(IMGDict["input"]==null)
                {
                    throw new Exception("Select an Image");
                }


                var img = IMGDict["input"].Clone();
                var imgSource = img.Convert<Gray, byte>()
                    .SmoothGaussian(3)
                    .ThresholdBinaryInv(new Gray(240), new Gray(255));

                var imgTarget = imgTemplate.Convert<Gray, byte>()
                    .SmoothGaussian(3)
                    .ThresholdBinaryInv(new Gray(240), new Gray(255));

                // get contours of source and target images
                var imgSourceContours = CalculateContours(imgSource, area);
                var imgTargetContours = CalculateContours(imgTarget, area);

                if (imgSourceContours.Size == 0 || imgTargetContours.Size == 0)
                {
                    // exception handling for poor image selection
                    throw new Exception("Not enough contours");
                }

                //loops through all contours in image and comparing to target
                for (int i = 0; i < imgSourceContours.Size; i++)
                {
                    var distance = CvInvoke.MatchShapes(imgSourceContours[i], imgTargetContours[0], matchType);

                    if (distance<=threshold)
                    {
                        var rect = CvInvoke.BoundingRectangle(imgSourceContours[i]);
                        img.Draw(rect, new Bgr(0, 255, 0), 4);
                        CvInvoke.PutText(img, distance.ToString("F6"), new Point(rect.X, rect.Y + 20),
                            Emgu.CV.CvEnum.FontFace.HersheyPlain, 3, new MCvScalar(255, 0, 0));
                    }
                }

                pictureBox1.Image = img.ToBitmap();
            }
            catch(Exception ex)
            {
                //
                throw new Exception(ex.Message);
            }
        }

        //calculate contrours, a necessary input for CvInvoke, thresholdarea denotes default size
        private VectorOfVectorOfPoint CalculateContours(Image<Gray, byte> img, double thresholdarea = 1000)
        {
            try
            {
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat h = new Mat();

                CvInvoke.FindContours(img, contours, h, Emgu.CV.CvEnum.RetrType.External,
                    Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                VectorOfVectorOfPoint filteredContours = new VectorOfVectorOfPoint();
                
                // filtering out text using threshholdarea defined in method
                for (int i = 0; i < contours.Size; i++)
                {
                    var area = CvInvoke.ContourArea(contours[i]);
                    if (area >= thresholdarea)
                    {
                        filteredContours.Push(contours[i]);
                    }
                }

                return filteredContours;
            }
            catch (Exception ex)
            {
                //
                throw new Exception(ex.Message);
            }
        }
    }
}
