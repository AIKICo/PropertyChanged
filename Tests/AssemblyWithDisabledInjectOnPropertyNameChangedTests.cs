public class AssemblyWithDisabledInjectOnPropertyNameChangedTests
{
    static TestResult testResult;

    static AssemblyWithDisabledInjectOnPropertyNameChangedTests()
    {
        var task = new ModuleWeaver
        {
            InjectOnPropertyNameChanged = false
        };
        testResult = task.ExecuteTestRun(
            "AssemblyWithDisabledInjectOnPropertyNameChanged.dll",
            ignoreCodes: ["0x80131869"]);
    }

    [Fact]
    public void DefaultMethodCallsAreNotInjected()
    {
        var instance = testResult.GetInstance(nameof(ClassWithOnPropertyChangedMethod));
        instance.Property1 = "foo";

        Assert.Equal(0, instance.OnProperty1ChangedCallCount);
    }

    [Fact]
    public void CustomMethodCallsAreInjected()
    {
        var instance = testResult.GetInstance(nameof(ClassWithConfiguredOnPropertyChanged));
        instance.Property1 = "foo";

        Assert.Equal(1, instance.OnProperty1ChangedCallCount);
    }
}
