using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Link04dz.Model
{
    [Table(Name = "TablesManufacturer")]
    public class TablesManufacturer
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int intManufacturerID { get; set; }

        [Column(Name = "strManufacturerChecklistId")]
        public string strManufacturerChecklistId { get; set; }

        [Column(Name = "strName")]
        public string strName { get; set; }


        [Association(ThisKey = "intManufacturerID", OtherKey = "intManufacturerID")]
        public EntitySet<newEquipment> newEquipmentsTab { get; set; }

        [Association(ThisKey = "intManufacturerID", OtherKey = "intManufacturerID")]
        public EntitySet<TablesModel> TablesModelsTab { get; set; }
    }
}
