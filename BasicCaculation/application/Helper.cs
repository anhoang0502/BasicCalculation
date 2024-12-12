using System.Linq;
using System.Windows.Forms;

namespace BasicCaculation.application
{
    public static class Helper
    {
        public static string nhapgiatri(object sender)
        {
            Button num = (Button)sender;
            return num.Text;
        }
        public static string xoagiatri(string text)
        {
            if (text.Length == 0)
            {
                text = "0";
            }
            else
                text = text.Remove(text.Length - 1);
            return text;
        }
    }
}