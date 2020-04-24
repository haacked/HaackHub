using System;

namespace HaackHub
{
    public abstract class Annotation : Content
    {
        public Range LineNumberRange { get; set; }
        
        public void Deconstruct(out int start, out int end)
        {
            (start, end) = (LineNumberRange.Start.Value, LineNumberRange.End.Value);
        }
    }
}