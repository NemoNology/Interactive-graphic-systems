using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Console_Project
{
    public class GameObjectsController
    {
        public readonly Shader Shader;
        public readonly List<GameObject> GameObjects;

        public GameObjectsController(Shader shader, GameObject? gameObject = null)
        {
            gameObject = gameObject is null ? 
                Figure.Empty.ToGameObject()
                : gameObject;
            List<GameObject> gameObjects = new(1) {gameObject};
            Shader = shader;
            GameObjects = gameObjects;
        }

        public void Draw()
        {
            GL.UseProgram(Shader.ShaderProgramHandler);

            Parallel.ForEach(GameObjects, gameObject =>
            {
                gameObject.Draw();
            });
        }

        public void Transform(Matrix4 transformMatrix)
        {
            Parallel.ForEach(GameObjects, gameObject =>
            {
                gameObject.Transform(transformMatrix);
            });
        }

        public static GameObjectsController Empty =>
            new GameObjectsController(Shader.DefaultShader);

        public static GameObjectsController Triangle =>
            new GameObjectsController(Shader.DefaultShader, Figure.TestTriangle.ToGameObject());
    }
}