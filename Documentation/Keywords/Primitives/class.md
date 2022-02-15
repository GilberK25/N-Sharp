# Keywords/Primitives
## `class`

A class is the default and most used type of [primitive](Primitives.md). It has the default characteristics:
- Nullable.
- Can derive from an interface or other class.
- Other classes can derive from this.
- Can be marked abstract.
- Can contain an entry method.
- Can contain a static constructor
- Does not require a constructor.

```csharp
using namespace System;

namespace ExampleA
{
    public class TypeA
    {
        public static Console console;

        static TypeA => con = new;

        public static void Main()
        {
            TypeA obj1 = new, obj2 = null;
            console.Write("Hello World!");
        }
    }

    public abstract class TypeB : TypeA
    {
        public abstract void Hi();
    }
}
```
