﻿Feature: JsonEquals
	Validate the Json Equals operator

# JsonString
Scenario Outline: Equals for json element backed value as a string
	Given the JsonElement backed JsonString <jsonValue>
	When I compare it to the string <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| "Hello"   | "Hello"   | true   |
		| "Hello"   | "Goodbye" | false  |
		| null      | null      | true   |
		| null      | "Goodbye" | false  |

Scenario Outline: Equals for dotnet backed value as a string
	Given the dotnet backed JsonString <jsonValue>
	When I compare it to the string <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| "Hello"   | "Hello"   | true   |
		| "Hello"   | "Goodbye" | false  |

Scenario Outline: Equals for string json element backed value as an IJsonValue
	Given the JsonElement backed JsonString <jsonValue>
	When I compare the string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "P3Y6M4DT12H30M5S"             | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "www.example.com"              | false  |
		| "Hello"   | "http://foo.bar/?baz=qux#quux" | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |
		| "Hello"   | "192.168.0.1"                  | false  |
		| "Hello"   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for string dotnet backed value as an IJsonValue
	Given the dotnet backed JsonString <jsonValue>
	When I compare the string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "P3Y6M4DT12H30M5S"             | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "www.example.com"              | false  |
		| "Hello"   | "http://foo.bar/?baz=qux#quux" | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |
		| "Hello"   | "192.168.0.1"                  | false  |
		| "Hello"   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for string json element backed value as an object
	Given the JsonElement backed JsonString <jsonValue>
	When I compare the string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "P3Y6M4DT12H30M5S"             | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "www.example.com"              | false  |
		| "Hello"   | "http://foo.bar/?baz=qux#quux" | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |
		| "Hello"   | "192.168.0.1"                  | false  |
		| "Hello"   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "Hello"   | <new object()>                 | false  |
		| "Hello"   | null                           | false  |

Scenario Outline: Equals for string dotnet backed value as an object
	Given the dotnet backed JsonString <jsonValue>
	When I compare the string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "P3Y6M4DT12H30M5S"             | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "www.example.com"              | false  |
		| "Hello"   | "http://foo.bar/?baz=qux#quux" | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |
		| "Hello"   | "192.168.0.1"                  | false  |
		| "Hello"   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "Hello"   | <new object()>                 | false  |
		| "Hello"   | null                           | false  |
		| "Hello"   | <null>                         | false  |
		| "Hello"   | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonBoolean
Scenario Outline: Equals for json element backed value as a boolean
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare it to the boolean <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value | result |
		| true      | true  | true   |
		| false     | false | true   |
		| true      | false | false  |
		| false     | true  | false  |
		| true      | null  | false  |
		| null      | true  | false  |
		| null      | null  | true   |

Scenario Outline: Equals for dotnet backed value as a boolean
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare it to the boolean <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value | result |
		| false     | true  | false  |
		| false     | false | true   |
		| true      | true  | true   |
		| true      | false | false  |

Scenario Outline: Equals for boolean json element backed value as an IJsonValue
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare the boolean to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "P3Y6M4DT12H30M5S"             | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "www.example.com"              | false  |
		| false     | "http://foo.bar/?baz=qux#quux" | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |
		| false     | "192.168.0.1"                  | false  |
		| false     | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for boolean dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare the boolean to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "P3Y6M4DT12H30M5S"             | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "www.example.com"              | false  |
		| false     | "http://foo.bar/?baz=qux#quux" | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |
		| false     | "192.168.0.1"                  | false  |
		| false     | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for boolean json element backed value as an object
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare the boolean to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "P3Y6M4DT12H30M5S"             | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "www.example.com"              | false  |
		| false     | "http://foo.bar/?baz=qux#quux" | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |
		| false     | "192.168.0.1"                  | false  |
		| false     | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| false     | <new object()>                 | false  |
		| false     | null                           | false  |

Scenario Outline: Equals for boolean dotnet backed value as an object
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare the boolean to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "P3Y6M4DT12H30M5S"             | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "www.example.com"              | false  |
		| false     | "http://foo.bar/?baz=qux#quux" | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |
		| false     | "192.168.0.1"                  | false  |
		| false     | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| false     | <new object()>                 | false  |
		| false     | null                           | false  |
		| false     | <null>                         | false  |
		| false     | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonArray
Scenario Outline: Equals for json element backed value as an array
	Given the JsonElement backed JsonArray <jsonValue>
	When I compare it to the array <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| [1,"2",3] | [1,"2",3] | true   |
		| [1,"2",3] | [3,"2",1] | false  |
		| [1,"2",3] | [1,2,3]   | false  |
		| []        | []        | true   |
		| []        | [3,2,1]   | false  |
		| null      | null      | true   |
		| null      | [1,2,3]   | false  |

Scenario Outline: Equals for dotnet backed value as an array
	Given the dotnet backed JsonArray <jsonValue>
	When I compare it to the array <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| [1,"2",3] | [1,"2",3] | true   |
		| [1,"2",3] | [3,"2",1] | false  |
		| [1,"2",3] | [1,2,3]   | false  |
		| []        | []        | true   |
		| []        | [3,2,1]   | false  |

Scenario Outline: Equals for array json element backed value as an IJsonValue
	Given the JsonElement backed JsonArray <jsonValue>
	When I compare the array to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "P3Y6M4DT12H30M5S"             | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "www.example.com"              | false  |
		| [1,2,3]   | "http://foo.bar/?baz=qux#quux" | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |
		| [1,2,3]   | "192.168.0.1"                  | false  |
		| [1,2,3]   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for array dotnet backed value as an IJsonValue
	Given the dotnet backed JsonArray <jsonValue>
	When I compare the array to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "P3Y6M4DT12H30M5S"             | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "www.example.com"              | false  |
		| [1,2,3]   | "http://foo.bar/?baz=qux#quux" | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |
		| [1,2,3]   | "192.168.0.1"                  | false  |
		| [1,2,3]   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for array json element backed value as an object
	Given the JsonElement backed JsonArray <jsonValue>
	When I compare the array to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "P3Y6M4DT12H30M5S"             | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "www.example.com"              | false  |
		| [1,2,3]   | "http://foo.bar/?baz=qux#quux" | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |
		| [1,2,3]   | "192.168.0.1"                  | false  |
		| [1,2,3]   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for array dotnet backed value as an object
	Given the dotnet backed JsonArray <jsonValue>
	When I compare the array to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "P3Y6M4DT12H30M5S"             | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "www.example.com"              | false  |
		| [1,2,3]   | "http://foo.bar/?baz=qux#quux" | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |
		| [1,2,3]   | "192.168.0.1"                  | false  |
		| [1,2,3]   | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| [1,2,3]   | <new object()>                 | false  |
		| [1,2,3]   | null                           | false  |
		| [1,2,3]   | <null>                         | false  |
		| [1,2,3]   | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonBase64Content
Scenario Outline: Equals for json element backed value as a base64content
	Given the JsonElement backed JsonBase64Content <jsonValue>
	When I compare it to the base64content <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| null                           | null                           | true   |
		| null                           | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |

Scenario Outline: Equals for dotnet backed value as a base64content
	Given the dotnet backed JsonBase64Content <jsonValue>
	When I compare it to the base64content <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |

Scenario Outline: Equals for base64content json element backed value as an IJsonValue
	Given the JsonElement backed JsonBase64Content <jsonValue>
	When I compare the base64content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for base64content dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBase64Content <jsonValue>
	When I compare the base64content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for base64content json element backed value as an object
	Given the JsonElement backed JsonBase64Content <jsonValue>
	When I compare the base64content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |

