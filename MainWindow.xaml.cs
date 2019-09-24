using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace DigiproProjectFirst {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {
        public PlotModel MyModel {
            get; private set;
        }

        public PlotModel MyModel2 {
            get; private set;
        }

        public MainWindow() {
            InitializeComponent();
            MyModel = new PlotModel { Title = "Your Equation", LegendTitle = "Equations" };
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Distance" });
            MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Height" });

            MyModel2 = new PlotModel { Title = "Your Equation", LegendTitle = "Equations" };
            MyModel2.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Distance" });
            MyModel2.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Height" });
        }

        private void AddFileClick(object sender, RoutedEventArgs e) {
            //Button b = sender as Button;
            //b.Content = "Add File Clicked";
            graph();
            graph2();
        }



        


        public double getValue(double x, double y) {
            //return (10 * x * x + 11 * x * y * y + 12 * x * y);
            return System.Math.Sin(5 * x); //this is f(x) = return __
        }
        public double getValue2(double x, double y) {
            //return (10 * x * x + 11 * x * y * y + 12 * x * y);
            return System.Math.Sin(5 * x); //this is f(x) = return __
        }
        

        //setting the values to the function
        public FunctionSeries GetFunction() {
            int n = 100;
            FunctionSeries serie = new FunctionSeries();
            for (double x = 0; x < n; x += 0.1) {
                for (double y = 0; y < n; y += 0.1) {
                    //adding the points based x,y
                    DataPoint data = new DataPoint(x, getValue(x, y));

                    //adding the point to the serie
                    serie.Points.Add(data);
                }
            }
            //returning the serie
            return serie;
        }

        public FunctionSeries GetFunction2() {
            int n = 100;
            FunctionSeries serie = new FunctionSeries();
            for (double x = 0; x < n; x += 0.3) {
                for (double y = 0; y < n; y += 0.3) {
                    //adding the points based x,y
                    DataPoint data = new DataPoint(x, getValue2(x, y));

                    //adding the point to the serie
                    serie.Points.Add(data);
                }
            }
            //returning the serie
            return serie;
        }


        public void graph() {
            MyModel = new PlotModel { Title = "" };
            MyModel.LegendPosition = LegendPosition.RightBottom;
            MyModel.LegendPlacement = LegendPlacement.Outside;
            MyModel.LegendOrientation = LegendOrientation.Horizontal;

            MyModel.Series.Add(GetFunction());
            var Yaxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Minimum = -3, Maximum=3 };
            OxyPlot.Axes.LinearAxis XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = 10 };
            XAxis.Title = "X";
            Yaxis.Title = "Y";
            MyModel.Axes.Add(Yaxis);
            MyModel.Axes.Add(XAxis);
            this.plot.Model = MyModel;
        }

        public void graph2() {
            int n = 10;

            var model = new PlotModel {
                Title = "",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s2 = new ColumnSeries { Title = "Frequency", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };
            var valueAxis = new LinearAxis { Position = AxisPosition.Left, AbsoluteMinimum = 0 };


            for (int i = 0; i < 10; i++) {
                categoryAxis.Labels.Add(i.ToString());
                s2.Items.Add(new ColumnItem { Value = getValue2(i,0) });
            }


            model.Series.Add(s2);
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);


            this.plot2.Model = model;
        }
    }
}
