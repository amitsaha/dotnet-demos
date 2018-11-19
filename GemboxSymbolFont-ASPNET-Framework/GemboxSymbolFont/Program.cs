using GemBox.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemboxSymbolFont
{
    class Program
    {
        static void Main(string[] args)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var document = DocumentModel.Load("DocWithSymbol.docx");
            document.Save("DocWithSymbol.pdf");

        }
    }
}
