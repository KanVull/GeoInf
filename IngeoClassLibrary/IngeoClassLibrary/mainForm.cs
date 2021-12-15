using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ingeo;

namespace IngeoClassLibrary
{
    public partial class mainForm : Form
    {
        public static IngeoControl ingeoControl;
        String current_object_id = "";
        static Database database = null;
        public const String BUILDINGS_LAYER_ID = "0008000003F3";
        public const String BUILDINGS_STYLE_ID = "0008000003F5";


        public mainForm(IIngeoApplication fApplication)
        {
            ingeoControl = new IngeoControl(fApplication);
            InitializeComponent();
            database = new Database();
            this.UpdateData();

        }
        // Обработчик клика по кнопке: Получить идентификаторы объектов
        private void buttonGetObjects_Click(object sender, EventArgs e)
        {
            listBoxObjects.Items.Clear();
            listBoxObjects.Items.AddRange
                (ingeoControl.GetMapsInfo().ToArray());
        }
        // Обработчик клика по кнопке: Идентификатор выделенного объекта
        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            string status;
            textBoxIDSelectedObject.Text =
                ingeoControl.GetSelectObjectId(out status);
            MessageBox.Show(status);
        }
        // Очистка данных
        private void clearDijkstraData()
        {
            textBoxPath.Text = "";
            listBoxCoordinates.Items.Clear();
            listBoxIDs.Items.Clear();
            listBoxLength.Items.Clear();
        }
        // Обработчик кнопки: Алгоритм Дейкстры. 
        // Запуск алгоритма и заполнение списков
        private void buttonDijkstra_Click(object sender, EventArgs e)
        {
            clearDijkstraData();
            textBoxPath.Text = ShortestPath.run(ingeoControl);
            listBoxCoordinates.Items.AddRange
                 (ShortestPath.coordinates.ToArray());
            listBoxIDs.Items.AddRange(ShortestPath.ids.ToArray());
            listBoxLength.Items.AddRange(ShortestPath.length.ToArray());
        }

        public void UpdateData()
        {
            // Если выделен не 1 объект – очищаем поля и выходим
            if (ingeoControl.FApplication.Selection.Count != 1)
            {
                current_object_id = "";
                txbDeltaSquare.Text = "";
                txbFactSquare.Text = "";
                txbLegalSquare.Text = "";
                txbStatus.Text = "";
                txbDeltaSquare.BackColor = SystemColors.Control;
                txbStatus.BackColor = SystemColors.Control;
                btnSave.Enabled = false;
                return;
            }
            String selected_obj_id = ingeoControl.FApplication.Selection.IDs[0];
            // Если выделен нужный слой и нужный стиль
            if (ingeoControl.FApplication.ActiveProjectView.SelectedLayerView.Layer.ID == BUILDINGS_LAYER_ID
                && ingeoControl.FApplication.ActiveDb.MapObjects.GetObject(selected_obj_id).Shapes[0].StyleID == BUILDINGS_STYLE_ID)
            {
                // Реальная площадь
                decimal object_square = Convert.ToDecimal(Math.Round(ingeoControl.FApplication.ActiveDb.MapObjects.GetObject(selected_obj_id).Square, 5));
                // Считываем площадь с БД и рассчитываем разницу
                Decimal legal_square;
                String object_coords;
                database.ReadObjectData(selected_obj_id, out legal_square, out object_coords);
                decimal square_delta = (object_square - legal_square);

                // Считывем данные
                txbFactSquare.Text = object_square.ToString();
                txbLegalSquare.Text = legal_square.ToString();
                txbDeltaSquare.Text = square_delta.ToString();

                //поле статуса объекта
                if (square_delta == 0)
                    txbStatus.Text = "Построен законно";
                if (square_delta > 0 && legal_square == 0)
                    txbStatus.Text = "Полностью незаконно построен";
                if (square_delta > 0 && legal_square > 0)
                    txbStatus.Text = "Незаконная пристройка";
                if (square_delta < 0)
                    txbStatus.Text = "Незаконная перестройка";

                //при отклонении площади - подсветка цветом
                if (square_delta != 0)
                    txbDeltaSquare.BackColor = Color.FromArgb(255, 128, 128);
                else
                    txbDeltaSquare.BackColor = Color.FromArgb(128, 255, 128);

                txbStatus.BackColor = txbDeltaSquare.BackColor;

                current_object_id = selected_obj_id;
                btnSave.Enabled = (txbFactSquare.Text != txbLegalSquare.Text || txbLegalSquare.Text == "");
            }
            else
            {
                // если выделен объект с другого слоя или с другим стилем – 
                // очищаем данные
                current_object_id = "";
                txbDeltaSquare.Text = "";
                txbFactSquare.Text = "";
                txbLegalSquare.Text = "";
                txbStatus.Text = "";
                txbDeltaSquare.BackColor = SystemColors.Control;
                txbStatus.BackColor = SystemColors.Control;
                btnSave.Enabled = false;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (current_object_id != "")
                {
                    IngeoControl app = ingeoControl;
                    database.SaveObjectData(current_object_id, app);
                    UpdateData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n\r\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        List<string> visited = new List<string>();
        private void addTouchedObjects(string id, string current_layer, string id_style_vertex)
        {
            IIngeoContour contour = ingeoControl.GetMapObjectFromID(id).Shapes[0].Contour;
            IIngeoMapObjectsQuery query =  ingeoControl.FApplication.ActiveDb.MapObjects.QueryByContour(current_layer, contour, TIngeoContourRelation.incrTouched, TIngeoContourRelation.incrTouched);
            visited.Add(id);

            while (!query.EOF)
            {
                // Если мы не посещали этот объект - посещаем
                if (!visited.Contains(query.ObjectID.ToString()))
                {
                    visited.Add(query.ObjectID);

                    // если у объекта нужный стиль и объекта нет в списке
                    if (ingeoControl.GetMapObjectFromID(query.ObjectID).Shapes[0].Style.ID == id_style_vertex)
                        if (!listBoxObject.Items.Contains(query.ObjectID.ToString()))
                            listBoxObject.Items.Add(query.ObjectID);
                    // Рекурсивно вызываем функцию для возвращенных элементов
                    addTouchedObjects(query.ObjectID, current_layer, id_style_vertex);
                }
                query.MoveNext();
            }
        }


        private void buttonFind_Click(object sender, EventArgs e)
        {
            string status;
            string idSelected = ingeoControl.GetSelectObjectId(out status);
            textBoxStatus.Text = status;
            if (idSelected == null) return;

            // Очищаем списки перед вызовом функции
            visited.Clear();
            listBoxObject.Items.Clear();
            string ID_STYLE_VERTEX = "0001000003FC";
            string current_layer = ingeoControl.FApplication.ActiveProjectView.SelectedLayerView.Layer.ID;

            // вызов рекурсивной функции
            addTouchedObjects(idSelected, current_layer, ID_STYLE_VERTEX);

        }

        private void listBoxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ingeoControl.FApplication.Selection.DeselectAll();
            ingeoControl.FApplication.Selection.Select(listBoxObject.SelectedItem.ToString(), 0);
        }
    }
}

