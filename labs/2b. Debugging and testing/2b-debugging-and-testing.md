# Lab 2b: Debugging and testing

**Objective**: This exercise demonstrates some of the best practices when debugging and testing source generators.

## 1. Analyze the existing implementation

1. Open the provided solution and try to build and run the application. Unfortunately the author has messed up a couple of things and the solution does not build.
2. The author has made an attempt to create an automatic caching decorator source generator. Take a look at the `MessageStore` class and familirise yourself with its intention.
3. Take a look at the generated file `MessageStoreCachingDecorator.g.cs`.
4. Finally take a look at the source generator `CachingDecoratorGenerator`.

## 2. Debugging the build issues

### 2.1 Attaching the debugger

The most useful debugging tool is the debugger. At this time the application is not building, but the source generator project is. When the source generator is executed it is part of the compilers' runtime. It is executed during the compilation of the application project. This allows for debugging of the source generator during the build of the application.

1. Open the `CachingDecoratorGenerator` file and add the following call to the `GenerateCachingDecorator` method: `Debugger.Launch();`.
2. Build your solution and a popup should appear. Select the current instance of your IDE. You should now be in debug mode.

### 2.2 Fixing the build errors

1. Continue your execution in the debugger and figure out where the big amount of gibberish in the generated code is coming from. Fix it so a valid class is generated.
2. Open the `MessageStore` class in the `Application` project. Change the method signatures a little bit and save the file.
3. Undo your changes and save the file again.

Perhaps you have noticed that you are now constantly being spammed by popups asking to choose a debugger. Launching a debugger everytime the source generator executes is far from ideal. Remove the `Debugger.Launch();` call.

## 3. Testing the generator

### 3.1. Analyzing the tests

Open the `CachingDecoratorGeneratorTests`. Notice how the tests are implemented:

1. Arrange a source file. This could also be an existing file in your project.
2. Execute the source generator.
3. Assert that the source generator has generated the expected file.

### 3.2. Compiling the source code

Executing the source generator has not yet been implemented. Let's change that.

1. Create a syntax tree from the input source code. This can be done by using the `CSharpSyntaxTree`.
2. Compile the syntax tree. Use the `CSharpCompilation`.

### 3.3. Executing the source generator(s)

You have now compiled the source code. However, the source generators have not yet been added.

1. Create a `CSharpGeneratorDriver`. Note that the source requires both generators to compile succesfully.
2. Call `RunGeneratorsAndUpdateCompilation` to compile the source code including the source generators.
3. The output of the compiled code is not very interesting. For these tests the generated files are interesting. Retrieve them using `GetRunResult`.
4. Return only the result of the `CachingDecoratorGenerator`.
5. Run the tests again. If you have succesfully implemented the `RunGenerator` method one of the tests should be succeeding. If that is not the case, fix the method by using the assertion messages and debugging.

### 3.4. Debugging the source generator

The source generator seems to be working for block scoped namespaces, but fails to generate correct output for file scoped namespaces. Calling the generator from a unit tests has created a new entry point into the generator. Unit tests conveniently allow for very easy debugging:

1. Add a breakpoint in the `CachingDecoratorGenerator`.
2. Run the failing test.
3. Figure out why the generated namespace is incorrect. If you are having difficulty in figuring out the issue, use the `Syntax Visualizer` window to find out the difference between a block scoped namespace and a file scoped namespace.
4. Fix the bug causing the test to fail.
5. Both the tests should now be passing.

## Learning outcomes

After completing this lab, you should understand:

- How to write unit tests for your source generators.
- How to easily debug your source generators by using unit tests as an entry point.
- How to use the Syntax Visualizer window to analyze code structures.
