using DataTableAccessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace StudentRegistrationApp
{
    public partial class StudentRegistrationAppForm : Form
    {

        // field to keep the access layer field

        private SqlDataTableAccessLayer registrationDB;

        // dataset will hold all tables being used

        private DataSet registrationDataSet;

        public StudentRegistrationAppForm()
        {
            InitializeComponent();

            // form display name

            Text = "Student Registration App";

            // get a new access layer and dataset

            registrationDB = new SqlDataTableAccessLayer();

            registrationDataSet = new DataSet()
            {
                // must be named for backup purposes

                DataSetName = "StudentRegistrationDataSet",
            };

            //get the connection string from App.config and openconnection
            string connectionString = registrationDB.GetConnectionString("StudentRegistrationDB");
            registrationDB.OpenConnection(connectionString);

            InitializeDataGridViewAndDataSet(dataGridViewDepartments, registrationDataSet, "Departments");
            InitializeDataGridViewAndDataSet(dataGridViewStudents, registrationDataSet, "Students");

            //DepartmentMajorsCount is a view
            dataGridViewDepartmentMajorsCount.DataSource = registrationDB.GetDataTable("DepartmentMajorsCount");
            dataGridViewDepartmentMajorsCount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDepartmentMajorsCount.ReadOnly = true;
            dataGridViewDepartmentMajorsCount.AllowUserToAddRows = false; //user unable to edit or add rows
            dataGridViewDepartmentMajorsCount.RowHeadersVisible = false;

            //event handlers to backup and restore the database using DAL methods
            buttonBackupDatabase.Click += (s, e) => registrationDB.BackupDataSetToXML(registrationDataSet);
            buttonRestoreDatabaseFromBackup.Click += (s, e) => registrationDB.RestoreDataSetFromBackup(registrationDataSet);


            this.FormClosing += (s, e) => registrationDB.CloseConnection();

        }

        /// <summary>
        /// Initialize datagridview control and associated data table
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        public void InitializeDataGridViewAndDataSet(DataGridView dataGridView, DataSet dataSet, string tableName)
        {
            //get the table filled from the database
            DataTable table = registrationDB.GetDataTable(tableName);

            //set the datasource to the tabel
            dataGridView.DataSource = table;
            //autosize columns mode set to fill
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //multiselect set to true
            dataGridView.MultiSelect = true;

            //this is for datagridviewstudent
            if (table.Columns[0].AutoIncrement == true)
            {
                dataGridView.DefaultValuesNeeded += (s, e) => NewRowBeingAdded(s as DataGridView, e);
            }

            //handle insertion
            table.RowChanged += Table_RowChanged;

            //handle any column changes (cells)
            table.ColumnChanged += Table_ColumnChanged;
            //handle deltion
            table.RowDeleted += Table_RowDeleted;

            dataSet.Tables.Add(table); //for backup and restore

        }
        /// <summary>
        /// delete a row in the database given the datarow that was deleted from the control and datatable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                registrationDB.DeleteTableRow(e.Row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //update view
            registrationDB.LoadDataTable(dataGridViewDepartmentMajorsCount.DataSource as DataTable);

        }

        /// <summary>
        /// update database with the changed column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            //Only do this if an existing cell is changed (for update)
            if (e.Row.RowState != DataRowState.Detached)
            {
                //if this is an identity column, it is only modified by the insert tablerow
                if (e.Column.AutoIncrement == false)
                {
                    //update the entire row
                    try
                    {
                        registrationDB.UpdateTableRow(e.Row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //reload student datatable
                    registrationDB.LoadDataTable(dataGridViewStudents.DataSource as DataTable);
                    //update view
                    registrationDB.LoadDataTable(dataGridViewDepartmentMajorsCount.DataSource as DataTable);
                }
            }
        }

        /// <summary>
        /// Insert a record into the db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //insert if there was an add action
            if (e.Action == DataRowAction.Add)
            {
                try
                {
                    registrationDB.InsertTableRow(e.Row);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insertion failed: " + ex.Message);
                }

                //update view (dapartmentmajorscount)
                registrationDB.LoadDataTable(dataGridViewDepartmentMajorsCount.DataSource as DataTable);
            }
        }

        /// <summary>
        /// If a new row is being added, set the id column in the control to -1
        /// </summary>
        /// <param name="e"></param>
        private void NewRowBeingAdded(DataGridView dataGridView, DataGridViewRowEventArgs e)
        {
            DataTable table = dataGridView.DataSource as DataTable;

            if (table.Columns[0].AutoIncrement == true)
            {
                e.Row.Cells[0].Value = -1;
            }
        }

    }
}
