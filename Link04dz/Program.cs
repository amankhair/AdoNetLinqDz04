using Link04dz.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Link04dz
{
    class Program
    {
        static McsDB db = new McsDB();

        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            Task6();
        }

        static void Task1()
        {
            //Пункт 2
            //Используя класс DataContext произвести выборку данных из таблицы TableEquipmentHistory и newEquipment 
            //используя при этом join выгрузить следующие данные: intGarageRoom, strSerialNo, intTypeHistory, 
            //dStartDate, dEndDate, intDaysCount, intStatys

            var data = db.GetTable<TableEquipmentHistory>()
                .Join(db.GetTable<newEquipment>(),
                    teh => teh.intEquipmentID,
                    ne => ne.intEquipmentID,
                    (teh, ne) => new
                    {
                        intGarageRoom = ne.intGarageRoom,
                        strSerialNo = ne.strSerialNo,
                        intTypeHistory = teh.intTypeHistory,
                        dStartDate = teh.dStartDate,
                        dEndDate = teh.dEndDate,
                        intDaysCount = teh.intDaysCount,
                        intStatys = teh.intStatys
                    });

            db.Log = Console.Out;

            foreach (var item in data)
            {
                Console.WriteLine("intGarageRoom: {0}", item.intGarageRoom);
                Console.WriteLine("strSerialNo: {0}", item.strSerialNo);
                Console.WriteLine("intTypeHistory: {0}", item.intTypeHistory);
                Console.WriteLine("dStartDate: {0}", item.dStartDate);
                Console.WriteLine("dEndDate: {0}", item.dEndDate);
                Console.WriteLine("intDaysCount: {0}", item.intDaysCount);
                Console.WriteLine("intStatys: {0}", item.intStatys);
                Console.WriteLine();
            }
        }

        static void Task2()
        {
            //Пункт 3
            //Из результатов пункта 2, создать таблицу в БД, и результаты первой выборки загрузить во вновь созданную таблицу

            string sqlCmd = "CREATE TABLE NewTable " +
                            "(TableTask2Id INT NOT NULL PRIMARY KEY IDENTITY(1,1)," +
                            "intGarageRoom NVARCHAR(20)," +
                            "strSerialNo NVARCHAR(20)," +
                            "intTypeHistory INT," +
                            "dStartDate DATETIME," +
                            "dEndDate DATETIME," +
                            "intDaysCount INT," +
                            "intStatys INT)";
            db.ExecuteCommand(sqlCmd);
            db.SubmitChanges();

            var data = db.GetTable<TableEquipmentHistory>()
                .Join(db.GetTable<newEquipment>(),
                    teh => teh.intEquipmentID,
                    ne => ne.intEquipmentID,
                    (teh, ne) => new
                    {
                        intGarageRoom = ne.intGarageRoom,
                        strSerialNo = ne.strSerialNo,
                        intTypeHistory = teh.intTypeHistory,
                        dStartDate = teh.dStartDate,
                        dEndDate = teh.dEndDate,
                        intDaysCount = teh.intDaysCount,
                        intStatys = teh.intStatys
                    });

            List<NewTable> ntList = new List<NewTable>();

            foreach (var item in data.ToList())
            {
                NewTable nt = new NewTable();

                nt.intGarageRoom = item.intGarageRoom;
                nt.strSerialNo = item.strSerialNo;
                nt.intTypeHistory = item.intTypeHistory;
                nt.dStartDate = item.dStartDate;
                nt.dEndDate = item.dEndDate;
                nt.intDaysCount = item.intDaysCount;
                nt.intStatys = item.intStatys;

                ntList.Add(nt);
            }

            db.GetTable<NewTable>().InsertAllOnSubmit(ntList);
            db.SubmitChanges();
            Console.WriteLine("Операция прошла успешно!");

            //Возможно есть более оптимальный вариант, но это то, что у меня получилось)
        }

        static void Task3()
        {
            //Используя присоединённый режим, произвести добавление записей в таблицу newEquipment, 
            //при  этом необходимо произвести запись данных так же в таблицу TablesManufacturer, 
            //для таких моделей как: Audi, BMW,KIA, JEEP

            string insertValues = "INSERT TablesManufacturer VALUES (null, 'Audi')" +
                                  "INSERT TablesManufacturer VALUES (null, 'BMW')" +
                                  "INSERT TablesManufacturer VALUES (null, 'KIA')" +
                                  "INSERT TablesManufacturer VALUES (null, 'JEEP')" +
                                  //
                                  "INSERT newEquipment VALUES " +
                                  "('1230-A', 23, 138, '2010', 20, 'ACS123', 10, 9, 2, '05.04.2015', 15000, '12.12.2017', 26123.5, " +
                                  "26123.5, 32, 7, 0, 1, 0, 0, 0, 3, '', null, 4, null, null, 4, null, null, null, 0)" +
                                  //
                                  "INSERT newEquipment VALUES " +
                                  "('1330-B', 24, 138, '2010', 20, 'ACS123', 10, 9, 2, '05.04.2015', 15000, '12.12.2017', 26123.5, " +
                                  "26123.5, 32, 7, 0, 1, 0, 0, 0, 3, '', null, 4, null, null, 4, null, null, null, 0)" +
                                  //
                                  "INSERT newEquipment VALUES " +
                                  "('1430-K', 25, 138, '2010', 20, 'ACS123', 10, 9, 2, '05.04.2015', 15000, '12.12.2017', 26123.5, " +
                                  "26123.5, 32, 7, 0, 1, 0, 0, 0, 3, '', null, 4, null, null, 4, null, null, null, 0)" +
                                  //
                                  "INSERT newEquipment VALUES " +
                                  "('1530-J', 26, 138, '2010', 20, 'ACS123', 10, 9, 2, '05.04.2015', 15000, '12.12.2017', 26123.5, " +
                                  "26123.5, 32, 7, 0, 1, 0, 0, 0, 3, '', null, 4, null, null, 4, null, null, null, 0)";

            db.ExecuteCommand(insertValues);

            //что-то не так

        }

        static void Task4()
        {
            //Связать таблицы newEquipment с таблицами: TablesModel, TablesManufacturer:
            //a.используя отложенную загрузку данных
            //b.Использовать оптимальный вариант выгрузки данных, 
            //дабы сократить количество обращений к БД запросов.


            Table<newEquipment> newEquipments = db.GetTable<newEquipment>();

            var data = from eq in newEquipments
                       where eq.intManufacturerID == 1
                       select
                           from tmanuf in eq.TablesManufacturersTab
                           from tmod in eq.TablesModelsTab
                           select new
                           {
                               eq.intManufacturerID,
                               eq.strSerialNo,
                               tmanuf.strName,
                               tmod.strImage
                           };

            db.Log = Console.Out;

            foreach (var item in data)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine("intManufacturer: {0}", item2.intManufacturerID);
                    Console.WriteLine("strSerialNo: {0}", item2.strSerialNo);
                    Console.WriteLine("strName: {0}", item2.strName);
                    Console.WriteLine("strImage: {0}", item2.strImage);
                    Console.WriteLine();
                }
            }
        }

        static void Task5()
        {
            //Написать запрос для выгрузки данных из таблицы newEquipment.
            //Так же написать запрос из таблицы TablesModel, при этом модели машин должны быть только те, 
            //которых в таблице newEquipment > 10, результат этого запроса должен возвращать только intModelID.
            //Далее используя Contains выгрузить данные из таблицы newEquipment.

            Table<newEquipment> newEquipments = db.GetTable<newEquipment>();

            Table<TablesModel> Tmodels = db.GetTable<TablesModel>();

            //var data = (from tmod in Tmodels
            //    from eq in tmod.newEquipmentsTab
            //    where eq.intModelID > 10
            //    select new
            //    {
            //        tmod.intModelID
            //    }).ToList();

            IEnumerable<int> items = Tmodels.Where(w => w.intModelID > 10).Select(s => s.intModelID);

            var data2 = from eq in newEquipments
                        where items.Contains((int)eq.intModelID)
                        select new
                        {
                            eq.intModelID,
                            eq.strSerialNo
                        };

            foreach (var item in data2)
            {
                Console.WriteLine(item.intModelID + " - " + item.strSerialNo);
            }

            //не знаю насколько правильно получилось
        }

        static void Task6()
        {
            //Произвести удаление данных из таблицы TableEquipmentHistory, 
            //только те у которых dEndDate пусто. 
            //При этом удаление не должно содержать ни какие циклы.

            IEnumerable<TableEquipmentHistory> eqHistory = db.GetTable<TableEquipmentHistory>();

            var data = from eh in eqHistory
                       where eh.dEndDate == null
                       select eh;

            db.GetTable<TableEquipmentHistory>().DeleteAllOnSubmit(data);
            db.SubmitChanges();
            Console.WriteLine("Объекты удалены");
        }
    }
}
