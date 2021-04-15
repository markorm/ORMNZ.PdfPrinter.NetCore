using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORMNZ.PdfPrinter
{

    /// <summary>
    /// Html to Pdf printer.
    /// </summary>
    public class HtmlPdfPrinter : PdfPrinter
    {
        private readonly string _html;
        private readonly string _out_dir;
        private readonly string _footer;
        private readonly string _header;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="module">The path to the module file.</param>
        /// <param name="html">The html content.</param>
        /// <param name="out_dir">The output directory.</param>
        /// <param name="footer">The footer html or url.</param>
        /// <param name="header">The header html or url.</param>
        public HtmlPdfPrinter(
            string module,
            string html,
            string out_dir,
            string footer = null,
            string header = null)
            : base(module, "printHtml")
        {
            _html = html;
            _out_dir = out_dir;
            _footer = footer;
            _header = header;
        }

        /// <summary>
        /// Print html to pdf.
        /// </summary>
        /// <returns></returns>
        public async Task Print()
        {
            await Print(_html, _out_dir, _footer, _header);
        }
    }

}
