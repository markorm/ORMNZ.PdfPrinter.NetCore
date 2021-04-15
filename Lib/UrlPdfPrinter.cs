using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ORMNZ.PdfPrinter
{
    /// <summary>
    /// Url to Pdf printer.
    /// </summary>
    public class UrlPdfPrinter : PdfPrinter
    {
        private readonly string _url;
        private readonly string _out_dir;
        private readonly string _footer;
        private readonly string _header;
        private readonly UrlPdfPrinterAuth _auth;
        private readonly string _selector;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="module">The path to the module file.</param>
        /// <param name="html">The html content.</param>
        /// <param name="out_dir">The output directory.</param>
        /// <param name="footer">The footer html or url.</param>
        /// <param name="header">The header html or url.</param>
        /// <param name="auth">The cookie data needed for auth.</param>
        /// <param name="selector">The selector to wait for.</param>
        public UrlPdfPrinter(
            string module,
            string url,
            string out_dir,
            string footer = null,
            string header = null,
            UrlPdfPrinterAuth auth = null, string selector = null)
            : base(module, "printUrl")
        {
            _url = url;
            _out_dir = out_dir;
            _footer = footer;
            _header = header;
            _auth = auth;
            _selector = selector;
        }

        /// <summary>
        /// Print url to pdf.
        /// </summary>
        /// <returns></returns>
        public async Task Print()
        {
            await Print(_url, _out_dir, _footer, _header, _auth.ToJson(), _selector);
        }
    }

    /// <summary>
    /// Defines auth for a url pdf printer.
    /// </summary>
    public class UrlPdfPrinterAuth
    {
        private readonly AuthType _type;
        private readonly Cookie _cookie;
        private readonly string _header;

        /// <summary>
        /// Create auth using a cookie.
        /// </summary>
        /// <param name="cookie"></param>
        public UrlPdfPrinterAuth(Cookie cookie)
        {
            _cookie = cookie;
            _type = AuthType.Cookie;
        }

        /// <summary>
        /// Create auth using an authorization header. 
        /// </summary>
        /// <param name="header"></param>
        public UrlPdfPrinterAuth(string header)
        {
            _header = header;
            _type = AuthType.Header;
        }

        /// <summary>
        /// Serialize to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            var opts = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            if (_type == AuthType.Cookie)
            {
                return JsonSerializer.Serialize(new { type = _type, value = _cookie }, opts);
            }
            else
            {
                return JsonSerializer.Serialize(new { type = _type, value = _header }, opts);
            }
        }

        /// <summary>
        /// The supported auth types.
        /// </summary>
        private enum AuthType
        {
            Cookie = 0,
            Header = 1
        }

    }

}
