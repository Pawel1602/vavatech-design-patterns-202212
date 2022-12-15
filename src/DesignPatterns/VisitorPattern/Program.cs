using System;
using System.Collections.ObjectModel;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Visitor Pattern!");

            Form form = Get();

            string html = form.GetHtml();

            System.IO.File.WriteAllText("index.html", html);
        }

        public static Form Get()
        {
            Form form = new Form
            {
                Name = "/forms/customers",
                Title = "Design Patterns",

                Body = new Collection<Control>
                {

                    new Control { Type = ControlType.Label, Caption = "Person", Name = "lblName" },
                    new Control { Type = ControlType.TextBox, Caption = "FirstName", Name = "txtFirstName", Value = "John"},
                    new Control { Type = ControlType.Checkbox, Caption = "IsAdult", Name = "chkIsAdult", Value = "true" },
                    new Control {  Type = ControlType.Button, Caption = "Submit", Name = "btnSubmit", ImageSource = "save.png" },
                }

            };

            return form;
        }
    }

}
