[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class Tests : System.Attribute
{
    // See the attribute guidelines at
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    public int priority { get; private set; }

    // This is a positional argument
    public Tests()
    {
        this.priority = 0;
    }
    public Tests(int priority)
    {
        this.priority = priority;
    }
}