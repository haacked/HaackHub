namespace HaackHub
{
    public class CommentAnnotation : Annotation
    {
        public Comment Comment { get; set; } = null!;
        
        protected override Content Content => Comment;
    }
}