Scenario Outline: Equals for base64content dotnet backed value as an object
	Given the dotnet backed JsonBase64Content <jsonValue>
	When I compare the base64content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <null>                         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonBase64String
Scenario Outline: Equals for json element backed value as a base64string
	Given the JsonElement backed JsonBase64String <jsonValue>
	When I compare it to the base64string <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| null                           | null                           | true   |
		| null                           | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |

Scenario Outline: Equals for dotnet backed value as a base64string
	Given the dotnet backed JsonBase64String <jsonValue>
	When I compare it to the base64string <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |

Scenario Outline: Equals for base64string json element backed value as an IJsonValue
	Given the JsonElement backed JsonBase64String <jsonValue>
	When I compare the base64string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for base64string dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBase64String <jsonValue>
	When I compare the base64string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for base64string json element backed value as an object
	Given the JsonElement backed JsonBase64String <jsonValue>
	When I compare the base64string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |

Scenario Outline: Equals for base64string dotnet backed value as an object
	Given the dotnet backed JsonBase64String <jsonValue>
	When I compare the base64string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "P3Y6M4DT12H30M5S"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "www.example.com"              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "http://foo.bar/?baz=qux#quux" | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "192.168.0.1"                  | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <null>                         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonContent
Scenario Outline: Equals for json element backed value as a content
	Given the JsonElement backed JsonContent <jsonValue>
	When I compare it to the content <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                  | result |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }" | true   |
		| "{ \"first\": \"1\" }" | "Goodbye"              | false  |
		| null                   | null                   | true   |
		| null                   | "{ \"first\": \"1\" }" | false  |

Scenario Outline: Equals for dotnet backed value as a content
	Given the dotnet backed JsonContent <jsonValue>
	When I compare it to the content <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                  | result |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }" | true   |
		| "{ \"first\": \"1\" }" | "Goodbye"              | false  |

Scenario Outline: Equals for content json element backed value as an IJsonValue
	Given the JsonElement backed JsonContent <jsonValue>
	When I compare the content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "P3Y6M4DT12H30M5S"             | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "www.example.com"              | false  |
		| "{ \"first\": \"1\" }" | "http://foo.bar/?baz=qux#quux" | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |
		| "{ \"first\": \"1\" }" | "192.168.0.1"                  | false  |
		| "{ \"first\": \"1\" }" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for content dotnet backed value as an IJsonValue
	Given the dotnet backed JsonContent <jsonValue>
	When I compare the content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "P3Y6M4DT12H30M5S"             | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "www.example.com"              | false  |
		| "{ \"first\": \"1\" }" | "http://foo.bar/?baz=qux#quux" | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |
		| "{ \"first\": \"1\" }" | "192.168.0.1"                  | false  |
		| "{ \"first\": \"1\" }" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for content json element backed value as an object
	Given the JsonElement backed JsonContent <jsonValue>
	When I compare the content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "P3Y6M4DT12H30M5S"             | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "www.example.com"              | false  |
		| "{ \"first\": \"1\" }" | "http://foo.bar/?baz=qux#quux" | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |
		| "{ \"first\": \"1\" }" | "192.168.0.1"                  | false  |
		| "{ \"first\": \"1\" }" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "{ \"first\": \"1\" }" | <new object()>                 | false  |
		| "{ \"first\": \"1\" }" | null                           | false  |

Scenario Outline: Equals for content dotnet backed value as an object
	Given the dotnet backed JsonContent <jsonValue>
	When I compare the content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "P3Y6M4DT12H30M5S"             | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "www.example.com"              | false  |
		| "{ \"first\": \"1\" }" | "http://foo.bar/?baz=qux#quux" | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |
		| "{ \"first\": \"1\" }" | "192.168.0.1"                  | false  |
		| "{ \"first\": \"1\" }" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "{ \"first\": \"1\" }" | <new object()>                 | false  |
		| "{ \"first\": \"1\" }" | null                           | false  |
		| "{ \"first\": \"1\" }" | <null>                         | false  |
		| "{ \"first\": \"1\" }" | <undefined>                    | false  |
		| null                   | null                           | true   |
		| null                   | <null>                         | true   |
		| null                   | <undefined>                    | false  |

# JsonDate
Scenario Outline: Equals for json element backed value as a date
	Given the JsonElement backed JsonDate <jsonValue>
	When I compare it to the date <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value        | result |
		| "2018-11-13" | "2018-11-13" | true   |
		| "Garbage"    | "2018-11-13" | false  |
		| "2018-11-13" | "Goodbye"    | false  |
		| null         | null         | true   |
		| null         | "2018-11-13" | false  |

Scenario Outline: Equals for dotnet backed value as a date
	Given the dotnet backed JsonDate <jsonValue>
	When I compare it to the date <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value        | result |
		| "Garbage"    | "2018-11-13" | false  |
		| "2018-11-13" | "2018-11-13" | true   |
		| "2018-11-13" | "Goodbye"    | false  |

Scenario Outline: Equals for date json element backed value as an IJsonValue
	Given the JsonElement backed JsonDate <jsonValue>
	When I compare the date to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "Garbage"    | "2018-11-13"                   | false  |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "www.example.com"              | false  |
		| "2018-11-13" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13" | "192.168.0.1"                  | false  |
		| "2018-11-13" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for date dotnet backed value as an IJsonValue
	Given the dotnet backed JsonDate <jsonValue>
	When I compare the date to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "Garbage"    | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "www.example.com"              | false  |
		| "2018-11-13" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13" | "192.168.0.1"                  | false  |
		| "2018-11-13" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for date json element backed value as an object
	Given the JsonElement backed JsonDate <jsonValue>
	When I compare the date to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "www.example.com"              | false  |
		| "2018-11-13" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13" | "192.168.0.1"                  | false  |
		| "2018-11-13" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "2018-11-13" | <new object()>                 | false  |
		| "2018-11-13" | null                           | false  |

Scenario Outline: Equals for date dotnet backed value as an object
	Given the dotnet backed JsonDate <jsonValue>
	When I compare the date to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "www.example.com"              | false  |
		| "2018-11-13" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13" | "192.168.0.1"                  | false  |
		| "2018-11-13" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "2018-11-13" | <new object()>                 | false  |
		| "2018-11-13" | null                           | false  |
		| "2018-11-13" | <null>                         | false  |
		| "2018-11-13" | <undefined>                    | false  |
		| null         | null                           | true   |
		| null         | <null>                         | true   |
		| null         | <undefined>                    | false  |

# JsonDateTime
Scenario Outline: Equals for json element backed value as a dateTime
	Given the JsonElement backed JsonDateTime <jsonValue>
	When I compare it to the dateTime <value>
	Then the result should be <result>

	Examples:
		| jsonValue                   | value                       | result |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13T20:20:39+00:00" | true   |
		| "Garbage"                   | "2018-11-13T20:20:39+00:00" | false  |
		| "2018-11-13T20:20:39+00:00" | "Goodbye"                   | false  |
		| null                        | null                        | true   |
		| null                        | "2018-11-13T20:20:39+00:00" | false  |

Scenario Outline: Equals for dotnet backed value as a dateTime
	Given the dotnet backed JsonDateTime <jsonValue>
	When I compare it to the dateTime <value>
	Then the result should be <result>

	Examples:
		| jsonValue                   | value                       | result |
		| "Garbage"                   | "2018-11-13T20:20:39+00:00" | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13T20:20:39+00:00" | true   |
		| "2018-11-13T20:20:39+00:00" | "Goodbye"                   | false  |

