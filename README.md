# Test Driven Development (TDD) Example Repository

This repository demonstrates the principles of Test Driven Development (TDD) using a simple C# program to calculate ratios of positive, negative, and zero values in an array.

## Overview

Test Driven Development (TDD) is a software development approach where tests are written before the code they are intended to validate. This ensures that the code meets the expected requirements defined by the tests. The process typically follows these steps:

1. **Write a Test**: Create a test that defines the expected behavior of a small unit of code.
2. **Run the Test**: Execute the test to ensure it fails (since the code under test hasn't been written yet).
3. **Write the Code**: Implement the minimum amount of code necessary to pass the test.
4. **Run Tests**: Execute all tests to ensure the newly written code and existing codebase function as expected.
5. **Refactor (if necessary)**: Improve the code without changing its behavior, ensuring it remains clean and maintainable.

This repository contains a simple example illustrating how to apply TDD principles to solve a common programming problem.

## Example Problem: PlusMinusCalculator

The `PlusMinusCalculator` calculates the ratios of positive, negative, and zero values in an array of integers.

### Input Format

- The first line contains an integer, `n`, the size of the array.
- The second line contains `n` space-separated integers that describe the array.

### Output Format

- Print the following 3 lines, each to 6 decimals:
  - Proportion of positive values
  - Proportion of negative values
  - Proportion of zeros

### Example

**Input:**

