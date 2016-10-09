using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace DianDang

{

    public partial class CapturePicForm : Form

    {

        Pick pick;

        private string mPath;

        public CapturePicForm()

        {
            InitializeComponent();

        }

        private void CapturePicForm_Load(object sender, EventArgs e)

        {

            int left=0;

            int top=0;

            int width=352;

            int height=288;

            pick = new Pick( panelPreview.Handle, left,top,  width, height );

            pick.Start();

        }

        private void b_play_Click(object sender, EventArgs e)

        {
            int left = 0;

            int top = 0;

            int width =352;

            int height = 288; 

            pick = new Pick(panelPreview.Handle, left, top, width, height);

            pick.Start();

        }

        private void b_stop_Click(object sender, EventArgs e)

        {
            pick.Stop();

        }

     

        //protected override void OnClosing(CancelEventArgs e)

        //{
        //    //if (MessageBox.Show("��������?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //    //{

        //    //    CreatePawnForm.g_PhotoPath = mPath;

        //    //    Application.Exit();
        //    //}

        //    //else
        //    //{

        //    //    e.Cancel = true;
        //    //}

        //}

        private void b_pic_Click(object sender, EventArgs e)//����

        {  

            if (this.btnPic.Text == "ץͼ") //���������

            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                btnPic.Text = "����";

                saveFileDialog.Filter = "ͼƬ*.bmp;*.jpg;.jpeg;*.gif|*.bmp|�����ļ�(*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)

                {

                    mPath = saveFileDialog.FileName;

                    pick.GrabImage(mPath);

                    CreatePawnForm.g_PhotoPath = mPath;

                    //picShow.ImageLocation = mPath;  //����ʾ�ڷ�����

                    //picShow.Location = new Point(110, 12);

                    //picShow.Visible = true;

                    //panelPreview.Visible = false;

                    pick.Stop();

                    this.Close();

                }

            }

            else

            {

                btnPic.Text = "ץͼ";

                //picShow.Visible = false;

                //panelPreview.Visible = true;

                pick.Start();

            }

        }

    }

}