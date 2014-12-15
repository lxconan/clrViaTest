# CLR via Test

This is project is part of the C# language training plan. Please read the following guidelines before start.

## BanKai.Basic

The basic part contains test with the following form

```csharp
[Fact]
public void should_take_first_n_elements_using_take()
{
    var sequence = new[] {1, 2, 3, 4, 5};

    IEnumerable<int> filteredElements = sequence.Take(3);

    // please update variable value to fix the test.
    IEnumerable<int> expectedResult = new[] {1, 2, 3, 4, 5};

    Assert.Equal(expectedResult, filteredElements);
}
```

Each test containing in this project will _fail_ by default. __DO NOT__ run the test first! Please read the test to get a basic idea, then try to correct the test following the hint __comment__.

For example. In the test above, you can only modify the line after the comment 

```csharp
// please update variable value to fix the test.
IEnumerable<int> expectedResult = new[] {1, 2, 3, 4, 5};
```

Please run the test again after modification to see if the test is corrected. If it is succeeded, please check all the codes related to this test (including the dependency demo class) and make sure you have fully understood them; while, if it fails again, please check the reason and try to correct it again.

Please correct all the test __FOLLOWING THE SEQUENCE NUMBER__ to make your life easy.