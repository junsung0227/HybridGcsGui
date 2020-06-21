using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace KAL_GCS_LINKSTAR_1_0.GUI
{
    public class LineHandler
    {
        #region Member Variables - Private
        private Canvas mBaseCanvas;
        private Line mLine;
        private Point mStartPoint;
        private Point mEndPoint;
        private double mLineThickness;
        private Brush mLineColor;
        private DoubleCollection mLineDash;
        // End arrow shape needed to add here 
        private int mZindex;

        private bool mIsActive;
        private DoubleAnimation daStartPointX;
        private DoubleAnimation daStartPointY;
        #endregion  Member Variables - Private


        #region Accessors
        public Canvas MBaseCanvas { get => mBaseCanvas; set => mBaseCanvas = value; }
        //public Ellipse MEllipse { get => mEllipse; }
        //public double MRadius { get => mRadius; set => mRadius = value; }
        //public Point MCenterPoint { get => mCenterPoint; }
        public double MLineThickness { get => mLineThickness; set => mLineThickness = value; }
        public Brush MLineColor { get => mLineColor; set => mLineColor = value; }
        public double MZindex { get => mZindex; }
        public bool MIsActive { get => mIsActive; }
        #endregion Accessors


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LineHandler()
        {
            this.mLine = new Line();
        }


        /// <summary>
        /// Create a line and set the initial properties
        /// </summary>
        /// <param name="pBaseCanvas"></param>
        public LineHandler(Canvas pBaseCanvas, Point pStartPosition, Point pEndPosition, int pZIndex, double pLineThickness, Color pLineColor) : this()
        {
            // Set main canvas
            this.mBaseCanvas = pBaseCanvas;
            this.mBaseCanvas.Children.Add(this.mLine);

            // Set the line position
            this.mStartPoint = pStartPosition;
            mLine.X1 = this.mStartPoint.X;
            mLine.Y1 = this.mStartPoint.Y;

            this.mEndPoint = pEndPosition;
            mLine.X2 = this.mEndPoint.X;
            mLine.Y2 = this.mEndPoint.Y;

            // Set line color
            this.mLineColor = new SolidColorBrush(pLineColor);
            this.mLine.Stroke = mLineColor;

            // Set line thickness
            this.mLineThickness = pLineThickness;
            this.mLine.StrokeThickness = mLineThickness;

            this.mZindex = pZIndex;
            Canvas.SetZIndex(mLine, this.mZindex);

            this.mIsActive = false;
        }
        #endregion Constructor

        #region Member Methods - Public
        public void SetLineStatus(bool pIsActive)
        {
            if (this.mIsActive == pIsActive)    // Do nothing
                return;

            this.mIsActive = pIsActive;

            if (mIsActive == true)
            {
                // Set line dash
                mLineDash = new DoubleCollection();
                mLineDash.Add(1);
                mLineDash.Add(0);
                mLineDash.Add(0.5);
                this.mLine.StrokeDashArray = mLineDash;

                daStartPointX = new DoubleAnimation(this.mStartPoint.X, this.mEndPoint.X, TimeSpan.FromSeconds(0.3));
                daStartPointY = new DoubleAnimation(this.mStartPoint.Y, this.mEndPoint.Y, TimeSpan.FromSeconds(0.3));

                //daStartPointX.AutoReverse = true;
                //daStartPointY.AutoReverse = true;
                daStartPointX.RepeatBehavior = RepeatBehavior.Forever;
                daStartPointY.RepeatBehavior = RepeatBehavior.Forever;

                this.mLine.BeginAnimation(Line.X1Property, daStartPointX);
                this.mLine.BeginAnimation(Line.Y1Property, daStartPointY);
            }
            else
            {   
                daStartPointX.BeginTime = null; ;
                this.mLine.BeginAnimation(Line.X1Property, daStartPointX);
                daStartPointY.BeginTime = null; ;
                this.mLine.BeginAnimation(Line.Y1Property, daStartPointY);

                //this.mLine.StrokeDashArray = null;
                //mLine.X1 = this.mStartPoint.X;
                //mLine.Y1 = this.mStartPoint.Y;
            }
        }
        #endregion Member Methods - Public
    }
}


//// Change color
//this.mLineColor = new SolidColorBrush(Color.FromScRgb(0, 255, 0, 0));
//this.mLine.Stroke = mLineColor;

//// Just for your referenece
//this.mLine.Stroke.Opacity = 0;

//ColorAnimation ca = new ColorAnimation();

////투명에서 빨간색으로 1초동안 변화되는 애니메이션 정의
//ca.From = Color.FromScRgb(0, 255, 0, 0);                
//ca.To = Color.FromScRgb(100, 255, 0, 0);
//ca.Duration = new Duration(TimeSpan.FromSeconds(0.3));
//ca.AutoReverse = true;
//ca.RepeatBehavior = RepeatBehavior.Forever; // 반복횟수

////등록된 컬러에 애니메이선 시작
//mLineColor.BeginAnimation(SolidColorBrush.ColorProperty, ca);