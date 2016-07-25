namespace ReflectionTraining
{
    public class CorrectString
    {
        public static string SplitIt(string data, char symbol, int value)
        {
            return data.Split(symbol)[value];
        }

    }
}
