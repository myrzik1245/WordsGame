namespace Assets._Project.Develop.UI.Factories
{
    public interface IView
    {
    }

    public interface IPopupView : IView
    {
        void Show();
        void Hide();
    }
}