Scenario Outline: Equals for dateTime json element backed value as an IJsonValue
	Given the JsonElement backed JsonDateTime <jsonValue>
	When I compare the dateTime to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                   | value                          | result |
		| "2018-11-13T20:20:39+00:00" | "Hello"                        | false  |
		| "2018-11-13T20:20:39+00:00" | "Goodbye"                      | false  |
		| "2018-11-13T20:20:39+00:00" | 1                              | false  |
		| "2018-11-13T20:20:39+00:00" | 1.1                            | false  |
		| "2018-11-13T20:20:39+00:00" | [1,2,3]                        | false  |
		| "2018-11-13T20:20:39+00:00" | { "first": "1" }               | false  |
		| "2018-11-13T20:20:39+00:00" | true                           | false  |
		| "2018-11-13T20:20:39+00:00" | false                          | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13T20:20:39+00:00"    | true   |
		| "2018-11-13T20:20:39+00:00" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13"                   | false  |
		| "Garbage"                   | "2018-11-13"                   | false  |
		| "2018-11-13T20:20:39+00:00" | "hello@endjin.com"             | false  |
		| "2018-11-13T20:20:39+00:00" | "www.example.com"              | false  |
		| "2018-11-13T20:20:39+00:00" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13T20:20:39+00:00" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13T20:20:39+00:00" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13T20:20:39+00:00" | "192.168.0.1"                  | false  |
		| "2018-11-13T20:20:39+00:00" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for dateTime dotnet backed value as an IJsonValue
	Given the dotnet backed JsonDateTime <jsonValue>
	When I compare the dateTime to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                   | value                          | result |
		| "2018-11-13T20:20:39+00:00" | "Hello"                        | false  |
		| "2018-11-13T20:20:39+00:00" | "Goodbye"                      | false  |
		| "2018-11-13T20:20:39+00:00" | 1                              | false  |
		| "2018-11-13T20:20:39+00:00" | 1.1                            | false  |
		| "2018-11-13T20:20:39+00:00" | [1,2,3]                        | false  |
		| "2018-11-13T20:20:39+00:00" | { "first": "1" }               | false  |
		| "2018-11-13T20:20:39+00:00" | true                           | false  |
		| "2018-11-13T20:20:39+00:00" | false                          | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13T20:20:39+00:00"    | true   |
		| "2018-11-13T20:20:39+00:00" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13"                   | false  |
		| "Garbage"                   | "2018-11-13"                   | false  |
		| "2018-11-13T20:20:39+00:00" | "hello@endjin.com"             | false  |
		| "2018-11-13T20:20:39+00:00" | "www.example.com"              | false  |
		| "2018-11-13T20:20:39+00:00" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13T20:20:39+00:00" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13T20:20:39+00:00" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13T20:20:39+00:00" | "192.168.0.1"                  | false  |
		| "2018-11-13T20:20:39+00:00" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for dateTime json element backed value as an object
	Given the JsonElement backed JsonDateTime <jsonValue>
	When I compare the dateTime to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                   | value                          | result |
		| "2018-11-13T20:20:39+00:00" | "Hello"                        | false  |
		| "2018-11-13T20:20:39+00:00" | "Goodbye"                      | false  |
		| "2018-11-13T20:20:39+00:00" | 1                              | false  |
		| "2018-11-13T20:20:39+00:00" | 1.1                            | false  |
		| "2018-11-13T20:20:39+00:00" | [1,2,3]                        | false  |
		| "2018-11-13T20:20:39+00:00" | { "first": "1" }               | false  |
		| "2018-11-13T20:20:39+00:00" | true                           | false  |
		| "2018-11-13T20:20:39+00:00" | false                          | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13T20:20:39+00:00"    | true   |
		| "2018-11-13T20:20:39+00:00" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13"                   | false  |
		| "2018-11-13T20:20:39+00:00" | "hello@endjin.com"             | false  |
		| "2018-11-13T20:20:39+00:00" | "www.example.com"              | false  |
		| "2018-11-13T20:20:39+00:00" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13T20:20:39+00:00" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13T20:20:39+00:00" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13T20:20:39+00:00" | "192.168.0.1"                  | false  |
		| "2018-11-13T20:20:39+00:00" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "2018-11-13T20:20:39+00:00" | <new object()>                 | false  |
		| "2018-11-13T20:20:39+00:00" | null                           | false  |

Scenario Outline: Equals for dateTime dotnet backed value as an object
	Given the dotnet backed JsonDateTime <jsonValue>
	When I compare the dateTime to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                   | value                          | result |
		| "2018-11-13T20:20:39+00:00" | "Hello"                        | false  |
		| "2018-11-13T20:20:39+00:00" | "Goodbye"                      | false  |
		| "2018-11-13T20:20:39+00:00" | 1                              | false  |
		| "2018-11-13T20:20:39+00:00" | 1.1                            | false  |
		| "2018-11-13T20:20:39+00:00" | [1,2,3]                        | false  |
		| "2018-11-13T20:20:39+00:00" | { "first": "1" }               | false  |
		| "2018-11-13T20:20:39+00:00" | true                           | false  |
		| "2018-11-13T20:20:39+00:00" | false                          | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13T20:20:39+00:00"    | true   |
		| "2018-11-13T20:20:39+00:00" | "P3Y6M4DT12H30M5S"             | false  |
		| "2018-11-13T20:20:39+00:00" | "2018-11-13"                   | false  |
		| "2018-11-13T20:20:39+00:00" | "hello@endjin.com"             | false  |
		| "2018-11-13T20:20:39+00:00" | "www.example.com"              | false  |
		| "2018-11-13T20:20:39+00:00" | "http://foo.bar/?baz=qux#quux" | false  |
		| "2018-11-13T20:20:39+00:00" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13T20:20:39+00:00" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13T20:20:39+00:00" | "192.168.0.1"                  | false  |
		| "2018-11-13T20:20:39+00:00" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "2018-11-13T20:20:39+00:00" | <new object()>                 | false  |
		| "2018-11-13T20:20:39+00:00" | null                           | false  |
		| "2018-11-13T20:20:39+00:00" | <null>                         | false  |
		| "2018-11-13T20:20:39+00:00" | <undefined>                    | false  |
		| null                        | null                           | true   |
		| null                        | <null>                         | true   |
		| null                        | <undefined>                    | false  |

# JsonDuration
Scenario Outline: Equals for json element backed value as a duration
	Given the JsonElement backed JsonDuration <jsonValue>
	When I compare it to the duration <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value              | result |
		| "P3Y6M4DT12H30M5S" | "P3Y6M4DT12H30M5S" | true   |
		| "Garbage"          | "P3Y6M4DT12H30M5S" | false  |
		| "P3Y6M4DT12H30M5S" | "Goodbye"          | false  |
		| null               | null               | true   |
		| null               | "P3Y6M4DT12H30M5S" | false  |

Scenario Outline: Equals for dotnet backed value as a duration
	Given the dotnet backed JsonDuration <jsonValue>
	When I compare it to the duration <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value              | result |
		| "Garbage"          | "P3Y6M4DT12H30M5S" | false  |
		| "P3Y6M4DT12H30M5S" | "P3Y6M4DT12H30M5S" | true   |
		| "P3Y6M4DT12H30M5S" | "Goodbye"          | false  |

