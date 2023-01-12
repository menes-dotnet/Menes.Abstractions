﻿@perScenarioContainer

Feature: Float Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify float values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Body with valid values
    Given I have constructed the OpenAPI specification with a response body of type 'number', and format 'float'
    When I try to build a response from the value '<Value>' of type 'System.Single'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value     | ExpectedResult |
        | 0         | 0              |
        | 0.1       | 0.1            |
        | 1234      | 1234           |
        | -1234     | -1234          |
        | 1234.5    | 1234.5         |
        | -1234.567 | -1234.567      |

Scenario Outline: Header with valid values
    Given I have constructed the OpenAPI specification with a response header called 'X-Test' of type 'string', and format 'float'
    When I try to build a response from an OpenAPI result with these values
        | Name   | Type          | Value   |
        | X-Test | System.Single | <Value> |
    Then the response header called 'X-Test' should be '<ExpectedResult>'

    Examples:
        | Value     | ExpectedResult |
        | 0         | 0              |
        | 0.1       | 0.1            |
        | 1234      | 1234           |
        | -1234     | -1234          |
        | 1234.5    | 1234.5         |
        | -1234.567 | -1234.567      |
