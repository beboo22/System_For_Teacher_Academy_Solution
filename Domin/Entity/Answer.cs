namespace Domin.Entity
{
    public class Answer:BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public string Answers { get; set; } = null!;
        public int ExamSubmissionId { get; set; }
        public ExamSubmission examSubmission { get; set; } = null!;
    }
}