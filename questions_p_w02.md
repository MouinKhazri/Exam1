P_W02
 
1. Explain handling exceptions in .NET/C#. 
**Your answer:**
Handling exceptions is when you place code that might fail in a try block, when an error happens, it gets passed to a "catch" block where you can respond to the error. You can also add a "finally" block after "try" and "catch" which cleans up the resource, which wont let the program crash.



2. What is the purpose of the IDisposable interface in C#? When should you use it?
**Your answer:**
It's an interface that allows classes to provide ways to release resources that havent been managed like files, memory, or database connections when they arent needed anymore. You use it if a class has resources that have to be explicitly cleaned up, the main method Dispose() is called to free the resources promptly instead of waiting for garbage collector.
