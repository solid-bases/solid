# Single Responsibility Principle

The Single Responsibility Principle (SRP) states that a class or module should have *one, and only one, reason to change*.

Where *responsibility* is defined as *reason to change*.

## In practice

Let's consider, as an example, the `WallBuilder` class and ask ourself:

> When the class need to be changed? What should the class change?

Answer is «when the wall changes». Is it true?

Of course, it is: if the wall height or shape changes, the class will have to change. (`BuildWall` method)

But wait! Also when the single row width or shape changes, the class needs to change! (`NewBricksRow` and `PlaceBrickInRow` method)

**!! We are breaking the SRP rule !!**

### Code example

Consider the class `Shell`, that provides the interface to access some functionalities of our application, such us opening a new window, launching a new terminal, set colors, get the version number.

The class looks like this:

```csharp
public class Shell {
    public void OpenNewWindow() { /* code */ }
    public void LaunchNewTerminal() { /* code */ }
    public void ChangeWindowColor() { /* code */ }
    public void ChangeShellColor() { /* code */ }
    private int GetMajorVersionNumber() { /* code */ }
    private int GetMinorVersionNumber() { /* code */ }
    private int GetPatchVersionNumber() { /* code */ }
}
```

> Is this class respecting the Single Responsibility Principle? No, it isn't.

Assuming that the methods are doing what their names suggest, we could identify 3 different responsibility:

* the shell itself
* the windows
* the version

A cleaner situation could be:

```csharp
public class Shell {
    public void ChangeShellColor() { /* code */ }
}

public class Windows {
    public void OpenNewWindow() { /* code */ }
    public void LaunchNewTerminal() { /* code */ }
    public void ChangeWindowColor() { /* code */ }
}

public class Version {
    public int GetMajorVersionNumber() { /* code */ }
    public int GetMinorVersionNumber() { /* code */ }
    public int GetPatchVersionNumber() { /* code */ }
}
```

In this way, each class will handle only one responsibility.

> And what if I want the `Shell` to expose all the functionalities in one class?

In this case [Facade design pattern](https://refactoring.guru/design-patterns/facade), [Forwarding](https://en.wikipedia.org/wiki/Forwarding_(object-oriented_programming)), [Delegation](https://en.wikipedia.org/wiki/Delegation_(object-oriented_programming)) are only few example of solutions to our problem!

For example, let's use Delegation, that will use `Windows` and `ShellHandler` delegates to expose all the `Shell` functionalities:

```csharp
public class Shell {
    public Windows _windows;
    public ShellHandler _shell;
    public Shell(Windows windows, ShellHandler shell) {
        _windows = windows;
        _shell = shell
    }

    public void OpenNewWindow() => _windows.OpenNewWindow();
    public void LaunchNewTerminal() => _windows.LaunchNewTerminal();
    public void ChangeWindowColor() => _windows.ChangeWindowColor();
    public void ChangeShellColor() => _shell.ChangeShellColor();
}

public class ShellHandler {
    public void ChangeShellColor() { /* code */ }
}

public class Windows {
    public void OpenNewWindow() { /* code */ }
    public void LaunchNewTerminal() { /* code */ }
    public void ChangeWindowColor() { /* code */ }
}

public class Version {
    public int GetMajorVersionNumber() { /* code */ }
    public int GetMinorVersionNumber() { /* code */ }
    public int GetPatchVersionNumber() { /* code */ }
}
```

In this way we are fulfilling both:

* the necessity to expose all the Shell functionalities form a single class
* the necessity to respect SRP

## Why is this a problem?

During the creation of a class, breaking the SRP is not a problem itself.

The problems begun when you've to modify the class: when the SRP is not fulfilled a change to a responsibility (e.g. the shape of a row), could unexpectedly have a side effect on some other responsibility (e.g. the height of the wall), causing a not-easy detectable regression.

When the number of the changes increase, the probability to introduce some other bugs increase as well.

This will generate a chain of bug that will result in a «mess», in which the productivity will constantly decrease asymptotically to zero.

![Productivity with mess](productivity_with_mess.png)

For further details see the chapter [The Total Cost of Owning a Mess](https://www.informit.com/articles/article.aspx?p=1235624&seqNum=3) from «Clean Code: A Handbook of Agile Software Craftsmanship book».

## How could we fix this?

Let's refactor the code!

> Tip: code should always provide automatic tests that could be executed to verify that the refactor didn't break the initial functionality.<br />
> When tests are not provided you could:
>
> * start using the IDE refactor functionalities (for example in Visual Studio Code)
> * proceed using a «Refactor by TDD» approach. This method will be explained in [bdd-training](https://github.com/solid-bases/bdd-training) repository.

## Corollaries

Applying SRP, we could assume this corollaries.

### Functions

> «The first rule of functions is that they should be small. The second rule of the functions is that *they should be smaller than that*.»
> [...]
> «Functions should do one thing. They should do it well. They should do it only.»
> Robert C. Martin - Clean Code - Chapter 3: Functions

### Classes

> «The first rule of classes is that they should be small. The second rule of the classes is that *they should be smaller than that*.»
> Robert C. Martin - Clean Code - Chapter 10: Classes
