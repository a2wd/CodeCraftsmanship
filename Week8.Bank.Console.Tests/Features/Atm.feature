Feature: Atm
	We will implement the deposit, withdraw and print statement operations for clients

@coreOperations
Scenario: A client carries out transactions and prints a statement
	Given a client makes a deposit of 10 on 10-01-2012
	And a client makes a deposit of 20 on 13-01-2012
	And a client makes a withdrawal of 5 on 14-01-2012
	When the client prints their statement
	Then they would see the expected statement
