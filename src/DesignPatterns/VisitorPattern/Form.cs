using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace VisitorPattern
{
    // Abstract Visitor
    public interface IVisitor
    {
        void Visit(Label control);
        void Visit(TextBox control);
        void Visit(CheckBox control);
        void Visit(Button control);
        string Output { get; }
    }

    // Concrete Visitor
    public class HtmlVisitor : IVisitor
    {
        private readonly StringBuilder builder = new StringBuilder();

        public HtmlVisitor()
        {
            builder.AppendLine("<html>");
            // builder.AppendLine($"<title>{Title}</title>";);

            builder.AppendLine("<body>");
        }

        public void Visit(Label control)
        {
            builder.AppendLine($"<span>{control.Caption}</span>");
        }

        public void Visit(TextBox control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>\"");
        }

        public void Visit(CheckBox control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>");
        }

        public void Visit(Button control)
        {
            builder.AppendLine($"<button><img src='{control.ImageSource}'/>{control.Caption}</button>");
        }

        private void AppendEndDocument()
        {
            builder.AppendLine("</body>");
            builder.AppendLine("</html>");
        }

        public string Output
        {
            get
            {
                AppendEndDocument();

                return builder.ToString();
            }
        }
    }


    public class MarkdownVisitor : IVisitor
    {
        private readonly StringBuilder builder = new StringBuilder();

        public void Visit(Label control)
        {
            builder.AppendLine($"**{control.Caption}**");
        }

        public void Visit(TextBox control)
        {
            builder.AppendLine($"*{control.Caption}* {control.Value}");
        }

        public void Visit(CheckBox control)
        {
            
        }

        public void Visit(Button control)
        {
            throw new System.NotImplementedException();
        }

        public string Output => builder.ToString();
    }

    // Abstract Element
    public abstract class Control
    {
        public string Name { get; set; }
        public string Caption { get; set; }

        public abstract void Accept(IVisitor visitor);

        //public abstract string OutputHtml { get; }
        //public abstract string OutputMarkdown { get; }
    }

    public class Label : Control
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class TextBox : Control
    {
        public string Value { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CheckBox : Control
    {
        public bool Value { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Button : Control
    {
        public string ImageSource { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public enum ControlType
    {
        Label,
        TextBox,
        Checkbox,
        Button
    }


    public class Form : Control
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<Control> Body { get; set; }

        public override void Accept(IVisitor visitor)
        {
            foreach (var control in Body)
            {
                control.Accept(visitor);
            }
        }
    }

}
