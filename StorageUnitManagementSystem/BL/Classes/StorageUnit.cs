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
            //
            //Property Name : deflaut constructor
            //Purpose       : Public property to give access to _line1 instance variable
            //Re-use        : none
            //Input         : none
            //                
            //Output        : noe
            //
        }

        public bool UnitOccupied
        {
            //
            //Property Name : property string Line1
            //Purpose       : Public property to give access to _line1 instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _line1
            //Output        : string
            //                - value stored in _line1 instance variable
            //
            get { return _unitOccupied; }//end get
            set { _unitOccupied = value; }//end set
        }//end property

        public bool UnitArrears
        {
            //
            //Property Name : property string Line1
            //Purpose       : Public property to give access to _unitArrears instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitArrears
            //Output        : string
            //                - value stored in _unitArrears instance variable
            //
            get { return _unitArrears; }//end get
            set { _unitArrears = value; }//end set
        }//end property

        public bool UnitInAdvance
        {
            //
            //Property Name : property string UnitInAtvance
            //Purpose       : Public property to give access to _unitInAdvance instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitInAdvance
            //Output        : string
            //                - value stored in _unitInAdvance instance variable
            //
            get { return _unitInAdvance; }//end get
            set { _unitInAdvance = value; }//end set
        }//end proterty

        public bool UnitUpToDate
        {
            //
            //Property Name : property string UnitUpToData
            //Purpose       : Public property to give access to _unitUpToDate instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitUpToDate
            //Output        : string
            //                - value stored in _unitUpToDate instance variable
            //
            get { return _unitUpToDate; }//end get
            set { _unitUpToDate = value; }//end set
        }//end property

        public string UnitOwnerId
        {
            //
            //Property Name : property string UnitOwnerId
            //Purpose       : Public property to give access to _unitOwnerId instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitOwnerId
            //Output        : string
            //                - value stored in _unitOwnerId instance variable
            //
            get { return _unitOwnerId; }//end get
            set { _unitOwnerId = value; }//end set
        }//end property




        public string UnitId
        {
            //
            //Property Name : property string UnitId
            //Purpose       : Public property to give access to _unitId instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitId
            //Output        : string
            //                - value stored in _unitId instance variable
            //
            get { return _unitId; }//end get
            set { _unitId = value; }//end set
        }//end propery



        public string UnitClassification
        {
            //
            //Property Name : property string UserClassification
            //Purpose       : Public property to give access to _userClassification instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitClassification
            //Output        : string
            //                - value stored in _unitClassification instance variable
            //
            get { return _unitClassification; }//end get
            set { _unitClassification = value; }//end set
        }//end property



        public string UnitSize
        {
            //
            //Property Name : property string UnitSize
            //Purpose       : Public property to give access to _unitSize instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _uniteSize
            //Output        : string
            //                - value stored in _unitSize instance variable
            //
            get { return _unitSize; }//end get
            set { _unitSize = value; }//end set
        }//end property

        public double UnitPrice
        {
            //
            //Property Name : property string Line1
            //Purpose       : Public property to give access to _unitPrice instance variable
            //Re-use        : none
            //Input         : string value
            //                - the user supplied _unitPrice
            //Output        : string
            //                - value stored in _unitPrice instance variable
            //
            get { return _unitPrice; }//end get
            set { _unitPrice = value; }//end set
        }//end property
    }//end class
}//end namespace
