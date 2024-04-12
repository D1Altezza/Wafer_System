using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class EdgeDetect
{
    public double cross_Point_X = 0.0, cross_Point_Y = 0.0;


    Point2d ref_Point_Left_Center;
    Point2d ref_Point_Right_Center;
    Mat canny;
    Mat gray;
    Mat blur;



    struct CrossPoint_Detail
    {
        public OpenCvSharp.Point2d CrossPoint { get; set; }
        public LineSegmentPoint Line { get; set; }

    }
    CrossPoint_Detail crossPoint_Detail = new CrossPoint_Detail();
    List<CrossPoint_Detail> CrossPointCollection = new List<CrossPoint_Detail>();

    double minDist = 0;
    int min_index = 0;
    //依圖像尺寸定義    
    //改十字
    LineSegmentPoint lineSegmentPoint_V = new LineSegmentPoint(new OpenCvSharp.Point(800, 0), new OpenCvSharp.Point(800, 1200));
    LineSegmentPoint lineSegmentPoint_H = new LineSegmentPoint(new OpenCvSharp.Point(0, 600), new OpenCvSharp.Point(1600, 600));

    public void define_Img_Area(Bitmap source_img)
    {

        ref_Point_Left_Center = new Point2d(0, source_img.Height / 2);

        ref_Point_Right_Center = new Point2d(source_img.Width, source_img.Height / 2);

    }
    //邊緣檢測
    public Point2d edge(Bitmap sorce_img, string mode)
    {
        define_Img_Area(sorce_img);
        gray = BitmapConverter.ToMat(sorce_img);
        //switch (Point_ID)
        //{
        //    case 1:
        //        Cv2.ImWrite(@"C:\Users\MyUser.MyUser-PC.000\Desktop\point1.jpg", gray);
        //        break;
        //    case 2:
        //        Cv2.ImWrite(@"C:\Users\MyUser.MyUser-PC.000\Desktop\point2.jpg", gray);
        //        break;
        //    case 3:
        //        Cv2.ImWrite(@"C:\Users\MyUser.MyUser-PC.000\Desktop\point3.jpg", gray);
        //        break;
        //}
        blur = new Mat();
        canny = new Mat();
        Cv2.GaussianBlur(gray, blur, new OpenCvSharp.Size(7, 7), 0);
        //Cv2.ImShow("GaussianBlur", blur);
        #region get canny            
        Cv2.Canny(blur, canny, 40, 40 * 3, 3, true);
        Cv2.Canny(blur, canny, 40, 40 * 3, 3, true);
        #endregion

        #region find contours
        OpenCvSharp.Point[][] contours;
        HierarchyIndex[] hierarchyIndexes;

        Cv2.FindContours(
            canny,
            out contours,
            out hierarchyIndexes,
            mode: RetrievalModes.External,
            method: ContourApproximationModes.ApproxSimple);
        #endregion

        var select_refer_Point = new Point2d();
        var select_refer_Line = new LineSegmentPoint();
        switch (mode)
        {

            case "ref_Point_Left_Center":
                select_refer_Point = ref_Point_Left_Center;
                select_refer_Line = lineSegmentPoint_H;
                break;

            case "ref_Point_Right_Center":
                select_refer_Point = ref_Point_Right_Center;
                select_refer_Line = lineSegmentPoint_H;
                break;
        }

        //LineDetection(select_refer_Point, select_refer_Line,ref c_point);
        CrossPointCollection.Clear();
        minDist = 0;
        min_index = 0;

        Cv2.Threshold(canny, gray, 0, 255, ThresholdTypes.Binary);//二值化

        Mat stElem = Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(1, 1));

        LineSegmentPoint[] lineSegmentPoint;
        //lineSegmentPoint = Cv2.HoughLinesP(gray, 0.8, Cv2.PI / 180, 90, 10, 6000);
        lineSegmentPoint = Cv2.HoughLinesP(gray, 0.8, Cv2.PI / 180, 10, 0, 0);


        Cv2.CvtColor(gray, gray, ColorConversionCodes.GRAY2BGR);
        for (int i = 0; i < lineSegmentPoint.Length; i++)
        {
            Cv2.Line(gray, lineSegmentPoint[i].P1, lineSegmentPoint[i].P2, Scalar.RandomColor(), 1, OpenCvSharp.LineTypes.Link8);
            crossPoint_Detail.Line = lineSegmentPoint[i];
            crossPoint_Detail.CrossPoint = CrossPoint(lineSegmentPoint[i], select_refer_Line);
            CrossPointCollection.Add(crossPoint_Detail);

        }

        //Cv2.ImShow("All Line", gray);
        Cv2.ImWrite(@"C:\Users\User\Desktop\test_save.jpg", gray);
        for (int i = 0; i < CrossPointCollection.Count; i++)
        {
            if (CrossPointCollection[i].CrossPoint != new Point2d())
            {
                if (minDist == 0)
                {
                    minDist = CrossPointCollection[i].CrossPoint.DistanceTo(select_refer_Point);
                    min_index = i;
                }
                else if (minDist > CrossPointCollection[i].CrossPoint.DistanceTo(select_refer_Point))
                {
                    minDist = CrossPointCollection[i].CrossPoint.DistanceTo(select_refer_Point);
                    min_index = i;
                }
            }
        }
        if (CrossPointCollection.Count != 0)
        {
            Cv2.Line(gray, CrossPointCollection[min_index].Line.P1, CrossPointCollection[min_index].Line.P2, Scalar.Red, 1, OpenCvSharp.LineTypes.Link8);
            Cv2.Line(gray, lineSegmentPoint_V.P1, lineSegmentPoint_V.P2, Scalar.White, 1, OpenCvSharp.LineTypes.Link8);
            Cv2.Line(gray, lineSegmentPoint_H.P1, lineSegmentPoint_H.P2, Scalar.White, 1, OpenCvSharp.LineTypes.Link8);
            Cv2.Line(gray, select_refer_Line.P1, select_refer_Line.P2, Scalar.Yellow, 1, OpenCvSharp.LineTypes.Link8);
            Cv2.Line(gray, select_refer_Line.P1, select_refer_Line.P2, Scalar.White, 1, OpenCvSharp.LineTypes.Link8);
            var c_point = CrossPointCollection[min_index].CrossPoint;
            cross_Point_X = CrossPointCollection[min_index].CrossPoint.X;
            cross_Point_Y = CrossPointCollection[min_index].CrossPoint.Y;
            return c_point;
        }
        else
        {
            var c_point = new Point2d(0, 0);
            return c_point;
        }
    }

    //線段識別
    public void LineDetection(Point2d Ref_Point, LineSegmentPoint Ref_line, ref Point2d c_point)
    {

    }
    //求交點
    OpenCvSharp.Point2d CrossPoint(OpenCvSharp.LineSegmentPoint line1, OpenCvSharp.LineSegmentPoint line2)
    {
        OpenCvSharp.Point2d pt = new OpenCvSharp.Point();
        // line1's cpmponent
        double X1 = line1.P2.X - line1.P1.X;//b1
        double Y1 = line1.P2.Y - line1.P1.Y;//a1
                                            // line2's cpmponent
        double X2 = line2.P2.X - line2.P1.X;//b2
        double Y2 = line2.P2.Y - line2.P1.Y;//a2
                                            // distance of 1,2
        double X21 = line2.P1.X - line1.P1.X;
        double Y21 = line2.P1.Y - line1.P1.Y;
        // determinant
        double D = Y1 * X2 - Y2 * X1;// a1b2-a2b1
        if (D == 0) return new Point2d();
        // cross point
        pt.X = (X1 * X2 * Y21 + Y1 * X2 * line1.P1.X - Y2 * X1 * line2.P1.X) / D;
        // on screen y is down increased ! 
        pt.Y = -(Y1 * Y2 * X21 + X1 * Y2 * line1.P1.Y - X2 * Y1 * line2.P1.Y) / D;
        // segments intersect.
        if ((Math.Abs(pt.X - line1.P1.X - X1 / 2) <= Math.Abs(X1 / 2)) &&
            (Math.Abs(pt.Y - line1.P1.Y - Y1 / 2) <= Math.Abs(Y1 / 2)) &&
            (Math.Abs(pt.X - line2.P1.X - X2 / 2) <= Math.Abs(X2 / 2)) &&
            (Math.Abs(pt.Y - line2.P1.Y - Y2 / 2) <= Math.Abs(Y2 / 2)))
        {
            return pt;
        }
        return new Point2d();
    }

    public double CalculateCicular(Point2d px1, Point2d px2, Point2d px3)
    {
        double x1, y1, x2, y2, x3, y3;
        double a, b, c, g, e, f;

        x1 = px1.X;
        y1 = px1.Y;
        x2 = px2.X;
        y2 = px2.Y;
        x3 = px3.X;
        y3 = px3.Y;

        e = 2 * (x2 - x1);
        f = 2 * (y2 - y1);
        g = x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1;

        a = 2 * (x3 - x2);
        b = 2 * (y3 - y2);
        c = x3 * x3 - x2 * x2 + y3 * y3 - y2 * y2;
        Point2d center;
        center.X = (g * b - c * f) / (e * b - a * f);
        center.Y = (a * g - c * e) / (a * f - b * e);

        var D = Math.Sqrt((center.X - x1) * (center.X - x1) + (center.Y - y1) * (center.Y - y1)) * 2;
        return D;
    }
    public Point2d point_converter(double radius, double angleDegrees)
    {
        //double radius = 1; // 半徑
        //double angleDegrees = 30; // 角度（30度）

        // 將角度轉換為弧度
        double angleRadians = angleDegrees * Math.PI / 180;

        // 計算直角坐標
        double x = radius * Math.Cos(angleRadians);
        double y = radius * Math.Sin(angleRadians);
        return new Point2d(x, y);
    }
}
