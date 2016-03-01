using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo
{
    public class RichTextBoxWriter : System.IO.TextWriter
    {
        private readonly RichTextBox output;

        public override Encoding Encoding => Encoding.UTF8;

        public RichTextBoxWriter(RichTextBox output)
        {
            this.output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            string text = value.ToString(CultureInfo.InvariantCulture);
            output.AppendText(text);
        }

    }
}
