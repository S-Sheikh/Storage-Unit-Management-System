using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StorageUnitManagementSystem.BL.Classes
{
    public class LeaseUnits
    {
        private Client client;
        //private string clientId;
        //private string clientSurname;
        //private string clientName;
        private StorageUnit storageUnit;
        //private string unitId;
        //private string unitClass;
        private int noOfUnits; 
        private int availableUnits;
        private string typeOfPayment;
        private string dateOfPayment;
        private string dateOfContractStart;
        private string dateOfContractEnd;
        private string amountPaid;
        private string amountOwed;
        private string amountDeposited;
        private string clientCurrentTotal;
        private bool clientWaitingList;
        private bool unitLeased;
        private bool clientAdded;

        public LeaseUnits()
        {
            client = new Client();
            storageUnit = new StorageUnit();
        }

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        public StorageUnit StorageUnit
        {
            get { return storageUnit; }
            set { storageUnit = value; }
        }

        public int NoOfUnits
        {
            get { return noOfUnits; }
            set { noOfUnits = value; }
        }

        public int AvailableUnits
        {
            get { return availableUnits; }
            set { availableUnits = value; }
        }

        public string TypeOfPayment
        {
            get { return typeOfPayment; }
            set { typeOfPayment = value; }
        }

        public string DateOfPayment
        {
            get { return dateOfPayment; }
            set { dateOfPayment = value; }
        }

        public string DateOfContractStart
        {
            get { return dateOfContractStart; }
            set { dateOfContractStart = value; }
        }

        public string DateOfContractEnd
        {
            get { return dateOfContractEnd; }
            set { dateOfContractStart = value; }
        }

        public string AmountPaid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }

        public string AmountOwed
        {
            get { return amountOwed; }
            set { amountOwed = value; }
        }

        public string AmountDeposited
        {
            get { return amountDeposited; }
            set { amountDeposited = value; }
        }

        public string ClientCurrentTotal
        {
            get { return clientCurrentTotal; }
            set { clientCurrentTotal = value; }
        }

        public bool ClientWaitingList
        {
            get { return clientWaitingList; }
            set { clientWaitingList = value; }
        }

        public bool UnitLeased
        {
            get { return unitLeased; }
            set { unitLeased = value; }
        }

        public bool ClientAdded
        {
            get { return clientAdded; }
            set { clientAdded = value; }
        }

        public string LeaseID;
    }
}
