Feature: CheckOutInfo

A short summary of the feature

@tag1
Scenario: User adds a product to cart and proceeds to checkout
	Given user adds a product to cart 
	When the user clicks to checkout and adds info
	| firstName | lastName | zipCode |
	| Conor      | Hoey    | BT34 5PF |

