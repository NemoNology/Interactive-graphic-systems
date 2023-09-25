using OpenTK.Graphics.OpenGL;

namespace Console_Project
{
    public class OpenGLExtensions
    {
        public static readonly int Ver2AttributeSize = 2,
            Ver3AttributeSize = 3;

        /// <summary>
        /// Creating Vertex Buffer Object
        /// </summary>
        static int CreateVBO(
            float[] vertices,
            int verticesTypeSize,
            BufferUsageHint bufferUsageHint = BufferUsageHint.StaticDraw
        )
        {
            var vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                vertices.Length * verticesTypeSize,
                vertices,
                bufferUsageHint
            );
            return vbo;
        }

        /// <summary>
        /// Create Vertex Array Object
        /// </summary>
        /// <param name="vertexStride"> How many numbers one vertex have </param>
        public static (int, int, int) InitGameObjectByFigure(Figure figure, 
            BufferUsageHint bufferUsageHint = BufferUsageHint.StaticDraw,
            int vertexStride = 3)
        {
            var vertices = figure.Vertices;
            var size = sizeof(float);

            // Vertex Buffer Object
            var vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                vertices.Length * size,
                vertices,
                bufferUsageHint
            ); 

            // Vertex Array Object
            var vao = GL.GenVertexArray();
            // TODO: [0] Why this zero? What's that means?
            var zero = 0;
            GL.BindVertexArray(vao);
            GL.VertexAttribPointer(
                zero,
                Ver3AttributeSize,
                VertexAttribPointerType.Float,
                false,
                vertexStride * size,
                0
            );
            // TODO: [0] ...
            GL.EnableVertexAttribArray(zero);

            // Element Buffer Object
            var indices = figure.Indices;
            var ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                indices.Length * sizeof(uint),
                indices,
                bufferUsageHint
            );

            return (vbo, vao, ebo);
        }
    };
}
