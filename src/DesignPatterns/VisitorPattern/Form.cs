using System.Collections.Generic;

namespace VisitorPattern
{
    public class Form
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<Control> Body { get; set; }

        public string GetHtml()
        {
            string html = "<html>";

            html += $"<title>{Title}</title>";

            html += "<body>";

            foreach (var control in Body)
            {
                switch (control.Type)
                {
                    case ControlType.Label:
                        html += $"<span>{control.Caption}</span>"; break;

                    case ControlType.TextBox:
                        html += $"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>"; break;

                    case ControlType.Checkbox:
                        html += $"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>"; break;

                    case ControlType.Button:
                        html += $"<button><img src='{control.ImageSource}'/>{control.Caption}</button>"; break;
                }

            }

            html += "</body>";
            html += "</html>";

            return html;
        }
    }

}
