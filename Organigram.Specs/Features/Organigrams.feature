Feature: Organigrams API

Scenario: Get list of organigrams as unauthenticated client
	Given I am not authenticated
	And I perform a GET request on /organigrams
	Then the response status code should be 401

Scenario: Get list of organigrams as authenticated client
	Given I am authenticated
	And I perform a GET request on /organigrams
	Then the response status code should be 200