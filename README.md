1. It is the remake of the BankAutomation(C) project, I prepared in C #.  Instead of struct, arrays and for loops; classes, lists and foreach loops are used.
2. A text file named "AccountDatabase.txt" is created in the file directory where the program runs first.
3. Customer informations (name, surname, password and balance) are kept in this text file.
4. If a user is created in the program, then the text file is updated.
5. When the program starts, an instance of DatabaseOperation class is instantiated, and the account information in the database is queried.
6. The queried account informations are stored in an instance of the List <BankAccount> class, which holds values ​​type of BankAccount class.
7. The entered name, surname and password informations are compared with the instance of BankAccount class. If they match, the user can access to program menu.
8. At the end of withdrawals, deposits and money transfers, the Database.txt file is constantly updated.
