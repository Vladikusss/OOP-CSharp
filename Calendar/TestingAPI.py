 """
 /*
 * Created by Vladdy | 22.02.2025
 * Last Updated: 22.02.2025
 * Program: API Testing - will be used as blueprint in c#
 * Version: 1.0
 * Status: In Progress
 */
 """

import requests # Make requests to API
from datetime import datetime # Format user's input


def ValidateInput(user_date: str):
    """Function to validate input"""
    try:
        date_obj = datetime.strptime(user_date, "%Y-%m-%d") # Validate date
        year = date_obj.year # Used in API call
        return year
    except ValueError: # Wrong date format from user
        print("❌[DateError] --- Invalid date format. Please follow the format of YYYY-MM-DD.")
        return False


def MakeAPICall(year: int, country: str):
    """Function to make API calls to https://date.nager.at/"""
    api_url = f"https://date.nager.at/api/v3/PublicHolidays/{year}/{country}"
    response = requests.get(api_url) # Pull data from API
    return response

def PrintHolidays(api_response, user_date, country):
    """Function to output desired information to the user"""
    holidays = api_response.json() # Convert data into JSON
    # List containing names of holidays if they appear on user's date
    matching_holidays = [x["localName"] for x in holidays if x["date"] == user_date]

    if matching_holidays: # If there are holidays on user's date - output the result
        print(f"\n🎉 Public Holiday(s) on {user_date} in {country}:")
        for x in matching_holidays: # Loop through the list of holidays
            print(f"- {x}")
    else: # No holiday's on user's date
        print(f"\n❌ No public holidays on {user_date} in {country}.\n")


def Main():
    """Main function that calls all the other functions"""
    while True:
        user_date = input("Please enter the date you are interested in (YYYY-MM-DD): ").strip()

        year = ValidateInput(user_date)
        country_code = "GB"

        api_response = MakeAPICall(year, country_code) # Response from web-server
        if api_response.status_code == 200: # 200 -> successful http request from client
            PrintHolidays(api_response, user_date, country_code) # Call function to output holidays
        else:
            print(f"⚠️[{api_response}] --- Failed to retrieve data. Check your internet connection or API status.")
            break

if __name__ == "__main__":
    Main()