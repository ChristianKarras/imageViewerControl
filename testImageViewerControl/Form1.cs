namespace testImageViewerControl
{
    public partial class Form1 : Form
    {

        // Class for testeing the image viewer control
       

        // creating some intitial values
        public Form1()
        {
            InitializeComponent();
            createTestImage();
        }

        int sizeX = 800;
        int sizeY = 600;

        int centerX = 300;
        int centerY = 200;

        double sigmaX = 80;
        double sigmaY = 50;

        double[,] testImg;
        double[,] gauss;

        
        void createTestImage()
        {
            testImg = new double[sizeX, sizeY];
            gauss = new double[sizeX, sizeY];
            for (int i = 0; i < testImg.GetLength(0); i++)
            {
                for (int j = 0; j < testImg.GetLength(1); j++)
                {
                    Random rnd = new Random();
                    //testImg[i, j] = parabolaX * (j - centerX) * (j - centerX) + parabolaY * (i - centerY) * (i - centerY) + rnd.NextDouble();
                    testImg[i, j] = (rnd.NextDouble() - 0.5) * 1000;

                    double x = i - centerX;
                    double y = j - centerY;
                    gauss[i, j] = 100 * Math.Exp(-(x * x + y * y) / (sigmaX * sigmaX + sigmaY * sigmaY)) - 20;
                }
            }

        }

        // setting images
        private void button1_Click(object sender, EventArgs e)
        {

            imageViewerControl1.setImage(testImg);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            imageViewerControl1.setImage(gauss);
        }

        // saving images
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Tiff fiel|*.tiff";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageViewerControl1.saveImage(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Tiff, true);
            }

        }


        // rescaling images
        private void button4_Click(object sender, EventArgs e)
        {
            imageViewerControl1.rescale();
        }


        // adding and removing overlays
        private void button5_Click(object sender, EventArgs e)
        {

            if (button5.Text == "Set Some Overlay")
            {
                List<Point> pl = new List<Point>();
                List<Rectangle> rl = new List<Rectangle>();
                List<Rectangle> el = new List<Rectangle>();

                pl.Add(new Point(50, 100));
                pl.Add(new Point(500, 1000));
                el.Add(new Rectangle(200, 300, 10, 20));
                rl.Add(new Rectangle(100, 100, 1000, 1000));
                rl.Add(new Rectangle(100, 100, 200, 300));

                imageViewerControl1.pointOverlays = pl;
                imageViewerControl1.rectOverlays = rl;
                imageViewerControl1.ellipseOverlays = el;
                button5.Text = "Remove Overlay";
            }
            else if (button5.Text == "Remove Overlay")
            {

                imageViewerControl1.pointOverlays = new List<Point>();
                imageViewerControl1.rectOverlays = new List<Rectangle>();
                imageViewerControl1.ellipseOverlays = new List<Rectangle>();
                button5.Text = "Set Some Overlay";
            }
            
        }

        // getting image parameters out
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Compl val at image cursor = " + imageViewerControl1.parameters.cmplxDataValueAtImageCursor.ToString();
        }


        // setting and removeing thresholds
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Set Custom Threshold")
            {
                double ut = imageViewerControl1.parameters.dataSetMax * 0.8;
                double lt = imageViewerControl1.parameters.dataSetMax * 0.2;
                imageViewerControl1.setDisplayThresholds(ut, lt);
                button7.Text = "Remove Threshold";
            }
            else if (button7.Text == "Remove Threshold")
            {
                imageViewerControl1.removeDisplayThresholds();
                button7.Text = "Set Custom Threshold";
            }
        }
    }
}
