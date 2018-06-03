using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
	    private const char Off = 'O';
		private const char Yellow = 'Y';
	    private const char Red = 'R';

	    private const int LampsOnHourRow1 = 5;
	    private const int LampsOnMinuteRow1 = 12;
	    private const int LampsOnRow2 = 5;

	    public string ConvertTime(string aTime)
        {
	        int hour, minute, second;

			try
			{
		        var time = aTime.Split(':');
		        hour = int.Parse(time[0]);
		        minute = int.Parse(time[1]);
		        second = int.Parse(time[2]);
	        }
			catch (Exception)
	        {
		        Console.WriteLine("Invalid timestamp");
		        throw;
	        }

			var result = new StringBuilder();

			DisplaySecondsRow(second, result);
	        DisplayHoursRow1(hour, result);
	        DisplayHoursRow2(hour, result);
	        DisplayMinutesRow1(minute, result);
			DisplayMinutesRow2(minute, result);

	        return result.ToString();
        }

	    private void DisplaySecondsRow(int second, StringBuilder result)
	    {
		    result.Append(second % 2 == 0 ? Yellow : Off);
		    result.AppendLine();
	    }

	    private void DisplayHoursRow1(int hour, StringBuilder result)
	    {
		    for (int i = 1; i < LampsOnHourRow1; i++)
		    {
			    result.Append(hour / (5 * i) > 0 ? Red : Off);
		    }

		    result.AppendLine();
	    }

	    private void DisplayHoursRow2(int hour, StringBuilder result)
	    {
		    for (int i = 1; i < LampsOnRow2; i++)
		    {
			    result.Append(hour % 5 >= i ? Red : Off);
		    }

		    result.AppendLine();
	    }

	    private void DisplayMinutesRow1(int minute, StringBuilder result)
	    {
		    for (int i = 1; i < LampsOnMinuteRow1; i++)
		    {
			    var isOff = minute / (5 * i) == 0;
			    var isQuarter = i % 3 == 0;

			    result.Append(isOff ? Off : (isQuarter ? Red : Yellow));
		    }

		    result.AppendLine();
	    }

	    private void DisplayMinutesRow2(int minute, StringBuilder result)
	    {
		    for (int i = 1; i < LampsOnRow2; i++)
		    {
			    result.Append(minute % 5 >= i ? Yellow : Off);
		    }
	    }
    }
}
