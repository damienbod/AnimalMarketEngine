﻿namespace AnimalMarketEngine.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class LifecycleTransientAttribute : System.Attribute
    {
        public double version;

        public LifecycleTransientAttribute()
        {
            version = 1.0;
        }
    }
}
