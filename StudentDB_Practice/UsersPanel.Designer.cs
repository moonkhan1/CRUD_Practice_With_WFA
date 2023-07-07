using System.Windows.Forms;

namespace StudentDB_Practice
{
    partial class UsersPanel
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            EditButton = new Button();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(305, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(469, 264);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(26, 146);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(26, 286);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 3;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 37);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 112);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 5;
            label2.Text = "Surname";
            // 
            // button2
            // 
            button2.Location = new Point(305, 390);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(290, 343);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(521, 390);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 8;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(521, 343);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 9;
            label4.Text = "label4";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(26, 225);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(245, 27);
            dateTimePicker1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 191);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 11;
            label5.Text = "Date Of Birth";
            // 
            // EditButton
            // 
            EditButton.Location = new Point(168, 286);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(115, 29);
            EditButton.TabIndex = 12;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(102, 343);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(118, 29);
            DeleteButton.TabIndex = 13;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UsersPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "UsersPanel";
            Text = "UsersPanel";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Button EditButton;
        private Button DeleteButton;
    }
}