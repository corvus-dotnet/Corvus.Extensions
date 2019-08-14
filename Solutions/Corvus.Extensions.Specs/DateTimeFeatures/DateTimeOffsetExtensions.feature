Feature: DateTimeOffsetExtensions
	In order to perform common operations on dates and times using the datetimeoffset type
	As a developer
	I want a variety of extension methods to help me out

Scenario: calculate the approximate difference between two identical datetimeoffsets
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T13:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "less than a minute"

Scenario: calculate the approximate difference between two datetimeoffsets a minute apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T13:46:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about one minute"

Scenario: calculate the approximate difference between two datetimeoffsets five minutes apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T13:50:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 5 minutes"

Scenario: calculate the approximate difference between two datetimeoffsets 30 minutes apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T14:15:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 30 minutes"

Scenario: calculate the approximate difference between two datetimeoffsets 45 minutes apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T14:30:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 45 minutes"

Scenario: calculate the approximate difference between two datetimeoffsets 1 hour apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T14:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about one hour"

Scenario: calculate the approximate difference between two datetimeoffsets 1.5 hour apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T15:15:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 2 hours"

Scenario: calculate the approximate difference between two datetimeoffsets 2.5 hour apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-15T16:15:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 2 hours"

Scenario: calculate the approximate difference between two datetimeoffsets 12 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-16T01:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 12 hours"

Scenario: calculate the approximate difference between two datetimeoffsets 18 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-16T07:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two datetimeoffsets 22 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-16T11:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two datetimeoffsets 24 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-16T13:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two datetimeoffsets 26 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-16T15:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about one day"

Scenario: calculate the approximate difference between two datetimeoffsets 72 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-18T13:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 3 days"

Scenario: calculate the approximate difference between two datetimeoffsets 144 hours apart
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2011-04-21T13:45:26.1234+01:00 |
	When I calculate the approximate difference between datetimeoffset 1 and datetimeoffset 2
	Then the approximate difference should be "about 6 days"

Scenario: create chronological key from a date time using a suffix
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological keys for the datetimeoffsets with the suffix 'AppendMe'
	Then the datetimeoffset keys should be
	| Value                          |
	| 000634384683261234000-AppendMe |
	| 000634706091271234000-AppendMe |
	| 000637230699261234000-AppendMe |
	| 000637230699261235000-AppendMe |

Scenario: create chronological key from a date time with a uniqueid
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological keys for the datetimeoffsets with a unique suffix
	Then the datetimeoffset keys should match the following with a guid
	| Value                  |
	| 000634384683261234000- |
	| 000634706091271234000- |
	| 000637230699261234000- |
	| 000637230699261235000- |

Scenario: create chronological key stem without a suffix from a date time 
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological key stems for the datetimeoffsets 
	Then the datetimeoffset keys should be
	| Value                 |
	| 000634384683261234000- |
	| 000634706091271234000- |
	| 000637230699261234000- |
	| 000637230699261235000- |

Scenario: create chronological key from a date time without a suffix
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create chronological keys for the datetimeoffsets
	Then the datetimeoffset keys should be
	| Value                 |
	| 000634384683261234000 |
	| 000634706091271234000 |
	| 000637230699261234000 |
	| 000637230699261235000 |

Scenario: create reverse chronological key from a date time using a suffix
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological keys for the datetimeoffsets with the suffix 'AppendMe'
	Then the datetimeoffset keys should be
	| Value                          |
	| 002520994292738765999-AppendMe |
	| 002520672884728765999-AppendMe |
	| 002518148276738765999-AppendMe |
	| 002518148276738764999-AppendMe |

Scenario: create reverse chronological key from a date time with a uniqueid
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological keys for the datetimeoffsets with a unique suffix
	Then the datetimeoffset keys should match the following with a guid
	| Value                  |
	| 002520994292738765999- |
	| 002520672884728765999- |
	| 002518148276738765999- |
	| 002518148276738764999- |

Scenario: create reverse chronological key stem without a suffix from a date time 
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological key stems for the datetimeoffsets 
	Then the datetimeoffset keys should be
	| Value                  |
	| 002520994292738765999- |
	| 002520672884728765999- |
	| 002518148276738765999- |
	| 002518148276738764999- |

