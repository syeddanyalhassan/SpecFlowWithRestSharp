Feature: Add Item to Cart on Amazon

Scenario: Add item to the cart
    Given I am on the Amazon home page
    When I search for "TP-Link Tri-Band BE9300"
    And I click on the first search result
    And I add the item to the cart
    And I go to the cart
    Then I validate the correct item and amount