using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ImageFormat = System.Drawing.Imaging.ImageFormat;




namespace testImageViewerControl
{
    /// <summary>
    /// A class for viewing 2 dimensional data sets of type double, Complex or Uint16. 
    /// 
    /// The viewer is desinged as a controll for windows forms
    /// 
    /// The purpose is to have an easy control for viewing (simple) images after certain states of data processing. Hence the image viewer in its current version only supports greyscale images
    /// Control of the image (such as scaling linear / log or and so on can be done via a context menu on the image
    /// For interaction with the program the follwoing funcitons and members of the control are public:
    ///     
    ///     Methods:
    ///         setImage -> sets the image data set
    ///         getImage -> gets the displayed image as bitmap (with or wihout overlays
    ///         saveImage -> Save the image to a file
    ///         setDisplayThresholds -> Externally set the values at which the image will be clipped? (values below will be black or highligted, above are white or highlighted
    ///         removeDisplayThresholds -> Remove externally set display thresholds
    ///         rescale -> rescale the dynamic range of the image to display image range in 256 grey levels between black and white 

    ///     
    /// 
    ///     Members:
    ///         pixelSizeInUmX -> Set the pixelsize of the image to micro meter
    ///         pixelSizeRatioYbX  -> if x and y do have different pixel sizes, you can set the ratio here (default is 1, so same pixelsizes)
    ///         Lists pointOverlays, rectOverlays, ellipseOverlays: these will be shown as overlays in the image
    ///     
    /// NOTE: Scottplot is required to make the imageviewer work. It can be installed to the project via NuGet Package manager or downloaded here:  https://scottplot.net/quickstart/winforms/
    /// Licence of ScottPlot is MIT
    /// </summary>
    public partial class imageViewerControl : UserControl
    {
        public imageViewerControl()
        {
            InitializeComponent();
            // init values here
            OverlayColorStripComboBox1.SelectedIndex = 6;
            toolStripOverlayLineSize.SelectedIndex = 2;
            NumericMax.Maximum = Decimal.MaxValue;
            NumericMax.Minimum = Decimal.MinValue;
            NumericMin.Maximum = Decimal.MaxValue;
            NumericMin.Minimum = Decimal.MinValue;

            // set events here to avoid from disappearing
            trackBar1.Scroll += trackBar1_Scroll;
            NumericMin.ValueChanged += NumericMin_ValueChanged;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.PreviewKeyDown += pictureBox1_PreviewKeyDown;
            CMItemSave.Click += CMItemSave_Click;
            saveInclOverlaysToolStripMenuItem.Click += saveInclOverlaysToolStripMenuItem_Click;
            CMcopytoClipboard.Click += CMcopytoClipboard_Click;
            copyToClipboardInclOverlaysToolStripMenuItem.Click += copyToClipboardInclOverlaysToolStripMenuItem_Click;
            keepAspektRatioToolStripMenuItem.Click += keepAspektRatioToolStripMenuItem_Click;
            autoscaleToolStripMenuItem.Click += autoscaleToolStripMenuItem_Click;
            rescaleToolStripMenuItem.Click += rescaleToolStripMenuItem_Click;
            highlightThresholdedAreasToolStripMenuItem.Click += highlightThresholdedAreasToolStripMenuItem_Click;
            linearToolStripMenuItem.Click += linearToolStripMenuItem_Click;
            logToolStripMenuItem.Click += logToolStripMenuItem_Click;
            centerCursorToolStripMenuItem.Click += centerCursorToolStripMenuItem_Click;
            showCorsairCirclesToolStripMenuItem.Click += showCorsairCirclesToolStripMenuItem_Click;
            simpleToolStripMenuItem.Click += simpleToolStripMenuItem_Click;
            zoomToolStripMenuItem.Click += zoomToolStripMenuItem_Click;
            unzoomToolStripMenuItem.Click += unzoomToolStripMenuItem_Click;
            zoomSelectedAreaToolStripMenuItem.Click += zoomSelectedAreaToolStripMenuItem_Click;
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            OverlayColorStripComboBox1.SelectedIndexChanged += OverlayColorStripComboBox1_SelectedIndexChanged;
            toolStripOverlayLineSize.SelectedIndexChanged += toolStripOverlayLineSize_SelectedIndexChanged;
            CM_cmplxAbs.Click += CM_cmplxAbs_Click;
            CM_cmplxPhase.Click += CM_cmplxPhase_Click;
            CM_cmplxReal.Click += CM_cmplxReal_Click;
            CM_cmplxImag.Click += CM_cmplxImag_Click;
            NumericGamma.ValueChanged += NumericGamma_ValueChanged;
            NumericMax.ValueChanged += NumericMax_ValueChanged;
        }


        #region TODOs
        // TODO:  multidim images (mulitple channels)


        // TODO: Set Colormap (Heat, GW, Cyclic)
        // Handle corsair ring size adaption


        #endregion

        #region global settings parameters (not public)
        // image data information
        private double[,] rawImage = null;
        private Complex[,] cmplxRawImage = null;
        private double[] yPosLineCutInUm;
        private double[] xPosLineCutInUm;
        private double[] yLineCut;
        private double[] xLineCut;
        private static Complex valueAtImageCursorRaw;
        private static Complex valueAtMouseCursorRaw;
        private static Size rawSize = new Size();
        private static PointF pxs = new PointF(1, 1);
        private double pxsRatio = 1;


        // double dispRangeMin;
        // double dispRangeMax;

        private static double rawImageMax = Double.MinValue;
        private static double rawImageMin = Double.MaxValue;
        // sizes of potentially zoomed area of the image (means: only same like raw image dimensions, if not zoomed!) -> size of displayed area will be stored there


        // cursor and selectionss
        private static Point dataCursorCoordinate = new Point(-1, -1);         // image cursor crd in coordinate System of data
        private Point mouseCursorCoordinate = new Point(-1, -1);        // mouse cursor crd in coordinate system of picture box
        private static Point dataMouseCursorCoordinate = new Point(-1, -1);   // mouse cursor crd in coordinate system of data
        private int corsairRingDiameter = 0;
        private int corsairRingCount = 3;
        private static System.Drawing.Rectangle zoomedArea;       // Rect describing the zoom area on the data set (pixel coordinates of data set)
        private static Point selectionStart = new Point(-1, -1);
        private static System.Drawing.Rectangle selection; // Rect describing the selection in the data set - coordinates of image
        private static double displMax;
        private static double displMin;

        // Display settings
        int upperThreasholdColor = Convert.ToInt32("FF0000", 16);
        int lowerThreasholdColor = Convert.ToInt32("0000FF", 16);
        private DISPCOMPLEXCOMPONENT showComplx = DISPCOMPLEXCOMPONENT.ABS;
        private Bitmap imgToShow;
        private Bitmap imageAndOverlays;
        private System.Drawing.Rectangle areaOfDrawnImageInPictureBox;   // Pixels of image
        private double displayRangeUpperThreshold = Double.MaxValue;
        private double displayRangeLowerThreshold = Double.MinValue;
        private DISPLAYMODE mode = DISPLAYMODE.LINEAR;
        private SELECTIONKIND selec = SELECTIONKIND.SIMPLE;
        private double gammaValue = 1;
        private System.Drawing.Color overlayColor = System.Drawing.Color.Blue;
        private int overlayLineSize = 1;
        int nthVal = 10;  // for scaling the display: the nths smallest or largest element of the image crop ->this will be used to define the max and min display range
        private List<System.Drawing.Rectangle> rOL = new List<System.Drawing.Rectangle>();
        private List<System.Drawing.Rectangle> eOL = new List<System.Drawing.Rectangle>();
        private List<System.Drawing.Point> pOL = new List<System.Drawing.Point>();

