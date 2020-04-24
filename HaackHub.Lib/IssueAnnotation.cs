namespace HaackHub
{
    public class IssueAnnotation : Annotation
    {
        public Issue Issue { get; set; }
        
        protected override Content Content => Issue;
    }
}