//********************************************************************************************
//Author: Sergey Stoyan, CliverSoft.com
//        http://cliversoft.com
//        stoyan@cliversoft.com
//        sergey.stoyan@gmail.com
//        27 February 2007
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DTTest> dates = new List<DTTest>();
            dates.Add(new DTTest(@"Member since:  	10-Feb-2008", new DateTime(2008, 2, 10, 0, 0, 0)));
            dates.Add(new DTTest(@"Last Update: 18:16 11 Feb '08 ", new DateTime(2008, 2, 11, 18, 16, 0)));
            dates.Add(new DTTest(@"date	Tue, Feb 10, 2008 at 11:06 AM", new DateTime(2008, 2, 10, 11, 06, 0)));
            dates.Add(new DTTest(@"see at 12/31/2007 14:16:32", new DateTime(2007, 12, 31, 14, 16, 32)));
            dates.Add(new DTTest(@"sack finish 14:16:32 November 15 2008, 1-144 app", new DateTime(2008, 11, 15, 14, 16, 32)));
            dates.Add(new DTTest(@"Genesis Message - Wed 04 Feb 08 - 19:40", new DateTime(2008, 2, 4, 19, 40, 0)));
            dates.Add(new DTTest(@"The day 07/31/07 14:16:32 is ", new DateTime(2007, 7, 31, 14, 16, 32)));
            dates.Add(new DTTest(@"Shipping is on us until December 24, 2008 within the U.S. ", new DateTime(2008, 12, 24, 0, 0, 0)));
            dates.Add(new DTTest(@" 2008 within the U.S. at 14:16:32", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 16, 32)));
            dates.Add(new DTTest(@"5th November, 1994, 8:15:30 pm", new DateTime(1994, 11, 5, 20, 15, 30)));
            dates.Add(new DTTest(@"7 boxes January 31 , 14:16:32.", new DateTime(DateTime.Now.Year, 1, 31, 14, 16, 32)));
            dates.Add(new DTTest(@"the blue sky of Sept  30th  2008 14:16:32", new DateTime(2008, 9, 30, 14, 16, 32)));
            dates.Add(new DTTest(@" e.g. 1997-07-16T19:20:30+01:00", new DateTime(1997, 7, 16, 19, 20, 30)));
            dates.Add(new DTTest(@"Apr 1st, 2008 14:16:32 tufa 6767", new DateTime(2008, 4, 1, 14, 16, 32)));
            dates.Add(new DTTest(@"wait for 07/31/07 14:16:32", new DateTime(2007, 7, 31, 14, 16, 32)));
            dates.Add(new DTTest(@"later 12.31.08 and before 1.01.09", new DateTime(2008, 12, 31, 0, 0, 0)));
            dates.Add(new DTTest(@"Expires: Sept  30th  2008 14:16:32", new DateTime(2008, 9, 30, 14, 16, 32)));
            dates.Add(new DTTest(@"Offer expires Apr 1st, 2007, 14:16:32", new DateTime(2007, 4, 1, 14, 16, 32)));
            dates.Add(new DTTest(@"Expires  14:16:32 January 31.", new DateTime(DateTime.Now.Year, 1, 31, 14, 16, 32)));
            dates.Add(new DTTest(@"Expires  14:16:32 January 31-st.", new DateTime(DateTime.Now.Year, 1, 31, 14, 16, 32)));
            dates.Add(new DTTest(@"Expires 23rd January 2010.", new DateTime(2010, 1, 23, 0, 0, 0)));
            dates.Add(new DTTest(@"Expires January 22nd, 2010.", new DateTime(2010, 1, 22, 0, 0, 0)));
            dates.Add(new DTTest(@"Expires DEC 22, 2010.", new DateTime(2010, 12, 22, 0, 0, 0)));
            dates.Add(new DTTest(@"Version: 1.0.0.692 6/1/2010 2:28:04 AM ", new DateTime(2010, 6, 1, 2, 28, 4)));
            dates.Add(new DTTest(@"Version: 1.0.0.692 04/21/11 12:30am ", new DateTime(2011, 4, 21, 00, 30, 00)));
            dates.Add(new DTTest(@"Version: 1.0.0.692 04/21/11 12:30pm ", new DateTime(2011, 4, 21, 12, 30, 00)));
            dates.Add(new DTTest(@"Version: Thu Aug 06 22:32:15 MDT 2009 ", new DateTime(2009, 8, 6, 22, 32, 15)));

            test(dates, TestFormat.DATE);

            dates.Add(new DTTest(@"Your program recognizes string : 21 Jun 2010 04:20:19 -0430 blah blah", new DateTime(2010, 6, 20, 23, 50, 19, DateTimeKind.Utc)));
            dates.Add(new DTTest(@"Your program recognizes string : 21 Jun 2010 04:20:19 UTC blah blah", new DateTime(2010, 6, 21, 4, 20, 19, DateTimeKind.Utc)));
            dates.Add(new DTTest(@"Your program recognizes string : 21 Jun 2010 04:20:19 EST blah blah", new DateTime(2010, 6, 20, 23, 20, 19, DateTimeKind.Utc)));
            
            test(dates, TestFormat.DATE_TIME);
            test(dates, TestFormat.TIME);

            Console.WriteLine("TOTAL ERRORS: " + total_errors.ToString() + "\n\n");

            Console.WriteLine("\n##################################   USAGE SAMPLE");
            List<string> ds = new List<string>();
            ds.Add(@"The last round was June 10, 2004; this time the unbroken record was held.");
            ds.Add(@"The last round was 2:14PM; this time the unbroken record was held.");
            ds.Add(@"The last round was on Tuesday; this time the unbroken record was held.");
            foreach (string date in ds)
            {
                Console.WriteLine("\n* " + date);
                DateTimeRoutines.ParsedDateTime dt;
                if (DateTimeRoutines.TryParseDateOrTime(date, DateTimeRoutines.DateTimeFormat.USA_DATE, out dt))
                {
                    if (dt.IsDateFound)
                        Console.WriteLine("Date was found: " + dt.DateTime.ToString());
                    else if (dt.IsTimeFound)
                        Console.WriteLine("Time only was found: " + dt.DateTime.ToString());
                }
                else
                    Console.WriteLine("Date was not found");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
        static int total_errors = 0;

        enum TestFormat
        {
            DATE,
            TIME,
            DATE_TIME
        }

        class DTTest
        {
            public string test;
            public DateTime answer;
            public DTTest(string test, DateTime answer)
            {
                this.test = test;
                this.answer = answer;
            }
        }

        static void test(List<DTTest> dates, TestFormat test_format)
        {
            int errors = 0;

            Console.WriteLine("\n\n##################################   " + test_format.ToString());
            DateTimeRoutines.ParsedDateTime t;
            foreach (DTTest test in dates)
            {
                string date = test.test;
                Console.WriteLine("");
                Console.WriteLine("* " + date);

                switch (test_format)
                {
                    case TestFormat.DATE:
                        if (date.TryParseDate(DateTimeRoutines.DateTimeFormat.USA_DATE, out t))
                            if (t.DateTime.Date == test.answer.Date)
                                Console.WriteLine(t.DateTime.ToString());
                            else
                            {
                                Console.WriteLine(">>>>>> ERROR: " + t.DateTime.Date.ToString() + " <> " + test.answer.Date.ToString());
                                errors++;
                            }
                        else
                        {
                            if (DateTime.Now.Year != test.answer.Year || DateTime.Now.Month != test.answer.Month || DateTime.Now.Day != test.answer.Day)
                            {
                                Console.WriteLine(">>>>>> ERROR: not found");
                                errors++;
                            }
                            else
                                Console.WriteLine("-----");
                        }
                        break;
                    case TestFormat.DATE_TIME:
                        if (date.TryParseDateOrTime(DateTimeRoutines.DateTimeFormat.USA_DATE, out t))
                            if (t.IsUtcOffsetFound && test.answer.Kind == DateTimeKind.Utc && t.UtcDateTime == test.answer || !t.IsUtcOffsetFound && t.DateTime == test.answer)
                                Console.WriteLine(t.DateTime.ToString());
                            else
                            {
                                Console.WriteLine(">>>>>> ERROR: " + t.DateTime.ToString() + " <> " + test.answer.ToString() + " and " + t.UtcDateTime.ToString() + " <> " + test.answer.ToString());
                                errors++;
                            }
                        else
                        {
                            Console.WriteLine(">>>>>> ERROR: not found");
                            errors++;
                        }
                        break;
                    case TestFormat.TIME:
                        if (date.TryParseTime(DateTimeRoutines.DateTimeFormat.USA_DATE, out t, null))
                            if (t.IsUtcOffsetFound && test.answer.Kind == DateTimeKind.Utc && t.UtcDateTime.TimeOfDay == test.answer.TimeOfDay || !t.IsUtcOffsetFound && t.DateTime.TimeOfDay == test.answer.TimeOfDay)
                                Console.WriteLine(t.DateTime.ToLongTimeString());
                            else
                            {
                                Console.WriteLine(">>>>>> ERROR: " + t.DateTime.TimeOfDay.ToString() + " <> " + test.answer.TimeOfDay.ToString() + " and " + t.UtcDateTime.TimeOfDay.ToString() + " <> " + test.answer.TimeOfDay.ToString());
                                errors++;
                            }
                        else
                        {
                            if (0 != test.answer.Hour || 0 != test.answer.Minute || 0 != test.answer.Second)
                            {
                                Console.WriteLine(">>>>>> ERROR: not found");
                                errors++;
                            }
                            else
                                Console.WriteLine("-----");
                        }
                        break;
                }
            }

            Console.WriteLine("\n\n@@@@@@@@@@@@@@@@@@@@@@@@@@@ ERRORS: " + errors.ToString() + "\n\n");
            total_errors += errors;
        }
    }
}

