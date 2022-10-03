# EcommerceJala

EcommerceJala is an app that helps you to manage your shopping,
You can add and remove an item, check what was added to the cart 
and compute a total of your shopping list. If you want to access to a shoping cart
you have to login using your username if not create a new user.

## Steps:

1. users can login using their usernames.
2. users are abel to register in case they are not registered
3. The program will give a welcome to existig users.
4. The program will ask you to select an option to perform an action with the shopping cart.
5. users can add an item and its price to the shopping cart.
6. users remove an item to the shopping cart.
7. users can check what was added to their carts.
8. users can compute a total of what they added to the shopping cart.
9. the program will say thank the users for shopping at EcommerceJala.

## User Stories
1. As a User, I want to be abel to loggin to and recieve a message welcome to EcommerceJala if credentails are right.
2. As a user, I want to be able to signup if I don't have an account.

3. As a User, I can see my name in the console after logging in.

4. As a User, I want to be abel to add items to my shopping cart.
5. As a User, I want to be abel to remove items from my shopping cart.
6. As a User, I want to be abel to edit items of my shopping cart. 
7. As a User, I want to be abel to check all the current items I have in my shopping cart.
8. As a User, I want to be abel to see the list of my items order by price (Descending.)
9. As a User, I want to be abel to compute the total price of the items I currently have in my shopping cart.

10. As a User, I want to be to receive an error message if I selected an Invalid option.
11. As a user I want to be to receive an message say Thank your for visiting us after finishing my shoppping.


12. As an Admin, I want to be abel to create a list of items to sell in my EcommerceJala Data Base.
13. As an Admin, I want to be abel to Edit the list of items to sell in my EcommerceJala Data Base.
14. As an Admin, I want to be abel to Remove items to sell in my EcommerceJala Data Base.
15. As an Admin, I want to be abel to view all items on the console from my EcommerceJala Data Base.

## CRC Components:

Class Account SignIn, SignUp. // Colaborate (Admin, User).
Class Admin: Store Admin accounts // Collaborate (Item)
Class User:  Store Users Accounts // Collaborate (ShppingCart)
Class Item: create/add item, update item, remove items, View list of Items (Database) // Collaborate (ShoppintCart, Admin) 
class Shopping cart: Add items, Remove added items, View added items (order by price Descending), Compute Total // Collaborate (Item, User)


