# Interface Segregation Principle

The interface segregation principle (ISP) states that no code should be forced to depend on methods it does not use.

Consider the following interface

```csharp
interface IBankAccount {
    List<Operation> Operations { get; set; }
    void InTransfer(decimal amount);
    void OutTransfer(decimal amount);
    void Reset();
}

class BankAccount : IBankAccount
{
    public decimal AccountBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Owner { get; set; }
    public List<Operation> Operations { get; set; }

    public void InTransfer(decimal amount)
    {
        // code here...
    }

    public void OutTransfer(decimal amount)
    {
        // code here...
    }

    public void Reset()
    {
        // code here...
    }
}
```

and consider this client code

```csharp
class ECommerce {
    const IBankAccount _ourBankAccount;
    private IBankAccount _customerBankAccount;
    public ECommerce(IBankAccount customerBankAccount) {
        _customerBankAccount = customerBankAccount
    }

    void PerformPayment(decimal amount) {
        // ... code
        _customerBankAccount.OutTransfer(amount);
        _ourBankAccount.InTransfer(amount);
        // ... code
    }
}
```

The `PerformPayment` method clearly need only the `OutTransfer` and `InTransfer` methods, but in the purposed design it is depending on an interface that requires to implement also a `Reset` and a `Operations` members.

This is not useful for the client purpose: ISP stands to do not force code to have dependencies through not used methods.

Applying ISP, we could rewrite the ECommerce class in this way

```csharp
class ECommerce {
    const ICanInTransfer _ourAccount;
    private ICanOutTransfer _customerAccount;
    public ECommerce(ICanOutTransfer customerAccount) {
        _customerAccount = customerAccount
    }

    void PerformPayment(decimal amount) {
        // ... code
        _customerAccount.OutTransfer(amount);
        _ourAccount.InTransfer(amount);
        // ... code
    }
}
```

and the interfaces will now be

```csharp
interface IHaveOperations {
    List<Operation> Operations { get; set; }
}
interface ICanInTransfer {
    void InTransfer(decimal amount);
}
interface ICanOutTransfer {
    void OutTransfer(decimal amount);
}
interface ICanTransferMoney : ICanInTransfer, ICanOutTransfer {}
interface IHaveReset {
    void Reset();
}
interface IBankAccount : IHaveOperations, ICanTransferMoney, IHaveReset {}

class BankAccount : IBankAccount
{
    public decimal AccountBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Owner { get; set; }
    public List<Operation> Operations { get; set; }

    public void InTransfer(decimal amount)
    {
        // code here...
    }

    public void OutTransfer(decimal amount)
    {
        // code here...
    }

    public void Reset()
    {
        // code here...
    }
}
```

## Why?

An example of why the ISP is so important can be easily explained with an example.

Let's suppose we want, in a later time, to implement the possibility to use a credit card payment. Let's suppose that the interface of a `CreditCardAccount` is

```csharp
interface ICreditCardAccount {
    List<Operation> Operations { get; set; }
    void InTransfer(decimal amount);
    void OutTransfer(decimal amount);
}
```

If we use the first ECommerce code, with the `IBankAccount`, we have to change the `ECommerce` code, in order to introduce a less restrictive interface, that does not requires the `Reset` method, in order to be able to delegate the `IBankAccount` to the `ECommerce` class:

```csharp
interface IBankAccount : ICreditCardAccount {
    void Reset();
}

class ECommerce {
    const ICanInTransfer _ourAccount;
    private ICreditCardAccount _customerAccount;
    public ECommerce(ICreditCardAccount customerAccount) {
        _customerAccount = customerAccount
    }

    void PerformPayment(decimal amount) {
        // ... code
        _customerAccount.OutTransfer(amount);
        _ourAccount.InTransfer(amount);
        // ... code
    }
}
```

And this will happen each time, in each part of the code we introduce a dependency over not required methods.

So, why not?

* it is costless
* it reduce bug risks (*remember the `e=mc²` formula `[errors = (more code)²]`*!)
* it enhance the code flexibility
