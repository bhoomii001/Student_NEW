using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication2.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Age { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Bhoomi Dangar\\Downloads\\Student_NEW\\Student_NEW\\WebApplication2\\AppData\\Student_Demo.mdf;Integrated Security=True");

        public List<Student> getData(string id)
        {
            List<Student> lstStu = new List<Student>();
            string query = "select * from StudentData";
            if (!string.IsNullOrWhiteSpace(id))
            {
                query = "select * from StudentData where Id =" + id;
            }
            SqlDataAdapter apt = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            apt.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstStu.Add(new Student { Id = Convert.ToInt32(dr["Id"].ToString()), Name = dr["Name"].ToString(), Email = dr["Email"].ToString(), Address = dr["Address"].ToString(), Age = dr["Age"].ToString() });
            }
            return lstStu;
        }

        //Insert a record into a database table
        public bool insert(Student Stu)
        {
            if (Stu.Name != string.Empty && Stu.Email != string.Empty && Stu.Address != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("insert into StudentData values(@name,@email,@address,@age)", con);
                cmd.Parameters.AddWithValue("@name", Stu.Name);
                cmd.Parameters.AddWithValue("@email", Stu.Email);
                cmd.Parameters.AddWithValue("@address", Stu.Address);
                cmd.Parameters.AddWithValue("@age", Stu.Age);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
            }

            return false;
        }

        //Update a record into a database table
        public bool update(Student Emp)
        {
            SqlCommand cmd = new SqlCommand("update StudentData set Name=@name, Email=@email,Address=@Address,Age=@age where Id = @id", con);
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@email", Emp.Email);
            cmd.Parameters.AddWithValue("@Address", Emp.Address);
            cmd.Parameters.AddWithValue("@age", Emp.Age);
            cmd.Parameters.AddWithValue("@id", Emp.Id); con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }

            return false;
        }

        //delete a record from a database table

        public bool delete(Student Emp)
        {
            SqlCommand cmd = new SqlCommand("delete StudentData where Id = @id", con); 
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

    }
}