Scenario: create reverse chronological key from a date time without a suffix
	Given the following datetimeoffsets
	| Value                          |
	| 2011-04-15T13:45:26.1234+01:00 |
	| 2012-04-21T13:45:27.1234+01:00 |
	| 2020-04-21T13:45:26.1234+01:00 |
	| 2020-04-21T13:45:26.1235+01:00 |
	When I create reverse chronological keys for the datetimeoffsets
	Then the datetimeoffset keys should be
	| Value                 |
	| 002520994292738765999 |
	| 002520672884728765999 |
	| 002518148276738765999 |
	| 002518148276738764999 |

Scenario: create a datetimeoffset from a unix timestamp
	When I convert the unix timestamp -412856257 to a datetimeoffset
	Then the result should be the datetimeoffset "1956-12-1T13:42:23.000Z"

Scenario: create a unix timestamp from a datetimeoffset
	When I convert the datetimeoffset "2013-11-7T04:12:59.000Z" to a unix timestamp
	Then the result should be the unix timestamp 1383797579

Scenario: create a range of days
	When I create a range of datetimeoffsets from "2013-11-7T23:59:59.000" to "2013-11-11T23:59:59.000" 
	Then the datetimeoffset range should be
	| Value                   |
	| 2013-11-07T00:00:00.000 |
	| 2013-11-08T00:00:00.000 |
	| 2013-11-09T00:00:00.000 |
	| 2013-11-10T00:00:00.000 |
	| 2013-11-11T00:00:00.000 |

Scenario: create a range consisting of a single day
	When I create a range of datetimeoffsets from "2013-11-7T23:59:59.000" to "2013-11-7T23:59:59.000" 
	Then the datetimeoffset range should be
	| Value                   |
	| 2013-11-07T00:00:00.000 |

Scenario: create a range heading back in time
	When I create a range of datetimeoffsets from "2013-11-11T23:59:59.000" to "2013-11-7T23:59:59.000" 
	Then the datetimeoffset range should be
	| Value                   |
	| 2013-11-11T00:00:00.000 |
	| 2013-11-10T00:00:00.000 |
	| 2013-11-09T00:00:00.000 |
	| 2013-11-08T00:00:00.000 |
	| 2013-11-07T00:00:00.000 |

Scenario Outline: determine if a date is after another date with a specific granularity
	When I ask if <date1> is after <date2> with <granularity>
	Then the answer should be <result>
Examples:
| date1                   | date2                   | granularity | result |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Second      | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Second      | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Second      | true   |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Second      | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Second      | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Minute      | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Minute      | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Minute      | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.000 | Minute      | true   |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Minute      | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Minute      | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Hour        | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Hour        | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Hour        | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.000 | Hour        | true   |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Hour        | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Hour        | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Day         | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Day         | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Day         | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Day         | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Day         | false  |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.000 | Day         | true   |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Day         | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Day         | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Week        | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Week        | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Week        | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Week        | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Week        | false  |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Week        | false  |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.000 | Week        | true   |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Week        | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Week        | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Month       | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Month       | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Month       | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Month       | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Month       | false  |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Month       | false  |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Month       | false  |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Month       | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Month       | true   |
| 2019-02-01T08:00:00.000 | 2019-01-01T08:00:00.001 | Month       | true   |
| 2019-02-01T08:00:00.000 | 2019-01-01T08:00:00.000 | Month       | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Year        | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Year        | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Year        | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Year        | false  |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Year        | true   |
| 2020-01-01T08:00:00.000 | 2019-01-01T08:00:00.001 | Year        | true   |
| 2020-01-01T08:00:00.000 | 2019-01-01T08:00:00.000 | Year        | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Year        | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Year        | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Decade      | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Decade      | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Decade      | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | false  |
| 2019-01-01T07:01:00.000 | 2018-01-01T08:00:00.001 | Decade      | false  |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Decade      | true   |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Decade      | true   |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Decade      | true   |
| 2029-01-01T08:00:00.000 | 2019-01-01T08:00:00.001 | Decade      | true   |
| 2029-01-01T08:00:00.000 | 2019-01-01T08:00:00.000 | Decade      | true   |
| 2019-01-01T08:00:01.251 | 2019-01-01T08:00:01.250 | Century     | false  |
| 2019-01-01T08:00:01.999 | 2019-01-01T08:00:01.001 | Century     | false  |
| 2019-01-01T08:00:02.000 | 2019-01-01T08:00:01.001 | Century     | false  |
| 2019-01-01T08:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-01-01T09:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-01-02T08:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-01-08T07:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-01-08T08:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-02-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2019-01-01T07:01:00.000 | 2018-01-01T08:00:00.001 | Century     | false  |
| 2020-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Century     | false  |
| 2029-01-01T07:01:00.000 | 2019-02-01T08:00:00.001 | Century     | false  |
| 2029-01-01T07:01:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2029-01-01T08:00:00.000 | 2019-01-01T08:00:00.001 | Century     | false  |
| 2029-01-01T08:00:00.000 | 2019-01-01T08:00:00.000 | Century     | false  |
| 2119-01-01T08:00:00.000 | 2019-01-01T08:00:00.000 | Century     | true   |
| 2119-01-01T08:00:00.000 | 2019-06-01T07:00:00.000 | Century     | true   |
| 2100-01-01T08:00:00.000 | 2099-12-31T23:59:59.999 | Century     | true   |

