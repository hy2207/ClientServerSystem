namespace AS1HChoi
{
    partial class CarListingsForm
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
            this.labelAllCar = new System.Windows.Forms.Label();
            this.dataGridViewAllCar = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelCountResult = new System.Windows.Forms.Label();
            this.labelAvgPriceResult = new System.Windows.Forms.Label();
            this.labelAvgPrice = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelMake = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelDealer = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.textBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.checkBoxPrice = new System.Windows.Forms.CheckBox();
            this.checkBoxEngine = new System.Windows.Forms.CheckBox();
            this.textBoxMaxEngine = new System.Windows.Forms.TextBox();
            this.labelMaxEngine = new System.Windows.Forms.Label();
            this.textBoxMinEngine = new System.Windows.Forms.TextBox();
            this.labelMinEngine = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSelectCar = new System.Windows.Forms.Label();
            this.dataGridViewSelectCar = new System.Windows.Forms.DataGridView();
            this.labelAvgSelectCarResult = new System.Windows.Forms.Label();
            this.labelAvgSelectCar = new System.Windows.Forms.Label();
            this.labelCountSelectResult = new System.Windows.Forms.Label();
            this.labelCountSelectCar = new System.Windows.Forms.Label();
            this.listBoxMake = new System.Windows.Forms.ListBox();
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.listBoxColor = new System.Windows.Forms.ListBox();
            this.listBoxDealer = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectCar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAllCar
            // 
            this.labelAllCar.AutoSize = true;
            this.labelAllCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAllCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAllCar.Location = new System.Drawing.Point(44, 20);
            this.labelAllCar.Name = "labelAllCar";
            this.labelAllCar.Size = new System.Drawing.Size(66, 19);
            this.labelAllCar.TabIndex = 0;
            this.labelAllCar.Text = "All Cars";
            // 
            // dataGridViewAllCar
            // 
            this.dataGridViewAllCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllCar.Location = new System.Drawing.Point(44, 54);
            this.dataGridViewAllCar.Name = "dataGridViewAllCar";
            this.dataGridViewAllCar.RowHeadersWidth = 51;
            this.dataGridViewAllCar.RowTemplate.Height = 24;
            this.dataGridViewAllCar.Size = new System.Drawing.Size(610, 141);
            this.dataGridViewAllCar.TabIndex = 1;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(67, 210);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(57, 17);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Count =";
            // 
            // labelCountResult
            // 
            this.labelCountResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCountResult.Location = new System.Drawing.Point(130, 209);
            this.labelCountResult.Name = "labelCountResult";
            this.labelCountResult.Size = new System.Drawing.Size(72, 25);
            this.labelCountResult.TabIndex = 4;
            // 
            // labelAvgPriceResult
            // 
            this.labelAvgPriceResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAvgPriceResult.Location = new System.Drawing.Point(485, 209);
            this.labelAvgPriceResult.Name = "labelAvgPriceResult";
            this.labelAvgPriceResult.Size = new System.Drawing.Size(150, 25);
            this.labelAvgPriceResult.TabIndex = 6;
            // 
            // labelAvgPrice
            // 
            this.labelAvgPrice.AutoSize = true;
            this.labelAvgPrice.Location = new System.Drawing.Point(370, 210);
            this.labelAvgPrice.Name = "labelAvgPrice";
            this.labelAvgPrice.Size = new System.Drawing.Size(109, 17);
            this.labelAvgPrice.TabIndex = 5;
            this.labelAvgPrice.Text = "Average Price =";
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelFilter.Location = new System.Drawing.Point(44, 256);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(55, 19);
            this.labelFilter.TabIndex = 7;
            this.labelFilter.Text = "Filters";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(263, 252);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(103, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset Filters";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(41, 306);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(49, 17);
            this.labelMake.TabIndex = 9;
            this.labelMake.Text = "Makes";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(202, 306);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(45, 17);
            this.labelYear.TabIndex = 11;
            this.labelYear.Text = "Years";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(341, 306);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(48, 17);
            this.labelColor.TabIndex = 13;
            this.labelColor.Text = "Colors";
            // 
            // labelDealer
            // 
            this.labelDealer.AutoSize = true;
            this.labelDealer.Location = new System.Drawing.Point(480, 306);
            this.labelDealer.Name = "labelDealer";
            this.labelDealer.Size = new System.Drawing.Size(57, 17);
            this.labelDealer.TabIndex = 15;
            this.labelDealer.Text = "Dealers";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPrice.Location = new System.Drawing.Point(44, 444);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(42, 19);
            this.labelPrice.TabIndex = 17;
            this.labelPrice.Text = "Price";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(112, 444);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(30, 17);
            this.labelMin.TabIndex = 18;
            this.labelMin.Text = "Min";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(152, 441);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(100, 22);
            this.textBoxMinPrice.TabIndex = 19;
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(152, 478);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxPrice.TabIndex = 21;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(112, 481);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(33, 17);
            this.labelMax.TabIndex = 20;
            this.labelMax.Text = "Max";
            // 
            // checkBoxPrice
            // 
            this.checkBoxPrice.AutoSize = true;
            this.checkBoxPrice.Location = new System.Drawing.Point(152, 506);
            this.checkBoxPrice.Name = "checkBoxPrice";
            this.checkBoxPrice.Size = new System.Drawing.Size(131, 21);
            this.checkBoxPrice.TabIndex = 22;
            this.checkBoxPrice.Text = "Search on Price";
            this.checkBoxPrice.UseVisualStyleBackColor = true;
            // 
            // checkBoxEngine
            // 
            this.checkBoxEngine.AutoSize = true;
            this.checkBoxEngine.Location = new System.Drawing.Point(454, 504);
            this.checkBoxEngine.Name = "checkBoxEngine";
            this.checkBoxEngine.Size = new System.Drawing.Size(174, 21);
            this.checkBoxEngine.TabIndex = 28;
            this.checkBoxEngine.Text = "Search on Engine Size";
            this.checkBoxEngine.UseVisualStyleBackColor = true;
            // 
            // textBoxMaxEngine
            // 
            this.textBoxMaxEngine.Location = new System.Drawing.Point(454, 476);
            this.textBoxMaxEngine.Name = "textBoxMaxEngine";
            this.textBoxMaxEngine.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxEngine.TabIndex = 27;
            // 
            // labelMaxEngine
            // 
            this.labelMaxEngine.AutoSize = true;
            this.labelMaxEngine.Location = new System.Drawing.Point(414, 479);
            this.labelMaxEngine.Name = "labelMaxEngine";
            this.labelMaxEngine.Size = new System.Drawing.Size(33, 17);
            this.labelMaxEngine.TabIndex = 26;
            this.labelMaxEngine.Text = "Max";
            // 
            // textBoxMinEngine
            // 
            this.textBoxMinEngine.Location = new System.Drawing.Point(454, 439);
            this.textBoxMinEngine.Name = "textBoxMinEngine";
            this.textBoxMinEngine.Size = new System.Drawing.Size(100, 22);
            this.textBoxMinEngine.TabIndex = 25;
            // 
            // labelMinEngine
            // 
            this.labelMinEngine.AutoSize = true;
            this.labelMinEngine.Location = new System.Drawing.Point(414, 442);
            this.labelMinEngine.Name = "labelMinEngine";
            this.labelMinEngine.Size = new System.Drawing.Size(30, 17);
            this.labelMinEngine.TabIndex = 24;
            this.labelMinEngine.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(325, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Engine Size";
            // 
            // labelSelectCar
            // 
            this.labelSelectCar.AutoSize = true;
            this.labelSelectCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSelectCar.Location = new System.Drawing.Point(44, 554);
            this.labelSelectCar.Name = "labelSelectCar";
            this.labelSelectCar.Size = new System.Drawing.Size(111, 19);
            this.labelSelectCar.TabIndex = 29;
            this.labelSelectCar.Text = "Selected Cars";
            // 
            // dataGridViewSelectCar
            // 
            this.dataGridViewSelectCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectCar.Location = new System.Drawing.Point(40, 590);
            this.dataGridViewSelectCar.Name = "dataGridViewSelectCar";
            this.dataGridViewSelectCar.RowHeadersWidth = 51;
            this.dataGridViewSelectCar.RowTemplate.Height = 24;
            this.dataGridViewSelectCar.Size = new System.Drawing.Size(614, 150);
            this.dataGridViewSelectCar.TabIndex = 30;
            // 
            // labelAvgSelectCarResult
            // 
            this.labelAvgSelectCarResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAvgSelectCarResult.Location = new System.Drawing.Point(483, 758);
            this.labelAvgSelectCarResult.Name = "labelAvgSelectCarResult";
            this.labelAvgSelectCarResult.Size = new System.Drawing.Size(150, 21);
            this.labelAvgSelectCarResult.TabIndex = 34;
            // 
            // labelAvgSelectCar
            // 
            this.labelAvgSelectCar.AutoSize = true;
            this.labelAvgSelectCar.Location = new System.Drawing.Point(370, 758);
            this.labelAvgSelectCar.Name = "labelAvgSelectCar";
            this.labelAvgSelectCar.Size = new System.Drawing.Size(109, 17);
            this.labelAvgSelectCar.TabIndex = 33;
            this.labelAvgSelectCar.Text = "Average Price =";
            // 
            // labelCountSelectResult
            // 
            this.labelCountSelectResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCountSelectResult.Location = new System.Drawing.Point(125, 758);
            this.labelCountSelectResult.Name = "labelCountSelectResult";
            this.labelCountSelectResult.Size = new System.Drawing.Size(72, 25);
            this.labelCountSelectResult.TabIndex = 32;
            // 
            // labelCountSelectCar
            // 
            this.labelCountSelectCar.AutoSize = true;
            this.labelCountSelectCar.Location = new System.Drawing.Point(67, 762);
            this.labelCountSelectCar.Name = "labelCountSelectCar";
            this.labelCountSelectCar.Size = new System.Drawing.Size(57, 17);
            this.labelCountSelectCar.TabIndex = 31;
            this.labelCountSelectCar.Text = "Count =";
            // 
            // listBoxMake
            // 
            this.listBoxMake.FormattingEnabled = true;
            this.listBoxMake.ItemHeight = 16;
            this.listBoxMake.Location = new System.Drawing.Point(44, 326);
            this.listBoxMake.Name = "listBoxMake";
            this.listBoxMake.Size = new System.Drawing.Size(120, 84);
            this.listBoxMake.TabIndex = 35;
            // 
            // listBoxYear
            // 
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.ItemHeight = 16;
            this.listBoxYear.Location = new System.Drawing.Point(205, 326);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.Size = new System.Drawing.Size(65, 84);
            this.listBoxYear.TabIndex = 36;
            // 
            // listBoxColor
            // 
            this.listBoxColor.FormattingEnabled = true;
            this.listBoxColor.ItemHeight = 16;
            this.listBoxColor.Location = new System.Drawing.Point(344, 326);
            this.listBoxColor.Name = "listBoxColor";
            this.listBoxColor.Size = new System.Drawing.Size(65, 84);
            this.listBoxColor.TabIndex = 37;
            // 
            // listBoxDealer
            // 
            this.listBoxDealer.FormattingEnabled = true;
            this.listBoxDealer.ItemHeight = 16;
            this.listBoxDealer.Location = new System.Drawing.Point(483, 326);
            this.listBoxDealer.Name = "listBoxDealer";
            this.listBoxDealer.Size = new System.Drawing.Size(121, 84);
            this.listBoxDealer.TabIndex = 38;
            // 
            // CarListingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 796);
            this.Controls.Add(this.listBoxDealer);
            this.Controls.Add(this.listBoxColor);
            this.Controls.Add(this.listBoxYear);
            this.Controls.Add(this.listBoxMake);
            this.Controls.Add(this.labelAvgSelectCarResult);
            this.Controls.Add(this.labelAvgSelectCar);
            this.Controls.Add(this.labelCountSelectResult);
            this.Controls.Add(this.labelCountSelectCar);
            this.Controls.Add(this.dataGridViewSelectCar);
            this.Controls.Add(this.labelSelectCar);
            this.Controls.Add(this.checkBoxEngine);
            this.Controls.Add(this.textBoxMaxEngine);
            this.Controls.Add(this.labelMaxEngine);
            this.Controls.Add(this.textBoxMinEngine);
            this.Controls.Add(this.labelMinEngine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxPrice);
            this.Controls.Add(this.textBoxMaxPrice);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.textBoxMinPrice);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelDealer);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelMake);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.labelAvgPriceResult);
            this.Controls.Add(this.labelAvgPrice);
            this.Controls.Add(this.labelCountResult);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.dataGridViewAllCar);
            this.Controls.Add(this.labelAllCar);
            this.Name = "CarListingsForm";
            this.Text = "Assignment 1 - Car Listings";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAllCar;
        private System.Windows.Forms.DataGridView dataGridViewAllCar;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelCountResult;
        private System.Windows.Forms.Label labelAvgPriceResult;
        private System.Windows.Forms.Label labelAvgPrice;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelMake;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelDealer;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox textBoxMinPrice;
        private System.Windows.Forms.TextBox textBoxMaxPrice;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.CheckBox checkBoxPrice;
        private System.Windows.Forms.CheckBox checkBoxEngine;
        private System.Windows.Forms.TextBox textBoxMaxEngine;
        private System.Windows.Forms.Label labelMaxEngine;
        private System.Windows.Forms.TextBox textBoxMinEngine;
        private System.Windows.Forms.Label labelMinEngine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSelectCar;
        private System.Windows.Forms.DataGridView dataGridViewSelectCar;
        private System.Windows.Forms.Label labelAvgSelectCarResult;
        private System.Windows.Forms.Label labelAvgSelectCar;
        private System.Windows.Forms.Label labelCountSelectResult;
        private System.Windows.Forms.Label labelCountSelectCar;
        private System.Windows.Forms.ListBox listBoxMake;
        private System.Windows.Forms.ListBox listBoxYear;
        private System.Windows.Forms.ListBox listBoxColor;
        private System.Windows.Forms.ListBox listBoxDealer;
    }
}

