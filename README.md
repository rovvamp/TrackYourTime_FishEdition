# SoftwareEngineeringExam
A new repository for a desktop pet idle game for my MDH assignment in software engineering


Code conventions
I followed the C# coding Standards as recommended by Microsoft

Naming Conventions: 
PascalCase for class names and Methods (eg. GameManager, StartTimer() )
camelCase for fields and method Parameters (eg. _currencyLabel, _timeLeft)

Code Structure & Formatting:
Braces ({}) on new lines for better readability
proper spacing: if (condition) { ... } instead of  if(condition){...}

Consistent access modifier: 
private for class variables that shouldn't be accessed externally
public for properties and methods meant to be used externally


Project-Specific conventions

File & Folder Organization:
assets folder for imported images and sounds
scenes folder for all the available scenes
scripts folder for all the available scripts
seperate UI folder for UI scenes because UI is special :P
UnitTests for the Unit test

I also changed all the colors of the folder to make it easy indistinguishable

Debugging:
I used a lot of GD.Print() to debug my code and find issues faster.

I added debugging keys to make it easier for me and for you to see the result (otherwise you would have to wait 1 hour for my countdown to go to 0 and that's not fun)

I also commented a lot of code for myself to understand but later on reduced it a lot for a more clear structure

Unit tests:

I attempted to implement the unit tests using NUnit in visual studio code. I wanted to validate the functions of the currency managment and purchase logic. Despite multiple HOURS of Troubleshooting, Research and debugging I just couldn't make the test run without it spitting a red carpet of errors in my face.

I installed NUnit and NUnit Test Adapter and checked for its intallastion multiple times.
I created seperate Unit Test Project.
Nothing worked. the test runner just did not want to recognize my test as such.

But the unit test code is written and included in the repository.
I am very interested in Feedback if you find the problem!!

On another note. I had this big and great idea for my game but it turned out to be a bit more complicated than i expected so I did Kind of fall into the "feature creep hole". 
So for next time I have learned to rather keep it REALLYYY simple. But his time I was too stubborn to change my idea :D

Assets:
All fish pngs were sourced from: pnggallery.com
Seashell: https://pnggallery.com/seashell#image1
Background: https://images7.alphacoders.com/351/351076.jpg
The decoration art was kindly provided by Sofia Kuzyushina

I got all sounds from: https://freesound.org
