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
            this.imageList.Images.SetKeyName(0, "jiandang.bmp");
            this.imageList.Images.SetKeyName(1, "shudang.bmp");
            this.imageList.Images.SetKeyName(2, "xudang.bmp");
            this.imageList.Images.SetKeyName(3, "juedang.bmp");
            this.imageList.Images.SetKeyName(4, "qingsuan.bmp");
            this.imageList.Images.SetKeyName(5, "zijin.bmp");
            this.imageList.Images.SetKeyName(6, "yewu.bmp");
            this.imageList.Images.SetKeyName(7, "dangbiao.bmp");
            this.imageList.Images.SetKeyName(8, "dangtong.bmp");
            this.imageList.Images.SetKeyName(9, "yingbiao.bmp");
            this.imageList.Images.SetKeyName(10, "yingtong.bmp");
            // 
            // panelToolBox
            // 
            this.panelToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolBox.Location = new System.Drawing.Point(0, 0);
            this.panelToolBox.Name = "panelToolBox";
            this.panelToolBox.Size = new System.Drawing.Size(177, 483);
            this.panelToolBox.TabIndex = 0;
            // 
            // ToolBoxForm
            // 
            this.AutoHidePortion = 175;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 483);
            this.CloseButton = false;
            this.ControlBox = false;
            this.Controls.Add(this.panelToolBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolBoxForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panelToolBox;
    }
}