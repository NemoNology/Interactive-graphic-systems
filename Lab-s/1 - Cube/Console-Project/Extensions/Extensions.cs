namespace Console_Project
{
    public static class Extensions
    {
        public static GameObject ToGameObject(this Figure figure) =>
        new GameObject(figure);
    }
}