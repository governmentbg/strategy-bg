namespace WebCommon.Models
{
    public class QuestionaryAnswerVM
	{
        public bool Selected { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}
