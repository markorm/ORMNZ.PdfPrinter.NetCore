using Jering.Javascript.NodeJS;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ORMNZ.PdfPrinter
{
    /// <summary>
    /// The base Pdf Printer.
    /// </summary>
    public abstract class PdfPrinter
    {
        protected readonly string _module;
        protected readonly string _method;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="module">The path to the module file.</param>
        /// <param name="method">The method to invoke.</param>
        public PdfPrinter(string module, string method)
        {
            _module = module;
            _method = method;
        }

        /// <summary>
        /// Print to pdf.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task Print(params object[] args)
        {
            await StaticNodeJSService.InvokeFromFileAsync(_module, _method, args);
        }
    }

}
