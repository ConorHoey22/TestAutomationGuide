Feature: Login Parallel

Check login 

@tag1
Scenario Outline: User provides Valid login details 
	Given The user is on the login page
	When The user provides a username <username>
	And The user provides a password <password>
	Then The user is logged in
	Then user adds their firstName and lastName
	Then display user info 

Examples: 
| username      | password     |
| standard_user | secret_sauce |
| problem_user  | secret_sauce |


