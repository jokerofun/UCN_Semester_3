namespace WebApp.Models
{
    public class BuyerName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BuyerName(string FirstName,string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public BuyerName()
        {

        }
    }
}