Scenario Outline: determine if a date is before another date with a specific granularity
	When I ask if <date1> is before <date2> with <granularity>
	Then the answer should be <result>
Examples:
| date1                   | date2                   | granularity | result |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Second      | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Second      | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Second      | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Second      | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Second      | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Minute      | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Minute      | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Minute      | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.000 | 2019-01-01T08:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Minute      | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Minute      | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Hour        | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Hour        | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Hour        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Hour        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.000 | 2019-01-01T09:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Hour        | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Hour        | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Day         | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Day         | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Day         | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Day         | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Day         | false  |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.000 | 2019-01-02T08:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Day         | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Day         | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Day         | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Week        | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Week        | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Week        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Week        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Week        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Week        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.000 | 2019-01-08T08:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Week        | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Week        | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Week        | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Month       | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Month       | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Month       | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Month       | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Month       | false  |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Month       | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Month       | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Month       | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Month       | true   |
| 2019-01-01T08:00:00.001 | 2019-02-01T08:00:00.000 | Month       | true   |
| 2019-01-01T08:00:00.000 | 2019-02-01T08:00:00.000 | Month       | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Year        | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Year        | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Year        | false  |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Year        | true   |
| 2019-01-01T08:00:00.001 | 2020-01-01T08:00:00.000 | Year        | true   |
| 2019-01-01T08:00:00.000 | 2020-01-01T08:00:00.000 | Year        | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Year        | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Year        | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Decade      | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Decade      | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Decade      | false  |
| 2018-01-01T08:00:00.001 | 2019-01-01T07:01:00.000 | Decade      | false  |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Decade      | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Decade      | true   |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Decade      | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Decade      | true   |
| 2019-01-01T08:00:00.001 | 2029-01-01T08:00:00.000 | Decade      | true   |
| 2019-01-01T08:00:00.000 | 2029-01-01T08:00:00.000 | Decade      | true   |
| 2019-01-01T08:00:01.250 | 2019-01-01T08:00:01.251 | Century     | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:01.999 | Century     | false  |
| 2019-01-01T08:00:01.001 | 2019-01-01T08:00:02.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T08:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-01-01T09:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-01-02T08:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T07:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-01-08T08:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2019-02-01T07:01:00.000 | Century     | false  |
| 2018-01-01T08:00:00.001 | 2019-01-01T07:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2020-01-01T07:01:00.000 | Century     | false  |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Century     | false  |
| 2019-02-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2029-01-01T07:01:00.000 | Century     | false  |
| 2019-01-01T08:00:00.001 | 2029-01-01T08:00:00.000 | Century     | false  |
| 2019-01-01T08:00:00.000 | 2029-01-01T08:00:00.000 | Century     | false  |
| 2019-01-01T08:00:00.000 | 2119-01-01T08:00:00.000 | Century     | true   |
| 2019-06-01T07:00:00.000 | 2119-01-01T08:00:00.000 | Century     | true   |
| 2099-12-31T23:59:59.999 | 2100-01-01T08:00:00.000 | Century     | true   |