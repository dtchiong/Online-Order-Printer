# Online-Order-Printer
An app that allows easy viewing and printing of online orders

![Sample screenshot](https://imgur.com/OjckiR7.png)

### About
This application streamlines the process of preparing online orders at any restaurant by enabling workers to view orders from different services such as DoorDash and GrubHub, in a single interface, and allows these orders to be easily printed to labels with a click of a button. Therefore, not only does this solution eliminate the possibility of human errors from workers having to maintain cognitive overhead from constantly switching between reading the order in the email that can span multiple pages and entering the order in the POS machine, but also, this app significantly improves the efficiency of the store by allowing workers to immediately begin preparing the order.

### Features
* Support for Doordash and Grubhub online orders—designed to work with any restaurant (UberEats support to come later)
* Automatic confirmation of orders as they are received by the restaurant
* Sound notifications for orders in real time
* EZ 1-click printing of orders to physical labels using a supported label printer
* Support for optmizing the printed label by assigning custom aliases in place of long names and configuring default modifiers to be hidden from the print view
* Ability to view current orders and past orders up to two weeks ago
* Intuitive list interface to view orders and their associated meta information such as customer name, pickup time, and print status—with color-coded cells so that information is absorbed at a glance
* Ability to view in-depth detail of an order's items, item modifiers, and special instructions
* User authentication

### Prerequisites
* [.NET Framework 4.7.2](https://www.microsoft.com/net/download/dotnet-framework-runtime) or higher
* Windows 10/8/7
* Internet connection
* [Desktop Zebra printers](https://www.zebra.com/us/en/products/printers/desktop/compact-desktop-printers.html) (tested on the ZD410 with 2.25" x 1.25" size labels)
* An authorized account with an associated restaurant
