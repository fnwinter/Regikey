namespace REGIKEY
{
    partial class RegiKey
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegiKey));
            this.button_hide = new System.Windows.Forms.Button();
            this.edit_INIFile = new System.Windows.Forms.RichTextBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.link_webpage = new System.Windows.Forms.LinkLabel();
            this.label_webpage = new System.Windows.Forms.Label();
            this.button_startup = new System.Windows.Forms.Button();
            this.button_check_vkeys = new System.Windows.Forms.Button();
            this.link_vkcode_page = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button_hide
            // 
            this.button_hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_hide.Location = new System.Drawing.Point(486, 326);
            this.button_hide.Name = "button_hide";
            this.button_hide.Size = new System.Drawing.Size(75, 23);
            this.button_hide.TabIndex = 9;
            this.button_hide.Text = "Hide";
            this.button_hide.UseVisualStyleBackColor = true;
            this.button_hide.Click += new System.EventHandler(this.button_hide_click);
            // 
            // edit_INIFile
            // 
            this.edit_INIFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_INIFile.Location = new System.Drawing.Point(12, 12);
            this.edit_INIFile.Name = "edit_INIFile";
            this.edit_INIFile.Size = new System.Drawing.Size(560, 274);
            this.edit_INIFile.TabIndex = 1;
            this.edit_INIFile.Text = "";
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(405, 326);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 8;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(324, 326);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // link_webpage
            // 
            this.link_webpage.AutoSize = true;
            this.link_webpage.Location = new System.Drawing.Point(255, 299);
            this.link_webpage.Name = "link_webpage";
            this.link_webpage.Size = new System.Drawing.Size(213, 12);
            this.link_webpage.TabIndex = 6;
            this.link_webpage.TabStop = true;
            this.link_webpage.Text = "http://www.vonstage.com/REGIKEY";
            this.link_webpage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_webpage_LinkClicked);
            // 
            // label_webpage
            // 
            this.label_webpage.AutoSize = true;
            this.label_webpage.Location = new System.Drawing.Point(200, 299);
            this.label_webpage.Name = "label_webpage";
            this.label_webpage.Size = new System.Drawing.Size(49, 12);
            this.label_webpage.TabIndex = 0;
            this.label_webpage.Text = "Usage :";
            // 
            // button_startup
            // 
            this.button_startup.Location = new System.Drawing.Point(12, 326);
            this.button_startup.Name = "button_startup";
            this.button_startup.Size = new System.Drawing.Size(137, 23);
            this.button_startup.TabIndex = 10;
            this.button_startup.Text = "Set as startup";
            this.button_startup.UseVisualStyleBackColor = true;
            this.button_startup.Click += new System.EventHandler(this.button_startup_Click);
            // 
            // button_check_vkeys
            // 
            this.button_check_vkeys.Location = new System.Drawing.Point(155, 326);
            this.button_check_vkeys.Name = "button_check_vkeys";
            this.button_check_vkeys.Size = new System.Drawing.Size(121, 23);
            this.button_check_vkeys.TabIndex = 11;
            this.button_check_vkeys.Text = "Check VKey value";
            this.button_check_vkeys.UseVisualStyleBackColor = true;
            this.button_check_vkeys.Click += new System.EventHandler(this.button_check_vkeys_Click);
            // 
            // link_vkcode_page
            // 
            this.link_vkcode_page.AutoSize = true;
            this.link_vkcode_page.Location = new System.Drawing.Point(474, 299);
            this.link_vkcode_page.Name = "link_vkcode_page";
            this.link_vkcode_page.Size = new System.Drawing.Size(87, 12);
            this.link_vkcode_page.TabIndex = 12;
            this.link_vkcode_page.TabStop = true;
            this.link_vkcode_page.Text = "VK Code page";
            this.link_vkcode_page.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_vkcode_page_LinkClicked);
            // 
            // RegiKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.link_vkcode_page);
            this.Controls.Add(this.button_check_vkeys);
            this.Controls.Add(this.button_startup);
            this.Controls.Add(this.label_webpage);
            this.Controls.Add(this.link_webpage);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.edit_INIFile);
            this.Controls.Add(this.button_hide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "RegiKey";
            this.Text = "REGIKEY";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegiKey_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_hide;
        private System.Windows.Forms.RichTextBox edit_INIFile;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.LinkLabel link_webpage;
        private System.Windows.Forms.Label label_webpage;
        private System.Windows.Forms.Button button_startup;
        private System.Windows.Forms.Button button_check_vkeys;
        private System.Windows.Forms.LinkLabel link_vkcode_page;
    }
}