        // flags
        private bool keepAspectRatio = true;
        private bool showCorsairCircles = false;
        private bool dataIsComplex = false;
        private bool autoScale = false;
        private bool selecting = false;
        private bool _requiresMinMaxBoxUpdat = false;
        private bool showOverlays = true;
        private bool markThresholdedAreas = false;
        private bool _externalThresholdSet = false;
        private bool _imageIsProcessing = false;
        private bool _mouseOnPicturebox = false;

        // locking / threading etc
        private readonly object _lock = new object();

        private class bkgrdWorkerArgs
        {
            internal readonly Complex[,] cmplxData;
            internal readonly double[,] dblData;

            internal bkgrdWorkerArgs(Complex[,] cData, double[,] dData)
            {
                cmplxData = cData;
                dblData = dData;
            }
        }

        // Timing infos
        private static double timeToLoadImageMS = 0;

        /// <summary>
        /// Image Parameter Collection
        /// </summary>
        public imageParameters parameters
        {
            get
            {
                return new imageParameters();
            }
        }



        // depreciated infors
        // double valueAtPixelProcessed;
        //private int imWidth = 0;
        //private int imHeight = 0;
        //private double[,] displayeImageArea = null;

        public class imageParameters
        {
            public imageParameters()
            {
                dataSetSizePixels = rawSize;
                dataSetSizeMicroMeter = new SizeF(rawSize.Width * pxs.X, rawSize.Height * pxs.Y);
                displayedDataSetSizePixels = zoomedArea.Size;
                displayedDataSetSizeMicroMeter = new SizeF(zoomedArea.Width * pxs.X, zoomedArea.Height * pxs.Y);
                pixelSizeMicroMeter = pxs;
                imageCursorCoordinatePixels = dataCursorCoordinate;
                mouseCursorCoordinatePixels = dataMouseCursorCoordinate;
                positionOfSelectionPixels = selection.Location;
                selectionSizePixels = selection.Size;
                selectionSizeMicroMeter = new SizeF(selection.Width * pxs.X, selection.Height * pxs.Y);
                selectionDiagonalPixels = Math.Sqrt(selection.Width * selection.Width + selection.Height * selection.Height);
                selectionDiagonalMicroMeter = Math.Sqrt(selectionSizeMicroMeter.Width * selectionSizeMicroMeter.Width + selectionSizeMicroMeter.Height * selectionSizeMicroMeter.Height);
                dblDataValueAtMouseCursor = valueAtMouseCursorRaw.Real;
                dblDataValueAtImageCursor = valueAtImageCursorRaw.Real;
                cmplxDataValueAtImageCursor = valueAtImageCursorRaw;
                cmplxDataValueAtMouseCursor = valueAtMouseCursorRaw;
                dataSetMax = rawImageMax;
                dataSetMin = rawImageMin;
                displayedDataSetMax = displMax;
                displayedDataSetMin = displMin;
                loadTimeOfImageMicroSeconds = timeToLoadImageMS;
            }


            public Size dataSetSizePixels { get; }
            public SizeF dataSetSizeMicroMeter { get; }
            public Size displayedDataSetSizePixels { get; }
            public SizeF displayedDataSetSizeMicroMeter { get; }

            public PointF pixelSizeMicroMeter { get; }
            public Point imageCursorCoordinatePixels { get; }
            public Point mouseCursorCoordinatePixels { get; }
            public Point positionOfSelectionPixels { get; }
            public Size selectionSizePixels { get; }
            public SizeF selectionSizeMicroMeter { get; }
            public double selectionDiagonalPixels { get; }
            public double selectionDiagonalMicroMeter { get; }
            public double dblDataValueAtMouseCursor { get; }
            public Complex cmplxDataValueAtMouseCursor { get; }
            public double dblDataValueAtImageCursor { get; }
            public Complex cmplxDataValueAtImageCursor { get; }
            public double dataSetMax { get; }
            public double dataSetMin { get; }

            public double displayedDataSetMax { get; }
            public double displayedDataSetMin { get; }

            public double loadTimeOfImageMicroSeconds { get; }

        }

        private enum DISPLAYMODE
        {
            LINEAR,  // DEFAULT
            LOG
        }

        private enum SELECTIONKIND
        {
            SIMPLE,
            ZOOM,
        }

        private enum MOUSESCROLLACTION
        {
            ZOOM,
            RINGSIZE
        }

        private enum DISPCOMPLEXCOMPONENT
        {
            ABS,
            PHASE,
            REAL,
            IMAG

        }

        #endregion


        #region PUBLIC Paramters
        // negative Pixelsizes are not blocked on purpose
        /// <summary>
        /// Pixel size in x direction (2nd dimension of an input array), Negative pixelsizes are allowed on purpose, default is 1
        /// </summary>
        public double pixelSizeInUmX
        {
            set
            { pxs = new PointF((float)value, (float)value * (float)pxsRatio); }
        }
        /// <summary>
        /// The ratio pixelsize in X / pixelsize in Y, default is 1
        /// </summary>
        public double pixelSizeRatioYbyX
        {
            set
            {
                pxsRatio = value;
                pxs = new PointF(pxs.X, pxs.X * (float)value);
            }
        }

        /// <summary>
        /// Set the minimum and maximum thresholds to display the image values larger than maxThreshold and smaller minThreshold will be clipped to those values and highlightet if that option is activated. Remove these thresholds again with removeDisplayThresholds
        /// </summary>
        /// <param name="maxThreshold">Max Threshold</param>
        /// <param name="minThreshold">Min Threshold</param>

        public void setDisplayThresholds(double maxThreshold, double minThreshold)
        {
            displayRangeUpperThreshold = maxThreshold;
            displayRangeLowerThreshold = minThreshold;
            _externalThresholdSet = true;
            updateImage();
        }
        /// <summary>
        /// Remove the thresholding previously set with setDisplayThresholds
        /// </summary>
        public void removeDisplayThresholds()
        {
            if (_externalThresholdSet)
            {
                displayRangeUpperThreshold = Double.MaxValue;
                displayRangeLowerThreshold = Double.MinValue;
                rescale();
                _externalThresholdSet = false;
            }
        }

        /// <summary>
        /// Rescale the intensity of the image
        /// </summary>
        public void rescale()
        {
            _requiresMinMaxBoxUpdat = true;
            updateImage();
        }



        /// <summary>
        /// List of rectangels to be displayed as overlay (in pixels)
        /// </summary>
        public List<System.Drawing.Rectangle> rectOverlays
        {
            set
            {
                rOL = value;
                pictureBox1.Invalidate();
            }

        }

        /// <summary>
        /// List of ellipses to be displayed as overlay (in pixels)
        /// </summary>
        public List<System.Drawing.Rectangle> ellipseOverlays
        {
            set
            {
                eOL = value;
                pictureBox1.Invalidate();
            }
        }
        /// <summary>
        /// List of points to be displayed as overlay (in pixels)
        /// </summary>
        public List<Point> pointOverlays
        {
            set
            {
                pOL = value;
                pictureBox1.Invalidate();
            }
        }
        #endregion


