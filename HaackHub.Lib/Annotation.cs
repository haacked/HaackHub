using System;

namespace HaackHub
{
    public abstract class Annotation : Content
    {
        public Range LineNumberRange { get; set; }
    }
}