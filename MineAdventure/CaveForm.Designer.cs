namespace MineAdventure
{
    partial class CaveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaveForm));
            this.pbFloor = new System.Windows.Forms.PictureBox();
            this.pbLowerWall = new System.Windows.Forms.PictureBox();
            this.pbUpperWall = new System.Windows.Forms.PictureBox();
            this.pbRightWall = new System.Windows.Forms.PictureBox();
            this.pbLeftWall = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLowerWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpperWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFloor
            // 
            this.pbFloor.Image = global::MineAdventure.Properties.Resources.BedrockFloor;
            this.pbFloor.Location = new System.Drawing.Point(50, 50);
            this.pbFloor.Name = "pbFloor";
            this.pbFloor.Size = new System.Drawing.Size(500, 500);
            this.pbFloor.TabIndex = 4;
            this.pbFloor.TabStop = false;
            // 
            // pbLowerWall
            // 
            this.pbLowerWall.Image = global::MineAdventure.Properties.Resources.HorisontalWall;
            this.pbLowerWall.Location = new System.Drawing.Point(50, 550);
            this.pbLowerWall.Name = "pbLowerWall";
            this.pbLowerWall.Size = new System.Drawing.Size(500, 50);
            this.pbLowerWall.TabIndex = 3;
            this.pbLowerWall.TabStop = false;
            // 
            // pbUpperWall
            // 
            this.pbUpperWall.Image = global::MineAdventure.Properties.Resources.HorisontalWall;
            this.pbUpperWall.Location = new System.Drawing.Point(50, 0);
            this.pbUpperWall.Name = "pbUpperWall";
            this.pbUpperWall.Size = new System.Drawing.Size(500, 50);
            this.pbUpperWall.TabIndex = 2;
            this.pbUpperWall.TabStop = false;
            // 
            // pbRightWall
            // 
            this.pbRightWall.Image = global::MineAdventure.Properties.Resources.VerticallWall;
            this.pbRightWall.Location = new System.Drawing.Point(550, 0);
            this.pbRightWall.Name = "pbRightWall";
            this.pbRightWall.Size = new System.Drawing.Size(50, 600);
            this.pbRightWall.TabIndex = 1;
            this.pbRightWall.TabStop = false;
            // 
            // pbLeftWall
            // 
            this.pbLeftWall.Image = global::MineAdventure.Properties.Resources.VerticallWall;
            this.pbLeftWall.Location = new System.Drawing.Point(0, 0);
            this.pbLeftWall.Name = "pbLeftWall";
            this.pbLeftWall.Size = new System.Drawing.Size(50, 600);
            this.pbLeftWall.TabIndex = 0;
            this.pbLeftWall.TabStop = false;
            // 
            // pbPlayer
            // 
            this.pbPlayer.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayer.Image")));
            this.pbPlayer.Location = new System.Drawing.Point(50, 50);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(50, 50);
            this.pbPlayer.TabIndex = 5;
            this.pbPlayer.TabStop = false;
            // 
            // CaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbFloor);
            this.Controls.Add(this.pbLowerWall);
            this.Controls.Add(this.pbUpperWall);
            this.Controls.Add(this.pbRightWall);
            this.Controls.Add(this.pbLeftWall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CaveForm";
            this.Text = "CaveForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaveForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLowerWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpperWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeftWall;
        private System.Windows.Forms.PictureBox pbRightWall;
        private System.Windows.Forms.PictureBox pbUpperWall;
        private System.Windows.Forms.PictureBox pbLowerWall;
        private System.Windows.Forms.PictureBox pbFloor;
        private System.Windows.Forms.PictureBox pbPlayer;
    }
}