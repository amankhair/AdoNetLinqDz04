using System;
using System.Data.Linq.Mapping;

namespace Link04dz.Model
{
    [Table(Name = "NewTable")]
    public class NewTable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int TableTask2Id { get; set; }

        [Column(Name = "intGarageRoom")]
        public string intGarageRoom { get; set; }

        [Column(Name = "strSerialNo")]
        public string strSerialNo { get; set; }

        [Column(Name = "intTypeHistory")]
        public int? intTypeHistory { get; set; }

        [Column(Name = "dStartDate")]
        public DateTime? dStartDate { get; set; }

        [Column(Name = "dEndDate")]
        public DateTime? dEndDate { get; set; }

        [Column(Name = "intDaysCount")]
        public int? intDaysCount { get; set; }

        [Column(Name = "intStatys")]
        public int? intStatys { get; set; }
    }
}
