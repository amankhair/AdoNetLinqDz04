using System.Data.Linq;

namespace Link04dz.Model
{
    class McsDB : DataContext
    {
        public McsDB() : base(@"Data Source=AMANKELDI-PC;Initial Catalog=MCS; integrated security=true")
        {

        }

        public Table<TableEquipmentHistory> TableEquipmentHistorys { get; set; }
        public Table<newEquipment> newEquipments { get; set; }
        public Table<TablesModel> TablesModels { get; set; }
        public Table<TablesManufacturer> TablesManufacturers { get; set; }

        public Table<NewTable> NewTables { get; set; }
    }

}
