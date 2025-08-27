[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class TestAttribute : System.Attribute
{
    public int Priority { get; private set; }

    public TestAttribute() : this(int.MaxValue)
    {
    }
    public TestAttribute(int priority)
    {
        this.Priority = priority;
    }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class TestGroupAttribute : System.Attribute
{
    public string Name { get; private set; }
    public string Desc;
    public int CompareDataCount { get; private set; }

    public TestGroupAttribute(string name) : this(name, byte.MaxValue)
    {
    }
    public TestGroupAttribute(string name, int compareDataCount)
    {
        this.Name = name;
        this.CompareDataCount = compareDataCount;
    }
}

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class TestChartAttribute : System.Attribute
{
    public int Id { get; private set; }
    public TestChartAttribute(int id)
    {
        this.Id = id;
    }
}