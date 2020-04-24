namespace HaackHub
{
    public class IssueAnnotation : Annotation
    {
        public Issue Issue { get; set; } = null!;
        
        protected override Content Content => Issue;
    }
}