namespace DianDang
{
    partial class ToolBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBoxForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panelToolBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "金色调-蓝色标题栏-界面_06.png");
            this.imageList.Images.SetKeyName(1, "金色调-蓝色标题栏-界面_06-10.png");
            this.imageList.Images.SetKeyName(2, "金色调-蓝色标题栏-界面_06-12.png");
            this.imageList.Images.SetKeyName(3, "金色调-蓝色标题栏-界面_06-14.png");
            this.imageList.Images.SetKeyName(4, "金色调-蓝色标题栏-界面_06-16.png");
            this.imageList.Images.SetKeyName(5, "zijin.png");
            this.imageList.Images.SetKeyName(6, "yewu.png");
            this.imageList.Images.SetKeyName(7, "dangbiao.png");
            this.imageList.Images.SetKeyName(8, "dangtong.png");
            this.imageList.Images.SetKeyName(9, "yingbiao.png");
            this.imageList.Images.SetKeyName(10, "yingtong.png");
            // 
            // panelToolBox
            // 
            this.panelToolBox.BackColor = System.Drawing.Color.White;
            this.panelToolBox.Location = new System.Drawing.Point(0, 0);
            this.panelToolBox.Name = "panelToolBox";
            this.panelToolBox.Size = new System.Drawing.Size(177, 650);
            this.panelToolBox.TabIndex = 0;
            // 
            // ToolBoxForm
            // 
            this.AutoHidePortion = 175;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(177, 680);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panelToolBox);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolBoxForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panelToolBox;
    }
}