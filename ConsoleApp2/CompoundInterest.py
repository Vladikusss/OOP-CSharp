# Program to calculate compound interest
# This will then be translated into c#

amount = int(input("Please enter the sum you want to put in: ")) # decimal
interest_rate = 4.11 # decimal %
percentage_multiplier = round(interest_rate/100, 4) # decimal

print("The interest rate at the moment is:", interest_rate)
print("The percentage multiplier is:", percentage_multiplier)
# Without withdrawals/deposits
yearly_Income = round(amount + (amount * percentage_multiplier), 2) # decimal
monthly_Income = round((amount / 12) * percentage_multiplier, 2) # decimal
daily_Income = round((amount / 365) * percentage_multiplier, 2) # decimal

print("In one year your savings will be:", yearly_Income)
print("This is", monthly_Income, "every month and", daily_Income, "every day")