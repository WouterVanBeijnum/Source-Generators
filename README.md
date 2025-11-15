# Source Generators

This repository contains a comprehensive collection of hands-on labs designed to develop proficiency in working with C# source generators. Each lab is self-contained and can be completed independently, allowing learners to progress through the exercises in any order that suits their learning objectives.

## Beginner Level

### 1. Hello, Source Generator!

Build your first source generator from the ground up.

**Learning objectives:**

- Distinguish between analyzer projects and standard class libraries, understanding their different purposes and configurations
- Configure a project to include and utilize source generators effectively
- Create a basic source generator that demonstrates the fundamental concepts of compile-time code generation

## Intermediate Level

### 2a. Eliminating Boilerplate

Develop a source generator that automatically eliminates repetitive boilerplate code.

**Learning objectives:**

- Identify common patterns of boilerplate code that can be automated through source generation
- Implement attribute-driven code generation to reduce manual coding overhead
- Design source generators that respond to custom marker attributes and generate corresponding implementation code
- Navigate and analyze the Roslyn syntax tree to extract meaningful information from existing code
- Transform syntax tree data into generated C# code that maintains type safety and consistency

### 2b. Debugging and Testing

Develop a source generator that validates code patterns and reports custom diagnostics to developers.

**Learning objectives:**

- Understand the debugging experience for source generators using the debugger and breakpoints
- Test source generators and verify generated code
- Use the Syntax Visualizer to understand code structures

### 2c. Schema to code

Build a source generator that transforms external schema definitions into strongly-typed C# models.

**Learning objectives:**

- Implement the IncrementalSourceGenerator pipeline for optimal performance and reliability
- Process and incorporate external data files into the source generation workflow
- Handle file system dependencies and change detection within the incremental generation pipeline
