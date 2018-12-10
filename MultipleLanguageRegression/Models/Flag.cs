namespace MultipleLanguageRegression.Models
{
    public static class Flag
    {
        static bool _flag;

        public static bool FlagValue
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
            }
        }
    }
}