        #region PUBLIC private saving
        /// <summary>
        /// Save the displayed image as image file
        /// </summary>
        /// <param name="savePathWithoutExtension">Path of the image</param>
        /// <param name="format">Format of saving the image</param>
        /// <param name="saveOverlay">Include depcited overlays or not?</param>
        public void saveImage(string savePathWithoutExtension, ImageFormat format, bool saveOverlay)
        {
            if (imgToShow != null)
            {
                FileStream fs = new FileStream(savePathWithoutExtension + "." + format.ToString(), FileMode.OpenOrCreate);
                saveImage(fs, format, saveOverlay);
            }
        }
        /// <summary>
        /// Returns a bitmap of the depicted image
        /// </summary>
        /// <param name="withOverlays">Should the depcited overlays be included in the image or not?</param>
        /// <returns></returns>
        public Bitmap getImage(bool withOverlays)
        {
            if (imgToShow != null)
            {
                if (withOverlays)
                {
                    imageAndOverlays = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(imageAndOverlays, new System.Drawing.Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    return (imageAndOverlays.Clone(areaOfDrawnImageInPictureBox, imageAndOverlays.PixelFormat));
                }
                else
                {
                    return (imgToShow);
                }
            }
            else
                return null;
        }

        private void imgToClipBoard(bool saveOverlay)
        {
            if (imgToShow != null)
            {
                if (saveOverlay)
                {
                    imageAndOverlays = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(imageAndOverlays, new System.Drawing.Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    Clipboard.SetImage(imageAndOverlays.Clone(areaOfDrawnImageInPictureBox, imageAndOverlays.PixelFormat));
                }
                else
                {
                    Clipboard.SetImage(imgToShow);
                }
            }
        }

        private void saveImage(FileStream fs, ImageFormat format, bool saveOverlay)
        {
            try
            {
                if (imgToShow != null)
                {
                    if (saveOverlay)
                    {
                        // only saving the area of interest doesnt work unfortunately
                        imageAndOverlays = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.DrawToBitmap(imageAndOverlays, new System.Drawing.Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                        imageAndOverlays.Clone(areaOfDrawnImageInPictureBox, imageAndOverlays.PixelFormat).Save(fs, format);
                    }
                    else
                        imgToShow.Save(fs, format);


                }
            }
            finally
            {
                fs.Close();
            }

        }



        #endregion



        #region PUBLIC set image data



        /// <summary>
        ///  set the image to display
        /// </summary>
        /// <param name="image"> UINT16 1D array for image</param>
        /// <param name="imageWidth">width in pixels</param>
        /// <param name="imageHeight"> height in pixels</param>
        /// <exception cref="Exception"></exception>
        public void setImage(UInt16[] image, int imageWidth, int imageHeight)
        {

            double px;
            if (imageWidth * imageHeight == image.Length)
            {
                DateTime t1 = DateTime.Now;
                reset(imageWidth, imageHeight);
                dataIsComplex = false;
                for (int i = 0; i < imageHeight; i++)
                {
                    for (int j = 0; j < imageWidth; j++)
                    {
                        px = (double)image[i * imageWidth + j];
                        if (px > rawImageMax) rawImageMax = px;
                        if (px < rawImageMin) rawImageMin = px;
                        rawImage[i, j] = px;
                    }
                }

                updateImage();  // this takes typically 45 ms, so its now shifted to a Backrougnd worker thread
                timeToLoadImageMS = (DateTime.Now - t1).TotalMilliseconds;

            }
            else
            {
                throw new Exception("Image widht and image height do not match image length");
            }

        }
        /// <summary>
        /// set the image to display
        /// </summary>
        /// <param name="image">image data in double</param>
        /// <param name="imageWidth">image width</param>
        /// <param name="imageHeight">image height</param>
        /// <exception cref="Exception"></exception>
        public void setImage(double[] image, int imageWidth, int imageHeight)
        {
            double px;
            if (imageWidth * imageHeight == image.Length)
            {
                DateTime t1 = DateTime.Now;
                reset(imageWidth, imageHeight);
                dataIsComplex = false;
                for (int i = 0; i < imageHeight; i++)
                {
                    for (int j = 0; j < imageWidth; j++)
                    {
                        px = (double)image[i * imageWidth + j];
                        if (px > rawImageMax) rawImageMax = px;
                        if (px < rawImageMin) rawImageMin = px;
                        rawImage[i, j] = px;
                    }
                }
                updateImage();
                timeToLoadImageMS = (DateTime.Now - t1).TotalMilliseconds;
            }
            else
            {
                throw new Exception("Image widht and image height do not match image length");
            }
        }

        /// <summary>
        /// set the image to display
        /// </summary>
        /// <param name="image">image data in Complex</param>
        /// <param name="imageWidth">image width</param>
        /// <param name="imageHeight">image height</param>
        /// <exception cref="Exception"></exception>
        public void setImage(Complex[] image, int imageWidth, int imageHeight)
        {

            if (imageWidth * imageHeight == image.Length)
            {
                DateTime t1 = DateTime.Now;
                Complex px;
                double dblPx;
                reset(imageWidth, imageHeight);
                dataIsComplex = true;
                for (int i = 0; i < imageHeight; i++)
                {
                    for (int j = 0; j < imageWidth; j++)
                    {
                        px = (Complex)image[i * imageWidth + j];
                        cmplxRawImage[i, j] = px;

                    }
                }
                updateImage();
                timeToLoadImageMS = (DateTime.Now - t1).TotalMilliseconds;
            }
            else
            {
                throw new Exception("Image widht and image height do not match image length");
            }

        }


        /// <summary>
        /// set the image to display
        /// </summary>
        /// <param name="image">2d Image data (Uint16)</param>
        public void setImage(UInt16[,] image)
        {
            DateTime t1 = DateTime.Now;
            double px;
            reset(image.GetLength(1), image.GetLength(0));
            dataIsComplex = false;
            for (int i = 0; i < rawSize.Height; i++)
            {
                for (int j = 0; j < rawSize.Width; j++)
                {
                    px = (double)image[i, j];
                    if (px > rawImageMax) rawImageMax = px;
                    if (px < rawImageMin) rawImageMin = px;
                    rawImage[i, j] = px;

                }
            }
            updateImage();
            timeToLoadImageMS = (DateTime.Now - t1).TotalMilliseconds;
        }
        /// <summary>
        /// set the image to display
        /// </summary>
        /// <param name="image">2d Image data (Double)</param>
        public void setImage(double[,] image)
        {
            DateTime t1 = DateTime.Now;
            double px;
            reset(image.GetLength(1), image.GetLength(0));
            dataIsComplex = false;
            for (int i = 0; i < rawSize.Height; i++)
            {
                for (int j = 0; j < rawSize.Width; j++)
                {
                    px = (double)image[i, j];
                    if (px > rawImageMax) rawImageMax = px;
                    if (px < rawImageMin) rawImageMin = px;
                    rawImage[i, j] = px;
                }
            }
            updateImage();
            timeToLoadImageMS = (DateTime.Now - t1).TotalMilliseconds;
        }
        /// <summary>
        /// set the image to display
        /// </summary>
        /// <param name="image">2d Image data (Complex)</param>
        public void setImage(Complex[,] image)
        {
            DateTime t1 = DateTime.Now;
            Complex px;
            double dblPx = 0;
            reset(image.GetLength(1), image.GetLength(0));
            for (int i = 0; i < rawSize.Height; i++)
            {
                for (int j = 0; j < rawSize.Width; j++)
                {
                    px = (Complex)image[i, j];
                    cmplxRawImage[i, j] = px;

                }
            }
            updateImage();
            timeToLoadImageMS = (DateTime.Now - t1).TotalMilliseconds;
        }

        #endregion




        #region utility functions
        private void reset(int imW, int imH)
        {
            rawImage = new double[imH, imW];
            if (rawSize.Width != imW || rawSize.Height != imH)
            {
                rawSize = new Size(imW, imH);
                resetZoom();
                _requiresMinMaxBoxUpdat = true;
            }
            rawImageMax = Double.MinValue;
            rawImageMin = Double.MaxValue;
            //dispAreaMax = Double.MinValue;
            //dispAreaMin = Double.MaxValue;

            if (zoomedArea.Width == 0 && zoomedArea.Height == 0)
            {
                zoomedArea = new System.Drawing.Rectangle(0, 0, imW, imH);
            }
            if (dataCursorCoordinate.X == -1) centerDataCursor();
        }

        private double getCmplxVal(Complex c)
        {
            double v = 0;
            if (showComplx == DISPCOMPLEXCOMPONENT.ABS) v = c.Magnitude;
            if (showComplx == DISPCOMPLEXCOMPONENT.REAL) v = c.Real;
            if (showComplx == DISPCOMPLEXCOMPONENT.IMAG) v = c.Imaginary;
            if (showComplx == DISPCOMPLEXCOMPONENT.PHASE) v = c.Phase;
            return (v);

        }

        #region Cursor and transformation between pictureBox and data
        private void moveDataCursor(int dx, int dy)
        {
            if (dataCursorCoordinate.X != -1)
            {

                int newX = dataCursorCoordinate.X + dx;
                int newY = dataCursorCoordinate.Y + dy;
                if (pointInRect(new Point(newX, newY), zoomedArea))
                    dataCursorCoordinate = new Point(newX, newY);
            }
        }

        private void centerDataCursor()
        {
            dataCursorCoordinate = new Point(zoomedArea.Width / 2 + zoomedArea.X / 2, zoomedArea.Height / 2 + zoomedArea.Y / 2);
        }
        private System.Drawing.Rectangle convDataRectToPictureBoxRect(System.Drawing.Rectangle dataRect)
        {
            Point p1 = new Point(dataRect.X, dataRect.Y);
            Point p2 = new Point(dataRect.X + dataRect.Width, dataRect.Y + dataRect.Height);
            System.Drawing.Rectangle r = rectFromTwoPoints(convDataPointToPictureBoxPoint(p1), convDataPointToPictureBoxPoint(p2));
            return r;
        }

        private Point convImgPointToDataPoint(Point imgPoint)
        {
            Point dPt = new Point(-1, -1);
            if (areaOfDrawnImageInPictureBox.Width != 0 && zoomedArea.Width != 0)
            {
                int ptx = (int)Math.Round((((double)imgPoint.X - (double)areaOfDrawnImageInPictureBox.X) / (double)areaOfDrawnImageInPictureBox.Width * (double)zoomedArea.Width) + (double)zoomedArea.X);
                int pty = (int)Math.Round((((double)imgPoint.Y - (double)areaOfDrawnImageInPictureBox.Y) / (double)areaOfDrawnImageInPictureBox.Height * (double)zoomedArea.Height) + (double)zoomedArea.Y);
                dPt = new Point(ptx, pty);
            }
            return (dPt);
        }

        private Point convDataPointToPictureBoxPoint(Point dataPoint)
        {
            Point pctBxPt = new Point(-1, -1);
            if (areaOfDrawnImageInPictureBox.Width != 0 && zoomedArea.Width != 0)
            {
                int ptx = (int)Math.Round((double)(dataPoint.X - (double)zoomedArea.X) / (double)zoomedArea.Width * (double)areaOfDrawnImageInPictureBox.Width + (double)areaOfDrawnImageInPictureBox.X);
                int pty = (int)Math.Round((double)(dataPoint.Y - (double)zoomedArea.Y) / (double)zoomedArea.Height * (double)areaOfDrawnImageInPictureBox.Height + (double)areaOfDrawnImageInPictureBox.Y);
                pctBxPt = new Point(ptx, pty);
            }
            return (pctBxPt);
        }

        #endregion


        #region Utils for geometrical structures
        private bool pointInRect(Point point, System.Drawing.Rectangle rect)
        {
            return (point.X >= rect.X && point.X < rect.X + rect.Width && point.Y >= rect.Y && point.Y < rect.Y + rect.Height);

        }

        private System.Drawing.Rectangle rectAroundCenter(int xCenter, int yCenter, int width, int height)
        {
            int x0 = xCenter - (int)(Math.Round((double)width / 2));
            int y0 = yCenter - (int)(Math.Round((double)height / 2));
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(x0, y0, width, height);
            return rect;
        }

        private System.Drawing.Rectangle rectFromTwoPoints(Point p1, Point p2)
        {

            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int w = Math.Abs(p1.X - p2.X);
            int h = Math.Abs(p1.Y - p2.Y);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(x, y, w, h);
            return rect;
        }

        #endregion

        #region Pixel transformations
        private int ConvertGt32bppRGB(int Gray) //~8ms pro 640*480 Bild
        {
            return Gray << 8 | Gray << 16 | Gray;
        }

        private double preProcPixel(double value)
        {
            // Convert to correct scaling: Linear, Gamma or logarithmic scale!
            if (mode == DISPLAYMODE.LOG)
            {
                value = value - displayRangeLowerThreshold;
                if (value < 0) value = 0;

                value = Math.Log10(value + 1);
            }
            else if (gammaValue != 1)
            {
                value = (value - displayRangeLowerThreshold) / (displayRangeUpperThreshold - displayRangeLowerThreshold);
                if (value < 0) value = 0;
                if (value > 1) value = 1;
                value = Math.Pow(value, gammaValue);
                value = value * (displayRangeUpperThreshold - displayRangeLowerThreshold) + displayRangeLowerThreshold;
            }
            return (value);
        }

        private int convPixel(double value, double lowerThersh, double upperThresh)
        {
            // convert a double value in the correct int (0..255) for displaying in a bitmap -> actually: To correct color!
            int iVal = 0;
            double _dblRange;
            if (value > upperThresh)
                iVal = markThresholdedAreas ? upperThreasholdColor : ConvertGt32bppRGB(255);
            else if (value < lowerThersh)
                iVal = markThresholdedAreas ? lowerThreasholdColor : ConvertGt32bppRGB(0);
            else
            {
                //_dblRange = dispAreaMax - dispAreaMin;
                iVal = (int)Math.Round((value - lowerThersh) / (upperThresh - lowerThersh) * 255);
                iVal = ConvertGt32bppRGB(iVal);
            }
            return iVal;
        }
        #endregion


        // Find out the rectangular in the picturebox where the image is displayed
        private System.Drawing.Rectangle getAreaOfDrawnImageInPictureBox()
        {

            System.Drawing.Rectangle area;
            if (keepAspectRatio && zoomedArea.Width != 0 && zoomedArea.Height != 0)
            {
                double dataAspect = (double)zoomedArea.Width / (double)zoomedArea.Height;
                double pictureBoxAspect = (double)pictureBox1.ClientRectangle.Width / (double)pictureBox1.ClientRectangle.Height;
                if (dataAspect > pictureBoxAspect)
                {
                    int h = (int)Math.Round(pictureBox1.ClientRectangle.Height * pictureBoxAspect / dataAspect);
                    int posY = (int)Math.Round((double)pictureBox1.ClientRectangle.Height / 2 - h / 2);
                    area = new System.Drawing.Rectangle(0, posY, pictureBox1.ClientRectangle.Width, h);
                }
                else
                {
                    int w = (int)Math.Round(pictureBox1.ClientRectangle.Width * dataAspect / pictureBoxAspect);
                    int posX = (int)Math.Round((double)pictureBox1.ClientRectangle.Width / 2 - w / 2);
                    area = new System.Drawing.Rectangle(posX, 0, w, pictureBox1.ClientRectangle.Height);
                }
            }
            else
            {
                area = pictureBox1.ClientRectangle;
            }
            return area;
        }


        private List<double> makeMinList(List<double> l, double v, int maxLenght)
        {
            int idx = 0;
            // assume l is already full
            if (l.Count >= maxLenght)
            {
                // largest elemtent is on pos 0, smallest element is on last position, so if larger, we don't do anything
                if (v >= l[0]) return l;
                else l.RemoveAt(0);  // kick out largest valeu
            }
            else
            {
                // if list empty set element and return
                if (l.Count == 0)
                {
                    l.Add(v);
                    return l;
                }
            }
            // if not returned here that means: the element has to be sorted in the list (since the list ist not yet full, or the element is too small to be ignored!
            while (true)
            {
                // if end of list -> insert at end and stop
                if (idx == l.Count)
                {
                    l.Add(v); break;
                }
                else if (v >= l[idx])   // not at end, but value is larger or equal than next value in list
                {
                    l.Insert(idx, v);
                    break;
                }
                idx++;
            }
            return l;
        }

        private List<double> makeMaxList(List<double> l, double v, int maxLenght)
        {
            int idx = 0;
            // assume l is already full
            if (l.Count >= maxLenght)
            {
                // smallees elemtent is on pos 0, smallest element is on last position, so if larger, we don't do anything
                if (v <= l[0]) return l;
                else l.RemoveAt(0);  // kick out largest valeu
            }
            else
            {
                // if list empty set element and return
                if (l.Count == 0)
                {
                    l.Add(v);
                    return l;
                }
            }
            // if not returned here that means: the element has to be sorted in the list (since the list ist not yet full, or the element is too small to be ignored!
            while (true)
            {
                // if end of list -> insert at end and stop
                if (idx == l.Count)
                {
                    l.Add(v); break;
                }
                else if (v <= l[idx])   // not at end, but value is larger or equal than next value in list
                {
                    l.Insert(idx, v);
                    break;
                }
                idx++;
            }
            return l;
        }


        #endregion

        #region Definitions for zoomedArea
        private void resetZoom()
        {
            zoomedArea = new System.Drawing.Rectangle(new Point(0, 0), rawSize);
        }

        private void setZoomedArea(System.Drawing.Rectangle r)
        {
            int x, y, w, h;
            x = r.X;
            x = x < 0 ? 0 : x;
            y = r.Y;
            y = y < 0 ? 0 : y;
            w = x + r.Width >= rawSize.Width ? rawSize.Width - x : r.Width;
            w = w < 0 ? 0 : w;
            h = y + r.Height >= rawSize.Height ? rawSize.Height - y : r.Height;
            h = h < 0 ? 0 : h;
            zoomedArea = new System.Drawing.Rectangle(x, y, w, h);
        }


        #endregion


        #region Data Retrieval from Raw Images

        private Complex getValueAtDataSetCoordinate(Point crd)
        {
            try
            {
                Complex v = dataIsComplex ? cmplxRawImage[crd.Y, crd.X] : new Complex(rawImage[crd.Y, crd.X], 0);
                return v;
            }
            catch (Exception e) { return (new Complex(0, 0)); }
        }

        private void extractLineCutsFromDisplayedImage(Complex[,] _cmplRaw, double[,] _dblRaw)
        {
            int _cursorX = 0;
            int _cursorY = 0;
            int _zoomW = 0;
            int _zoomH = 0;
            int _zoomX = 0;
            int _zoomY = 0;
            Interlocked.Exchange(ref _cursorX, dataCursorCoordinate.X);
            Interlocked.Exchange(ref _cursorY, dataCursorCoordinate.Y);
            Interlocked.Exchange(ref _zoomX, zoomedArea.X);
            Interlocked.Exchange(ref _zoomY, zoomedArea.Y);
            Interlocked.Exchange(ref _zoomW, zoomedArea.Width);
            Interlocked.Exchange(ref _zoomH, zoomedArea.Height);

            lock (_lock)
            {
                // todo lock this ressource
                //if (pointInRect(dataCursorCoordinate, zoomedArea))
                Point _cu = new Point(_cursorX, _cursorY);
                Rectangle _zo = new Rectangle(_zoomX, _zoomY, _zoomW, _zoomH);
                if (pointInRect(_cu, _zo))
                {
                    xLineCut = new double[_zo.Width];
                    xPosLineCutInUm = new double[_zo.Width];
                    yLineCut = new double[_zo.Height];
                    yPosLineCutInUm = new double[_zo.Height];

                    valueAtImageCursorRaw = getValueAtDataSetCoordinate(_cu);
                    for (int i = 0; i < _zo.Width; i++)
                    {

                        xLineCut[i] = dataIsComplex ? getCmplxVal(_cmplRaw[_cu.Y, i + _zo.X]) : _dblRaw[_cu.Y, i + _zo.X];
                        xPosLineCutInUm[i] = (i + _zo.X) * pxs.X;
                    }
                    for (int i = 0; i < _zo.Height; i++)
                    {
                        yLineCut[i] = dataIsComplex ? getCmplxVal(_cmplRaw[i + _zo.Y, _cu.X]) : _dblRaw[i + _zo.Y, _cu.X];
                        yPosLineCutInUm[i] = (i + _zo.Y) * pxs.Y; ;
                    }
                }
            }

        }


        private double[,] extractDisplayedDataFromRaw(Complex[,] _cmplRaw, double[,] _dblRaw)
        {
            double px;
            double[,] displayeImageArea = new double[zoomedArea.Height, zoomedArea.Width];

            List<double> minVal = new List<double>();
            List<double> maxVal = new List<double>();
            lock (_lock)
            {

                if (dataIsComplex && _cmplRaw != null)
                {
                    try
                    {
                        for (int i = 0; i < zoomedArea.Height; i++)
                        {
                            for (int j = 0; j < zoomedArea.Width; j++)
                            {
                                px = getCmplxVal(_cmplRaw[i + zoomedArea.Y, j + zoomedArea.X]);
                                minVal = makeMinList(minVal, px, nthVal);
                                maxVal = makeMaxList(maxVal, px, nthVal);
                                displayeImageArea[i, j] = preProcPixel(px);

                            }
                        }
                    }
                    catch (Exception e) { }
                }
                else if (_dblRaw != null)
                {
                    //Console.WriteLine("_dblRaw Größe {0}, zoomed area: {1}", _dblRaw.Length,zoomedArea.ToString());
                    try
                    {
                        for (int i = 0; i < zoomedArea.Height; i++)
                        {
                            for (int j = 0; j < zoomedArea.Width; j++)
                            {
                                px = _dblRaw[i + zoomedArea.Y, j + zoomedArea.X];
                                minVal = makeMinList(minVal, px, nthVal);
                                maxVal = makeMaxList(maxVal, px, nthVal);
                                displayeImageArea[i, j] = preProcPixel(px);
                            }
                        }
                    }
                    catch (Exception e) { }

                }

                if (minVal.Count > 0 && maxVal.Count > 0)
                {
                    if (autoScale || _requiresMinMaxBoxUpdat)
                    {
                        displayRangeLowerThreshold = minVal[0];
                        displayRangeUpperThreshold = maxVal[0];
                    }
                    displMax = maxVal.Last();
                    displMin = minVal.Last();
                }
            }
            return displayeImageArea;
        }

        #endregion




        #region Handle Bitmaps for display


        private int[] rawToImgBuf(double[,] input)
        {
            double lt = preProcPixel(displayRangeLowerThreshold);
            double ut = preProcPixel(displayRangeUpperThreshold);

            if (input == null)
                return (null);
            else
            {
                // prepare image display
                ;

                int[] buf = new int[input.Length];

                // fill buffer and lineCuts
                for (int i = 0; i < input.GetLength(0); i++)
                {
                    for (int j = 0; j < input.GetLength(1); j++)
                    {

                        // scale and fill buffer
                        buf[i * input.GetLength(1) + j] = convPixel(input[i, j], lt, ut);

                    }
                }

                return (buf);

            }
        }

        private Bitmap imgBufToBmp(int[] _buf, int _width, int _height)
        {
            if (_buf == null) return null;
            BitmapData bd;
            Bitmap returnBitMap = new Bitmap(_width, _height, PixelFormat.Format32bppPArgb);
            bd = returnBitMap.LockBits(new System.Drawing.Rectangle(0, 0, _width, _height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            if (_buf.Length == _width * _height) { Marshal.Copy(_buf, 0, bd.Scan0, (int)_buf.Length); }

            returnBitMap.UnlockBits(bd);
            bd = null;
            return (returnBitMap);
        }

        #endregion



        #region drawing of the picture box
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen overlayPen1 = new Pen(System.Drawing.Color.Yellow, 1);  // for highlighting fixed overlays in image
            Pen overlayPen2 = new Pen(System.Drawing.Color.Red, 1);     // for highlighting mouse active things
            Pen overlayPen3 = new Pen(overlayColor, overlayLineSize);   // Pen for external overlays

            if (imgToShow != null)
            {
                Point imageCursorCoordinate = new Point(-1, -1);        // image cursor crd in coordinate system of picture box    
                areaOfDrawnImageInPictureBox = getAreaOfDrawnImageInPictureBox();

                // image drawing
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(imgToShow, areaOfDrawnImageInPictureBox);

                // draw image cursore lines lines
                imageCursorCoordinate = convDataPointToPictureBoxPoint(dataCursorCoordinate);
                e.Graphics.DrawLine(overlayPen1, areaOfDrawnImageInPictureBox.Left, imageCursorCoordinate.Y, areaOfDrawnImageInPictureBox.Right, imageCursorCoordinate.Y);
                e.Graphics.DrawLine(overlayPen1, imageCursorCoordinate.X, areaOfDrawnImageInPictureBox.Top, imageCursorCoordinate.X, areaOfDrawnImageInPictureBox.Bottom);
                // draw corsair Rings
                if (showCorsairCircles)
                {
                    corsairRingDiameter = (int)((double)Math.Min(areaOfDrawnImageInPictureBox.Width, areaOfDrawnImageInPictureBox.Height) * 0.5);
                    for (int diameter = (int)((double)corsairRingDiameter / (double)corsairRingCount); diameter < corsairRingDiameter; diameter += (int)((double)corsairRingDiameter / (double)corsairRingCount))
                        e.Graphics.DrawEllipse(overlayPen1, rectAroundCenter(imageCursorCoordinate.X, imageCursorCoordinate.Y, diameter, diameter));
                }
                // draw selection
                if (selec == SELECTIONKIND.SIMPLE && selection.Width > 0 && selection.Height > 0)
                {
                    Point p1 = convDataPointToPictureBoxPoint(new Point(selection.X, selection.Y));
                    Point p2 = convDataPointToPictureBoxPoint(new Point(selection.X + selection.Width, selection.Y + selection.Height));
                    e.Graphics.DrawRectangle(overlayPen1, rectFromTwoPoints(p1, p2));

                }

                // externally added overlays
                if (showOverlays)
                {
                    foreach (Point p in pOL)
                    {
                        Point _p = convDataPointToPictureBoxPoint(p);
                        e.Graphics.DrawLine(overlayPen3, new Point(_p.X, _p.Y - 10), new Point(_p.X, _p.Y + 10));
                        e.Graphics.DrawLine(overlayPen3, new Point(_p.X - 10, _p.Y), new Point(_p.X + 10, _p.Y));
                    }
                    foreach (System.Drawing.Rectangle r in rOL)
                    {
                        e.Graphics.DrawRectangle(overlayPen3, convDataRectToPictureBoxRect(r));
                    }
                    foreach (System.Drawing.Rectangle elps in eOL)
                    {

                        e.Graphics.DrawEllipse(overlayPen3, convDataRectToPictureBoxRect(elps));
                    }
                }

                // draw cursor corsair of mouse
                if (mouseCursorCoordinate.X >= 0)
                {
                    e.Graphics.DrawLine(overlayPen2, areaOfDrawnImageInPictureBox.Left, mouseCursorCoordinate.Y, areaOfDrawnImageInPictureBox.Right, mouseCursorCoordinate.Y);
                    e.Graphics.DrawLine(overlayPen2, mouseCursorCoordinate.X, areaOfDrawnImageInPictureBox.Top, mouseCursorCoordinate.X, areaOfDrawnImageInPictureBox.Bottom);

                    if (selecting)
                    {
                        e.Graphics.DrawRectangle(overlayPen2, rectFromTwoPoints(selectionStart, mouseCursorCoordinate));
                    }
                }
                updatePlots();
                updateInfoTable();


                // draw Line Cuts


                //Console.WriteLine("Painting");
                //label1.Text = min.ToString(); 

                // only keep focus on picturebox if mouse is on
                if (_mouseOnPicturebox) pictureBox1.Focus();
            }


        }

        #region convToStrings
        private string valToString(double val)
        {
            return (string.Format("{0:#.###E+0}", val));
        }
        private string valToStringSimple(double val)
        {
            return (string.Format("{0:0.000}", val));
        }
        private string valToString(Complex val)
        {
            if (val.Imaginary == 0)
            {
                return (string.Format("{0:#.###E+0}", val.Real));
            }
            else
            {
                return (string.Format("{0:#.###E+0}", val.Real) + " + i" + string.Format("{0:#.###E+0}", val.Imaginary) + "(Abs = " + string.Format("{0:#.###E+0}", val.Magnitude) + " Phi = " + string.Format("{0:0.000}", val.Phase) + ")");
            }
        }
        private string valToString(int val)
        {
            return (val.ToString());
        }
        private string rectToString(System.Drawing.Rectangle rect)
        {
            double dpx = Math.Sqrt(rect.Width * rect.Width + rect.Height * rect.Height);
            double dum = Math.Sqrt(rect.Width * rect.Width * pxs.X * pxs.X + rect.Height * rect.Height * pxs.Y * pxs.Y);
            string s = "W = " + rect.Width.ToString() + " (" + string.Format("{0:0.000}", rect.Width * pxs.X) + ")" + " H = " + rect.Height.ToString() + " (" + string.Format("{0:0.000}", rect.Height * pxs.Y) + ")" + " D = " + string.Format("{0:0.000}", dpx) + " (" + string.Format("{0:0.000}", dum) + ")";
            return s;

        }

        private string posToString(Point pos)
        {
            return ("X = " + pos.X.ToString() + " Y = " + pos.Y.ToString());
        }
        private string posToString(PointF pos)
        {
            return ("X = " + string.Format("{0:0.000}", pos.X) + " Y = " + string.Format("{0:0.000}", pos.Y));
        }
        #endregion

        private void updateInfoTable()
        {
            imageParameters p = parameters;
            string[] cursorVal = new string[1];
            string[] selectionInfo = new string[3];
            cursorVal[0] = posToString(p.mouseCursorCoordinatePixels);
            if (selecting)
            {

                System.Drawing.Rectangle _r = rectFromTwoPoints(convImgPointToDataPoint(selectionStart), convImgPointToDataPoint(mouseCursorCoordinate));
                cursorVal[0] += "\t" + rectToString(_r) + "\t";
            }
            cursorVal[0] += "\t" + valToString(p.cmplxDataValueAtMouseCursor);
            textBoxCursorInfo.Lines = cursorVal;

            selectionInfo[0] = "PXS [um]: " + posToString(p.pixelSizeMicroMeter);
            if (selection.Width > 0)
            {
                selectionInfo[1] = "Pos:  " + posToString(selection.Location);
                selectionInfo[2] = "Size: " + rectToString(selection);
            }

            textBoxSelectionInfo.Lines = selectionInfo;
            textBoxFrameLoadTime.Text = "Frame Load [ms] = " + valToStringSimple(p.loadTimeOfImageMicroSeconds);


        }

        private void updatePlots()
        {
            /*
            PlotFormX.Plot.Clear();
            //PlotFormX.Plot.Add.SignalXY(xPosOfPixels, xCutDataProcessed);
            PlotFormX.Plot.Add.Scatter<double, double>(xPosLineCutInUm, xLineCut);
            PlotFormX.Plot.Axes.AutoScaleX();
            PlotFormX.Plot.Axes.AutoScaleY();
            PlotFormX.Refresh();
            PlotFormY.Plot.Clear();
            //PlotFormY.Plot.Add.SignalXY(yCutDataProcessed, yPosOfPixels);
            PlotFormY.Plot.Add.Scatter<double, double>(yLineCut, yPosLineCutInUm);
            PlotFormY.Plot.Axes.AutoScaleX();
            PlotFormY.Plot.Axes.AutoScaleY();
            PlotFormY.Refresh();
            */
        }

        // updates entire image that is displaye (including image data) -> done in background worker to not block gui
        private void updateImage()
        {

            if (!_imageIsProcessing)
            {
                _imageIsProcessing = true;
                backgroundWorker1.RunWorkerAsync(new bkgrdWorkerArgs(cmplxRawImage, rawImage));
            }
        }

        //int[] computeImageInBackground(Complex[,] _cmpImg, double[,] _dblImg, BackgroundWorker worker, DoWorkEventArgs e)
        int[] computeImageInBackground(bkgrdWorkerArgs b)
        {
            extractLineCutsFromDisplayedImage(b.cmplxData, b.dblData);
            int[] buf = rawToImgBuf(extractDisplayedDataFromRaw(b.cmplxData, b.dblData));
            return buf;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            e.Result = computeImageInBackground((bkgrdWorkerArgs)e.Argument);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _imageIsProcessing = false;
            if (e.Error != null)
            {
                textBoxSelectionInfo.Text = "Error loading image: " + e.Error.Message;
            }
            else
            {
                imgToShow = imgBufToBmp((int[])e.Result, zoomedArea.Width, zoomedArea.Height);
                if (autoScale || _requiresMinMaxBoxUpdat && imgToShow != null)
                {
                    _requiresMinMaxBoxUpdat = false;
                    NumericMax.Value = (decimal)displayRangeUpperThreshold;
                    NumericMin.Value = (decimal)displayRangeLowerThreshold;
                }
                valueAtMouseCursorRaw = getValueAtDataSetCoordinate(dataMouseCursorCoordinate);
                pictureBox1.Invalidate();
            }

        }


        #endregion



        #region GUI  
        #region GUI - MOUSE AND KEYBOARD INTERACTION

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pointInRect(e.Location, areaOfDrawnImageInPictureBox))
            {
                dataCursorCoordinate = convImgPointToDataPoint(e.Location);
                extractLineCutsFromDisplayedImage(cmplxRawImage, rawImage);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (pointInRect(e.Location, areaOfDrawnImageInPictureBox))
            {
                mouseCursorCoordinate = e.Location;
                dataMouseCursorCoordinate = convImgPointToDataPoint(e.Location);
                valueAtMouseCursorRaw = getValueAtDataSetCoordinate(dataMouseCursorCoordinate);
                pictureBox1.Invalidate();
            }

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            mouseCursorCoordinate = new Point(-1, -1);
            dataMouseCursorCoordinate = new Point(-1, -1);
            _mouseOnPicturebox = false;
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            _mouseOnPicturebox = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointInRect(e.Location, areaOfDrawnImageInPictureBox))
            {
                selectionStart = e.Location;
                selecting = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            selecting = false;
            if (e.Button == MouseButtons.Left)
            {
                selection = rectFromTwoPoints(convImgPointToDataPoint(selectionStart), convImgPointToDataPoint(e.Location));
                if (selection.Width == 0 || selection.Height == 0) selection = new System.Drawing.Rectangle();
                else if (selec == SELECTIONKIND.ZOOM)
                {
                    setZoomedArea(selection);
                    updateImage();
                }
                // TODO: why no pictureBox.Invalidated funcion here?
            }

        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { moveDataCursor(-1, 0); }
            if (e.KeyCode == Keys.Right) { moveDataCursor(1, 0); }
            if (e.KeyCode == Keys.Up) { moveDataCursor(0, -1); }
            if (e.KeyCode == Keys.Down) { moveDataCursor(0, 1); }
            extractLineCutsFromDisplayedImage(cmplxRawImage, rawImage);
            pictureBox1.Invalidate();

        }

        #endregion

        #region GUI - Picture Box Context Menu

        private void rescaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rescale();
        }
        private void keepAspektRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = keepAspektRatioToolStripMenuItem.Checked ? PictureBoxSizeMode.StretchImage : PictureBoxSizeMode.Zoom;
            keepAspectRatio = !keepAspektRatioToolStripMenuItem.Checked;
            keepAspektRatioToolStripMenuItem.Checked = !keepAspektRatioToolStripMenuItem.Checked;
        }

        private void showCorsairCirclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showCorsairCircles = !showCorsairCirclesToolStripMenuItem.Checked;
            showCorsairCirclesToolStripMenuItem.Checked = !showCorsairCirclesToolStripMenuItem.Checked;
        }