Scenario Outline: Equals for duration json element backed value as an IJsonValue
	Given the JsonElement backed JsonDuration <jsonValue>
	When I compare the duration to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "P3Y6M4DT12H30M5S" | "Hello"                        | false  |
		| "P3Y6M4DT12H30M5S" | "Goodbye"                      | false  |
		| "P3Y6M4DT12H30M5S" | 1                              | false  |
		| "P3Y6M4DT12H30M5S" | 1.1                            | false  |
		| "P3Y6M4DT12H30M5S" | [1,2,3]                        | false  |
		| "P3Y6M4DT12H30M5S" | { "first": "1" }               | false  |
		| "P3Y6M4DT12H30M5S" | true                           | false  |
		| "P3Y6M4DT12H30M5S" | false                          | false  |
		| "P3Y6M4DT12H30M5S" | "2018-11-13T20:20:39+00:00"    | false  |
		| "P3Y6M4DT12H30M5S" | "2018-11-13"                   | false  |
		| "P3Y6M4DT12H30M5S" | "P3Y6M4DT12H30M5S"             | true   |
		| "Garbage"          | "2018-11-13"                   | false  |
		| "P3Y6M4DT12H30M5S" | "hello@endjin.com"             | false  |
		| "P3Y6M4DT12H30M5S" | "www.example.com"              | false  |
		| "P3Y6M4DT12H30M5S" | "http://foo.bar/?baz=qux#quux" | false  |
		| "P3Y6M4DT12H30M5S" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "P3Y6M4DT12H30M5S" | "{ \"first\": \"1\" }"         | false  |
		| "P3Y6M4DT12H30M5S" | "192.168.0.1"                  | false  |
		| "P3Y6M4DT12H30M5S" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for duration dotnet backed value as an IJsonValue
	Given the dotnet backed JsonDuration <jsonValue>
	When I compare the duration to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "P3Y6M4DT12H30M5S" | "Hello"                        | false  |
		| "P3Y6M4DT12H30M5S" | "Goodbye"                      | false  |
		| "P3Y6M4DT12H30M5S" | 1                              | false  |
		| "P3Y6M4DT12H30M5S" | 1.1                            | false  |
		| "P3Y6M4DT12H30M5S" | [1,2,3]                        | false  |
		| "P3Y6M4DT12H30M5S" | { "first": "1" }               | false  |
		| "P3Y6M4DT12H30M5S" | true                           | false  |
		| "P3Y6M4DT12H30M5S" | false                          | false  |
		| "P3Y6M4DT12H30M5S" | "2018-11-13T20:20:39+00:00"    | false  |
		| "P3Y6M4DT12H30M5S" | "P3Y6M4DT12H30M5S"             | true   |
		| "P3Y6M4DT12H30M5S" | "2018-11-13"                   | false  |
		| "Garbage"          | "P3Y6M4DT12H30M5S"             | false  |
		| "P3Y6M4DT12H30M5S" | "hello@endjin.com"             | false  |
		| "P3Y6M4DT12H30M5S" | "www.example.com"              | false  |
		| "P3Y6M4DT12H30M5S" | "http://foo.bar/?baz=qux#quux" | false  |
		| "P3Y6M4DT12H30M5S" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "P3Y6M4DT12H30M5S" | "{ \"first\": \"1\" }"         | false  |
		| "P3Y6M4DT12H30M5S" | "192.168.0.1"                  | false  |
		| "P3Y6M4DT12H30M5S" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for duration json element backed value as an object
	Given the JsonElement backed JsonDuration <jsonValue>
	When I compare the duration to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "P3Y6M4DT12H30M5S" | "Hello"                        | false  |
		| "P3Y6M4DT12H30M5S" | "Goodbye"                      | false  |
		| "P3Y6M4DT12H30M5S" | 1                              | false  |
		| "P3Y6M4DT12H30M5S" | 1.1                            | false  |
		| "P3Y6M4DT12H30M5S" | [1,2,3]                        | false  |
		| "P3Y6M4DT12H30M5S" | { "first": "1" }               | false  |
		| "P3Y6M4DT12H30M5S" | true                           | false  |
		| "P3Y6M4DT12H30M5S" | false                          | false  |
		| "P3Y6M4DT12H30M5S" | "2018-11-13T20:20:39+00:00"    | false  |
		| "P3Y6M4DT12H30M5S" | "P3Y6M4DT12H30M5S"             | true   |
		| "P3Y6M4DT12H30M5S" | "2018-11-13"                   | false  |
		| "P3Y6M4DT12H30M5S" | "hello@endjin.com"             | false  |
		| "P3Y6M4DT12H30M5S" | "www.example.com"              | false  |
		| "P3Y6M4DT12H30M5S" | "http://foo.bar/?baz=qux#quux" | false  |
		| "P3Y6M4DT12H30M5S" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "P3Y6M4DT12H30M5S" | "{ \"first\": \"1\" }"         | false  |
		| "P3Y6M4DT12H30M5S" | "192.168.0.1"                  | false  |
		| "P3Y6M4DT12H30M5S" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "P3Y6M4DT12H30M5S" | <new object()>                 | false  |
		| "P3Y6M4DT12H30M5S" | null                           | false  |

Scenario Outline: Equals for duration dotnet backed value as an object
	Given the dotnet backed JsonDuration <jsonValue>
	When I compare the duration to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "P3Y6M4DT12H30M5S" | "Hello"                        | false  |
		| "P3Y6M4DT12H30M5S" | "Goodbye"                      | false  |
		| "P3Y6M4DT12H30M5S" | 1                              | false  |
		| "P3Y6M4DT12H30M5S" | 1.1                            | false  |
		| "P3Y6M4DT12H30M5S" | [1,2,3]                        | false  |
		| "P3Y6M4DT12H30M5S" | { "first": "1" }               | false  |
		| "P3Y6M4DT12H30M5S" | true                           | false  |
		| "P3Y6M4DT12H30M5S" | false                          | false  |
		| "P3Y6M4DT12H30M5S" | "2018-11-13T20:20:39+00:00"    | false  |
		| "P3Y6M4DT12H30M5S" | "2018-11-13"                   | false  |
		| "P3Y6M4DT12H30M5S" | "P3Y6M4DT12H30M5S"             | true   |
		| "P3Y6M4DT12H30M5S" | "hello@endjin.com"             | false  |
		| "P3Y6M4DT12H30M5S" | "www.example.com"              | false  |
		| "P3Y6M4DT12H30M5S" | "http://foo.bar/?baz=qux#quux" | false  |
		| "P3Y6M4DT12H30M5S" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "P3Y6M4DT12H30M5S" | "{ \"first\": \"1\" }"         | false  |
		| "P3Y6M4DT12H30M5S" | "192.168.0.1"                  | false  |
		| "P3Y6M4DT12H30M5S" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "P3Y6M4DT12H30M5S" | <new object()>                 | false  |
		| "P3Y6M4DT12H30M5S" | null                           | false  |
		| "P3Y6M4DT12H30M5S" | <null>                         | false  |
		| "P3Y6M4DT12H30M5S" | <undefined>                    | false  |
		| null               | null                           | true   |
		| null               | <null>                         | true   |
		| null               | <undefined>                    | false  |

# JsonEmail
Scenario Outline: Equals for json element backed value as a email
	Given the JsonElement backed JsonEmail <jsonValue>
	When I compare it to the email <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value              | result |
		| "hello@endjin.com" | "hello@endjin.com" | true   |
		| "Garbage"          | "hello@endjin.com" | false  |
		| "hello@endjin.com" | "Goodbye"          | false  |
		| null               | null               | true   |
		| null               | "hello@endjin.com" | false  |

Scenario Outline: Equals for dotnet backed value as a email
	Given the dotnet backed JsonEmail <jsonValue>
	When I compare it to the email <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value              | result |
		| "Garbage"          | "hello@endjin.com" | false  |
		| "hello@endjin.com" | "hello@endjin.com" | true   |
		| "hello@endjin.com" | "Goodbye"          | false  |

