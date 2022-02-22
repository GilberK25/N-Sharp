# Keywords/Packaging
## `namespace`

A namespace is a containing object for types. A namespace acts like a folder for code, and packages up the code into a library that can be imported with the [`using`](using.md) keyword. Namespaces can contain other namespaces, like how folders can contain subfolders. To get to a child namespace, mention the parent namespace, then add a `.`, and add the child namespace.

Namespaces can have accessibility modifiers.

```
public namespace NamespaceA // Parent namespace.
{
    public class TypeA { }

    public namespace NamespaceB // Child namespace.
    {
        public class TypeB { }
    }
}
```

```
using namespace NamespaceA;

public namespace NamespaceC
{
    public class TypeC
    {
        public static void Main()
        {
            TypeA a = new; // NamespaceA is already imported, no need to mention it.
            NamespaceB.TypeB b = new; // Child namespace is not imported

            NamespaceA.TypeA c = new; // Allowed, but not recommended.
        }
    }
}
```
