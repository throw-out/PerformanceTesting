[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class TestAttribute : System.Attribute
{
    public int priority { get; private set; }

    public TestAttribute()
    {
        this.priority = 0;
    }
    public TestAttribute(int priority)
    {
        this.priority = priority;
    }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class TestGroupAttribute : System.Attribute
{
    public string groupName { get; private set; }
    public int compareDataCount { get; private set; }

    public TestGroupAttribute(string groupName, int compareDataCount = int.MaxValue)
    {
        this.groupName = groupName;
        this.compareDataCount = compareDataCount;
    }
}