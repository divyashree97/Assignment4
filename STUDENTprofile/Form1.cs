using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUDENTprofile
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader r = null;
        string constr = "Data Source=(local);Initial Catalog=STUDENTprofile;Integrated Security=True;Pooling=False";
        private object id;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {

            string roll = txtroll.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string phone = txtphone.Text;
            string gender = "";
            if (rbfemale.Checked)
            {
                gender = "female";

            }
            if (rbmale.Checked)
            {
                gender = "male";
            }
            string department = cbdept.SelectedItem.ToString();
            string course = cbcourse.SelectedItem.ToString();
            string semester = cbsem.SelectedItem.ToString();

            try
            {
                con = new SqlConnection(constr);
                con.Open();
                string query = " insert into STUDENTprofile values(@roll,@name,@date,@gender,@dept,@course,@sem,@address,@phone)"; //giving parameyers to sql query
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@roll", roll);
                cmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dtpdateof.Value.Date;

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@course", course);

                cmd.Parameters.AddWithValue("@sem", semester);

                cmd.Parameters.AddWithValue("@address", address);

                cmd.Parameters.AddWithValue("@phone", phone);

                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                    MessageBox.Show("DATA INSERTED " + res);



            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {







            }
        }

        private void txtroll_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnselect_Click(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(constr);
                con.Open();
                string query = "select * from STUDENTprofile";
                cmd = new SqlCommand(query, con);
                r = cmd.ExecuteReader();
                lbselect.Items.Clear();


                while (r.Read())
                {
                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        lbselect.Items.Add(r[i]);


                    }
                    lbselect.Items.Add("************");
                }






            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();





            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string add = txtaddress.Text;
            string phn = txtphone.Text;
            string department = cbdept.SelectedItem.ToString();
            string course = cbcourse.SelectedItem.ToString();
            string semester = cbsem.SelectedItem.ToString();

            try
            {

                string id = txtroll.Text;
                MessageBox.Show("ID is : " + id);
                con = new SqlConnection(constr);
                con.Open();
                string query = "update STUDENTprofile set department= @dept ,course=@course,semester=@sem ,address=@address,phone = @phone where rollno= @id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@course", course);

                cmd.Parameters.AddWithValue("@sem", semester);

                cmd.Parameters.AddWithValue("@address", add);

                cmd.Parameters.AddWithValue("@phone", phn);
                cmd.Parameters.AddWithValue("@id", id);

                int res = cmd.ExecuteNonQuery();
                if (res > 0)

                    MessageBox.Show("updated" + res);

                else

                    MessageBox.Show("not updated ");







            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();










            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {


            try
            {

                string id = txtroll.Text;
                MessageBox.Show("ID is : " + id);
                con = new SqlConnection(constr);
                con.Open();
                string query = " delete from  STUDENTprofile where rollno = @id"; //giving parameyers to sql query
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)

                    MessageBox.Show("deleted" + res);

                else

                    MessageBox.Show("roll no not found ");








            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {

            try
            {

                string id = txtroll.Text;
                    con = new SqlConnection(constr);
                con.Open();
                string query = "select * from STUDENTprofile where rollno=@id ";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);


                r = cmd.ExecuteReader();
                lbselect.Items.Clear();


                while (r.Read())
                {
                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        lbselect.Items.Add(r[i]);


                    }

                    txtname.Text = r["name"].ToString();
                    dtpdateof.Text =((DateTime) r["Dateof"]).ToString();
                    if(r["gender"].ToString()=="male")
                        {
                        rbmale.Checked = true;

                    }
                    if (r["gender"].ToString() == "female")
                    {
                        rbfemale.Checked = true;

                    }
                    cbdept.SelectedItem = r["department"].ToString();
                    cbcourse.SelectedItem = r["course"].ToString();
                    cbsem.SelectedItem = r["semester"].ToString();
                    txtaddress.Text = r["address"].ToString();
                    txtphone.Text = r["phone"].ToString();



                    lbselect.Items.Add("************");




                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();







            }
        }
    }
}


