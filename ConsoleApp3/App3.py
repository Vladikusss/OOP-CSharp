# This program was translated from C# to Python

import random

def main():
    """Program to generate and manipulate random numbers"""

    # Generating and printing integers:
    integers = GenerateRandomIntegers()
    PrintRandomIntegers(integers)

    # Calculating and printing total of integers:
    sumOfIntegers = ComputeSum(integers)
    print(f"THe sum of random integers in the list is: {sumOfIntegers}")

    # Generating and Displaying histogram from integers:
    histogram = ComputeHistogram(integers)
    DisplayHistogram(histogram)

    # Test the function
    arr = [5, 3, 8, 4, 2, 25, 23, 867, 345, 23423423, 765, 293, 5, 345, 56478, 6, 98765, 645, 13, 68, 23]
    print("Before Sorting:", arr)
    insertion_sort(arr)
    print("\nAfter Sorting:", arr)

def insertion_sort(numbers):
    """Insertion sort algorithm to sort out array of numbers."""
    for i in range(1, len(numbers)): # start at index 1, as index 0 is assumed to be sorted
        currentElement = i # index from outer loop of current element
        beforeElement = i - 1 # index of the value before current index
        # while index of previous element is >=0 and value of previous element >= current element
        while beforeElement >= 0 and numbers[beforeElement] > numbers[currentElement]:
            numbers[beforeElement + 1] = numbers[beforeElement] # move previous element one step forward, e.g. 0->1
            beforeElement -= 1 # decrement by 1 to go to previous of previous element
        numbers[beforeElement + 1] = numbers[currentElement] # increment by 1 to put current element in correct position






def GenerateRandomIntegers() -> list:
    """Function to generate 100 numbers"""

    ls = []

    for x in range(0,100):
        # Generates 100 random numbers
        ls.append(random.randint(1,1001))

    return ls


def PrintRandomIntegers(nums: list) -> None:
    """Function to print random numbers"""

    for x in range(len(nums)): # Output generated numbers to the console
        print(nums[x], end=", ")
        if (x + 1) % 10 == 0: # Every 10 numbers a new line is added
            print()


def ComputeSum(nums: list) -> int:
    """Function to calculate sum of random integers"""

    total = 0
    for number in nums:
        total += number

    return total


def ComputeHistogram(nums: list) -> dict:
    """Function to compute frequency of each number"""
    frequency = dict()

    for number in nums: # Loop through each number
        if number in frequency: # Check if number is in dictionary
            frequency[number] += 1
        else: # Add number to the dictionary if not present
            frequency[number] = 1

    return frequency


def DisplayHistogram(freq: dict) -> None:
    """Function to display histogram"""
    for key, value in freq.items():
        print(key, ":", value)

if __name__ == "__main__":
    main()




