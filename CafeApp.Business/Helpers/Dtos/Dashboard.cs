﻿namespace CafeApp.Business.Helpers.Dtos
{
    public class DashboardTableModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TableState State { get; set; }
        public DashboardFactorModel Factor { get; set; }
        public string LastConnectionId { get; set; }
        public TableState LastState { get; set; }
    }
    public enum TableState
    {
        filled = 0,
        empty = 1,
        requesting = 2
    }
    public class DashboardFactorModel
    {
        public int TableId { get; set; }
        public string TableTitle { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FactorNumber { get; set; }
        public DateTime RecordTime { get; set; }
        public long TotalPrice { get { return Items.Select(x => x.TotalPrice).Sum(); } }
        public long Paid { get; set; }
        public long Dongi { get { return Items.Select(x => x.UnitPrice * x.SubmittedDongi).Sum(); } }
        public ICollection<DashboardFactorItemModel> Items { get; set; }
        public DashboardFactorModel()
        {
            Items = new List<DashboardFactorItemModel>();
        }
    }
    public class DashboardFactorItemModel
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public long TotalPrice { get { return TotalAmount * UnitPrice; } }
        public long UnitPrice { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int SubmittedDongi { get; set; }
        public void SubmitDongi()
        {
            SubmittedDongi = PaidAmount;
        }

    }
}