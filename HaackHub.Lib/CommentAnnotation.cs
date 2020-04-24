namespace HaackHub
{
    public class CommentAnnotation : Annotation
    {
        public Comment Comment { get; set; }
        
        protected override Content Content => Comment;
    }
}