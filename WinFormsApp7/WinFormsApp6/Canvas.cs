#pragma warning disable SYSLIB0011
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace WinFormsApp6
{
    public class Canvas
    {
        public List<Figure> Figures { get; private set; } = new List<Figure>();
        private Stack<byte[]> _undoStack = new Stack<byte[]>();
        private Stack<byte[]> _redoStack = new Stack<byte[]>();
        private const int HistoryDepth = 20;
        private static readonly BinaryFormatter _formatter = new BinaryFormatter();

        public Canvas()
        {
            SaveState();
        }

        public void AddFigure(Figure figure)
        {
            Figures.Add(figure);
            System.Diagnostics.Debug.WriteLine($"Добавлена фигура. Всего: {Figures.Count}, Тип: {figure.GetType().Name}");
            SaveState();
            _redoStack.Clear();
            FiguresChanged?.Invoke();
        }

        public void RemoveFigure(Figure figure)
        {
            Figures.Remove(figure);
            SaveState();
            _redoStack.Clear();
        }

        public void Draw(Graphics g)
        {
            System.Diagnostics.Debug.WriteLine($"Отрисовка: {Figures.Count} фигур");

            foreach (var figure in Figures)
            {
                figure.Draw(g);
            }
        }
        // Обновите метод GetFigureAt
        public Figure GetFigureAt(Point point)
        {
            for (int i = Figures.Count - 1; i >= 0; i--)
            {
                if (Figures[i].GetBounds().Contains(point))
                {
                    SetSelectedFigure(Figures[i]);
                    return Figures[i];
                }
            }
            ClearSelection();
            return null;
        }

        private void SaveState()
        {
            using (var ms = new MemoryStream())
            {
                _formatter.Serialize(ms, Figures);
                byte[] data = ms.ToArray();
                _undoStack.Push(data);

                // Ограничиваем глубину истории
                while (_undoStack.Count > HistoryDepth)
                {
                    var temp = new Stack<byte[]>();
                    while (_undoStack.Count > 1) temp.Push(_undoStack.Pop());
                    _undoStack.Clear();
                    while (temp.Count > 0) _undoStack.Push(temp.Pop());
                }
            }
        }

        public void Undo()
        {
            if (_undoStack.Count <= 1) return;

            // Сохраняем текущее состояние в Redo
            using (var ms = new MemoryStream())
            {
                _formatter.Serialize(ms, Figures);
                _redoStack.Push(ms.ToArray());
            }

            // Удаляем текущее состояние
            _undoStack.Pop();

            // Загружаем предыдущее состояние
            var previousData = _undoStack.Peek();
            using (var ms = new MemoryStream(previousData))
            {
                Figures = (List<Figure>)_formatter.Deserialize(ms);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;

            // Сохраняем текущее состояние в Undo
            using (var ms = new MemoryStream())
            {
                _formatter.Serialize(ms, Figures);
                _undoStack.Push(ms.ToArray());
            }

            // Загружаем состояние из Redo
            var redoData = _redoStack.Pop();
            using (var ms = new MemoryStream(redoData))
            {
                Figures = (List<Figure>)_formatter.Deserialize(ms);
            }
        }

        public void SaveToFile(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                _formatter.Serialize(fs, Figures);
            }
        }

        public void LoadFromFile(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                Figures = (List<Figure>)_formatter.Deserialize(fs);
            }
            _undoStack.Clear();
            _redoStack.Clear();
            SaveState();
        }
        public void SaveStateForUndo()
        {
            SaveState();
        }

        public event Action FiguresChanged;
        // Сброс выделения у всех фигур
        public void ClearSelection()
        {
            foreach (var figure in Figures)
            {
                figure.IsSelected = false;
            }
        }

        // Установка выделенной фигуры
        public void SetSelectedFigure(Figure figure)
        {
            ClearSelection();
            if (figure != null)
            {
                figure.IsSelected = true;
            }
        }



    }

}
#pragma warning restore SYSLIB0011сп