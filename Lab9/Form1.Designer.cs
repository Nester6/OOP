namespace ParametricGraph
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox inputR;
        private System.Windows.Forms.TextBox inputH;
        private System.Windows.Forms.TextBox inputTMin;
        private System.Windows.Forms.TextBox inputTMax;
        private System.Windows.Forms.Button drawButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.inputR = new System.Windows.Forms.TextBox();
            this.inputH = new System.Windows.Forms.TextBox();
            this.inputTMin = new System.Windows.Forms.TextBox();
            this.inputTMax = new System.Windows.Forms.TextBox();
            this.drawButton = new System.Windows.Forms.Button();
            System.Windows.Forms.Label labelR = new System.Windows.Forms.Label();
            System.Windows.Forms.Label labelH = new System.Windows.Forms.Label();
            System.Windows.Forms.Label labelTMin = new System.Windows.Forms.Label();
            System.Windows.Forms.Label labelTMax = new System.Windows.Forms.Label();
            System.Windows.Forms.Panel controlPanel = new System.Windows.Forms.Panel();

            // 
            // Form1
            // 
            this.Text = "Parametric Graph Plotter";
            this.Width = 800;
            this.Height = 600;

            // 
            // controlPanel
            // 
            controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            controlPanel.Height = 40;

            labelR.Text = "r:";
            labelR.Left = 10; labelR.Top = 10; labelR.Width = 20;
            inputR.Left = 30; inputR.Top = 7; inputR.Width = 50;

            labelH.Text = "h:";
            labelH.Left = 90; labelH.Top = 10; labelH.Width = 20;
            inputH.Left = 110; inputH.Top = 7; inputH.Width = 50;

            labelTMin.Text = "t min:";
            labelTMin.Left = 170; labelTMin.Top = 10; labelTMin.Width = 40;
            inputTMin.Left = 220; inputTMin.Top = 7; inputTMin.Width = 50;

            labelTMax.Text = "t max:";
            labelTMax.Left = 280; labelTMax.Top = 10; labelTMax.Width = 50;
            inputTMax.Left = 340; inputTMax.Top = 7; inputTMax.Width = 50;

            drawButton.Text = "Draw";
            drawButton.Left = 410; drawButton.Top = 5;
            drawButton.Click += new System.EventHandler(this.drawButton_Click);

            controlPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                labelR, inputR, labelH, inputH,
                labelTMin, inputTMin, labelTMax, inputTMax,
                drawButton
            });

            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);

            // 
            // Form1
            // 
            this.Controls.Add(this.canvas);
            this.Controls.Add(controlPanel);
        }
    }
}
