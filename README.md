

# How to use the program?
Download the main branch in a zip. Open the zip and extract all the files on your selected folder. Open the file "Program.cs" with double-click or, while using a program like Visual Studio Code 2022, open the file from the app.

# Chapter 0

User will insert their name and the will select from 8 options to continue its adventure.

# Chapter 1

User will enter the training part and automatically train for 5 days, getting random xp and hours of training. After that, user will be granted with a rank depending on the current xp of the user.
User will return to Chapter 0.

# Chapter 2

User will enter the salying monster part, getting a randomlly assigned monster. User will press a key to throw a dice and hit the enemy depending on the number of the dice. When the hp of the monster gets to 0, he user will level up.
User will return to Chapter 0

# Chapter 3

User will see a 5x5 field and it will be asked to insert on a row and column to try to find a treasure. User will dig on the selected spot and if it digs a treasure, it will get some bits (money) later at the end of the digging. Onthe other hand, if it finds nothing, user will continue digging without reward. User can dig 5 times.
User will return to Chapter 0.

# Chapter 4

User will see its inventory. If the inventor is empty, a message will appear, if it isn't empty, user will see the items previously bought on chapter 5.
User will return to Chapter 0.

# Chapter 5

User will be granted with the opportunity to buy items from a shop. User will select an item and, if it has enough bits, user will buy the item and the item will be sold. If user doesn't have enough money, user will be warned. User can exit whenever it can the shop.

# Chapter 6

User will be shown with the spells that it currently knows for its level. When user is level maximum (5), user will be able to see all spells from all levels.
User will return to Chapter 0.

# Chapter 7

User will be able to select between 3 scrolls. After that, user will select a type of decoding the scroll (Removing spaces from the scroll, counting the vowels of a scroll or only leaving the numbers of a scroll, revealing a secret code). When the user decodes a scroll with the three decoding ways, user will recieve a message of the fully decoded scrolls.
User will return to chapter 0.


# JOCS DE PROVES

# Chapter 0

| Tipus | magename |Expected | Result |
|----------------|-----------|----------------|-|
| normal |"     gHost28" | "Ghost28" | "Ghost28" |
| Error |  | Dumbass | Dumbass |

# Chapter 3

| Tipus | row | column |Expected | Result |
|----------------|-----------|----------------|-|-|
| normal | 2 | 3 | Digs in the 1,2 place of the matrix | Digs in the 1,2 place of the matrix |
| Limit| 1 | 1 | Digs in the 0,0 place of the matrix | Digs in the 0,0 place of the matrix |
| Error | -1 | a | MSG: ErrorDig| MSG: ErrorDig |
| Error | 6 | 7 | MSG: OutOfBounds | MSG: OutOfBounds |

Chapter 5

| Tipus | totalBits | answerShop | Expected | Result |
|----------------|-----------|----------------|-|-|
| Normal | 10 | 1 | totalBits = 0. MSG: EnoughMoney | totalBits = 0. MSG: EnoughMoney |
| Normal | 9 | 1 | MSG: MoreMoney | MSG: MoreMoney |
| Error | 10 | a | MSG: ErrorShop | MSG: ErrorShop|
| Error | 10 | 6 | MSG: WrongItem | MSG: WrongItem |

# Chapter 7

| Tipus | numscroll | numDecode | Expected | Result |
|----------------|-----------|----------------|-|-|
| Normal | 0 | 0 | Scroll 0 gets the spaces removed | Scroll 0 gets the spaces removes |
| Normal | 0 | 1 | Counts all the vowels of scroll 0 | Counts all vowels of scroll 0 |
| Normal | 0 | 2 | Gives the secret numbers, in order, of the scroll 0 | Gives the secret numbers, in order, of the scroll 0|
| Error | a | 2 | MSG: ErrorScroll | MSG: ErrorScroll |
| Error | 0 | a | MSG: ErrorDecode | MSG: ErrorDecode |
| Error | 4 | 1 | MSG: ErrorScroll | MSG: ErrorScroll |
| Error | 1 | 4 | MSG: ErrorDecode | MSG: ErrorDecode |
