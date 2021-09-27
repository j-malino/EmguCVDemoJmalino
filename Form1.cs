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

        private void toolStripMenuItemPregnancyTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IMGDict.ContainsKey("Input"))
                {
                    throw new Exception("Read an Image");
                }

                // used for filtering outside of test image area
                double threshold = 300;
                VectorOfVectorOfPoint filteredContours = new VectorOfVectorOfPoint();

                //clone it w/dict key, and smooth to reduce local noise, kernal size 3
                var img = IMGDict["input"].Clone().SmoothGaussian(3);

                //binarize the image
                var binary = img.Convert<Gray, byte>()
                    .ThresholdBinaryInv(new Gray(240), new Gray(255));

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hierachy = new Mat();

                CvInvoke.FindContours(binary, contours, hierachy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                
                // blank used for filtering later
                var output = binary.CopyBlank();

                //Filter out extra contours outside of image
                for (int i = 0; i < contours.Size; i++)
                {
                    var area = CvInvoke.ContourArea(contours[i]);
                    if (area>threshold)
                    {
                        filteredContours.Push(contours[i]);
                        // drawing the contours allows us to adjust threshold
                        //CvInvoke.DrawContours(output, contours, i, new MCvScalar(255), 2);
                    }
                }
                for (int i = 0; i < filteredContours.Size; i++)
                {
                    var bbox = CvInvoke.BoundingRectangle(filteredContours[i]);
                    binary.ROI = bbox;
                    var rects = ProcessParts(binary);
                    binary.ROI = Rectangle.Empty;

                    int count = rects.Count;
                    string msg = "";
                    int margin = 25;
                    MCvScalar color = new MCvScalar(0, 255, 0);

                    switch(count)
                    {
                        case 1:
                            msg = "Invalid"; // case when there is no control line, blank test area
                            color = new MCvScalar(0, 0, 255);
                            break;
                        case 2:
                            if (rects[0].Width*rects[0].Height < rects[1].Width*rects[1].Height)
                            {
                                msg = "Not Pregnant"; // case when there is only control line, no HCG line
                            }
                            else
                            {
                                msg = "Control line absent, HCG line positive, advise re-test"; // No control line but positive HCG line
                            }
                            color = new MCvScalar(0, 0, 255);
                            break;
                        case 3:
                            msg = "Pregnant";
                            color = new MCvScalar(0, 255, 0);
                            break;
                        default:
                            msg = "Invalid";
                            color = new MCvScalar(0, 0, 255);
                            break;
                    }
                    // put the message to the window
                    CvInvoke.PutText(img,msg,new Point(bbox.X + bbox.Width+margin, bbox.Y + margin), FontFace.HersheyPlain, 1.5, color, 2);

                }

                // allow us to look at output to adjust threshold
                pictureBox1.Image = output.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private List<Rectangle> ProcessParts(Image<Gray, byte> img)
        {
            try
            {
                double areaThreshold = 200;
                Rectangle rectangle = Rectangle.Empty;
                img._Not();

                var contours = new VectorOfVectorOfPoint();
                var h = new Mat();
                CvInvoke.FindContours(img,contours, h, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                List<Rectangle> bboxes = new List<Rectangle>();

                for (int i = 0; i <contours.Size; i++)
                {
                    // filters out largest non-test area on left
                    var area = CvInvoke.ContourArea(contours[i]);
                    if (area>areaThreshold)
                    {
                        bboxes.Add(CvInvoke.BoundingRectangle(contours[i]));
                    }
                }
                
                //lambda function
                var sortedBoxes = bboxes.OrderBy(b => b.X).ToList();

                if (sortedBoxes.Count>2)
                {
                    //
                    sortedBoxes.RemoveRange(sortedBoxes.Count - 2, 2);
                }
                else
                {
                    //
                    sortedBoxes.Clear();
                }

                return sortedBoxes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void toolStripMenuItemRotate_Click(object sender, EventArgs e)
        {
            try
            {
                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>()
                    .Rotate(15, new Bgr(255, 255, 255));
                pictureBox1.Image = img.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
