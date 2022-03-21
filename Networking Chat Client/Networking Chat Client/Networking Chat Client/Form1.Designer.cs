
namespace Networking_Chat_Client
{
    partial class Chat
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
            this.btn_send = new System.Windows.Forms.Button();
            this.rtbx_chat = new System.Windows.Forms.RichTextBox();
            this.tbx_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(336, 587);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 29);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // rtbx_chat
            // 
            this.rtbx_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbx_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbx_chat.Location = new System.Drawing.Point(12, 12);
            this.rtbx_chat.Name = "rtbx_chat";
            this.rtbx_chat.ReadOnly = true;
            this.rtbx_chat.Size = new System.Drawing.Size(399, 563);
            this.rtbx_chat.TabIndex = 3;
            this.rtbx_chat.Text = "";
            // 
            // tbx_input
            // 
            this.tbx_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_input.Location = new System.Drawing.Point(12, 587);
            this.tbx_input.Name = "tbx_input";
            this.tbx_input.Size = new System.Drawing.Size(318, 26);
            this.tbx_input.TabIndex = 4;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(423, 625);
            this.Controls.Add(this.tbx_input);
            this.Controls.Add(this.rtbx_chat);
            this.Controls.Add(this.btn_send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.RichTextBox rtbx_chat;
        private System.Windows.Forms.TextBox tbx_input;
    }
}

