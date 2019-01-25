using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Questionary
{
	[Table("questionary_possible_answers", Schema = "questionary")]
    public class QuestionaryPossibleAnswers
	{
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int QuestionaryHeaderId { get; set; }

        [Display(Name = "Отговор")]
        public string Answer { get; set; }
       
        [ForeignKey(nameof(QuestionaryHeaderId))]
        public virtual QuestionaryHeaders QuestionaryHeader { get; set; }
    }
}
