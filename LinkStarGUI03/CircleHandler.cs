using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KAL_GCS_LINKSTAR_1_0.GUI
{
    public class CircleHandler
    {
        #region Member Variables - Private
        private Canvas mBaseCanvas;
        private Ellipse mEllipse;
        private Point mCenterPoint;
        private double mRadius;
        private double mLineThickness;
        private Brush mLineColor;
        private ImageBrush mInnerImage;
        private double mZindex;
        #endregion  Member Variables - Private


        #region Accessors
        public Canvas MBaseCanvas { get => mBaseCanvas; set => mBaseCanvas = value; }
        public Ellipse MEllipse { get => mEllipse; }
        public double MRadius { get => mRadius; set => mRadius = value; }
        public Point MCenterPoint { get => mCenterPoint; }
        public double MLineThickness { get => mLineThickness; set => mLineThickness = value; }
        public Brush MLineColor { get => mLineColor; set => mLineColor = value; }
        public double MZindex { get => mZindex; }
        #endregion Accessors


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CircleHandler()
        {
            this.mEllipse = new Ellipse();
        }

        /// <summary>
        /// Create an ellipse and set the initial properties
        /// </summary>
        /// <param name="pBaseCanvas"></param>
        /// <param name="pCenterPoint"></param>
        /// <param name="pRadius"></param>
        public CircleHandler(Canvas pBaseCanvas, double pCenterPositionX, double pCenterPositionY, double pRadius, double pLineThickness, Color pLineColor) : this()
        {            
            // Set radius
            this.mRadius = pRadius;
            this.mEllipse.Width = this.mEllipse.Height = mRadius * 2;
            
            // Set main canvas
            this.mBaseCanvas = pBaseCanvas;
            this.mBaseCanvas.Children.Add(this.mEllipse);

            // Set position as center point
            this.mCenterPoint = new Point(pCenterPositionX, pCenterPositionY);
            Canvas.SetLeft(this.mEllipse, mCenterPoint.X - mRadius);
            Canvas.SetTop(this.mEllipse, mCenterPoint.Y - mRadius);

            // Set line color
            this.mLineColor = new SolidColorBrush(pLineColor);
            this.mEllipse.Stroke = mLineColor;

            // Set line thickness
            this.mLineThickness = pLineThickness;
            this.mEllipse.StrokeThickness = mLineThickness;
        }
        #endregion Constructor


        #region Member Methods - Public
        public void SetInnerImage(string pPath)
        {
            this.mInnerImage = new ImageBrush();
            this.mInnerImage.ImageSource = new BitmapImage(new Uri(pPath, UriKind.RelativeOrAbsolute));
            this.mInnerImage.Stretch = Stretch.Fill;
            this.mEllipse.Fill = mInnerImage;
        }

        public void SetZindex(int pIndex)
        {
            this.mZindex = pIndex;
            Canvas.SetZIndex(mEllipse, pIndex);
        }
        public Point GetBoundaryPositionByDegree(Double pDegree, Double pPortion)
        {
            Point rtVal = new Point();            

            double radian = (Math.PI * (pDegree - 90) / 180.0); //I assume the 12 hour direction is degree 0

            rtVal.X = (Math.Cos(radian) * mRadius * pPortion) + mCenterPoint.X;
            rtVal.Y = (Math.Sin(radian) * mRadius * pPortion) + mCenterPoint.Y;
            return rtVal;
        }
        #endregion Member Methods - Public


        #region Member Methods - Private
        
        #endregion Member Methods - Private
    }
}



//private BitmapImage GetBitmapImage(string pPath)
//{
//    BitmapImage rtVal = new BitmapImage();
//    rtVal = new BitmapImage();
//    rtVal.BeginInit();
//    rtVal.CacheOption = BitmapCacheOption.OnLoad;
//    rtVal.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
//    rtVal.UriSource = new Uri(@pPath, UriKind.Relative);
//    rtVal.EndInit();
//    return rtVal;
//}