using aplimat_labs.Utilities;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Models
{
    public class CubeMesh
    {
        public Vector3 position;
        
        public CubeMesh()
        {
            position = new Vector3();

        }

        public CubeMesh(Vector3 initPos)
        {
            position = initPos;
        }

        public CubeMesh(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }

        public void Draw(OpenGL gl, double r, double g, double b, double size)
        {
            gl.Color(r, g, b);
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //front face
            gl.Vertex(position.x - size, position.y + size, position.z + 0.5f);
            gl.Vertex(position.x - size, position.y - size, position.z + 0.5f);
            gl.Vertex(position.x + size, position.y + size, position.z + 0.5f);
            gl.Vertex(position.x + size, position.y - size, position.z + 0.5f);
            //right face
            gl.Vertex(position.x + 0.5f, position.y + 0.5f, position.z - 0.5f);
            gl.Vertex(position.x + 0.5f, position.y - 0.5f, position.z - 0.5f);
            //back face
            gl.Vertex(position.x - 0.5f, position.y + 0.5f, position.z - 0.5f);
            gl.Vertex(position.x - 0.5f, position.y - 0.5f, position.z - 0.5f);
            //left face
            gl.Vertex(position.x - 0.5f, position.y + 0.5f, position.z + 0.5f);
            gl.Vertex(position.x - 0.5f, position.y - 0.5f, position.z + 0.5f);
            gl.End();
            
            //top face
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(position.x - 0.5f, position.y + 0.5f, position.z + 0.5f);
            gl.Vertex(position.x + 0.5f, position.y + 0.5f, position.z + 0.5f);
            gl.Vertex(position.x - 0.5f, position.y + 0.5f, position.z - 0.5f);
            gl.Vertex(position.x + 0.5f, position.y + 0.5f, position.z - 0.5f);
            gl.End();
            
            //bottom face
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(position.x - 0.5f, position.y - 0.5f, position.z + 0.5f);
            gl.Vertex(position.x + 0.5f, position.y - 0.5f, position.z + 0.5f);
            gl.Vertex(position.x - 0.5f, position.y - 0.5f, position.z - 0.5f);
            gl.Vertex(position.x + 0.5f, position.y - 0.5f, position.z - 0.5f);
            gl.End();

        }

    }
}
