using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Console_Project
{
    public class GameObject
    {
        readonly Figure Figure;
        int VertexBufferHandler,
            VertexArrayHandler,
            ElementBufferHandler;

        public GameObject(Figure figure)
        {
            Figure = figure;
            Init();
        }

        /// <summary>
        /// Generating buffer from figure as ElementBufferObject and binding that buffer
        /// </summary>
        /// <returns> Genarated buffer </returns>
        public void Init(BufferUsageHint bufferUsageHint = BufferUsageHint.StaticDraw)
        {
            var vertices = Figure.VerticesCoordinates;
            var indices = Figure.Indices;

            (VertexBufferHandler, 
            VertexArrayHandler, 
            ElementBufferHandler) = 
                OpenGLExtensions.InitGameObjectByFigure(Figure);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Draw figure using ElementBufferObject
        /// </summary>
        public void Draw()
        {
            GL.BindVertexArray(VertexArrayHandler);
            GL.DrawElements(
                PrimitiveType.Triangles,
                Figure.Indices.Length,
                DrawElementsType.UnsignedInt,
                0
            );
        }

        public void Transform(Matrix4 transformMatrix)
        {
            Dispose();
            Figure.Transform(transformMatrix);
            Init();
        }

        public void Dispose(bool IsFullDispoce = false)
        {
            if (IsFullDispoce)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
            GL.DeleteBuffer(VertexBufferHandler);
            GL.DeleteBuffer(ElementBufferHandler);
            GL.DeleteVertexArray(VertexArrayHandler);
        }

        ~GameObject()
        {
            Dispose(true);
        }
    }
}
