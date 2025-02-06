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




