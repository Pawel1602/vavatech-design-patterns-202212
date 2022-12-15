namespace VisitorPattern
{
    public class Control
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public ControlType Type { get; set; }
        public string Value { get; set; }
        public string ImageSource { get; set; }
    }

    public enum ControlType
    {
        Label,
        TextBox,
        Checkbox,
        Button
    }

}
