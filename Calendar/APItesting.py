import requests
from datetime import datetime
from pprint import pprint

# Step 1: Ask user for input
user_date = input("Enter a date (YYYY-MM-DD): ").strip()

# Step 2: Extract year from the date
try:
    date_obj = datetime.strptime(user_date, "%Y-%m-%d")  # Validate format
    print(date_obj)
    year = date_obj.year
except ValueError:
    print("❌ Invalid date format. Please enter YYYY-MM-DD.")
    exit()

# Step 3: Send request to Nager.Date API for UK holidays in the given year
api_url = f"https://date.nager.at/api/v3/PublicHolidays/{year}/GB"
response = requests.get(api_url)
print(response)

# Step 4: Check if the API call was successful
if response.status_code == 200:
    holidays = response.json()
    pprint(holidays)
    # Step 5: Find if any holiday matches the exact date
    matching_holidays = [h["localName"] for h in holidays if h["date"] == user_date]

    # Step 6: Display the result
    if matching_holidays:
        print(f"\n🎉 Public Holiday(s) on {user_date}:")
        for holiday in matching_holidays:
            print(f"- {holiday}")
    else:
        print(f"\n❌ No public holidays on {user_date}.\n")
else:
    print("⚠️ Failed to retrieve data. Check your internet connection or API status.")

country_api_url = f"https://date.nager.at/api/v3/CountryInfo/GB"
country_response = requests.get(country_api_url)

if country_response.status_code == 200:
    country_info = country_response.json()
    pprint(country_info)
else:
    print("⚠️ Failed to retrieve data. Check your internet connection or API status.")