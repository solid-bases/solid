# Liskov substitution principle

The Liskov substitution principle (LSP) is a particular definition of a subtyping relation, called *strong behavioral subtyping*.

It states that an object (such as a class) may be replaced by a sub-object (such a class that extends the first class) without breaking the program.

> «If S is a declared subtype of T, objects of type S should behave as objects of type T are expected to behave, if they are treated as objects of type T»

## Example

Consider the following method

```csharp
void processBag(Bag bag) {
    if (!bag.IsEmpty()) { return; }
    while (!bag.IsEmpty()) {
        Element e = bag.Take();
        if (e.IsSmall()) {
            bag.Put(new Element(e.IncreaseSize()));
        }
    }
}
```

and consider the following classes

```csharp
class Bag {
    protected IEnumerable<Element> elements = new List<Element>();
    public bool IsEmpty() => !elements.Any();
    public Element Take() {
        var first = elements.First();
        elements = elements.Skip(1).Take(elements.Count() - 1);
        return first;
    }
    public void Put(Element element) {
        elements = elements.Append(element);
    }
}
class Stack : Bag { /* ... code ... */ }
class Heap : Bag { /* ... code ... */ }
```

To fulfill the LSP, the `processBag(Bag bag)` method must behave in the same way whether if called with a `Stack`, `Heap` or `Bag` object.

```csharp
// [somewhere]
var bag = new Bag();
var stack = new Stack();
var heap = new Heap();
processBag(bag);
processBag(stack);
processBag(heap);
```

The behaviour (and the result), should be the same in all the executions, specifically:

* `IsEmpty()` will always be true when the `elements` enumerable is empty
* `Take()` will always remove and return an element from the enumerable
* `Put(Element element)` will always put an element in the enumerable

> In the example, the difference will probably be the order:
>
> * `Stack` will `Put` and `Take` from the end of `elements` enumerable (LIFO)
> * `Heap` will randomly `Put` and `Take` in `elements` enumerable (RAB - Random Access Bag? 😅)