Scenario Outline: Equals for email json element backed value as an IJsonValue
	Given the JsonElement backed JsonEmail <jsonValue>
	When I compare the email to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "Garbage"          | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for email dotnet backed value as an IJsonValue
	Given the dotnet backed JsonEmail <jsonValue>
	When I compare the email to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "Garbage"          | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for email json element backed value as an object
	Given the JsonElement backed JsonEmail <jsonValue>
	When I compare the email to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "hello@endjin.com" | <new object()>                 | false  |
		| "hello@endjin.com" | null                           | false  |

Scenario Outline: Equals for email dotnet backed value as an object
	Given the dotnet backed JsonEmail <jsonValue>
	When I compare the email to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "hello@endjin.com" | <new object()>                 | false  |
		| "hello@endjin.com" | null                           | false  |
		| "hello@endjin.com" | <null>                         | false  |
		| "hello@endjin.com" | <undefined>                    | false  |
		| null               | null                           | true   |
		| null               | <null>                         | true   |
		| null               | <undefined>                    | false  |

# JsonIdnEmail
Scenario Outline: Equals for json element backed value as a idnEmail
	Given the JsonElement backed JsonIdnEmail <jsonValue>
	When I compare it to the idnEmail <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value              | result |
		| "hello@endjin.com" | "hello@endjin.com" | true   |
		| "Garbage"          | "hello@endjin.com" | false  |
		| "hello@endjin.com" | "Goodbye"          | false  |
		| null               | null               | true   |
		| null               | "hello@endjin.com" | false  |

Scenario Outline: Equals for dotnet backed value as a idnEmail
	Given the dotnet backed JsonIdnEmail <jsonValue>
	When I compare it to the idnEmail <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value              | result |
		| "Garbage"          | "hello@endjin.com" | false  |
		| "hello@endjin.com" | "hello@endjin.com" | true   |
		| "hello@endjin.com" | "Goodbye"          | false  |

Scenario Outline: Equals for idnEmail json element backed value as an IJsonValue
	Given the JsonElement backed JsonIdnEmail <jsonValue>
	When I compare the idnEmail to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "Garbage"          | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for idnEmail dotnet backed value as an IJsonValue
	Given the dotnet backed JsonIdnEmail <jsonValue>
	When I compare the idnEmail to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "Garbage"          | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for idnEmail json element backed value as an object
	Given the JsonElement backed JsonIdnEmail <jsonValue>
	When I compare the idnEmail to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "hello@endjin.com" | <new object()>                 | false  |
		| "hello@endjin.com" | null                           | false  |

Scenario Outline: Equals for idnEmail dotnet backed value as an object
	Given the dotnet backed JsonIdnEmail <jsonValue>
	When I compare the idnEmail to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue          | value                          | result |
		| "hello@endjin.com" | "Hello"                        | false  |
		| "hello@endjin.com" | "Goodbye"                      | false  |
		| "hello@endjin.com" | 1                              | false  |
		| "hello@endjin.com" | 1.1                            | false  |
		| "hello@endjin.com" | [1,2,3]                        | false  |
		| "hello@endjin.com" | { "first": "1" }               | false  |
		| "hello@endjin.com" | true                           | false  |
		| "hello@endjin.com" | false                          | false  |
		| "hello@endjin.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "hello@endjin.com" | "2018-11-13"                   | false  |
		| "hello@endjin.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "hello@endjin.com" | "hello@endjin.com"             | true   |
		| "hello@endjin.com" | "www.example.com"              | false  |
		| "hello@endjin.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "hello@endjin.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "hello@endjin.com" | "{ \"first\": \"1\" }"         | false  |
		| "hello@endjin.com" | "192.168.0.1"                  | false  |
		| "hello@endjin.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "hello@endjin.com" | <new object()>                 | false  |
		| "hello@endjin.com" | null                           | false  |
		| "hello@endjin.com" | <null>                         | false  |
		| "hello@endjin.com" | <undefined>                    | false  |
		| null               | null                           | true   |
		| null               | <null>                         | true   |
		| null               | <undefined>                    | false  |

# JsonHostname
Scenario Outline: Equals for json element backed value as a hostname
	Given the JsonElement backed JsonHostname <jsonValue>
	When I compare it to the hostname <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value             | result |
		| "www.example.com" | "www.example.com" | true   |
		| "Garbage"         | "www.example.com" | false  |
		| "www.example.com" | "Goodbye"         | false  |
		| null              | null              | true   |
		| null              | "www.example.com" | false  |

Scenario Outline: Equals for dotnet backed value as a hostname
	Given the dotnet backed JsonHostname <jsonValue>
	When I compare it to the hostname <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value             | result |
		| "Garbage"         | "www.example.com" | false  |
		| "www.example.com" | "www.example.com" | true   |
		| "www.example.com" | "Goodbye"         | false  |

Scenario Outline: Equals for hostname json element backed value as an IJsonValue
	Given the JsonElement backed JsonHostname <jsonValue>
	When I compare the hostname to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "Garbage"         | "2018-11-13"                   | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for hostname dotnet backed value as an IJsonValue
	Given the dotnet backed JsonHostname <jsonValue>
	When I compare the hostname to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "Garbage"         | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for hostname json element backed value as an object
	Given the JsonElement backed JsonHostname <jsonValue>
	When I compare the hostname to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "www.example.com" | <new object()>                 | false  |
		| "www.example.com" | null                           | false  |

Scenario Outline: Equals for hostname dotnet backed value as an object
	Given the dotnet backed JsonHostname <jsonValue>
	When I compare the hostname to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "www.example.com" | <new object()>                 | false  |
		| "www.example.com" | null                           | false  |
		| "www.example.com" | <null>                         | false  |
		| "www.example.com" | <undefined>                    | false  |
		| null              | null                           | true   |
		| null              | <null>                         | true   |
		| null              | <undefined>                    | false  |

# JsonIdnHostname
Scenario Outline: Equals for json element backed value as a idnHostname
	Given the JsonElement backed JsonIdnHostname <jsonValue>
	When I compare it to the idnHostname <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value             | result |
		| "www.example.com" | "www.example.com" | true   |
		| "Garbage"         | "www.example.com" | false  |
		| "www.example.com" | "Goodbye"         | false  |
		| null              | null              | true   |
		| null              | "www.example.com" | false  |

Scenario Outline: Equals for dotnet backed value as a idnHostname
	Given the dotnet backed JsonIdnHostname <jsonValue>
	When I compare it to the idnHostname <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value             | result |
		| "Garbage"         | "www.example.com" | false  |
		| "www.example.com" | "www.example.com" | true   |
		| "www.example.com" | "Goodbye"         | false  |

Scenario Outline: Equals for idnHostname json element backed value as an IJsonValue
	Given the JsonElement backed JsonIdnHostname <jsonValue>
	When I compare the idnHostname to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "Garbage"         | "2018-11-13"                   | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for idnHostname dotnet backed value as an IJsonValue
	Given the dotnet backed JsonIdnHostname <jsonValue>
	When I compare the idnHostname to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "Garbage"         | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for idnHostname json element backed value as an object
	Given the JsonElement backed JsonIdnHostname <jsonValue>
	When I compare the idnHostname to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "www.example.com" | <new object()>                 | false  |
		| "www.example.com" | null                           | false  |

