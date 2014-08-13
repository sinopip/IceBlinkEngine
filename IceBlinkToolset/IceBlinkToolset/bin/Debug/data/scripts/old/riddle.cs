using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            // get the trigger that fired this script
            Trigger trig = sf.gm.currentArea.AreaTriggerList.getTriggerByTag("lily_chest");
            trig.EnabledEvent1 = true; // this is the script fire event
            trig.EnabledEvent2 = false; // this is the container accessable event

            Riddle rid = new Riddle();
            rid.BackgroundImage = sf.frm.currentTheme.StandardThemeBitmap;
            DialogResult answer = rid.ShowDialog();
            if (answer == DialogResult.Yes)
            {
                trig.EnabledEvent1 = false;
                trig.EnabledEvent2 = true;
            }
            else
            {
                trig.EnabledEvent1 = true;
                trig.EnabledEvent2 = false;
            }

            //MessageBox.Show("exit riddle script");
        }

        public partial class Riddle : Form
        {
            public string answer;

            public Riddle()
            {
                InitializeComponent();
            }

            private void txtAnswer_TextChanged(object sender, EventArgs e)
            {
                answer = txtAnswer.Text;
            }

            private void btnAnswer_Click(object sender, EventArgs e)
            {
                if ((answer == "time") || (answer == "Time"))
                {
                    MessageBox.Show("That is correct...the chest opens");
                    DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect, try again");
                }
            }

            private void btnLeave_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }

	partial class Riddle
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
		    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Riddle));
		    this.label1 = new System.Windows.Forms.Label();
		    this.label2 = new System.Windows.Forms.Label();
		    this.txtAnswer = new System.Windows.Forms.TextBox();
		    this.btnAnswer = new System.Windows.Forms.Button();
		    this.label3 = new System.Windows.Forms.Label();
		    this.btnLeave = new System.Windows.Forms.Button();
		    this.label4 = new System.Windows.Forms.Label();
		    this.panel1 = new System.Windows.Forms.Panel();
		    this.panel1.SuspendLayout();
		    this.SuspendLayout();
		    // 
		    // label1
		    // 
		    this.label1.AutoSize = true;
		    this.label1.BackColor = System.Drawing.Color.Transparent;
		    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.label1.ForeColor = System.Drawing.Color.White;
		    this.label1.Location = new System.Drawing.Point(5, 52);
		    this.label1.Name = "label1";
		    this.label1.Size = new System.Drawing.Size(241, 102);
		    this.label1.TabIndex = 0;
		    this.label1.Text = "\"This thing all things devours:\r\nBirds, beasts, trees, flowers;\r\nGnaws iron, bite" +
			"s steel;\r\nGrinds hard stones to meal;\r\nSlays king, ruins town,\r\nAnd beats high m" +
			"ountain down.\"";
		    // 
		    // label2
		    // 
		    this.label2.AutoSize = true;
		    this.label2.BackColor = System.Drawing.Color.Transparent;
		    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.label2.ForeColor = System.Drawing.Color.White;
		    this.label2.Location = new System.Drawing.Point(3, 3);
		    this.label2.Name = "label2";
		    this.label2.Size = new System.Drawing.Size(227, 48);
		    this.label2.TabIndex = 1;
		    this.label2.Text = "Etched on the chest is the\r\nfollowing riddle:";
		    // 
		    // txtAnswer
		    // 
		    this.txtAnswer.BackColor = System.Drawing.Color.Black;
		    this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.txtAnswer.ForeColor = System.Drawing.Color.White;
		    this.txtAnswer.Location = new System.Drawing.Point(139, 215);
		    this.txtAnswer.Name = "txtAnswer";
		    this.txtAnswer.Size = new System.Drawing.Size(67, 26);
		    this.txtAnswer.TabIndex = 2;
		    this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		    this.txtAnswer.TextChanged += new System.EventHandler(this.txtAnswer_TextChanged);
		    // 
		    // btnAnswer
		    // 
		    this.btnAnswer.FlatAppearance.BorderColor = System.Drawing.Color.White;
		    this.btnAnswer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		    this.btnAnswer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
		    this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.btnAnswer.Location = new System.Drawing.Point(61, 253);
		    this.btnAnswer.Name = "btnAnswer";
		    this.btnAnswer.Size = new System.Drawing.Size(157, 32);
		    this.btnAnswer.TabIndex = 3;
		    this.btnAnswer.Text = "Speak Answer";
		    this.btnAnswer.UseVisualStyleBackColor = true;
		    this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
		    // 
		    // label3
		    // 
		    this.label3.AutoSize = true;
		    this.label3.BackColor = System.Drawing.Color.Black;
		    this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.label3.ForeColor = System.Drawing.Color.White;
		    this.label3.Location = new System.Drawing.Point(61, 217);
		    this.label3.Name = "label3";
		    this.label3.Size = new System.Drawing.Size(73, 22);
		    this.label3.TabIndex = 4;
		    this.label3.Text = "answer:\r\n";
		    // 
		    // btnLeave
		    // 
		    this.btnLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.btnLeave.Location = new System.Drawing.Point(61, 301);
		    this.btnLeave.Name = "btnLeave";
		    this.btnLeave.Size = new System.Drawing.Size(157, 32);
		    this.btnLeave.TabIndex = 5;
		    this.btnLeave.Text = "Leave Chest Alone";
		    this.btnLeave.UseVisualStyleBackColor = true;
		    this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
		    // 
		    // label4
		    // 
		    this.label4.AutoSize = true;
		    this.label4.BackColor = System.Drawing.Color.Transparent;
		    this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		    this.label4.ForeColor = System.Drawing.Color.White;
		    this.label4.Location = new System.Drawing.Point(157, 163);
		    this.label4.Name = "label4";
		    this.label4.Size = new System.Drawing.Size(74, 12);
		    this.label4.TabIndex = 6;
		    this.label4.Text = "©JRR Tolkein";
		    // 
		    // panel1
		    // 
		    this.panel1.BackColor = System.Drawing.Color.Black;
		    this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		    this.panel1.Controls.Add(this.label2);
		    this.panel1.Controls.Add(this.label4);
		    this.panel1.Controls.Add(this.label1);
		    this.panel1.Location = new System.Drawing.Point(12, 12);
		    this.panel1.Name = "panel1";
		    this.panel1.Size = new System.Drawing.Size(255, 185);
		    this.panel1.TabIndex = 7;
		    // 
		    // Riddle
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.ClientSize = new System.Drawing.Size(279, 348);
		    this.ControlBox = false;
		    this.Controls.Add(this.panel1);
		    this.Controls.Add(this.btnLeave);
		    this.Controls.Add(this.label3);
		    this.Controls.Add(this.btnAnswer);
		    this.Controls.Add(this.txtAnswer);
		    this.MaximizeBox = false;
		    this.MaximumSize = new System.Drawing.Size(295, 364);
		    this.MinimizeBox = false;
		    this.MinimumSize = new System.Drawing.Size(295, 364);
		    this.Name = "Riddle";
		    this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		    this.panel1.ResumeLayout(false);
		    this.panel1.PerformLayout();
		    this.ResumeLayout(false);
		    this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAnswer;
		private System.Windows.Forms.Button btnAnswer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnLeave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
	}
    }
}
