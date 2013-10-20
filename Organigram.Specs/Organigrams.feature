Feature: Organigrams API

@mytag
Scenario: Get list of organigrams
	Given I am not authenticated
	And I perform a GET request on /organigrams
	Then the response status code should be 401