        private void CMcopytoClipboard_Click(object sender, EventArgs e)
        {
            imgToClipBoard(false);
        }
        private void copyToClipboardInclOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgToClipBoard(true);
        }
        private void saveInclOverlaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgToShow != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Tiff Image|*.tiff|JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
                saveFileDialog1.Title = "Save Image To File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            saveImage(fs, ImageFormat.Tiff, true);
                            break;
                        case 2:
                            saveImage(fs, ImageFormat.Jpeg, true);
                            break;

                        case 3:
                            saveImage(fs, ImageFormat.Bmp, true);
                            break;

                        case 4:
                            saveImage(fs, ImageFormat.Png, true);
                            break;


                    }

                }

            }
        }

        private void CMItemSave_Click(object sender, EventArgs e)
        {
            if (imgToShow != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Tiff Image|*.tiff|JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
                saveFileDialog1.Title = "Save Image To File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            saveImage(fs, ImageFormat.Tiff, false);
                            break;
                        case 2:
                            saveImage(fs, ImageFormat.Jpeg, false);
                            break;

                        case 3:
                            saveImage(fs, ImageFormat.Bmp, false);
                            break;

                        case 4:
                            saveImage(fs, ImageFormat.Png, false);
                            break;

                    }

                }

            }
        }

        private void CM_cmplxAbs_Click(object sender, EventArgs e)
        {
            showComplx = DISPCOMPLEXCOMPONENT.ABS;
            CM_cmplxAbs.Checked = true;
            CM_cmplxImag.Checked = false;
            CM_cmplxPhase.Checked = false;
            CM_cmplxReal.Checked = false;
            updateImage();
        }

        private void CM_cmplxPhase_Click(object sender, EventArgs e)
        {
            showComplx = DISPCOMPLEXCOMPONENT.PHASE;
            CM_cmplxAbs.Checked = false;
            CM_cmplxImag.Checked = false;
            CM_cmplxPhase.Checked = true;
            CM_cmplxReal.Checked = false;
            updateImage();
        }

        private void CM_cmplxReal_Click(object sender, EventArgs e)
        {
            showComplx = DISPCOMPLEXCOMPONENT.REAL;
            CM_cmplxAbs.Checked = false;
            CM_cmplxImag.Checked = false;
            CM_cmplxPhase.Checked = false;
            CM_cmplxReal.Checked = true;
            updateImage();
        }

        private void CM_cmplxImag_Click(object sender, EventArgs e)
        {
            showComplx = DISPCOMPLEXCOMPONENT.IMAG;
            CM_cmplxAbs.Checked = false;
            CM_cmplxImag.Checked = true;
            CM_cmplxPhase.Checked = false;
            CM_cmplxReal.Checked = false;
            updateImage();
        }

        private void centerCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            centerDataCursor();
        }

        private void autoscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoscaleToolStripMenuItem.Checked)
            {
                autoscaleToolStripMenuItem.Checked = false;
                autoScale = false;
            }
            else
            {
                autoscaleToolStripMenuItem.Checked = true;
                autoScale = true;
                NumericMax.Value = (decimal)displayRangeUpperThreshold;
                NumericMin.Value = (decimal)displayRangeLowerThreshold;
            }
            NumericMin.Enabled = !autoScale;
            NumericMax.Enabled = !autoScale;
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleToolStripMenuItem.Checked = true;
            zoomToolStripMenuItem.Checked = false;
            selec = SELECTIONKIND.SIMPLE;

        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleToolStripMenuItem.Checked = false;
            zoomToolStripMenuItem.Checked = true;
            selec = SELECTIONKIND.ZOOM;
        }

        private void zoomSelectedAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selection.Width > 0 && selection.Height > 0)
            {

                setZoomedArea(selection);
                updateImage();
            }
        }

        private void unzoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetZoom();
            updateImage();
        }

        private void linearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearToolStripMenuItem.Checked = true;
            logToolStripMenuItem.Checked = false;
            mode = DISPLAYMODE.LINEAR;
            NumericGamma.Enabled = true;
            trackBar1.Enabled = true;
            updateImage();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearToolStripMenuItem.Checked = false;
            logToolStripMenuItem.Checked = true;
            mode = DISPLAYMODE.LOG;
            NumericGamma.Enabled = false;
            trackBar1.Enabled = false;
            updateImage();
        }

        private void OverlayColorStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OverlayColorStripComboBox1.SelectedIndex == 0) overlayColor = System.Drawing.Color.Blue;
            if (OverlayColorStripComboBox1.SelectedIndex == 1) overlayColor = System.Drawing.Color.Red;
            if (OverlayColorStripComboBox1.SelectedIndex == 2) overlayColor = System.Drawing.Color.Yellow;
            if (OverlayColorStripComboBox1.SelectedIndex == 3) overlayColor = System.Drawing.Color.Green;
            if (OverlayColorStripComboBox1.SelectedIndex == 4) overlayColor = System.Drawing.Color.LightBlue;
            if (OverlayColorStripComboBox1.SelectedIndex == 5) overlayColor = System.Drawing.Color.HotPink;
            if (OverlayColorStripComboBox1.SelectedIndex == 6) overlayColor = System.Drawing.Color.Violet;


            pictureBox1.Invalidate();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOverlays = !showToolStripMenuItem.Checked;
            showToolStripMenuItem.Checked = !showToolStripMenuItem.Checked;

        }

        private void toolStripOverlayLineSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripOverlayLineSize.SelectedIndex == 0) overlayLineSize = 1;
            if (toolStripOverlayLineSize.SelectedIndex == 1) overlayLineSize = 2;
            if (toolStripOverlayLineSize.SelectedIndex == 2) overlayLineSize = 3;
            if (toolStripOverlayLineSize.SelectedIndex == 3) overlayLineSize = 5;
            if (toolStripOverlayLineSize.SelectedIndex == 4) overlayLineSize = 10;
            pictureBox1.Invalidate();
        }

        private void highlightThresholdedAreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markThresholdedAreas = !highlightThresholdedAreasToolStripMenuItem.Checked;
            highlightThresholdedAreasToolStripMenuItem.Checked = !highlightThresholdedAreasToolStripMenuItem.Checked;
            updateImage();
        }

        #endregion

        #region GUI - Min Max and Gamma

        private void NumericMin_ValueChanged(object sender, EventArgs e)
        {

            displayRangeLowerThreshold = NumericMin.Value < NumericMax.Value ? (double)NumericMin.Value : (double)NumericMax.Value;
            updateImage();

        }

        private void NumericMax_ValueChanged(object sender, EventArgs e)
        {
            displayRangeUpperThreshold = NumericMin.Value < NumericMax.Value ? (double)NumericMax.Value : (double)NumericMin.Value; ;
            updateImage();
        }

        private void NumericGamma_ValueChanged(object sender, EventArgs e)
        {
            gammaValue = (double)NumericGamma.Value;
            int tbVal = (int)Math.Round(Math.Log10(gammaValue) * 100);
            tbVal = Math.Min(tbVal, trackBar1.Maximum);
            tbVal = Math.Max(tbVal, trackBar1.Minimum);
            trackBar1.Value = tbVal;
            updateImage();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gammaValue = Math.Pow(10, (double)trackBar1.Value / 100);
            NumericGamma.Value = (decimal)Math.Round(gammaValue, 3);
            updateImage();
        }








        #endregion

        #endregion



    }
}
