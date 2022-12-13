namespace XProgram.Core
{
    public static class StringExtension
    {
        public static string Indent(this string str)
        {
            return str.Replace("\r\n", "\r\n\t").Insert(0, "\t");
        }
    }
}
