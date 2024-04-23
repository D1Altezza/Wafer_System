using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Wafer_System.Auto_run_page1;

namespace Wafer_System
{
    public partial class Report_Form : Form
    {
        Main main;
        public Report_Form(Main main)
        {
            this.main = main;
            InitializeComponent();
        }
      
        private void Report_Form_Load(object sender, EventArgs e)
        {
            var col = main.db.GetCollection<RecData>("RecData");
            var data=col.FindAll().ToList();
            
            // 建立一個 DataTable
            var dataTable = new DataTable("CustomerTable");
           
          
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("FileName");
            dataTable.Columns.Add("Diameter");
            dataTable.Columns.Add("Diameter_Level");
            dataTable.Columns.Add("Thickness");
            dataTable.Columns.Add("Thickness_Level");
            dataTable.Columns.Add("TTV");
            dataTable.Columns.Add("TTV_Level");
            dataTable.Columns.Add("BOW");
            dataTable.Columns.Add("BOW_Level");
            dataTable.Columns.Add("WARP");
            dataTable.Columns.Add("WARP_Level");
            dataTable.Columns.Add("WaferID");
            dataTable.Columns.Add("Cassette_Number");
            dataTable.Columns.Add("Slot");
            dataTable.Columns.Add("LaserRawData");
            dataTable.Columns.Add("IsActive");

        
            // 添加資料列
            foreach (var item in data)
            {
                var row = dataTable.NewRow();
                row["Id"] = item.Id;
                row["FileName"] = item.FileName;
                row["Diameter"] = item.Diameter;
                row["Diameter_Level"] = item.Diameter_Level;
                row["Thickness"] = item.Thickness;
                row["Thickness_Level"] = item.Thickness_Level;
                row["TTV"] = item.TTV;
                row["TTV_Level"] = item.TTV_Level;
                row["BOW"] = item.BOW;
                row["BOW_Level"] = item.BOW_Level;
                row["WARP"] = item.WARP;
                row["WARP_Level"] = item.WARP_Level;
                row["WaferID"] = item.WaferID;
                row["Cassette_Number"] = item.Cassette_Number;
                row["Slot"] = item.Slot;
                row["LaserRawData"] = item.LaserRawData;
                row["IsActive"] = item.IsActive;

                // 其他欄位...
                dataTable.Rows.Add(row);
            }

            // 建立一個 DataSet
            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            //reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dataTable));



            this.reportViewer1.RefreshReport();
        }
    }
}
