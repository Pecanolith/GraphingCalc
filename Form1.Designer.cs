namespace Minesweeper
{
    partial class Board
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
            this.NewGame = new System.Windows.Forms.Button();
            this.MineNum = new System.Windows.Forms.TextBox();
            this.SizeX = new System.Windows.Forms.TextBox();
            this.SizeY = new System.Windows.Forms.TextBox();
            this.XLabel = new System.Windows.Forms.TextBox();
            this.YLabel = new System.Windows.Forms.TextBox();
            this.MinesLabel = new System.Windows.Forms.TextBox();
            this.RemainingMines = new System.Windows.Forms.TextBox();
            this.RemainingLabel = new System.Windows.Forms.TextBox();
            this.TimerUI = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.BackgroundImage = global::Minesweeper.Properties.Resources.Smiley;
            this.NewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewGame.FlatAppearance.BorderSize = 0;
            this.NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGame.Location = new System.Drawing.Point(600, 50);
            this.NewGame.Margin = new System.Windows.Forms.Padding(0);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(32, 32);
            this.NewGame.TabIndex = 0;
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // MineNum
            // 
            this.MineNum.Location = new System.Drawing.Point(524, 181);
            this.MineNum.Name = "MineNum";
            this.MineNum.Size = new System.Drawing.Size(40, 20);
            this.MineNum.TabIndex = 1;
            // 
            // SizeX
            // 
            this.SizeX.Location = new System.Drawing.Point(524, 262);
            this.SizeX.Name = "SizeX";
            this.SizeX.Size = new System.Drawing.Size(40, 20);
            this.SizeX.TabIndex = 2;
            // 
            // SizeY
            // 
            this.SizeY.Location = new System.Drawing.Point(524, 227);
            this.SizeY.Name = "SizeY";
            this.SizeY.Size = new System.Drawing.Size(40, 20);
            this.SizeY.TabIndex = 3;
            // 
            // XLabel
            // 
            this.XLabel.Location = new System.Drawing.Point(423, 262);
            this.XLabel.Name = "XLabel";
            this.XLabel.ReadOnly = true;
            this.XLabel.Size = new System.Drawing.Size(64, 20);
            this.XLabel.TabIndex = 4;
            this.XLabel.Text = "Width:";
            this.XLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // YLabel
            // 
            this.YLabel.Location = new System.Drawing.Point(423, 227);
            this.YLabel.Name = "YLabel";
            this.YLabel.ReadOnly = true;
            this.YLabel.Size = new System.Drawing.Size(64, 20);
            this.YLabel.TabIndex = 5;
            this.YLabel.Text = "Height:";
            this.YLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MinesLabel
            // 
            this.MinesLabel.Location = new System.Drawing.Point(423, 181);
            this.MinesLabel.Name = "MinesLabel";
            this.MinesLabel.ReadOnly = true;
            this.MinesLabel.Size = new System.Drawing.Size(64, 20);
            this.MinesLabel.TabIndex = 6;
            this.MinesLabel.Text = "Mines:";
            this.MinesLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RemainingMines
            // 
            this.RemainingMines.Location = new System.Drawing.Point(524, 299);
            this.RemainingMines.Name = "RemainingMines";
            this.RemainingMines.ReadOnly = true;
            this.RemainingMines.Size = new System.Drawing.Size(40, 20);
            this.RemainingMines.TabIndex = 7;
            // 
            // RemainingLabel
            // 
            this.RemainingLabel.Location = new System.Drawing.Point(423, 299);
            this.RemainingLabel.Name = "RemainingLabel";
            this.RemainingLabel.ReadOnly = true;
            this.RemainingLabel.Size = new System.Drawing.Size(64, 20);
            this.RemainingLabel.TabIndex = 8;
            this.RemainingLabel.Text = "Remaining:";
            this.RemainingLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TimerUI
            // 
            this.TimerUI.Location = new System.Drawing.Point(423, 354);
            this.TimerUI.Name = "TimerUI";
            this.TimerUI.ReadOnly = true;
            this.TimerUI.Size = new System.Drawing.Size(116, 20);
            this.TimerUI.TabIndex = 9;
            this.TimerUI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time
            // 
            this.time.Interval = 1000;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(667, 585);
            this.Controls.Add(this.TimerUI);
            this.Controls.Add(this.RemainingLabel);
            this.Controls.Add(this.RemainingMines);
            this.Controls.Add(this.MinesLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.SizeY);
            this.Controls.Add(this.SizeX);
            this.Controls.Add(this.MineNum);
            this.Controls.Add(this.NewGame);
            this.Name = "Board";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.TextBox MineNum;
        private System.Windows.Forms.TextBox SizeX;
        private System.Windows.Forms.TextBox SizeY;
        private System.Windows.Forms.TextBox XLabel;
        private System.Windows.Forms.TextBox YLabel;
        private System.Windows.Forms.TextBox MinesLabel;
        private System.Windows.Forms.TextBox RemainingMines;
        private System.Windows.Forms.TextBox RemainingLabel;
        private System.Windows.Forms.TextBox TimerUI;
        private System.Windows.Forms.Timer time;
    }
}

