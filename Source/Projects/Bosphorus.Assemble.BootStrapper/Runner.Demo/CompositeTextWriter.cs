using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo
{
    public class CompositeTextWriter : System.IO.TextWriter
    {
        private readonly IEnumerable<System.IO.TextWriter> writers;

        public CompositeTextWriter(IEnumerable<System.IO.TextWriter> writers)
        {
            this.writers = writers.ToList();
        }
        public CompositeTextWriter(params System.IO.TextWriter[] writers)
        {
            this.writers = writers;
        }

        public override void Write(char value)
        {
            foreach (var writer in writers)
                writer.Write(value);
        }

        public override void Write(string value)
        {
            foreach (var writer in writers)
                writer.Write(value);
        }

        public override void Flush()
        {
            foreach (var writer in writers)
                writer.Flush();
        }

        public override void Close()
        {
            foreach (var writer in writers)
                writer.Close();
        }

        public override Encoding Encoding => Encoding.ASCII;
    }
}
