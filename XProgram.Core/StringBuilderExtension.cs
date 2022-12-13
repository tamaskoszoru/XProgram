using System.Text;

namespace XProgram.Core
{
    public static class StringBuilderExtension
    {
        public static void RemoveLastChar(this StringBuilder sb)
        {
            sb.Remove(sb.Length - 1, 1);
        }

        public static void Indent(this StringBuilder sb)
        {

        }
    }
}
