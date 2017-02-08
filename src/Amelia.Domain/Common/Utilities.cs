namespace Amelia.Domain.Common
{
    public static class Utilities
    {
        public static string RemoveSpacesAndSpecialsChars(string value)
        {
            value = value.Replace(" ", "-");
            value = value.Replace(".", "-");
            value = value.Replace(",", string.Empty);
            value = value.Replace(";", string.Empty);
            value = value.Replace(":", string.Empty);
            value = value.Replace("?", string.Empty);
            value = value.Replace("¿", string.Empty);
            value = value.Replace("@", string.Empty);
            value = value.Replace("#", string.Empty);
            value = value.Replace("%", string.Empty);
            value = value.Replace("&", string.Empty);
            value = value.Replace("*", string.Empty);
            value = value.Replace("(", string.Empty);
            value = value.Replace(")", string.Empty);
            value = value.Replace("!", string.Empty);
            value = value.Replace("/", string.Empty);
            value = value.Replace("\\", string.Empty);
            value = value.Replace("|", string.Empty);
            value = value.Replace("+", string.Empty);
            value = value.Replace("{", string.Empty);
            value = value.Replace("}", string.Empty);
            value = value.Replace("[", string.Empty);
            value = value.Replace("]", string.Empty);

            value = value.Replace("á", "a");
            value = value.Replace("Á", "A");
            value = value.Replace("é", "e");
            value = value.Replace("É", "E");
            value = value.Replace("í", "i");
            value = value.Replace("Í", "I");
            value = value.Replace("ó", "o");
            value = value.Replace("Ó", "O");
            value = value.Replace("ú", "u");
            value = value.Replace("Ú", "u");
            value = value.Replace("ü", "u");
            value = value.Replace("Ü", "u");

            value = value.Replace("ñ", "n");
            value = value.Replace("Ñ", "N");

            return value.TrimEnd();
        }
    }
}