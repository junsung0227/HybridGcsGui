using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KAL_GCS_LINKSTAR_1_0.GUI
{
    public class StatusDiagram
    {
        #region Member Variables - Private
        private Canvas mBaseCanvas;
        private bool mIsInitialized;

        private CircleHandler mCircleLinkStar;
        private CircleHandler mCircleGcs;
        private CircleHandler mCircleEs;
        private CircleHandler mCircleTlog;
        private CircleHandler mCircleDrone1;
        private CircleHandler mCircleDrone2;

        private LineHandler mLineLinkStarToGcs;
        private LineHandler mLineLinkStarToEs;
        private LineHandler mLineLinkStarToTlog;
        private LineHandler mLineLinkStarToDrone1;
        private LineHandler mLineLinkStarToDrone2;

        private LineHandler mLineGcsToLinkStar;
        private LineHandler mLineEsToLinkStar;
        private LineHandler mLineTlogToLinkStar;
        private LineHandler mLineDrone1ToLinkStar;
        private LineHandler mLineDrone2ToLinkStar;
        #endregion Member Variables - Private


        #region Accessors

        #endregion Accessors


        #region Constructor
        /// <summary>
        /// Status Diagram handle
        /// </summary>
        /// <param name="pBaseCanvas">Base canvas component to draw a diagram</param>
        public StatusDiagram(Canvas pBaseCanvas)
        {
            this.mBaseCanvas = pBaseCanvas;
            this.mIsInitialized = false;
        }
        #endregion Constructor


        #region Member Methods - Public
        /// <summary>
        /// Draw initial symbols at the base position
        /// </summary>
        /// <param name="pDroneCount">At this time up to 0, 1, 2 drones can be acceptable</param>
        public void InitializeDiagram(int pDroneCount)
        {
            // Check if already initialized
            if (this.mIsInitialized == true)
                return;

            // Initial Degree from the LinkStar simbol
            int initDegreeGcs = 280;
            int initDegreeEs = 220;
            int initDegreeTlog = 350;
            int initDegreeDrone1 = 65;
            int initDegreeDrone2 = 130;

            // Draw a LinkStar symbol
            mCircleLinkStar = new CircleHandler(mBaseCanvas, mBaseCanvas.ActualWidth / 2, mBaseCanvas.ActualHeight / 2, 80, 10, Color.FromRgb(81, 181, 189));
            mCircleLinkStar.SetInnerImage("pack://application:,,,/Images/KE_Simbol.png");
            mCircleLinkStar.SetZindex(100);

            // Draw a GCS symbol    
            Point subIconCenterPoint;

            subIconCenterPoint = mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeGcs, 3);
            mCircleGcs = new CircleHandler(mBaseCanvas, subIconCenterPoint.X, subIconCenterPoint.Y, 60, 15, Color.FromRgb(81, 181, 189));
            mCircleGcs.SetInnerImage("pack://application:,,,/Images/GCS.png");
            mCircleGcs.SetZindex(90);

            // Draw a ES symbol   
            subIconCenterPoint = mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeEs, 2);
            mCircleEs = new CircleHandler(mBaseCanvas, subIconCenterPoint.X, subIconCenterPoint.Y, 50, 15, Color.FromRgb(81, 181, 189));
            mCircleEs.SetInnerImage("pack://application:,,,/Images/ES_White.png");
            mCircleEs.SetZindex(90);

            // Draw a tLog symbol 
            subIconCenterPoint = mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeTlog, 2.5);
            mCircleTlog = new CircleHandler(mBaseCanvas, subIconCenterPoint.X, subIconCenterPoint.Y, 40, 15, Color.FromRgb(81, 181, 189));
            mCircleTlog.SetInnerImage("pack://application:,,,/Images/tLog.png");
            mCircleTlog.SetZindex(90);

            // Draw a drone symbol 
            subIconCenterPoint = mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeDrone1, 2.5);
            mCircleDrone1 = new CircleHandler(mBaseCanvas, subIconCenterPoint.X, subIconCenterPoint.Y, 60, 15, Color.FromRgb(81, 181, 189));
            mCircleDrone1.SetInnerImage("pack://application:,,,/Images/DroneFront_White.png");
            mCircleDrone1.SetZindex(90);

            // Draw a drone symbol 
            subIconCenterPoint = mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeDrone2, 2);
            mCircleDrone2 = new CircleHandler(mBaseCanvas, subIconCenterPoint.X, subIconCenterPoint.Y, 40, 15, Color.FromRgb(81, 181, 189));
            mCircleDrone2.SetInnerImage("pack://application:,,,/Images/DroneFront_White.png");
            mCircleDrone2.SetZindex(90);

            // Draw a line between from LinkStar to node
            //int initDegreeGcs = 280;
            //int initDegreeEs = 220;
            //int initDegreeTlog = 350;
            //int initDegreeDrone1 = 65;
            //int initDegreeDrone2 = 130;

            this.mLineLinkStarToGcs = new LineHandler(mBaseCanvas, mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeGcs + 4, 0.9), mCircleGcs.GetBoundaryPositionByDegree(initDegreeGcs - 185, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineLinkStarToEs = new LineHandler(mBaseCanvas, mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeEs + 4, 0.9), mCircleEs.GetBoundaryPositionByDegree(initDegreeEs - 185, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineLinkStarToTlog = new LineHandler(mBaseCanvas, mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeTlog + 4, 0.9), mCircleTlog.GetBoundaryPositionByDegree(initDegreeTlog - 185, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineLinkStarToDrone1 = new LineHandler(mBaseCanvas, mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeDrone1 + 4, 0.9), mCircleDrone1.GetBoundaryPositionByDegree(initDegreeDrone1 - 185, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineLinkStarToDrone2 = new LineHandler(mBaseCanvas, mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeDrone2 + 4, 0.9), mCircleDrone2.GetBoundaryPositionByDegree(initDegreeDrone2 - 185, 0.9), 90, 10, Color.FromRgb(81, 181, 189));

            //Draw a line between from node to LinkStar
            this.mLineGcsToLinkStar = new LineHandler(mBaseCanvas, mCircleGcs.GetBoundaryPositionByDegree(initDegreeGcs - 175, 0.9), mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeGcs - 4, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
           // this.mLineEsToLinkStar = new LineHandler(mBaseCanvas, mCircleEs.GetBoundaryPositionByDegree(initDegreeEs - 175, 0.9), mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeEs - 4, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineTlogToLinkStar = new LineHandler(mBaseCanvas, mCircleTlog.GetBoundaryPositionByDegree(initDegreeTlog - 175, 0.9), mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeTlog - 4, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineDrone1ToLinkStar = new LineHandler(mBaseCanvas, mCircleDrone1.GetBoundaryPositionByDegree(initDegreeDrone1 - 175, 0.9), mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeDrone1 - 4, 0.9), 90, 10, Color.FromRgb(81, 181, 189));
            this.mLineDrone2ToLinkStar = new LineHandler(mBaseCanvas, mCircleDrone2.GetBoundaryPositionByDegree(initDegreeDrone2 - 175, 0.9), mCircleLinkStar.GetBoundaryPositionByDegree(initDegreeDrone2 - 4, 0.9), 90, 10, Color.FromRgb(81, 181, 189));

            this.mIsInitialized = true;
        }

        public void SetStatus(bool pTest)
        {
            mLineLinkStarToGcs.SetLineStatus(pTest);
            mLineLinkStarToEs.SetLineStatus(false);
            mLineLinkStarToTlog.SetLineStatus(true);
            mLineLinkStarToDrone1.SetLineStatus(false);
            mLineLinkStarToDrone2.SetLineStatus(true);

            mLineGcsToLinkStar.SetLineStatus(pTest);
            //mLineEsToLinkStar.SetLineStatus(false);
            mLineTlogToLinkStar.SetLineStatus(true);
            mLineDrone1ToLinkStar.SetLineStatus(false);
            mLineDrone2ToLinkStar.SetLineStatus(true);
        }
        #endregion Member Methods - Public


        #region Member Methods - Private

        #endregion Member Methods - Private
    }
}