# Keywords/Packaging
## `using`

The `using` keyword is a way to import namespaces or types from different [namespaces](namespace.md). They can be put anywhere in a file, but it is preferred to be at the top. Following the `using` word on the same line is the name of the [primitive type](../Primitives/Primitives.md) of the object. Example, `using namespace` to import a namespace (this is the most used one), or `using class`, to import a class. Then follows the name or "directory" (if the object is in a namespace) of the type intended to import.

When importing a namespace, all types (as well as child namespaces) are imported. However, in the case of child namespaces, the content in them is not imported, just their name. To import a child namespace, use the name of the parent namespace, then the child namespace, seperated by a '.'

When importing a class, all static fields are imported, or any child types. However, you cannot import non-static fields in a class.

You cannot import a structure, interface, enum, or delegate.

In a namespace, all other types in that namespace are automatically imported, and a `using` keyword is redundant.

**File 1:**
```nsharp
public namespace Example
{
    public class TypeA
    {
        public static int FieldA;
        public int FieldB;

        public static void MethodA() { }
    }
    
    public class TypeB
    {
        public void MethodB() { }
    }
}
```

**File 2:**
```nsharp
using namespace Example; // Import the "Example" namespace.
using class Example.TypeA; // Import the "Example.TypeA" class.
// Example is not automatically imported, so we still need the name here.

public namespace Example2
{
    public class TypeC
    {
        public TypeB FieldC;
        
        public void MethodC()
        {
            MethodA(); // Referring to `Example.TypeA.MethodA()` method imported.
            FieldA = 5;
            FieldB = -1; // FieldB is non-static, so it cannot be set.
        }
    }
}
```

**File 3:**
```nsharp
public namespace Example2
{
    public class TypeD
    {
        TypeC FieldD; // `TypeC` is part of the `Example2` namespace, so it doesn't need to be imported.
    }
}
```
