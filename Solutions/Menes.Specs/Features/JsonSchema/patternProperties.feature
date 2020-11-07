Feature: patternProperties
    In order to use json-schema
    As a developer
    I want to support patternProperties

Scenario Outline: patternProperties validates properties matching a regex
    Given the input JSON file "patternProperties.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | a single valid match is valid                                                    |
        | #/000/tests/001/data | true  | multiple valid matches is valid                                                  |
        | #/000/tests/002/data | false | a single invalid match is invalid                                                |
        | #/000/tests/003/data | false | multiple invalid matches is invalid                                              |
        | #/000/tests/004/data | true  | ignores arrays                                                                   |
        | #/000/tests/005/data | true  | ignores strings                                                                  |
        | #/000/tests/006/data | true  | ignores other non-objects                                                        |

Scenario Outline: multiple simultaneous patternProperties are validated
    Given the input JSON file "patternProperties.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | a single valid match is valid                                                    |
        | #/001/tests/001/data | true  | a simultaneous match is valid                                                    |
        | #/001/tests/002/data | true  | multiple matches is valid                                                        |
        | #/001/tests/003/data | false | an invalid due to one is invalid                                                 |
        | #/001/tests/004/data | false | an invalid due to the other is invalid                                           |
        | #/001/tests/005/data | false | an invalid due to both is invalid                                                |

Scenario Outline: regexes are not anchored by default and are case sensitive
    Given the input JSON file "patternProperties.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | true  | non recognized members are ignored                                               |
        | #/002/tests/001/data | false | recognized members are accounted for                                             |
        | #/002/tests/002/data | true  | regexes are case sensitive                                                       |
        | #/002/tests/003/data | false | regexes are case sensitive, 2                                                    |

Scenario Outline: patternProperties with boolean schemas
    Given the input JSON file "patternProperties.json"
    And the schema at "#/3/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/003/tests/000/data | true  | object with property matching schema true is valid                               |
        | #/003/tests/001/data | false | object with property matching schema false is invalid                            |
        | #/003/tests/002/data | false | object with both properties is invalid                                           |
        | #/003/tests/003/data | false | object with a property matching both true and false is invalid                   |
        | #/003/tests/004/data | true  | empty object is valid                                                            |
