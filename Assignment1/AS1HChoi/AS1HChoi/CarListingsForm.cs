using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AS1HChoi
{
    public partial class CarListingsForm : Form
    {
        List<Car> carList;
        public CarListingsForm()
        {
            InitializeComponent();
            //고ㅛ수님
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly; //이건 안해도되는듯?
            this.Text = "Assignment 1 - Car Listings";
            //요기까지

            ReadXML();

            InitialStateGridView();
            InitialStateListBox();
            DisplaySelectedCarList();

            //price filter
            checkBoxPrice.Click += CheckBoxPrice_Click;
            //engine size filter
            checkBoxEngine.Click += CheckBoxEngine_Click;

            //update when text in textbox is changed (price, enginesize)
            textBoxMinEngine.TextChanged += TextBoxMinEngine_TextChanged;
            textBoxMaxEngine.TextChanged += TextBoxMaxEngine_TextChanged;
            textBoxMinPrice.TextChanged += TextBoxMinPrice_TextChanged;
            textBoxMaxPrice.TextChanged += TextBoxMaxPrice_TextChanged;

            //Reset button
            buttonReset.Click += ButtonReset_Click;

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetFilter();
        }

        private void TextBoxMaxPrice_TextChanged(object sender, EventArgs e)
        {
            int maxPrice;
            if (int.TryParse(textBoxMaxPrice.Text, out maxPrice))
                DisplaySelectedCarList();
            else
            {
                MessageBox.Show(this, "Maximum price is missing or is not an integer");
                checkBoxEngine.Checked = false;
                DisplaySelectedCarList();
            }
        }

        private void TextBoxMinPrice_TextChanged(object sender, EventArgs e)
        {
            int minPrice;
            if (int.TryParse(textBoxMinPrice.Text, out minPrice))
                DisplaySelectedCarList();
            else
            {
                MessageBox.Show(this, "Minimum price is missing or is not an integer");
                checkBoxEngine.Checked = false;
                DisplaySelectedCarList();
            }
        }

        private void TextBoxMaxEngine_TextChanged(object sender, EventArgs e)
        {
            int maxEngine;
            if (int.TryParse(textBoxMaxEngine.Text, out maxEngine))
                DisplaySelectedCarList();
            else
            {
                MessageBox.Show(this, "Engine Maximum size is missing or is not an integer");
                checkBoxEngine.Checked = false;
                DisplaySelectedCarList();
            }
        }

        private void TextBoxMinEngine_TextChanged(object sender, EventArgs e)
        {
            int minEngine;
            if (int.TryParse(textBoxMinEngine.Text, out minEngine))
                DisplaySelectedCarList();
            else
            {
                MessageBox.Show(this, "Engine Minimum size is missing or is not an integer");
                checkBoxEngine.Checked = false;
                DisplaySelectedCarList();
            }
        }
        /// <summary>
        /// error handling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxEngine_Click(object sender, EventArgs e)
        {
            try
            {
                DisplaySelectedCarList();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Engine size is missing or is not an integer");
                checkBoxEngine.Checked = false;
            }
        }
        private void CheckBoxPrice_Click(object sender, EventArgs e)
        {
            try
            {
                DisplaySelectedCarList();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Price is missing or is not an integer");
                checkBoxPrice.Checked = false;
            }
        }

        /// <summary>
        /// class to read XML file
        /// </summary>
        private void ReadXML()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\..")
            };
            openFileDialog.Filter = "XML Files (*.xml)|*.xml"; //filter = "XML|*.xml"

            //user select okay button
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //open file for reading
                    StreamReader carsFile = new StreamReader(openFileDialog.FileName);
                    //create the serializer
                    XmlSerializer carSerializer = new XmlSerializer(typeof(List<Car>));

                    //deserialize to the list 
                    carList = carSerializer.Deserialize(carsFile) as List<Car>;
                    carsFile.Close();

                }
                catch (System.IO.FileNotFoundException e)
                {
                    //if cannot read file
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// initialize the DataGridview setting and add data from car list
        /// </summary>
        private void InitialStateGridView()
        {
            //1. All Cars datagridview
            dataGridViewAllCar.Columns.Clear(); //any columns created
            dataGridViewAllCar.ReadOnly = true; //no cell editing allowed
            dataGridViewAllCar.AllowUserToAddRows = false; //no rows can be added or deleted
            dataGridViewAllCar.AllowUserToDeleteRows = false;
            dataGridViewAllCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewAllCar.RowHeadersVisible = false;
            dataGridViewAllCar.AutoSize = false;
            dataGridViewAllCar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAllCar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //2. Selected cars datagridview
            dataGridViewSelectCar.Columns.Clear();
            dataGridViewSelectCar.ReadOnly = true;
            dataGridViewSelectCar.AllowUserToAddRows = false;
            dataGridViewSelectCar.AllowUserToDeleteRows = false;
            dataGridViewSelectCar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewSelectCar.RowHeadersVisible = false;
            dataGridViewSelectCar.AutoSize = false;
            dataGridViewSelectCar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectCar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //add header columns
            DataGridViewColumn[] headerColumn = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn() { Name = "Make" },
                new DataGridViewTextBoxColumn() { Name = "Year" },
                new DataGridViewTextBoxColumn() { Name = "Color" },
                new DataGridViewTextBoxColumn() { Name = "Engine Size" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                new DataGridViewTextBoxColumn() { Name = "Dealer" },
            };

            DataGridViewColumn[] headerColumn2 = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn() { Name = "Make" },
                new DataGridViewTextBoxColumn() { Name = "Year" },
                new DataGridViewTextBoxColumn() { Name = "Color" },
                new DataGridViewTextBoxColumn() { Name = "Engine Size" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                new DataGridViewTextBoxColumn() { Name = "Dealer" },
            };

            //add column to data grid view
            dataGridViewAllCar.Columns.AddRange(headerColumn);
            dataGridViewSelectCar.Columns.AddRange(headerColumn2);
            //set format price columns
            dataGridViewAllCar.Columns["Price"].DefaultCellStyle.Format = "c";
            dataGridViewSelectCar.Columns["Price"].DefaultCellStyle.Format = "c";

            //add data from car list
            int numberOfCar = 0; //result of count label
            double totalPrice = 0;
            double avgPrice = 0; //result of average price label

            //get car list and order by car maker
            var allCar = carList.OrderBy(c => c.Make);

            foreach (Car car in allCar)
            {
                dataGridViewAllCar.Rows.Add(car.Make, car.Year, car.Color, car.EngineSize, car.Price, car.Dealer);
                totalPrice += car.Price; //add each car's price to total price
            }

            numberOfCar = allCar.Count();
            avgPrice = totalPrice / numberOfCar;
            labelCountResult.Text = numberOfCar.ToString();
            labelAvgPriceResult.Text = avgPrice.ToString("c2");

        }

        /// <summary>
        /// initialize the list box setting and add data from car list
        /// </summary>
        private void InitialStateListBox()
        {
            //clear all
            listBoxMake.Items.Clear();
            listBoxYear.Items.Clear();
            listBoxColor.Items.Clear();
            listBoxDealer.Items.Clear();

            //allow the user to select multiple items
            listBoxMake.SelectionMode = SelectionMode.MultiExtended;
            listBoxYear.SelectionMode = SelectionMode.MultiExtended;
            listBoxColor.SelectionMode = SelectionMode.MultiExtended;
            listBoxDealer.SelectionMode = SelectionMode.MultiExtended;

            //add list for each list boxes(unique list)
            var makes = carList.OrderBy(c => c.Make).Select(c => c.Make).Distinct();
            var years = carList.OrderBy(c => c.Year).Select(c => c.Year).Distinct();
            var colors = carList.OrderBy(c => c.Color).Select(c => c.Color).Distinct();
            var dealers = carList.OrderBy(c => c.Dealer).Select(c => c.Dealer).Distinct();

            //set make list box
            listBoxMake.Items.AddRange(makes.ToArray());
            for (int idx = 0; idx < listBoxMake.Items.Count; idx++)
                listBoxMake.SetSelected(idx, true); //select all item
            //update datagridview by selected options
            listBoxMake.SelectedIndexChanged += ListBoxMake_SelectedIndexChanged;

            //set year list box
            int i = 0;
            foreach (var carYear in years)
            {
                listBoxYear.Items.Add(carYear.ToString());
                listBoxYear.SetSelected(i, true); //select all item
                i++;
            }
            listBoxYear.SelectedIndexChanged += ListBoxYear_SelectedIndexChanged;

            //set color list box
            listBoxColor.Items.AddRange(colors.ToArray());
            for (int idx = 0; idx < listBoxColor.Items.Count; idx++)
                listBoxColor.SetSelected(idx, true);
            listBoxColor.SelectedIndexChanged += ListBoxColor_SelectedIndexChanged;

            //set dealer list box 
            listBoxDealer.Items.AddRange(dealers.ToArray());
            for (int idx = 0; idx < listBoxDealer.Items.Count; idx++)
                listBoxDealer.SetSelected(idx, true);
            listBoxDealer.SelectedIndexChanged += ListBoxDealer_SelectedIndexChanged;
        }
        //update slected car list
        private void ListBoxDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedCarList();
        }

        private void ListBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedCarList();
        }

        private void ListBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedCarList();
        }

        private void ListBoxMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedCarList();
        }
        /// <summary>
        /// display selected car list in datagridview
        /// </summary>
        private void DisplaySelectedCarList()
        {
            dataGridViewSelectCar.Rows.Clear(); //clear old items

            //create list of selected options
            List<String> selectedMake = new List<string>();
            List<String> selectedYear = new List<string>();
            List<String> selectedColor = new List<string>();
            List<String> selectedDealer = new List<string>();

            //define price and engine size value from textbox
            int minPrice, maxPrice, minEngine, maxEngine;
            int.TryParse(textBoxMinPrice.Text, out minPrice);
            int.TryParse(textBoxMaxPrice.Text, out maxPrice);
            int.TryParse(textBoxMinEngine.Text, out minEngine);
            int.TryParse(textBoxMaxEngine.Text, out maxEngine);

            int numberOfCar = 0; //result of count label
            double totalPrice = 0;
            double avgPrice = 0; //result of average price label

            //add selected items in list box
            foreach (string make in listBoxMake.SelectedItems)
                selectedMake.Add(make);

            foreach (string year in listBoxYear.SelectedItems)
                selectedYear.Add(year);

            foreach (string color in listBoxColor.SelectedItems)
                selectedColor.Add(color);

            foreach (string dealer in listBoxDealer.SelectedItems)
                selectedDealer.Add(dealer);

            //compare carlist with options
            var selectedCar = carList.Where(c => selectedMake.Any(make => make.Equals(c.Make))
                && selectedYear.Any(year => year.Equals(c.Year.ToString()))
                && selectedColor.Any(color => color.Equals(c.Color))
                && selectedDealer.Any(dealer => dealer.Equals(c.Dealer))
                && ((c.Price >= minPrice && c.Price <= maxPrice) || !checkBoxPrice.Checked)
                && ((c.EngineSize >= minEngine && c.EngineSize <= maxEngine) || !checkBoxEngine.Checked)
                ).OrderBy(c => c.Make);

            //display selected car list, count and avarage value
            foreach (Car car in selectedCar)
            {
                dataGridViewSelectCar.Rows.Add(car.Make, car.Year, car.Color, car.EngineSize, car.Price, car.Dealer);
                totalPrice += car.Price; //add each car's price to total price
            }
            numberOfCar = selectedCar.Count();
            avgPrice = totalPrice / numberOfCar;
            labelCountSelectResult.Text = numberOfCar.ToString();
            labelAvgSelectCarResult.Text = avgPrice.ToString("c2");

        }
        /// <summary>
        /// reset filter button and initialize the form
        /// </summary>
        private void ResetFilter()
        {
            InitialStateGridView();
            //price filter
            checkBoxPrice.Click -= CheckBoxPrice_Click;
            //engine size filter
            checkBoxEngine.Click -= CheckBoxEngine_Click;

            //update when text in textbox is changed (price, enginesize)
            textBoxMinEngine.TextChanged -= TextBoxMinEngine_TextChanged;
            textBoxMaxEngine.TextChanged -= TextBoxMaxEngine_TextChanged;
            textBoxMinPrice.TextChanged -= TextBoxMinPrice_TextChanged;
            textBoxMaxPrice.TextChanged -= TextBoxMaxPrice_TextChanged;

            checkBoxPrice.Checked = false;
            checkBoxEngine.Checked = false;
            textBoxMinPrice.Text = ""; //how can i not diplay error message after setting text null??
            textBoxMaxPrice.Text = "";
            textBoxMinEngine.Text = "";
            textBoxMaxEngine.Text = "";
            DisplaySelectedCarList();
            //dataGridViewSelectCar = dataGridViewAllCar;

        }
    }


    /// <summary>
    /// Contains all car properties.
    /// </summary>
    [Serializable()]
    public class Car
    {
        public string Make { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal EngineSize { get; set; } // in litres
        public int Price { get; set; } // in dollars
        public string Dealer { get; set; } // dealer selling the car
        public Car() { }
    }
}
