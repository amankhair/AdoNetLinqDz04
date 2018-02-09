using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Link04dz.Model
{
    [Table(Name = "newEquipment")]
    public class newEquipment
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int intEquipmentID { get; set; }

        [Column(Name = "intGarageRoom")]
        public string intGarageRoom { get; set; }

        [Column(Name = "intManufacturerID")]
        public int? intManufacturerID { get; set; }

        [Column(Name = "intModelID")]
        public int intModelID { get; set; }

        [Column(Name = "strManufYear")]
        public string strManufYear { get; set; }

        [Column(Name = "intSNPrefixID")]
        public int? intSNPrefixID { get; set; }

        [Column(Name = "strSerialNo")]
        public string strSerialNo { get; set; }

        [Column(Name = "intEquipmentTypeID")]
        public int? intEquipmentTypeID { get; set; }

        [Column(Name = "intSMCSFamilyID")]
        public int? intSMCSFamilyID { get; set; }

        [Column(Name = "intSizeID")]
        public int? intSizeID { get; set; }

        [Column(Name = "CreateDate")]
        public DateTime? CreateDate { get; set; }

        [Column(Name = "intMetered")]
        public float? intMetered { get; set; }

        [Column(Name = "LastDate")]
        public DateTime? LastDate { get; set; }

        [Column(Name = "intLastMetered")]
        public float? intLastMetered { get; set; }

        [Column(Name = "intTotalMetered")]
        public float? intTotalMetered { get; set; }

        [Column(Name = "intlimitDay")]
        public int? intlimitDay { get; set; }

        [Column(Name = "intlimitWeek")]
        public int? intlimitWeek { get; set; }

        [Column(Name = "bitActive")]
        public bool? bitActive { get; set; }

        [Column(Name = "bitPreservation")]
        public bool? bitPreservation { get; set; }

        [Column(Name = "bitMeter")]
        public bool? bitMeter { get; set; }

        [Column(Name = "bitKTG")]
        public bool? bitKTG { get; set; }

        [Column(Name = "isDelete")]
        public bool? isDelete { get; set; } //constraint ?

        [Column(Name = "intLocationId")]
        public int? intLocationId { get; set; }

        [Column(Name = "strDescription")]
        public string strDescription { get; set; }

        [Column(Name = "floatCostTires")]
        public float? floatCostTires { get; set; }

        [Column(Name = "intCostTiresCurrency")]
        public int? intCostTiresCurrency { get; set; }

        [Column(Name = "floatAverageDivergence")]
        public float? floatAverageDivergence { get; set; }

        [Column(Name = "floatFullPrice")]
        public float? floatFullPrice { get; set; }

        [Column(Name = "intFullPriceCurrency")]
        public int? intFullPriceCurrency { get; set; }

        [Column(Name = "dateStartUpDate")]
        public DateTime? dateStartUpDate { get; set; }

        [Column(Name = "intServiceLife")]
        public int? intServiceLife { get; set; }

        [Column(Name = "intHoweverOddsAcceleration")]
        public int? intHoweverOddsAcceleration { get; set; }

        [Column(Name = "bitMethodAmortization")]
        public bool? bitMethodAmortization { get; set; }


        [Association(ThisKey = "intEquipmentID", OtherKey = "intEquipmentID")]
        public EntitySet<TableEquipmentHistory> TableEquipmentHistoriesTab { get; set; }

        [Association(ThisKey = "intManufacturerID", OtherKey = "intManufacturerID")]
        public EntitySet<TablesManufacturer> TablesManufacturersTab { get; set; }

        [Association(ThisKey = "intModelID", OtherKey = "intModelID")]
        public EntitySet<TablesModel> TablesModelsTab { get; set; }
    }
}
