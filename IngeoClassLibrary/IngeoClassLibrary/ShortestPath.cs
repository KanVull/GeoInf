using Ingeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngeoClassLibrary
{
    class ShortestPath
    {
        // Списки ребер, вершин и матрица смежности (с весами)
        static List<DoubleLine> listLines = new List<DoubleLine>();
        static List<DoublePoint> listPoint = new List<DoublePoint>();
        static double[,] matrLenght;
        // Константа: бесконечность
        const double INFINITY = 2147483647.0;

        /* -- Параметры -- */
        const string ID_STYLE_BRANCH = "0001000003FA";
        const string ID_STYLE_VERTEX = "0001000003FC";
        const string ID_STYLE_PATH = "00010000043B";
        const string ID_LAYER_PATH = "000100000437";
        const int BEGIN_VERTEX = 0;
        const int END_VERTEX = 10;

        /* -- Выходные данные -- */
        public static List<string> coordinates = new List<string>();
        public static List<string> ids = new List<string>();
        public static List<string> length = new List<string>();
        // Очистка списков
        private static void clearData()
        {
            listLines.Clear();
            listPoint.Clear();
            matrLenght = null;
            coordinates.Clear();
            ids.Clear();
            length.Clear();

        }
        // Вычисление данных: точек, ребер
        private static void getDataForAlgorthm(IngeoControl ingeoControl)
        {
            clearData();
            // Считывание данных с карты
            ingeoControl.GetMapsInfo();
            string firstVectorMap = ingeoControl.vectorMapsID[0];
            List<string> listLayers =
                ingeoControl.GetLayersIDFromMapID(firstVectorMap);
            List<string> objectIDs =
                ingeoControl.GetObjectIDFromLayerID(listLayers[0]);

            double x1, y1, a1, x2, y2, a2;
            // Цикл по всем объектам
            foreach (string id in objectIDs)
            {
                IIngeoMapObject mapObject =
                            ingeoControl.GetMapObjectFromID(id);
                IIngeoContourPart ContourPart =
                            mapObject.Shapes[0].Contour[0];
                String idStyle = mapObject.Shapes[0].Style.ID;
                // Считывание координат объекта и запись их в список
                for (int i = 0; i < ContourPart.VertexCount; i++)
                {
                    ContourPart.GetVertex(i, out x1, out y1, out a1);
                    coordinates.Add(x1.ToString() + "; " + y1.ToString());
                }
                ids.Add(idStyle);
                // Проверяем стиль ребер или стиль вершин 
                // и добавляем объект в соответствующий список
                if (idStyle == ID_STYLE_BRANCH)
                    if (ContourPart.VertexCount > 1)
                    {
                        ContourPart.GetVertex(0, out x1, out y1, out a1);
                        ContourPart.GetVertex(ContourPart.VertexCount - 1,
                            out x2, out y2, out a2);
                        listLines.Add(new DoubleLine(x1, y1, x2, y2));
                    }
                if (idStyle == ID_STYLE_VERTEX)
                    if (ContourPart.VertexCount > 0)
                    {
                        ContourPart.GetVertex(0, out x1, out y1, out a1);
                        listPoint.Add(new DoublePoint(x1, y1));
                    }
            }
            // Теперь мы знаем сколько у нас вершин
            // и можем инициализировать матрицу смежности
            matrLenght = new double[listPoint.Count, listPoint.Count];
            // В цикле находим начальную и конечную вершину каждого ребра
            // и добавляем в матрицу смежности значение его длины
            for (int k = 0; k < listLines.Count; k++)
            {
                int m = 0, n = 0;
                bool mOK = false, nOK = false;
                for (int i = 0; i < listPoint.Count; i++)
                {
                    if (!mOK && listLines[k].P1.Equals(listPoint[i]))
                    {
                        m = i;
                        mOK = true;
                        if (nOK)
                            break;
                    }

                    if (!nOK && listLines[k].P2.Equals(listPoint[i]))
                    {
                        n = i;
                        nOK = true;
                        if (mOK)
                            break;
                    }
                }
                matrLenght[m, n] = matrLenght[n, m] =
                            listLines[k].getLength();
            }
        }
        // Запуск алгоритма
        public static string run(IngeoControl ingeoControl)
        {
            string result = "";
            // Получаем данные
            getDataForAlgorthm(ingeoControl);

            int countPoint = listPoint.Count;
            double[] distance = new double[countPoint];
            bool[] visited = new bool[countPoint];
            // устанавливаем расстояние до вершин в бесконечность
            // и отмечаем, что ни одна вершина не посещена 
            for (int i = 0; i < countPoint; i++)
            {
                distance[i] = INFINITY;
                visited[i] = false;
            }
            // Расстояние до начальной вершины 0
            distance[BEGIN_VERTEX] = 0;
            // Посещаем все вершины и вычисляем кратчайшие пути
            for (int i = 0; i < countPoint - 1; i++)
            {
                int index = 0;
                double min = INFINITY;
                for (int j = 0; j < countPoint; j++)
                    if (!visited[j] && distance[j] <= min)
                    {
                        min = distance[j];
                        index = j;
                    }

                visited[index] = true;
                for (int j = 0; j < countPoint; j++)
                    if (!visited[j] && matrLenght[index, j] > 0 &&
                        distance[index] != INFINITY &&
                        distance[index] + matrLenght[index, j] < distance[j])
                        distance[j] = distance[index] + matrLenght[index, j];
            }
            // Выводим расстояния от исходной до всех вершин
            for (int i = 1; i < countPoint; i++)
                if (distance[i] != INFINITY)
                    length.Add(1 + " -> " + (i + 1) + " = " + distance[i]);
                else
                    length.Add(1 + " -> " + (i + 1) + " = " +
                            "маршрут недоступен");


            int versh = END_VERTEX;
            int newversh = 0;
            // Создаем контур и строим кратчайший путь
            IIngeoContourPart aContour =
                ingeoControl.createContour(ID_LAYER_PATH, ID_STYLE_PATH);
            while (versh != BEGIN_VERTEX)
            {
                result += versh + " -> ";
                aContour.InsertVertex(-1, listPoint[versh].X,
                            listPoint[versh].Y, 0);
                double min = INFINITY;
                for (int k = 0; k < countPoint; k++)
                    if (matrLenght[versh, k] > 0 && distance[k] < min)
                    {
                        newversh = k;
                        min = distance[k];
                    }
                versh = newversh;
            }
            result += versh;
            aContour.InsertVertex(-1, listPoint[versh].X,
                listPoint[versh].Y, 0);
            ingeoControl.applyChanges();

            return result;
        }
    }

}
