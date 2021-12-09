using FirebirdSql.Data.FirebirdClient;
using Ingeo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IngeoClassLibrary
{
    public class Database : IDisposable
    {
        // Создание экземпляра объекта
        public Database()
        {
            //подключение к БД
            String db_path = Path.GetDirectoryName(
             Assembly.GetCallingAssembly().Location) + "\\database.fdb";
            FbConnectionStringBuilder cs =
                        new FbConnectionStringBuilder();
            cs.Database = db_path;
            cs.UserID = "SYSDBA";
            cs.Password = "master";
            cs.Charset = "NONE";
            DbConnection = new FbConnection(cs.ToString());
            DbConnection.Open();
        }

        // Объект подключения к БД
        public FbConnection DbConnection = null;

        // Удаление информации по объекту
        public void DeleteObject(String object_id)
        {
            using (FbCommand cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText = "delete from OBJECT_DATA where OBJECT_ID=?";
                cmd.Parameters.AddWithValue("ID", object_id);
                cmd.ExecuteNonQuery();
            }
        }

        // Чтение информации по объекту из БД. 
        // Возвращает true если данные прочитаны в выходные переменные
        public bool ReadObjectData(String object_id, out Decimal object_square, out String object_coords)
        {
            using (FbCommand cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText =
                  "select * from OBJECT_DATA where OBJECT_ID=?";
                cmd.Parameters.AddWithValue("ID", object_id);
                using (FbDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        object_square =
                          Convert.ToDecimal(rdr["OBJECT_SQUARE"]);
                        object_coords = rdr["OBJECT_COORDS"].ToString();
                        return true;
                    }
                    else
                    {
                        object_square = 0;
                        object_coords = "";
                        return false;
                    }
                }
            }
        }

        // Сохранение информации по объекту
        public void SaveObjectData(String object_id,
                IngeoControl ingeoControl)
        {
            //получение списка вершин объекта
            IIngeoMapObject map_obj = ingeoControl.FApplication.ActiveDb.
                        MapObjects.GetObject(object_id);
            String object_coords_str = ingeoControl.ObjectToString(object_id);

            //создание пустой записи по объекту, если он не существует
            using (FbCommand cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText =
                  "select count(*) from OBJECT_DATA where OBJECT_ID=?";
                cmd.Parameters.AddWithValue("ID", object_id);
                int cnt = Convert.ToInt32(cmd.ExecuteScalar());
                if (cnt == 0)
                {
                    using (FbCommand cmd_ins = DbConnection.CreateCommand())
                    {
                        cmd_ins.CommandText =
                          "insert into OBJECT_DATA (OBJECT_ID) values (?)";
                        cmd_ins.Parameters.AddWithValue("ID", object_id);
                        cmd_ins.ExecuteNonQuery();
                    }
                }
            }

            //обновление существующей записи по объекту
            using (FbCommand cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText =
"update OBJECT_DATA set OBJECT_SQUARE=?, OBJECT_COORDS=? where OBJECT_ID=?";
                cmd.Parameters.AddWithValue("SQUARE",
                  Math.Round(map_obj.Square, 5));
                cmd.Parameters.AddWithValue("COORDS", object_coords_str);
                cmd.Parameters.AddWithValue("ID", object_id);
                cmd.ExecuteNonQuery();
            }
        }

        // закрытие подключения к БД при удалении объекта
        public void Dispose()
        {
            DbConnection.Close();
        }
    }

}
