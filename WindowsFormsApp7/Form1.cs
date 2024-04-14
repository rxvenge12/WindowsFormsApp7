using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        // Элемент управления для рисования
        private PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();
            InitializePictureBox();
        }

        // Метод для инициализации PictureBox
        private void InitializePictureBox()
        {
            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.BackColor = Color.White;
            Controls.Add(pictureBox);
        }

        // Метод для рисования фигур на PictureBox
        private void DrawShapes()
        {
            Graphics graphics = pictureBox.CreateGraphics();
            graphics.Clear(Color.White);

            // Создание экземпляров фигур
            Circle circle = new Circle(100, 100, 50);
            Square square = new Square(200, 200, 100);
            Rectangle rectangle = new Rectangle(300, 300, 150, 80);

            // Рисование фигур
            circle.Draw(graphics);
            square.Draw(graphics);
            rectangle.Draw(graphics);
        }

        // Обработчик события нажатия кнопки "Нарисовать фигуры"
        private void button1_Click(object sender, EventArgs e)
        {
            DrawShapes();
        }
    }

    // Базовый класс для геометрических фигур
    public abstract class Shape
    {
        // Поля для координат центра фигуры
        protected int centerX;
        protected int centerY;

        // Конструктор для инициализации координат центра
        public Shape(int centerX, int centerY)
        {
            this.centerX = centerX;
            this.centerY = centerY;
        }

        // Абстрактные методы для рисования и изменения размеров фигуры
        public abstract void Draw(Graphics graphics);
        public abstract void Resize(double factor);
    }

    // Класс для описания круга
    public class Circle : Shape
    {
        // Поле для радиуса круга
        private int radius;

        // Конструктор для инициализации центра и радиуса
        public Circle(int centerX, int centerY, int radius) : base(centerX, centerY)
        {
            this.radius = radius;
        }

        // Метод для рисования круга
        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
        }

        // Метод для изменения размеров круга (изменяет радиус)
        public override void Resize(double factor)
        {
            radius = (int)(radius * factor);
        }
    }

    // Класс для описания квадрата
    public class Square : Shape
    {
        // Поле для длины стороны квадрата
        private int sideLength;

        // Конструктор для инициализации центра и длины стороны
        public Square(int centerX, int centerY, int sideLength) : base(centerX, centerY)
        {
            this.sideLength = sideLength;
        }

        // Метод для рисования квадрата
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, centerX - sideLength / 2, centerY - sideLength / 2, sideLength, sideLength);
        }

        // Метод для изменения размеров квадрата (изменяет длину стороны)
        public override void Resize(double factor)
        {
            sideLength = (int)(sideLength * factor);
        }
    }

    // Класс для описания прямоугольника
    public class Rectangle : Shape
    {
        // Поля для ширины и высоты прямоугольника
        private int width;
        private int height;

        // Конструктор для инициализации центра, ширины и высоты
        public Rectangle(int centerX, int centerY, int width, int height) : base(centerX, centerY)
        {
            this.width = width;
            this.height = height;
        }

        // Метод для рисования прямоугольника
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, centerX - width / 2, centerY - height / 2, width, height);
        }

        // Метод для изменения размеров прямоугольника
        public override void Resize(double factor)
        {
            width = (int)(width * factor);
            height = (int)(height * factor);
        }
    }
}
