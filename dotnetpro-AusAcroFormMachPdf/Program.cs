using iText.Forms;
using iText.Kernel.Pdf;

var templatePath = "http://markus-kraus.de/template.pdf"; //e
var reader = new PdfReader(templatePath);
var writer = new PdfWriter("document.pdf");
var pdf = new PdfDocument(reader, writer);


var acroForm = PdfAcroForm.GetAcroForm(pdf, false);
//acroForm.GetField("Text1").SetValue($"{DateTime.Now}");

//acroForm.GetField("Text1").SetValue("Das ist ein anderer langer Text, der hoffenlich einen automatischen Zeilenumbruch erhält.");

var field = acroForm.GetField("Text1");
var format = field.GetDisplayValue();
if (string.IsNullOrEmpty(format))
    format = "Bezahlen Sie {0} € bis {1} ohne Abzüge";
var value = string.Format(format, 12, new DateOnly(2024, 5, 3).ToLongDateString());
field.SetValue(value);


pdf.Close();
//PdfTextFormField field = new TextFormFieldBuilder(pdf, "Text1")
//    .SetWidgetRectangle(new Rectangle(136, 733, 423, 18))
//    .CreateText();
