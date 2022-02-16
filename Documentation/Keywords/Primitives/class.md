# Keywords/Primitives
## `class`

A class is the default and most used type of [primitive](Primitives.md). It has the default characteristics:
- Nullable.
- Can derive from an interface or other class.
- Only other classes can derive from a class.
- Can be marked abstract.
- Can contain an entry method.
- Can contain a static constructor
- Does not require a constructor.

```nsharp
using namespace System;

public namespace Example
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

        public static void Main() { } 
        // This will cause the compiler to get confused and throw an error.
        // There should only be 1 `public static void Main()` (with or without the arguments)
    }
}
```
