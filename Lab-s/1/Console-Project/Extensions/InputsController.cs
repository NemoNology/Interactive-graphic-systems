namespace Console_Project
{
    partial class InputsController
    {
        public static event EventHandler? OnLMBClick;

        public static void InvokeLMBClick(object sender, EventArgs? eventArgs)
        {
            eventArgs ??= EventArgs.Empty;
            OnLMBClick?.Invoke(sender, eventArgs);
        }
    }
}
