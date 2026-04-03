#pragma warning disable SYSLIB0011

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private Canvas _canvas;
        private Figure _selectedFigure;
        private Figure _clipboardFigure;
        private bool _isDrawingArrow;
        private Point _arrowStartPoint;
        private bool _isRotating;
        private float _lastMouseAngle;
        private Arrow _rotatingArrow;
        private bool _isDragging;
        private Point _dragStartPoint;
        private Point _dragStartLocation;

        public Form1()
        {
            InitializeComponent();
            _canvas = new Canvas();
            this.KeyPreview = true;

            if (numericUpDown1 != null)
            {
                numericUpDown1.Minimum = 1;
                numericUpDown1.Maximum = 10;
                numericUpDown1.Value = 1;
                numericUpDown1.Increment = 0.5m;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (_isDrawingArrow)
            {
                _arrowStartPoint = e.Location;
                return;
            }

            if (_selectedFigure is Arrow arrow && arrow.IsPointOnRotationMarker(e.Location))
            {
                _isRotating = true;
                _rotatingArrow = arrow;
                _lastMouseAngle = GetAngleFromCenter(e.Location, arrow);
                panel1.Cursor = Cursors.Hand;
                return;
            }

            var figure = _canvas.GetFigureAt(e.Location);
            if (figure != null)
            {
                _selectedFigure = figure;
                _isDragging = true;
                _dragStartPoint = e.Location;
                _dragStartLocation = figure.Location;
                panel1.Cursor = Cursors.SizeAll;
                panel1.Invalidate();
            }
            else
            {
                _selectedFigure = null;
                _canvas.ClearSelection();
                panel1.Invalidate();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawingArrow && e.Button == MouseButtons.Left)
            {
                panel1.Invalidate();
                using (Graphics g = panel1.CreateGraphics())
                using (Pen pen = new Pen(Color.Gray, 2) { DashStyle = DashStyle.Dash })
                {
                    g.DrawLine(pen, _arrowStartPoint, e.Location);
                }
            }
            else if (_isRotating && e.Button == MouseButtons.Left && _rotatingArrow != null)
            {
                float currentAngle = GetAngleFromCenter(e.Location, _rotatingArrow);
                float delta = currentAngle - _lastMouseAngle;
                if (Math.Abs(delta) > 0.5f)
                {
                    _rotatingArrow.Rotate(delta);
                    _lastMouseAngle = currentAngle;
                    panel1.Invalidate();
                }
            }
            else if (_isDragging && e.Button == MouseButtons.Left && _selectedFigure != null)
            {
                int dx = e.Location.X - _dragStartPoint.X;
                int dy = e.Location.Y - _dragStartPoint.Y;
                _selectedFigure.Location = new Point(_dragStartLocation.X + dx, _dragStartLocation.Y + dy);
                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (_isDrawingArrow)
            {
                if (_arrowStartPoint != e.Location)
                {
                    var arrow = new Arrow(_arrowStartPoint, e.Location);
                    _canvas.AddFigure(arrow);
                    _selectedFigure = arrow;
                }
                _isDrawingArrow = false;
                panel1.Cursor = Cursors.Default;
                panel1.Invalidate();
            }
            else if (_isRotating)
            {
                _isRotating = false;
                _rotatingArrow = null;
                panel1.Cursor = Cursors.Default;
                _canvas.SaveStateForUndo();
            }
            else if (_isDragging)
            {
                _isDragging = false;
                panel1.Cursor = Cursors.Default;
                _canvas.SaveStateForUndo();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _canvas?.Draw(e.Graphics);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (!_isDragging && !_isRotating && !_isDrawingArrow)
            {
                _selectedFigure = null;
                _canvas.ClearSelection();
                panel1.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _selectedFigure != null)
            {
                _canvas.RemoveFigure(_selectedFigure);
                _selectedFigure = null;
                panel1.Invalidate();
                return;
            }

            if (e.KeyCode == Keys.Tab && _canvas.Figures.Count > 0)
            {
                if (_selectedFigure == null)
                {
                    _selectedFigure = _canvas.Figures[_canvas.Figures.Count - 1];
                }
                else
                {
                    int index = _canvas.Figures.IndexOf(_selectedFigure);
                    _selectedFigure = _canvas.Figures[(index + 1) % _canvas.Figures.Count];
                }
                _canvas.SetSelectedFigure(_selectedFigure);
                panel1.Invalidate();
                e.Handled = true;
                return;
            }

            if (_selectedFigure != null)
            {
                int step = e.Shift ? 1 : 5;
                int dx = 0, dy = 0;
                switch (e.KeyCode)
                {
                    case Keys.Left: dx = -step; break;
                    case Keys.Right: dx = step; break;
                    case Keys.Up: dy = -step; break;
                    case Keys.Down: dy = step; break;
                    default: return;
                }
                _selectedFigure.Move(dx, dy);
                panel1.Invalidate();
                e.Handled = true;
            }
        }

        private float GetAngleFromCenter(Point mouse, Arrow arrow)
        {
            Point center = arrow.GetRotationCenter();
            return (float)(Math.Atan2(mouse.Y - center.Y, mouse.X - center.X) * 180 / Math.PI);
        }

        // Обработчики кнопок
        private void buttonRedo_Click(object sender, EventArgs e)
        {
            _canvas.Redo();
            panel1.Invalidate();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            _canvas.Undo();
            panel1.Invalidate();
        }

        private void buttonDrawArrow_Click(object sender, EventArgs e)
        {
            _isDrawingArrow = true;
            panel1.Cursor = Cursors.Cross;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, _selectedFigure);
                    ms.Position = 0;
                    _clipboardFigure = (Figure)formatter.Deserialize(ms);
                }
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (_clipboardFigure != null)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, _clipboardFigure);
                    ms.Position = 0;
                    var newFigure = (Figure)formatter.Deserialize(ms);
                    newFigure.Move(10, 10);
                    _canvas.AddFigure(newFigure);
                    _selectedFigure = newFigure;
                    panel1.Invalidate();
                }
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                btnCopy_Click(sender, e);
                _canvas.RemoveFigure(_selectedFigure);
                _selectedFigure = null;
                panel1.Invalidate();
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (_selectedFigure == null) return;
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _selectedFigure.Stroke.Color = dialog.Color;
                panel1.Invalidate();
            }
        }

        private void buttonStrokeColor_Click(object sender, EventArgs e)
        {
            if (_selectedFigure == null)
            {
                MessageBox.Show("Сначала выделите фигуру!");
                return;
            }

            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = _selectedFigure.Stroke.Color;
            colorDialog.FullOpen = true;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedFigure.Stroke.Color = colorDialog.Color;
                panel1.Invalidate();
            }
        }

        private void dtnColor_Click(object sender, EventArgs e)
        {
            buttonStrokeColor_Click(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedFigure == null) return;
            _selectedFigure.Stroke.Width = (float)numericUpDown1.Value;
            panel1.Invalidate();
        }

        // Методы для меню
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonUndo_Click(sender, e);
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRedo_Click(sender, e);
        }

        private void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Vector files (*.vec)|*.vec";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _canvas.SaveToFile(sfd.FileName);
                MessageBox.Show("Сохранено!");
            }
        }

        private void LoadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Vector files (*.vec)|*.vec";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _canvas.LoadFromFile(ofd.FileName);
                _selectedFigure = null;
                panel1.Invalidate();
                MessageBox.Show("Загружено!");
            }
        }
    }
}

#pragma warning restore SYSLIB0011