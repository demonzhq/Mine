using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Collections;
using System.Reflection;
using System.Windows.Media;

namespace XWindow
{
    public class XWindow: Window
    {
        private List<string> ExceptionList = new List<string>();
        private int RunMode = 0;  //0-Save Default; 1-No Save Default;
        public string SavFileName = "status.sav";
        private PropertyInfo[] ComponuntList;

        public XWindow()
        {
            this.Closing += Xwindow_Closing;
            this.Loaded += Xwindow_Loaded;
        }

        private void Xwindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.ComponuntList = this.GetType().GetProperties();

        }

        private void Xwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                IEnumerator Controls = this.Controls.GetEnumerator();
                XmlDocument Root = new XmlDocument();
                Root.AppendChild(Root.CreateXmlDeclaration("1.0", "utf-8", null));

                XmlElement RootElement = Root.CreateElement("Components");



                CreatAllComponentsXML(this, RootElement, Root);

                Root.AppendChild(RootElement);
                Root.Save(SavFileName);

            }
            catch
            {

            }
        }



        List<object> FindVisualChild(DependencyObject obj)
        {
            try
            {
                List<object> TList = new List<object> { };
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null)
                    {
                        TList.Add(child);
                        List<object> childOfChildren = FindVisualChild(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                    else
                    {
                        List<object> childOfChildren = FindVisualChild(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                }
                return TList;
            }
            catch (Exception ee)
            {
                return null;
            }
        }
    }
}
