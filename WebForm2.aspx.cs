using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BMI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllRecords();
            }
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BodyRecord"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BodyRecord WHERE 1=1 ";

                if (!string.IsNullOrWhiteSpace(TextBox_NameSearch.Text))
                {
                    query += " AND Name LIKE @Name";
                }

                if (Calendar_Search.SelectedDate != DateTime.MinValue)
                {
                    query += " AND CONVERT(date, RecordDate) = @Date";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(TextBox_NameSearch.Text))
                    {
                        command.Parameters.AddWithValue("@Name", "%" + TextBox_NameSearch.Text + "%");
                    }

                    if (Calendar_Search.SelectedDate != DateTime.MinValue)
                    {
                        command.Parameters.AddWithValue("@Date", Calendar_Search.SelectedDate.Date);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    GridView_BMIRecords.DataSource = dt;
                    GridView_BMIRecords.DataBind();
                }
            }
        }

        private void LoadAllRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BodyRecord"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BodyRecord ORDER BY RecordDate DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    // 將身高從小數轉換為整數表示（例如 1.7 -> 170）
                    if (row["Height"] != DBNull.Value)
                    {
                        row["Height"] = (Convert.ToDouble(row["Height"]) * 100).ToString("0");
                    }

                    // 將 BMI 保留到小數點後第二位
                    if (row["BMI"] != DBNull.Value)
                    {
                        row["BMI"] = Convert.ToDouble(row["BMI"]).ToString("F2");
                    }

                    // 將性別轉換為繁體中文顯示
                    if (row["Gender"] != DBNull.Value)
                    {
                        string gender = row["Gender"].ToString();
                        row["Gender"] = gender == "male" ? "男性" : "女性";
                    }
                }

                GridView_BMIRecords.DataSource = dt;
                GridView_BMIRecords.DataBind();
            }
        }

        protected void Button_AddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}