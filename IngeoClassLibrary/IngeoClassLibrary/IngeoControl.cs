using Ingeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngeoClassLibrary
{
    struct DoublePoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        // Конструктор
        public DoublePoint(double x, double y) : this()
        {
            X = x;
            Y = y;
        }
        // Метод проверки на равенство точек
        public bool Equals(DoublePoint point)
        {
            return (point.X == this.X && point.Y == this.Y) ? true : false;
        }
    }
    // Структура «Линия» с вещественными точками
    struct DoubleLine
    {
        public DoublePoint P1 { get; set; }
        public DoublePoint P2 { get; set; }
        // Конструктор (передаем точки)
        public DoubleLine(DoublePoint p1, DoublePoint p2) : this()
        {
            P1 = p1;
            P2 = p2;
        }
        // Конструктор (передаем координаты точек)
        public DoubleLine(double x1, double y1, double x2, double y2) : this()
        {
            P1 = new DoublePoint(x1, y1);
            P2 = new DoublePoint(x2, y2);
        }
        // Вычисление длины линии
        public double getLength()
        {
            return Math.Sqrt(Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2));
        }
    }


    public class IngeoControl
    {
        public IIngeoApplication FApplication { get; private set; }
        public List<string> vectorMaps { get; private set; }
        public List<string> vectorMapsID { get; private set; }
        public IIngeoMapObjects mapObjects { get; private set; }
        public IngeoControl(IIngeoApplication app)
        {
            FApplication = app;
            vectorMaps = new List<string>();
            vectorMapsID = new List<string>();
            mapObjects = FApplication.ActiveDb.MapObjects;
        }
        // Получение списка идентификаторов объектов слоя
        public List<string> GetObjectIDFromLayerID(string aLayerID)
        {
            List<string> objectsID = new List<string>();
            IIngeoMapObjectsQuery aLayerObjects =
                    mapObjects.QueryByLayers(aLayerID);
            while (!aLayerObjects.EOF)
            {
                objectsID.Add(aLayerObjects.ObjectID);
                aLayerObjects.MoveNext();
            }
            return objectsID;
        }
        // Получение списка слоев карты
        public List<string> GetLayersIDFromMapID(string mapID)
        {
            List<string> layersID = new List<string>();
            IIngeoMap aMap;
            IIngeoLayer aLayer;
            aMap = FApplication.ActiveDb.MapFromID(mapID);
            if (aMap.MapType == TIngeoMapType.inmtVector)
            {
                IIngeoVectorMap vectorMap;
                vectorMap = (IIngeoVectorMap)aMap;
                for (int i = 0; i < vectorMap.Layers.Count; i++)
                {
                    aLayer = vectorMap.Layers[i];
                    layersID.Add(aLayer.ID);
                }
            }
            return layersID;
        }
        // Получение объекта карты по идентификатору
        public IIngeoMapObject GetMapObjectFromID(string objID)
        {
            return mapObjects.GetObject(objID);
        }
        // Получение информации о карте 
        public List<string> GetMapsInfo()
        {
            vectorMaps.Clear();
            vectorMapsID.Clear();

            List<string> IDobjects = new List<string>();
            IIngeoAreas anAreas = FApplication.ActiveDb.Areas;
            // Проходим по всем территориям и их картам
            foreach (IIngeoArea anArea in anAreas)
                for (int j = 0; j < anArea.Maps.Count; j++)
                    if (anArea.Maps[j].MapType == TIngeoMapType.inmtVector)
                    {
                        // Выбираем только векторные карты
                        IIngeoVectorMap aVectorMap =
                             (IIngeoVectorMap)anArea.Maps[j];
                        vectorMaps.Add(aVectorMap.Name);
                        vectorMapsID.Add(aVectorMap.ID);
                        // Проходим по слоям и добавляем все объекты в список
                        IIngeoLayers aLayers = aVectorMap.Layers;
                        for (int i = 0; i < aLayers.Count; i++)
                        {
                            IIngeoLayer aLayer = aLayers[i];
                            IDobjects.AddRange(GetObjectIDFromLayerID
                                     (aLayer.ID));
                        }
                    }
            return IDobjects;
        }
        // Получение идентификатора выделенного на карте объекта
        public string GetSelectObjectId(out string status)
        {
            string id = null;
            if (FApplication.Selection.Count == 0)
            {
                status = "Не выделено ни одного объекта";
            }
            else if (FApplication.Selection.Count > 1)
            {
                status = String.Format("Выделенo {0} объектов(а)",
                    FApplication.Selection.Count);
            }
            else
            {
                id = FApplication.Selection.get_IDs(0);
                status = String.Format("Выделен объект \"'{0}\"",
                    FApplication.Selection.get_IDs(0));
            }
            return id;
        }
        // Создание контура с указанием слоя и стиля
        public IIngeoContourPart createContour(string IDLayer, string IDStyle)
        {
            IIngeoMapObject aMapObject = mapObjects.AddObject(IDLayer);
            IIngeoShape aShape = aMapObject.Shapes.Insert(0, IDStyle);
            IIngeoContourPart aContour = aShape.Contour.Insert(-1);
            aContour.Closed = false;
            return aContour;
        }

        public String ObjectToString(String object_id)
        {
            IIngeoMapObject map_obj = FApplication.ActiveDb.MapObjects.GetObject(object_id);
            String object_coords_str = "";
            if (map_obj.Shapes.Count > 0 && map_obj.Shapes[0].Contour.Count > 0)
            {
                for (int i = 0;
                i < map_obj.Shapes[0].Contour[0].VertexCount; i++)
                {
                    double x, y, convex;
                    map_obj.Shapes[0].Contour[0].GetVertex(i, out x, out y, out convex);
                    if (object_coords_str != "")
                        object_coords_str += "|";
                    object_coords_str += x.ToString() + ";" + y.ToString() + ";" + convex.ToString();
                }
            }
            return object_coords_str;
        }

        public String CreateObjectFromString(String object_coords_str, String layer_id, String style_id)
        {
            if (object_coords_str == "") return "";

            //создание объекта
            IIngeoMapObjects map_objects = FApplication.ActiveDb.MapObjects;
            map_objects.TransactionName = "t1";
            IIngeoMapObject new_obj = map_objects.AddObject(layer_id);
            IIngeoShape new_shape = new_obj.Shapes.Insert(0, style_id);
            IIngeoContourPart cnt_part = new_shape.Contour.Insert(0);

            //добавление вершин в объект
            String[] coords_parts = object_coords_str.Split(new char[] { '|' });
            foreach (String vertex_data in coords_parts)
            {
                String[] vertex_data_values = vertex_data.Split(new char[] { ';' });
                double x = Convert.ToDouble(vertex_data_values[0]);
                double y = Convert.ToDouble(vertex_data_values[1]);
                double convex = Convert.ToDouble(vertex_data_values[2]);
                cnt_part.InsertVertex(cnt_part.VertexCount, x, y, convex);
            }

            cnt_part.Closed = true;
            map_objects.UpdateChanges();

            return new_obj.ID;
        }

        // Применение изменений к карте
        public void applyChanges()
        {
            mapObjects.UpdateChanges();
        }
    }


}
