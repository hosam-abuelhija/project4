using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace codesphere
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string id = txtID.Text;
            if (IsValidStudent(email, id))
            {
                lblMessage.Text = "Login successful!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("Courses for student.aspx");
            }
            else
            {
                lblMessage.Text = "Login failed. Student not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool IsValidStudent(string email, string id)
        {
            try
            {
                string[] studentLines = File.ReadAllLines(Server.MapPath("~/students.txt"));
                foreach (string line in studentLines)
                {
                    var studentData = line.Split(',');
                    if (studentData.Length == 2 && studentData[0].Equals(email, StringComparison.OrdinalIgnoreCase) && studentData[1] == id)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error reading students file: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            return false;
        }
    }
}