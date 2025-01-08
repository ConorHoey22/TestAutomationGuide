Feature: AddRemoveFromCart

Adding and Removing items from the cart

@VerifyCartCount
Scenario: Verify Cart counts after Adding and Removing items 
	Given login with valid credentials
	When User adds an items from the product list to the cart
	Then User verifies the cart count is correct
	When User removes one item from the cart
	Then User verifies the count has updated