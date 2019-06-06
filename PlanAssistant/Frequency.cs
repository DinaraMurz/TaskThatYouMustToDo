using System;

namespace PlanAssistant
{
    public class Frequency
    {
        private long v;

        public Frequency()
        {
        }

        public Frequency(long v)
        {
            this.v = v;
        }

        public string Name { get; set; }
        public TimeSpan Period { get; set; }
    }
}