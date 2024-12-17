using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace BMI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 初始化頁面時可以做一些預設設定
        }

        protected void Button_Calculate_Click(object sender, EventArgs e)
        {
            // 檢查輸入是否為空
            if (string.IsNullOrWhiteSpace(TextBox_Name.Text) ||
                string.IsNullOrWhiteSpace(TextBox_Height.Text) ||
                string.IsNullOrWhiteSpace(TextBox_Weight.Text) ||
                RadioButtonList_Gender.SelectedValue == "")
            {
                Label_Result.Text = "請填寫所有資訊";
                return;
            }

            Person pp = new Person
            {
                Name = TextBox_Name.Text,
                Gender = RadioButtonList_Gender.SelectedValue
            };

            double height = Double.Parse(TextBox_Height.Text);
            double weight = Double.Parse(TextBox_Weight.Text);

            // 轉換單位
            if (DropDownList_HeightUnit.SelectedValue == "cm")
            {
                height = height / 100;
            }
            else if (DropDownList_HeightUnit.SelectedValue == "in")
            {
                height *= 0.0254;
            }

            if (DropDownList_WeightUnit.SelectedValue == "lb")
            {
                weight *= 0.45359237;
            }

            pp.Height = height;
            pp.Weight = weight;

            // 計算BMI
            double bmi = pp.CalBMI();

            // 依性別計算BMI敘述
            string bmiDescription = GetBMIDescription(bmi, pp.Gender);

            Label_Result.Text = $"BMI: {bmi:F2}<br/>{bmiDescription}";

            // 儲存資料到資料庫
            SaveToDatabase(pp, bmi, Calendar_RecordDate.SelectedDate);

            // 導向第二個頁面
            Response.Redirect("WebForm2.aspx");
        }

        private string GetBMIDescription(double bmi, string gender)
        {
            if (gender == "male")
            {
                if (bmi < 18.5) return "體重過輕(男性)";
                if (bmi >= 18.5 && bmi <= 24) return "正常體重範圍(男性)";
                if (bmi > 24 && bmi <= 27) return "體重過重(男性)";
                return "肥胖(男性)";
            }
            else // female
            {
                if (bmi < 18.5) return "體重過輕(女性)";
                if (bmi >= 18.5 && bmi <= 22) return "正常體重範圍(女性)";
                if (bmi > 22 && bmi <= 25) return "體重過重(女性)";
                return "肥胖(女性)";
            }
        }

        private void SaveToDatabase(Person person, double bmi, DateTime recordDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BodyRecord"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BodyRecord (Name, Gender, Height, Weight, BMI, RecordDate) " +
                               "VALUES (@Name, @Gender, @Height, @Weight, @BMI, @RecordDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", person.Name);
                    command.Parameters.AddWithValue("@Gender", person.Gender);
                    command.Parameters.AddWithValue("@Height", person.Height);
                    command.Parameters.AddWithValue("@Weight", person.Weight);
                    command.Parameters.AddWithValue("@BMI", bmi);
                    command.Parameters.AddWithValue("@RecordDate", recordDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}