namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class TabAttribute : Attribute
    {
        public string Tab { get; } = "\t";
    }
}
