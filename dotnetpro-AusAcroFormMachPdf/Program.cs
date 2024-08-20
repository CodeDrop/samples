using iText.Forms;
using iText.Kernel.Pdf;

var templatePath = "template.pdf"; // "https://markus-kraus.de/template.pdf";
var reader = new PdfReader(templatePath);
var writer = new PdfWriter("document.pdf");
var pdf = new PdfDocument(reader, writer);


var acroForm = PdfAcroForm.GetAcroForm(pdf, false);
Console.WriteLine(string.Join(", ", acroForm.GetAllFormFields().Select(f => f.Key)));
acroForm.GetField("Text6").SetValue($"{DateTime.Now}");
acroForm.GetField("Text7").SetValue("Das ist ein anderer langer Text, der hoffenlich einen automatischen Zeilenumbruch erhält.");

var field = acroForm.GetField("Text7");
var format = "Bezahlen Sie {0} € bis {1} ohne Abzüge";// field.GetDisplayValue();
var value = string.Format(format, 12, new DateOnly(2024,5,3).ToLongDateString());
Console.WriteLine(value);
field.SetValue(value);


pdf.Close();
//PdfTextFormField field = new TextFormFieldBuilder(pdf, "Text1")
//    .SetWidgetRectangle(new Rectangle(136, 733, 423, 18))
//    .CreateText();
