namespace Bai5
{
    partial class ChatRoomForm
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
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.txtRoomCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(4, 1);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(774, 342);
            this.txtMessages.TabIndex = 0;
            this.txtMessages.TextChanged += new System.EventHandler(this.txtMessages_TextChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(11, 395);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(412, 50);
            this.txtMessage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input message";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(543, 380);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(216, 56);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(775, 173);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(144, 54);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create Room";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(775, 1);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(144, 54);
            this.btnJoin.TabIndex = 5;
            this.btnJoin.Text = "Join Room";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(775, 261);
            this.txtRoomName.Multiline = true;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(191, 57);
            this.txtRoomName.TabIndex = 6;
            // 
            // txtRoomCode
            // 
            this.txtRoomCode.Location = new System.Drawing.Point(775, 93);
            this.txtRoomCode.Multiline = true;
            this.txtRoomCode.Name = "txtRoomCode";
            this.txtRoomCode.Size = new System.Drawing.Size(191, 57);
            this.txtRoomCode.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(782, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(771, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name Room";
            // 
            // ChatRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 513);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRoomCode);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtMessages);
            this.Name = "ChatRoomForm";
            this.Text = "ChatRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtRoomCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}