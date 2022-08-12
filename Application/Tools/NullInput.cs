namespace Application.Tools
{
    public static class NullInput
    {
        public static void IsNull<T>(this T obj)
        {
            if (obj is null)
                throw new NullReferenceException($"{typeof(T)}یافت نشد");
        }
    }
}
