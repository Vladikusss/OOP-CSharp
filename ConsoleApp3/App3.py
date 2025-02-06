# This program was translated from C# to Python

import random

def main():
    Integers = GenerateRandomIntegers()
    PrintRandomIntegers(Integers)

def GenerateRandomIntegers() -> list:
    ls = []

    for x in range(0,100):
        ls.append(random.randint(1,1001))

    return ls


def PrintRandomIntegers(nums: list) -> None:
    for x in range(len(nums)):
        print(nums[x], end=", ")
        if (x + 1) % 10 == 0:
            print()


if __name__ == "__main__":
    main()




