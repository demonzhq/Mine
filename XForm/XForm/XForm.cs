using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XForm
{
    public class XForm:Form
    {
        private List<string> ExceptionList = new List<string>();
        private int RunMode = 0;  //0-Save Default; 1-No Save Default;
        public string SavFileName = "status.sav";
        public XForm()
        {
            
            this.FormClosing += XForm_FormClosing;
            this.Load += XForm_Load;
        }

        private void XForm_Load(object sender, EventArgs e)
        {
            InitialzeData();
        }

        public void SetSavFile(string File)
        {
            this.SavFileName = File;
        }



        void XForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private object GetControlInstance(object obj, string strControlName)
        {
            IEnumerator Controls = null;//所有控件
            Control c = null;//当前控件
            Object cResult = null;//查找结果
            if (obj.GetType() == this.GetType())//窗体
            {
                Controls = this.Controls.GetEnumerator();
            }
            else//控件
            {
                Controls = ((Control)obj).Controls.GetEnumerator();
            }
            while (Controls.MoveNext())//遍历操作
            {
                c = (Control)Controls.Current;//当前控件
                if (c.HasChildren)//当前控件是个容器
                {
                    if (c.Name == strControlName)
                        return c;
                    cResult = GetControlInstance(c, strControlName);//递归查找
                    if (cResult == null)//当前容器中没有，跳出，继续查找
                        continue;
                    else//找到控件，返回
                        return cResult;
                }
                else if (c.Name == strControlName)//不是容器，同时找到控件，返回
                {
                    return c;
                }
            }
            return null;//控件不存在
        }
        private void CreatAllComponentsXML(object obj, XmlElement RootElement, XmlDocument Root)
        {
            IEnumerator Controls = null;//所有控件
            Control c = null;//当前控件
            if (obj.GetType() == this.GetType())//窗体
            {
                Controls = this.Controls.GetEnumerator();
            }
            else//控件
            {
                Controls = ((Control)obj).Controls.GetEnumerator();
            }
            while (Controls.MoveNext())//遍历操作
            {
                c = (Control)Controls.Current;//当前控件
                if (c.HasChildren)//当前控件是个容器
                {
                    CreatAllComponentsXML(c, RootElement, Root);//递归查找 

                    CreatXML(c, RootElement, Root);
                }
                else
                {
                    CreatXML(c, RootElement, Root);
                }
            }
        }
        public void InitialzeData()
        {
            InitialzeDataFromFile(SavFileName);

        }
        private void CreatXML(object obj, XmlElement RootElement, XmlDocument Root)
        {
            bool XFormSave = true;
            string objType = obj.GetType().ToString();
            string objName = "";
            if (objType == "System.Windows.Forms.TextBox")
                objName = ((System.Windows.Forms.TextBox)obj).Name;
            if (objType == "System.Windows.Forms.NumericUpDown")
                objName = ((NumericUpDown)obj).Name;
            if (objType == "System.Windows.Forms.CheckBox")
                objName = ((System.Windows.Forms.CheckBox)obj).Name;
            if (objType == "System.Windows.Forms.ComboBox")
                objName = ((System.Windows.Forms.ComboBox)obj).Name;
            if (objType == "System.Windows.Forms.DateTimePicker")
                objName = ((System.Windows.Forms.DateTimePicker)obj).Name;
            if (objType == "System.Windows.Forms.RichTextBox")
                objName = ((System.Windows.Forms.RichTextBox)obj).Name;

            
            IEnumerable<string> theExceptionList = from string t in ExceptionList
                                                    where t == objName
                                                    select t;
            if (RunMode == 0)
            {
                XFormSave = true;
                foreach (string t in theExceptionList)
                    XFormSave = false;
            }
            if (RunMode == 1)
            {
                XFormSave = false;
                foreach (string t in theExceptionList)
                    XFormSave = true;
            }

            
                






            if (XFormSave)
            {
                if (objType == "System.Windows.Forms.TextBox")
                {
                    XmlElement theElement = Root.CreateElement("Component");
                    XmlElement theAttributes = Root.CreateElement("Name");

                    theAttributes.InnerText = objName;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Value");
                    theAttributes.InnerText = ((System.Windows.Forms.TextBox)obj).Text;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Type");
                    theAttributes.InnerText = "TextBox";
                    theElement.AppendChild(theAttributes);

                    RootElement.AppendChild(theElement);
                }
                if (objType == "System.Windows.Forms.NumericUpDown")
                {
                    XmlElement theElement = Root.CreateElement("Component");
                    XmlElement theAttributes = Root.CreateElement("Name");
                    theAttributes.InnerText = objName;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Value");
                    theAttributes.InnerText = ((NumericUpDown)obj).Value.ToString();
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Type");
                    theAttributes.InnerText = "NumericUpDown";
                    theElement.AppendChild(theAttributes);

                    RootElement.AppendChild(theElement);
                }
                if (objType == "System.Windows.Forms.CheckBox")
                {
                    XmlElement theElement = Root.CreateElement("Component");
                    XmlElement theAttributes = Root.CreateElement("Name");
                    theAttributes.InnerText = objName;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Value");
                    theAttributes.InnerText = ((System.Windows.Forms.CheckBox)obj).Checked.ToString();
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Type");
                    theAttributes.InnerText = "CheckBox";
                    theElement.AppendChild(theAttributes);

                    RootElement.AppendChild(theElement);
                }
                if (objType == "System.Windows.Forms.ComboBox")
                {
                    XmlElement theElement = Root.CreateElement("Component");
                    XmlElement theAttributes = Root.CreateElement("Name");
                    theAttributes.InnerText = objName;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Value");
                    theAttributes.InnerText = ((System.Windows.Forms.ComboBox)obj).SelectedIndex.ToString();
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Type");
                    theAttributes.InnerText = "ComboBox";
                    theElement.AppendChild(theAttributes);
                    RootElement.AppendChild(theElement);
                }
                if (objType == "System.Windows.Forms.DateTimePicker")
                {
                    XmlElement theElement = Root.CreateElement("Component");
                    XmlElement theAttributes = Root.CreateElement("Name");
                    theAttributes.InnerText = objName;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Value");
                    theAttributes.InnerText = ((System.Windows.Forms.DateTimePicker)obj).Value.ToString();
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Type");
                    theAttributes.InnerText = "DateTimePicker";
                    theElement.AppendChild(theAttributes);
                    RootElement.AppendChild(theElement);

                }
                if (objType == "System.Windows.Forms.RichTextBox")
                {
                    XmlElement theElement = Root.CreateElement("Component");
                    XmlElement theAttributes = Root.CreateElement("Name");
                    theAttributes.InnerText = objName;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Value");
                    theAttributes.InnerText = ((System.Windows.Forms.RichTextBox)obj).Text;
                    theElement.AppendChild(theAttributes);
                    theAttributes = Root.CreateElement("Type");
                    theAttributes.InnerText = "RichTextBox";
                    theElement.AppendChild(theAttributes);
                    RootElement.AppendChild(theElement);

                }
            }

        }

        public void InitialzeDataFromFile(string FileName)
        {
            try
            {
                XmlDocument Root = new XmlDocument();
                Root.Load(FileName);

                XmlNodeList theComponents = Root.GetElementsByTagName("Component");
                foreach (XmlNode q in theComponents)
                {
                    if (q.ChildNodes[2].InnerText == "TextBox")
                    {
                        System.Windows.Forms.TextBox Target = (System.Windows.Forms.TextBox)GetControlInstance(this, q.ChildNodes[0].InnerText);
                        if (Target != null)
                            Target.Text = q.ChildNodes[1].InnerText;
                    }

                    if (q.ChildNodes[2].InnerText == "NumericUpDown")
                    {
                        NumericUpDown Target = (NumericUpDown)GetControlInstance(this, q.ChildNodes[0].InnerText);
                        if (Target != null)
                            Target.Value = Convert.ToInt32(q.ChildNodes[1].InnerText);
                    }
                    if (q.ChildNodes[2].InnerText == "CheckBox")
                    {
                        System.Windows.Forms.CheckBox Target = (System.Windows.Forms.CheckBox)GetControlInstance(this, q.ChildNodes[0].InnerText);
                        if (Target != null)
                            Target.Checked = Convert.ToBoolean(q.ChildNodes[1].InnerText);
                    }
                    if (q.ChildNodes[2].InnerText == "ComboBox")
                    {
                        System.Windows.Forms.ComboBox Target = (System.Windows.Forms.ComboBox)GetControlInstance(this, q.ChildNodes[0].InnerText);
                        if (Target != null)
                            Target.SelectedIndex = Convert.ToInt32(q.ChildNodes[1].InnerText);
                    }
                    if (q.ChildNodes[2].InnerText == "DateTimePicker")
                    {
                        System.Windows.Forms.DateTimePicker Target = (System.Windows.Forms.DateTimePicker)GetControlInstance(this, q.ChildNodes[0].InnerText);
                        if (Target != null)
                            Target.Value = Convert.ToDateTime(q.ChildNodes[1].InnerText);
                    }
                    if (q.ChildNodes[2].InnerText == "RichTextBox")
                    {
                        System.Windows.Forms.RichTextBox Target = (System.Windows.Forms.RichTextBox)GetControlInstance(this, q.ChildNodes[0].InnerText);
                        if (Target != null)
                            Target.Text = q.ChildNodes[1].InnerText;
                    }
                }
            }
            catch
            {

            }
        }


        public void setSaveMode()
        {
            RunMode = 0;
        }


        public void setNoSaveMode()
        {
            RunMode = 1;
        }

        public void addExceptionNode(string Name)
        {
            ExceptionList.Add(Name);
        }

        public void removeExceptionNode(string Name)
        {
            ExceptionList.Remove(Name);
        }
        
    }
}