Scenario Outline: Equals for idnHostname dotnet backed value as an object
	Given the dotnet backed JsonIdnHostname <jsonValue>
	When I compare the idnHostname to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue         | value                          | result |
		| "www.example.com" | "Hello"                        | false  |
		| "www.example.com" | "Goodbye"                      | false  |
		| "www.example.com" | 1                              | false  |
		| "www.example.com" | 1.1                            | false  |
		| "www.example.com" | [1,2,3]                        | false  |
		| "www.example.com" | { "first": "1" }               | false  |
		| "www.example.com" | true                           | false  |
		| "www.example.com" | false                          | false  |
		| "www.example.com" | "2018-11-13T20:20:39+00:00"    | false  |
		| "www.example.com" | "2018-11-13"                   | false  |
		| "www.example.com" | "P3Y6M4DT12H30M5S"             | false  |
		| "www.example.com" | "hello@endjin.com"             | false  |
		| "www.example.com" | "www.example.com"              | true   |
		| "www.example.com" | "http://foo.bar/?baz=qux#quux" | false  |
		| "www.example.com" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "www.example.com" | "{ \"first\": \"1\" }"         | false  |
		| "www.example.com" | "192.168.0.1"                  | false  |
		| "www.example.com" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "www.example.com" | <new object()>                 | false  |
		| "www.example.com" | null                           | false  |
		| "www.example.com" | <null>                         | false  |
		| "www.example.com" | <undefined>                    | false  |
		| null              | null                           | true   |
		| null              | <null>                         | true   |
		| null              | <undefined>                    | false  |

# JsonInteger
Scenario Outline: Equals for json element backed value as a integer
	Given the JsonElement backed JsonInteger <jsonValue>
	When I compare it to the integer <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value | result |
		| 1         | 1     | true   |
		| 1         | 3     | false  |
		| null      | null  | true   |
		| null      | 1     | false  |

Scenario Outline: Equals for dotnet backed value as a integer
	Given the dotnet backed JsonInteger <jsonValue>
	When I compare it to the integer <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value | result |
		| 1         | 1     | true   |
		| 1         | 3     | false  |

Scenario Outline: Equals for integer json element backed value as an IJsonValue
	Given the JsonElement backed JsonInteger <jsonValue>
	When I compare the integer to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| 1         | "Hello"                        | false  |
		| 1         | "Goodbye"                      | false  |
		| 1         | 1                              | true   |
		| 1         | 1.1                            | false  |
		| 1         | [1,2,3]                        | false  |
		| 1         | { "first": "1" }               | false  |
		| 1         | true                           | false  |
		| 1         | false                          | false  |
		| 1         | "2018-11-13T20:20:39+00:00"    | false  |
		| 1         | "2018-11-13"                   | false  |
		| 1         | "P3Y6M4DT12H30M5S"             | false  |
		| 1         | "2018-11-13"                   | false  |
		| 1         | "hello@endjin.com"             | false  |
		| 1         | "www.example.com"              | false  |
		| 1         | "http://foo.bar/?baz=qux#quux" | false  |
		| 1         | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| 1         | "{ \"first\": \"1\" }"         | false  |
		| 1         | "192.168.0.1"                  | false  |
		| 1         | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for integer dotnet backed value as an IJsonValue
	Given the dotnet backed JsonInteger <jsonValue>
	When I compare the integer to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| 1         | "Hello"                        | false  |
		| 1         | "Goodbye"                      | false  |
		| 1         | 1                              | true   |
		| 1         | 1.1                            | false  |
		| 1         | [1,2,3]                        | false  |
		| 1         | { "first": "1" }               | false  |
		| 1         | true                           | false  |
		| 1         | false                          | false  |
		| 1         | "2018-11-13T20:20:39+00:00"    | false  |
		| 1         | "P3Y6M4DT12H30M5S"             | false  |
		| 1         | "2018-11-13"                   | false  |
		| 1         | "P3Y6M4DT12H30M5S"             | false  |
		| 1         | "hello@endjin.com"             | false  |
		| 1         | "www.example.com"              | false  |
		| 1         | "http://foo.bar/?baz=qux#quux" | false  |
		| 1         | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| 1         | "{ \"first\": \"1\" }"         | false  |
		| 1         | "192.168.0.1"                  | false  |
		| 1         | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for integer json element backed value as an object
	Given the JsonElement backed JsonInteger <jsonValue>
	When I compare the integer to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| 1         | "Hello"                        | false  |
		| 1         | "Goodbye"                      | false  |
		| 1         | 1                              | true   |
		| 1         | 1.1                            | false  |
		| 1         | [1,2,3]                        | false  |
		| 1         | { "first": "1" }               | false  |
		| 1         | true                           | false  |
		| 1         | false                          | false  |
		| 1         | "2018-11-13T20:20:39+00:00"    | false  |
		| 1         | "P3Y6M4DT12H30M5S"             | false  |
		| 1         | "2018-11-13"                   | false  |
		| 1         | "hello@endjin.com"             | false  |
		| 1         | "www.example.com"              | false  |
		| 1         | "http://foo.bar/?baz=qux#quux" | false  |
		| 1         | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| 1         | "{ \"first\": \"1\" }"         | false  |
		| 1         | "192.168.0.1"                  | false  |
		| 1         | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| 1         | <new object()>                 | false  |
		| 1         | null                           | false  |

Scenario Outline: Equals for integer dotnet backed value as an object
	Given the dotnet backed JsonInteger <jsonValue>
	When I compare the integer to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| 1         | "Hello"                        | false  |
		| 1         | "Goodbye"                      | false  |
		| 1         | 1                              | true   |
		| 1         | 1.1                            | false  |
		| 1         | [1,2,3]                        | false  |
		| 1         | { "first": "1" }               | false  |
		| 1         | true                           | false  |
		| 1         | false                          | false  |
		| 1         | "2018-11-13T20:20:39+00:00"    | false  |
		| 1         | "2018-11-13"                   | false  |
		| 1         | "P3Y6M4DT12H30M5S"             | false  |
		| 1         | "hello@endjin.com"             | false  |
		| 1         | "www.example.com"              | false  |
		| 1         | "http://foo.bar/?baz=qux#quux" | false  |
		| 1         | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| 1         | "{ \"first\": \"1\" }"         | false  |
		| 1         | "192.168.0.1"                  | false  |
		| 1         | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| 1         | <new object()>                 | false  |
		| 1         | null                           | false  |
		| 1         | <null>                         | false  |
		| 1         | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonIpV4
Scenario Outline: Equals for json element backed value as a ipV4
	Given the JsonElement backed JsonIpV4 <jsonValue>
	When I compare it to the ipV4 <value>
	Then the result should be <result>

	Examples:
		| jsonValue     | value         | result |
		| "192.168.0.1" | "192.168.0.1" | true   |
		| "192.168.0.1" | "192.168.0.2" | false  |
		| null          | null          | true   |
		| null          | "192.168.0.1" | false  |

Scenario Outline: Equals for dotnet backed value as a ipV4
	Given the dotnet backed JsonIpV4 <jsonValue>
	When I compare it to the ipV4 <value>
	Then the result should be <result>

	Examples:
		| jsonValue     | value         | result |
		| "192.168.0.1" | "192.168.0.1" | true   |
		| "192.168.0.1" | "192.168.0.2" | false  |

Scenario Outline: Equals for ipV4 json element backed value as an IJsonValue
	Given the JsonElement backed JsonIpV4 <jsonValue>
	When I compare the ipV4 to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue     | value                          | result |
		| "192.168.0.1" | "Hello"                        | false  |
		| "192.168.0.1" | "Goodbye"                      | false  |
		| "192.168.0.1" | 1                              | false  |
		| "192.168.0.1" | 1.1                            | false  |
		| "192.168.0.1" | [1,2,3]                        | false  |
		| "192.168.0.1" | { "first": "1" }               | false  |
		| "192.168.0.1" | true                           | false  |
		| "192.168.0.1" | false                          | false  |
		| "192.168.0.1" | "2018-11-13T20:20:39+00:00"    | false  |
		| "192.168.0.1" | "2018-11-13"                   | false  |
		| "192.168.0.1" | "P3Y6M4DT12H30M5S"             | false  |
		| "192.168.0.1" | "2018-11-13"                   | false  |
		| "192.168.0.1" | "hello@endjin.com"             | false  |
		| "192.168.0.1" | "www.example.com"              | false  |
		| "192.168.0.1" | "http://foo.bar/?baz=qux#quux" | false  |
		| "192.168.0.1" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "192.168.0.1" | "{ \"first\": \"1\" }"         | false  |
		| "192.168.0.1" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "192.168.0.1" | "192.168.0.1"                  | true   |

