namespace WebCommon.Models
{
    public class TextValueVM
    {
        public bool Selected { get; set; }
        public string Value { get; set; }
        public string Alias { get; set; }
        public string Text { get; set; }

        public TextValueVM()
        {

        }

        public TextValueVM(object value, string text)
        {
            this.Value = value?.ToString();
            this.Text = text;
        }
    }
}
