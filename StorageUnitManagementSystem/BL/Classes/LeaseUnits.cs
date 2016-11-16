namespace StorageUnitManagementSystem.BL.Classes
{
    public class LeaseUnits
    {
        public LeaseUnits()
        {
            Client = new Client();
            StorageUnit = new StorageUnit();
        }

        public Client Client { get; set; }

        public StorageUnit StorageUnit { get; set; }

        public string LeaseID { get; set; }


        public int NoOfUnits { get; set; }

        public string AvailableUnits { get; set; }

        public string TypeOfPayment { get; set; }

        public string DateOfPayment { get; set; }

        public string DateOfContractStart { get; set; }

        public string DateOfContractEnd { get; set; }

        public string AmountPaid { get; set; }

        public string AmountOwed { get; set; }

        public string AmountDeposited { get; set; }

        public string ClientCurrentTotal { get; set; }

        public bool ClientWaitingList { get; set; }

        public bool UnitLeased { get; set; }

        public bool ClientAdded { get; set; }

        public string TotalUnitPrice { get; set; }
    }
}