Scenario Outline: Equals for ipV4 dotnet backed value as an IJsonValue
	Given the dotnet backed JsonIpV4 <jsonValue>
	When I compare the ipV4 to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue     | value                          | result |
		| "192.168.0.1" | "Hello"                        | false  |
		| "192.168.0.1" | "Goodbye"                      | false  |
		| "192.168.0.1" | 1                              | false  |
		| "192.168.0.1" | 1.1                            | false  |
		| "192.168.0.1" | [1,2,3]                        | false  |
		| "192.168.0.1" | { "first": "1" }               | false  |
		| "192.168.0.1" | true                           | false  |
		| "192.168.0.1" | false                          | false  |
		| "192.168.0.1" | "2018-11-13T20:20:39+00:00"    | false  |
		| "192.168.0.1" | "P3Y6M4DT12H30M5S"             | false  |
		| "192.168.0.1" | "2018-11-13"                   | false  |
		| "192.168.0.1" | "P3Y6M4DT12H30M5S"             | false  |
		| "192.168.0.1" | "hello@endjin.com"             | false  |
		| "192.168.0.1" | "www.example.com"              | false  |
		| "192.168.0.1" | "http://foo.bar/?baz=qux#quux" | false  |
		| "192.168.0.1" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "192.168.0.1" | "{ \"first\": \"1\" }"         | false  |
		| "192.168.0.1" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "192.168.0.1" | "192.168.0.1"                  | true   |

Scenario Outline: Equals for ipV4 json element backed value as an object
	Given the JsonElement backed JsonIpV4 <jsonValue>
	When I compare the ipV4 to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue     | value                          | result |
		| "192.168.0.1" | "Hello"                        | false  |
		| "192.168.0.1" | "Goodbye"                      | false  |
		| "192.168.0.1" | 1                              | false  |
		| "192.168.0.1" | 1.1                            | false  |
		| "192.168.0.1" | [1,2,3]                        | false  |
		| "192.168.0.1" | { "first": "1" }               | false  |
		| "192.168.0.1" | true                           | false  |
		| "192.168.0.1" | false                          | false  |
		| "192.168.0.1" | "2018-11-13T20:20:39+00:00"    | false  |
		| "192.168.0.1" | "P3Y6M4DT12H30M5S"             | false  |
		| "192.168.0.1" | "2018-11-13"                   | false  |
		| "192.168.0.1" | "hello@endjin.com"             | false  |
		| "192.168.0.1" | "www.example.com"              | false  |
		| "192.168.0.1" | "http://foo.bar/?baz=qux#quux" | false  |
		| "192.168.0.1" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "192.168.0.1" | "{ \"first\": \"1\" }"         | false  |
		| "192.168.0.1" | <new object()>                 | false  |
		| "192.168.0.1" | "192.168.0.1"                  | true   |
		| "192.168.0.1" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "192.168.0.1" | null                           | false  |

Scenario Outline: Equals for ipV4 dotnet backed value as an object
	Given the dotnet backed JsonIpV4 <jsonValue>
	When I compare the ipV4 to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue     | value                          | result |
		| "192.168.0.1" | "Hello"                        | false  |
		| "192.168.0.1" | "Goodbye"                      | false  |
		| "192.168.0.1" | 1                              | false  |
		| "192.168.0.1" | 1.1                            | false  |
		| "192.168.0.1" | [1,2,3]                        | false  |
		| "192.168.0.1" | { "first": "1" }               | false  |
		| "192.168.0.1" | true                           | false  |
		| "192.168.0.1" | false                          | false  |
		| "192.168.0.1" | "2018-11-13T20:20:39+00:00"    | false  |
		| "192.168.0.1" | "2018-11-13"                   | false  |
		| "192.168.0.1" | "P3Y6M4DT12H30M5S"             | false  |
		| "192.168.0.1" | "hello@endjin.com"             | false  |
		| "192.168.0.1" | "www.example.com"              | false  |
		| "192.168.0.1" | "http://foo.bar/?baz=qux#quux" | false  |
		| "192.168.0.1" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "192.168.0.1" | "{ \"first\": \"1\" }"         | false  |
		| "192.168.0.1" | "192.168.0.1"                  | true   |
		| "192.168.0.1" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "192.168.0.1" | <new object()>                 | false  |
		| "192.168.0.1" | null                           | false  |
		| "192.168.0.1" | <null>                         | false  |
		| "192.168.0.1" | <undefined>                    | false  |
		| null          | null                           | true   |
		| null          | <null>                         | true   |
		| null          | <undefined>                    | false  |

# JsonIpV6
Scenario Outline: Equals for json element backed value as a ipV6
	Given the JsonElement backed JsonIpV6 <jsonValue>
	When I compare it to the ipV6 <value>
	Then the result should be <result>

	Examples:
		| jsonValue                  | value                      | result |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0001" | true   |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0002" | false  |
		| null                       | null                       | true   |
		| null                       | "0:0:0:0:0:ffff:c0a8:0001" | false  |

Scenario Outline: Equals for dotnet backed value as a ipV6
	Given the dotnet backed JsonIpV6 <jsonValue>
	When I compare it to the ipV6 <value>
	Then the result should be <result>

	Examples:
		| jsonValue                  | value                      | result |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0001" | true   |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0002" | false  |

Scenario Outline: Equals for ipV6 json element backed value as an IJsonValue
	Given the JsonElement backed JsonIpV6 <jsonValue>
	When I compare the ipV6 to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                  | value                          | result |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Hello"                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Goodbye"                      | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1                              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1.1                            | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | [1,2,3]                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | { "first": "1" }               | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | true                           | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | false                          | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13T20:20:39+00:00"    | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13"                   | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "P3Y6M4DT12H30M5S"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13"                   | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "hello@endjin.com"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "www.example.com"              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "http://foo.bar/?baz=qux#quux" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "{ \"first\": \"1\" }"         | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "192.168.0.1"                  | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0001"     | true   |

Scenario Outline: Equals for ipV6 dotnet backed value as an IJsonValue
	Given the dotnet backed JsonIpV6 <jsonValue>
	When I compare the ipV6 to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                  | value                          | result |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Hello"                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Goodbye"                      | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1                              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1.1                            | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | [1,2,3]                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | { "first": "1" }               | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | true                           | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | false                          | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13T20:20:39+00:00"    | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "P3Y6M4DT12H30M5S"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13"                   | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "P3Y6M4DT12H30M5S"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "hello@endjin.com"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "www.example.com"              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "http://foo.bar/?baz=qux#quux" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "{ \"first\": \"1\" }"         | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "192.168.0.1"                  | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0001"     | true   |

Scenario Outline: Equals for ipV6 json element backed value as an object
	Given the JsonElement backed JsonIpV6 <jsonValue>
	When I compare the ipV6 to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                  | value                          | result |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Hello"                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Goodbye"                      | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1                              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1.1                            | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | [1,2,3]                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | { "first": "1" }               | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | true                           | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | false                          | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13T20:20:39+00:00"    | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "P3Y6M4DT12H30M5S"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13"                   | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "hello@endjin.com"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "www.example.com"              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "http://foo.bar/?baz=qux#quux" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "{ \"first\": \"1\" }"         | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "192.168.0.1"                  | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0001"     | true   |
		| "0:0:0:0:0:ffff:c0a8:0001" | <new object()>                 | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | null                           | false  |

