
namespace HMSLibrary
{
    public class Reciption
    {
        SqlConnection con = new SqlConnection("Data Source=ANU;Initial Catalog=GSTHMS;Integrated Security=True;");
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public Reciption()
        { }

        public Reciption(Reciption rec)
        { }
        public void get()
        {
            //con.Open();
            //SqlCommand 
            //con.Close();
        }


        }
    }

