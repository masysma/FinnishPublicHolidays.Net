# Introduction 

.NET implementation of Finnish public holiday determination logic.

Implementation can determine the following (Finnish) public holidays:
- All Saints' Day (pyhäinpäivä)
- Ascension Day (helatorstai)
- Boxing Day (tapaninpäivä)
- Christmas Day (joulupäivä)
- Christmas Eve (jouluaatto)
- Easter (pääsiäispäivä)
- Easter Sunday (2. pääsiäispäivä)
- Epiphany (loppiainen)
- First Of May (vapunpäivä)
- GoodFriday (pitkäperjantai)
- Indepencence Day (itsenäisyyspäivä)
- Midsummer Day (juhannuspäivä)
- Midsummer Eve (juhannusaatto)
- New Years Day (uudenvuodenpäivä)
- Pentecost (helluntai)

# Getting Started

You can install the library from nuget.org.

	PM> Install-Package FinnishPublicHolidays

Checks can be applied via extension methods (available for DateTime and DateTimeOffset).

# Examples

	bool isWorkday = new DateTime(2021, 7, 15).IsWorkDay(); // Thursday
	// isWorkday: true

	bool isWorkday = new DateTime(2021, 12, 25).IsWorkDay(); // Christmas day
	// isWorkday: false

	bool isHoliday = new DateTimeOffset(2022, 4, 17).IsPublicHoliday(); // Easter
	// isHoliday: true

	Holiday easter = new DateTimeOffset(2022, 4, 17).GetHoliday(); // Easter
	// easter:  { Date: 2022-04-17 ,Name: "Pääsiäispäivä"}

	bool isWorkday = new DateTime(2022, 1, 2).IsWorkDay();  // Sunday
	// isWorkday: false 

For more usage examples, please see test methods from source code for reference.

# Contribute

If you notice an error or would like to contribute, please feel free make pull requests.

## License

Copyright &copy; 2021 Matti Sysmäläinen

Distributed under the Eclipse Public License.
