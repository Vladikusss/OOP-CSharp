"""
 /*
 * Created by Vladdy | 23.02.2025
 * Last Updated: 23.02.2025
 * Program: API Testing - will be used as blueprint in c#
 * Version: 2.0
 * Status: Completed
 */
"""

import requests # Make requests to API
from datetime import datetime # Format user's input


def ValidateInput(user_date):
    """Function to validate input"""
    try:
        date_obj = datetime.strptime(user_date, "%Y-%m-%d") # Validate date
        year = date_obj.year # Used in API call
        return year
    except ValueError: # Wrong date format from user
        print("❌[DateError] --- Invalid date format. Please follow the format of YYYY-MM-DD.")
        return False


def MakeAPICall(year, country):
    """Function to make API calls to https://date.nager.at/"""
    api_url = f"https://date.nager.at/api/v3/PublicHolidays/{year}/{country}"
    response = requests.get(api_url) # Pull data from API
    return response


def CountryAPICall(country):
    """Function to make an API call to get country's official name"""
    api_url = f"https://date.nager.at/api/v3/CountryInfo/{country}"
    response = requests.get(api_url)
    return response

def PrintHolidays(api_response, api_response2, user_date, country):
    """Function to output desired information to the user"""
    holidays = api_response.json() # Convert data into JSON
    countries = api_response2.json()
    # List containing names of holidays if they appear on user's date
    matching_holidays = [x["localName"] for x in holidays if x["date"] == user_date]

    if matching_holidays: # If there are holidays on user's date - output the result
        print(f"\n🎉 Public Holiday(s) on {user_date} in {countries["officialName"]}:")
        for x in matching_holidays: # Loop through the list of holidays
            print(f"- {x}")
    else: # No holiday's on user's date
        print(f"\n❌ No public holidays on {user_date} in {countries["officialName"]}.")


def Main():
    """Main function that calls all the other functions"""
    while True:
        user_date = input("Please enter the date you are interested in (YYYY-MM-DD): ").strip()

        year = ValidateInput(user_date)
        country_code = ["GB", "DE", "JP", "LV", "MD", "RU", "UA", "US"]

        for country in country_code:
            api_response = MakeAPICall(year, country) # Response from web-server
            if api_response.status_code == 200: # 200 -> successful http request from client
                api_response2 = CountryAPICall(country)
                PrintHolidays(api_response, api_response2, user_date, country) # Call function to output holidays
            else:
                print(f"⚠️[{api_response}] --- Failed to retrieve data. Check your internet connection or API status.")
                break
        break

if __name__ == "__main__":
    Main()