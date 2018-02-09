using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Link04dz.Model
{
    [Table(Name = "TablesModel")]
    public class TablesModel
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int intModelID { get; set; }

        [Column(Name = "strName")]
        public string strName { get; set; }

        [Column(Name = "intManufacturerID")]
        public int intManufacturerID { get; set; }

        [Column(Name = "intSMCSFamilyID")]
        public int intSMCSFamilyID { get; set; }

        [Column(Name = "strImage")]
        public string strImage { get; set; }

        [Association(ThisKey = "intManufacturerID", OtherKey = "intManufacturerID")]
        public EntitySet<TablesManufacturer> TablesManufacturersTab { get; set; }

        [Association(ThisKey = "intModelID", OtherKey = "intModelID")]
        public EntitySet<newEquipment> newEquipmentsTab { get; set; }
    }
}
