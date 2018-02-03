using SharpGL;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APLIMAT_DAY01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const float DEG2RAD = 3.14159f / 180.0f;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            gl.Translate(0.0f, 0.0f, -40.0f);

            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(15, 0, 0);
            gl.Vertex(-15, 0, 0);
            gl.End();

            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(0, 15, 0);
            gl.Vertex(0, -15, 0);
            gl.End();

            for (int i = -15; i <= 15; i++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(0.2, i, 0);
                gl.Vertex(-0.2, i, 0);
                gl.End();
            }

            for (int i = -15; i <= 15; i++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(i, 0.2, 0);
                gl.Vertex(i, -0.2, 0);
                gl.End();
            }

            //int x = 1, y = 1;
            //gl.PointSize(3);
            //gl.Begin(OpenGL.GL_POINTS);
            //gl.Vertex(x, y);
            //gl.End();

            //Linear function
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(1, 6);
            //gl.Vertex(-3, 10);
            //gl.End();

            //(0,0), (-2,4) (2,4)
            gl.Begin(OpenGL.GL_POINTS);
            float y = 0;
            for (float x = -20; x <= 20; x += 0.01f)
            {
                y = (x * x);
                gl.Vertex(x, y);
            }
            gl.End();
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //gl.Vertex(0, 1, 0);
            //gl.Vertex(-1, -1, 0);
            //gl.Vertex(1, -1, 0);
            //gl.End();

            float radius = 10.0f;
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                float degInRad = i * DEG2RAD;
                gl.Vertex(Math.Cos(degInRad) * radius, Math.Sin(degInRad) * radius);
            }
            gl.End();
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient    =    new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos         =    new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient     =    new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse     =    new float[] { 0.5f, 0.3f, 0.3f, 1.0f };
            float[] light0specular    =    new float[] { 0.8f, 0.8f, 0.8f, 1.0f };
            float[] lmodel_ambient    =    new float[] { 0.2f, 0.2f, 0.2f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }
    }
}
