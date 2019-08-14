Feature: DateTimeExtensions
	In order to perform common operations on dates and times
	As a developer
	I want a variety of extension methods to help me out

Scenario: calculate the approximate difference between two identical date times
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T13:45:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "less than a minute"

Scenario: calculate the approximate difference between two date times a minute apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T13:46:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about one minute"

Scenario: calculate the approximate difference between two date times five minutes apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T13:50:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 5 minutes"

Scenario: calculate the approximate difference between two date times 30 minutes apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T14:15:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 30 minutes"

Scenario: calculate the approximate difference between two date times 45 minutes apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T14:30:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 45 minutes"

Scenario: calculate the approximate difference between two date times 1 hour apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T14:45:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about one hour"

Scenario: calculate the approximate difference between two date times 1.5 hour apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T15:15:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 2 hours"

Scenario: calculate the approximate difference between two date times 2.5 hour apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-15T16:15:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 2 hours"

Scenario: calculate the approximate difference between two date times 12 hours apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-16T01:45:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 12 hours"

Scenario: calculate the approximate difference between two date times 18 hours apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-16T07:45:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two date times 22 hours apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-16T11:45:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two date times 24 hours apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234 |
	| 2011-04-16T13:45:26.1234 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two date times 26 hours apart
	Given the following datetimes
	| Value							 |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-16T15:45:26.1234+01:00 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two date times 72 hours apart
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-18T13:45:26.1234+01:00 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 3 days"

Scenario: calculate the approximate difference between two date times 144 hours apart
	Given the following datetimes
	| Value                    |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-21T13:45:26.1234+01:00 |
	When I calculate the approximate difference between datetime 1 and datetime 2
	Then the approximate difference should be "about 6 days"

Scenario: create chronological key from a date time using a suffix
	Given the following datetimes
	| Value							 |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological keys for the date times with the suffix 'AppendMe'
	Then the the keys should be
	| Value                          |
	| 000634384683261234000-AppendMe |
	| 000634706091271234000-AppendMe |
	| 000637230699261234000-AppendMe |
	| 000637230699261235000-AppendMe |

Scenario: create chronological key from a date time with a uniqueid
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological keys for the date times with a unique suffix
	Then the the keys should match the following with a guid
	| Value                  |
	| 000634384683261234000- |
	| 000634706091271234000- |
	| 000637230699261234000- |
	| 000637230699261235000- |

Scenario: create chronological key stem without a suffix from a date time 
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological key stems for the date times 
	Then the the keys should be
	| Value                 |
	| 000634384683261234000- |
	| 000634706091271234000- |
	| 000637230699261234000- |
	| 000637230699261235000- |

Scenario: create chronological key from a date time without a suffix
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological keys for the date times
	Then the the keys should be
	| Value                 |
	| 000634384683261234000 |
	| 000634706091271234000 |
	| 000637230699261234000 |
	| 000637230699261235000 |

Scenario: create reverse chronological key from a date time using a suffix
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological keys for the date times with the suffix 'AppendMe'
	Then the the keys should be
	| Value                          |
	| 002520994292738765999-AppendMe |
	| 002520672884728765999-AppendMe |
	| 002518148276738765999-AppendMe |
	| 002518148276738764999-AppendMe |

Scenario: create reverse chronological key from a date time with a uniqueid
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological keys for the date times with a unique suffix
	Then the the keys should match the following with a guid
	| Value                  |
	| 002520994292738765999- |
	| 002520672884728765999- |
	| 002518148276738765999- |
	| 002518148276738764999- |

Scenario: create reverse chronological key stem without a suffix from a date time 
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological key stems for the date times 
	Then the the keys should be
	| Value                  |
	| 002520994292738765999- |
	| 002520672884728765999- |
	| 002518148276738765999- |
	| 002518148276738764999- |

Scenario: create reverse chronological key from a date time without a suffix
	Given the following datetimes
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological keys for the date times
	Then the the keys should be
	| Value                 |
	| 002520994292738765999 |
	| 002520672884728765999 |
	| 002518148276738765999 |
	| 002518148276738764999 |

Scenario: create a datetime from a unix timestamp
	When I convert the unix timestamp -412856257 to a datetime
	Then the result should be the datetime "1956-12-1T13:42:23.0000"

Scenario: create a unix timestamp from a datetime
	When I convert the datetime "2013-11-7T04:12:59.0000" to a unix timestamp
	Then the result should be the unix timestamp 1383797579

Scenario: create a range of days
	When I create a range of days from "2013-11-7T23:59:59.000" to "2013-11-11T23:59:59.000" 
	Then the date range should be
	| Value                   |
	| 2013-11-07T00:00:00.000 |
	| 2013-11-08T00:00:00.000 |
	| 2013-11-09T00:00:00.000 |
	| 2013-11-10T00:00:00.000 |
	| 2013-11-11T00:00:00.000 |

Scenario: create a range consisting of a single day
	When I create a range of days from "2013-11-7T23:59:59.000" to "2013-11-7T23:59:59.000" 
	Then the date range should be
	| Value                   |
	| 2013-11-07T00:00:00.000 |

Scenario: create a range heading back in time
	When I create a range of days from "2013-11-11T23:59:59.000" to "2013-11-7T23:59:59.000" 
	Then the date range should be
	| Value                   |
	| 2013-11-11T00:00:00.000 |
	| 2013-11-10T00:00:00.000 |
	| 2013-11-09T00:00:00.000 |
	| 2013-11-08T00:00:00.000 |
	| 2013-11-07T00:00:00.000 |
