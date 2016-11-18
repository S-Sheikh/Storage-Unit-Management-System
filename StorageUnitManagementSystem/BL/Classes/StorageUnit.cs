namespace StorageUnitManagementSystem.BL.Classes
{
    //Programmer  : Shahbaaz Sheikh; Student Number: 214066614
    //Purpose     : Class for StorageUnits
    public class StorageUnit
    {
        private string _unitClassification;
        private string _unitSize;
        private double _unitPrice;
        private bool _unitArrears;
        private bool _unitUpToDate;
        private bool _unitInAdvance;
        private bool _unitOccupied;
        private string _unitOwnerId;
        private string _unitId;

        public StorageUnit()
        {
        }

        public bool UnitOccupied
        {
            get { return _unitOccupied; }
            set { _unitOccupied = value; }
        }

        public bool UnitArrears
        {
            get { return _unitArrears; }
            set { _unitArrears = value; }
        }

        public bool UnitInAdvance
        {
            get { return _unitInAdvance; }
            set { _unitInAdvance = value; }
        }

        public bool UnitUpToDate
        {
            get { return _unitUpToDate; }
            set { _unitUpToDate = value; }
        }

        public string UnitOwnerId
        {
            get { return _unitOwnerId; }
            set { _unitOwnerId = value; }
        }




        public string UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }



        public string UnitClassification
        {
            get { return _unitClassification; }
            set { _unitClassification = value; }
        }



        public string UnitSize
        {
            get { return _unitSize; }
            set { _unitSize = value; }
        }

        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
    }
}
