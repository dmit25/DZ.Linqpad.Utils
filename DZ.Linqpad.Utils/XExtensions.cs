using System.Xml.Linq;

namespace DZ.Linqpad.Utils
{
    public static class XExtensions
    {
        public static XElement ParseXElement(this string text)
        {
            return XElement.Parse(text);
        }
    }
}