Scenario Outline: Equals for ipV6 dotnet backed value as an object
	Given the dotnet backed JsonIpV6 <jsonValue>
	When I compare the ipV6 to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                  | value                          | result |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Hello"                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "Goodbye"                      | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1                              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | 1.1                            | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | [1,2,3]                        | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | { "first": "1" }               | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | true                           | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | false                          | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13T20:20:39+00:00"    | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "2018-11-13"                   | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "P3Y6M4DT12H30M5S"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "hello@endjin.com"             | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "www.example.com"              | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "http://foo.bar/?baz=qux#quux" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "{ \"first\": \"1\" }"         | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "192.168.0.1"                  | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | "0:0:0:0:0:ffff:c0a8:0001"     | true   |
		| "0:0:0:0:0:ffff:c0a8:0001" | <new object()>                 | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | null                           | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | <null>                         | false  |
		| "0:0:0:0:0:ffff:c0a8:0001" | <undefined>                    | false  |
		| null                       | null                           | true   |
		| null                       | <null>                         | true   |
		| null                       | <undefined>                    | false  |

# JsonUri
Scenario Outline: Equals for json element backed value as a uri
	Given the JsonElement backed JsonUri <jsonValue>
	When I compare it to the uri <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |
		| null                           | null                             | true   |
		| null                           | "http://foo.bar/?baz=qux#quux"   | false  |

Scenario Outline: Equals for dotnet backed value as a uri
	Given the dotnet backed JsonUri <jsonValue>
	When I compare it to the uri <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |

Scenario Outline: Equals for uri json element backed value as an IJsonValue
	Given the JsonElement backed JsonUri <jsonValue>
	When I compare the uri to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for uri dotnet backed value as an IJsonValue
	Given the dotnet backed JsonUri <jsonValue>
	When I compare the uri to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for uri json element backed value as an object
	Given the JsonElement backed JsonUri <jsonValue>
	When I compare the uri to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |

Scenario Outline: Equals for uri dotnet backed value as an object
	Given the dotnet backed JsonUri <jsonValue>
	When I compare the uri to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |
		| "http://foo.bar/?baz=qux#quux" | <null>                         | false  |
		| "http://foo.bar/?baz=qux#quux" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonUriReference
Scenario Outline: Equals for json element backed value as a uriReference
	Given the JsonElement backed JsonUriReference <jsonValue>
	When I compare it to the uriReference <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |
		| null                           | null                             | true   |
		| null                           | "http://foo.bar/?baz=qux#quux"   | false  |

Scenario Outline: Equals for dotnet backed value as a uriReference
	Given the dotnet backed JsonUriReference <jsonValue>
	When I compare it to the uriReference <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |

Scenario Outline: Equals for uriReference json element backed value as an IJsonValue
	Given the JsonElement backed JsonUriReference <jsonValue>
	When I compare the uriReference to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for uriReference dotnet backed value as an IJsonValue
	Given the dotnet backed JsonUriReference <jsonValue>
	When I compare the uriReference to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for uriReference json element backed value as an object
	Given the JsonElement backed JsonUriReference <jsonValue>
	When I compare the uriReference to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |

Scenario Outline: Equals for uriReference dotnet backed value as an object
	Given the dotnet backed JsonUriReference <jsonValue>
	When I compare the uriReference to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |
		| "http://foo.bar/?baz=qux#quux" | <null>                         | false  |
		| "http://foo.bar/?baz=qux#quux" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonIri
Scenario Outline: Equals for json element backed value as a iri
	Given the JsonElement backed JsonIri <jsonValue>
	When I compare it to the iri <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |
		| null                           | null                             | true   |
		| null                           | "http://foo.bar/?baz=qux#quux"   | false  |

Scenario Outline: Equals for dotnet backed value as a iri
	Given the dotnet backed JsonIri <jsonValue>
	When I compare it to the iri <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |

Scenario Outline: Equals for iri json element backed value as an IJsonValue
	Given the JsonElement backed JsonIri <jsonValue>
	When I compare the iri to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for iri dotnet backed value as an IJsonValue
	Given the dotnet backed JsonIri <jsonValue>
	When I compare the iri to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for iri json element backed value as an object
	Given the JsonElement backed JsonIri <jsonValue>
	When I compare the iri to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |

Scenario Outline: Equals for iri dotnet backed value as an object
	Given the dotnet backed JsonIri <jsonValue>
	When I compare the iri to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |
		| "http://foo.bar/?baz=qux#quux" | <null>                         | false  |
		| "http://foo.bar/?baz=qux#quux" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonIriReference
Scenario Outline: Equals for json element backed value as a iriReference
	Given the JsonElement backed JsonIriReference <jsonValue>
	When I compare it to the iriReference <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |
		| null                           | null                             | true   |
		| null                           | "http://foo.bar/?baz=qux#quux"   | false  |

Scenario Outline: Equals for dotnet backed value as a iriReference
	Given the dotnet backed JsonIriReference <jsonValue>
	When I compare it to the iriReference <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                            | result |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux"   | true   |
		| "http://foo.bar/?baz=qux#quux" | "http://jim.bob/?sue=sally#tina" | false  |

Scenario Outline: Equals for iriReference json element backed value as an IJsonValue
	Given the JsonElement backed JsonIriReference <jsonValue>
	When I compare the iriReference to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for iriReference dotnet backed value as an IJsonValue
	Given the dotnet backed JsonIriReference <jsonValue>
	When I compare the iriReference to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |

Scenario Outline: Equals for iriReference json element backed value as an object
	Given the JsonElement backed JsonIriReference <jsonValue>
	When I compare the iriReference to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |

Scenario Outline: Equals for iriReference dotnet backed value as an object
	Given the dotnet backed JsonIriReference <jsonValue>
	When I compare the iriReference to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "http://foo.bar/?baz=qux#quux" | "Hello"                        | false  |
		| "http://foo.bar/?baz=qux#quux" | "Goodbye"                      | false  |
		| "http://foo.bar/?baz=qux#quux" | 1                              | false  |
		| "http://foo.bar/?baz=qux#quux" | 1.1                            | false  |
		| "http://foo.bar/?baz=qux#quux" | [1,2,3]                        | false  |
		| "http://foo.bar/?baz=qux#quux" | { "first": "1" }               | false  |
		| "http://foo.bar/?baz=qux#quux" | true                           | false  |
		| "http://foo.bar/?baz=qux#quux" | false                          | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13T20:20:39+00:00"    | false  |
		| "http://foo.bar/?baz=qux#quux" | "2018-11-13"                   | false  |
		| "http://foo.bar/?baz=qux#quux" | "P3Y6M4DT12H30M5S"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "hello@endjin.com"             | false  |
		| "http://foo.bar/?baz=qux#quux" | "www.example.com"              | false  |
		| "http://foo.bar/?baz=qux#quux" | "http://foo.bar/?baz=qux#quux" | true   |
		| "http://foo.bar/?baz=qux#quux" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "http://foo.bar/?baz=qux#quux" | "{ \"first\": \"1\" }"         | false  |
		| "http://foo.bar/?baz=qux#quux" | "192.168.0.1"                  | false  |
		| "http://foo.bar/?baz=qux#quux" | "0:0:0:0:0:ffff:c0a8:0001"     | false  |
		| "http://foo.bar/?baz=qux#quux" | <new object()>                 | false  |
		| "http://foo.bar/?baz=qux#quux" | null                           | false  |
		| "http://foo.bar/?baz=qux#quux" | <null>                         | false  |
		| "http://foo.bar/?baz=qux#quux" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |