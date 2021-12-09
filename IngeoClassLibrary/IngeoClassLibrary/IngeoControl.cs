﻿using Ingeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngeoClassLibrary
{
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
        // Применение изменений к карте
        public void applyChanges()
        {
            mapObjects.UpdateChanges();
        }
    }


}
