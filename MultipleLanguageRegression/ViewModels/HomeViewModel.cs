namespace MultipleLanguageRegression.ViewModels
{
    public class HomeViewModel
    {
        public bool Flag { get; private set; }

        public HomeViewModel(bool flag)
        {
            Flag = flag;
        }
    }
}