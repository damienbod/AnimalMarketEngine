﻿namespace AnimalMarketEngine.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class LifecycleSingletonAttribute : System.Attribute
    {
        public double version;

        public LifecycleSingletonAttribute()
        {
            version = 1.0;
        }
    }
}
