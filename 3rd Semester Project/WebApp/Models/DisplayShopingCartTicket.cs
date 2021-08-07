using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class DisplayShopingCartTicket
    {
        public int Id { get; set; }
        public string TicketName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int AmountBought { get; set; }
        public Nullable<int> TripId { get; set; }
        private List<BuyerName> buyerNameList { get; set; }

        public DisplayShopingCartTicket(int Id, string TicketName, Nullable<decimal> Price, int AmountBought, Nullable<int> TripId)
        {
            this.Id = Id;
            this.TicketName = TicketName;
            this.Price = Price;
            this.AmountBought = AmountBought;
            this.TripId = TripId;
        }

        public DisplayShopingCartTicket()
        {
            buyerNameList = new List<BuyerName>();
        }

        //To revise
        public List<BuyerName> GetListOfBuyerNames()
        {
            return buyerNameList;
        }

        public void AddBuyerName(BuyerName buyerName)
        {
            buyerNameList.Add(buyerName);
        }

        public BuyerName GetName()
        {
            BuyerName temp = new BuyerName();
            temp = buyerNameList.First();
            buyerNameList.Remove(buyerNameList.First());
            return temp;
        }
        public void ClaerBuyerNameList()
        {
            buyerNameList.Clear();
        }
    }
}