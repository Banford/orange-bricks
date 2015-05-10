# orange-bricks
A cheaper... less featured player in the online estate agent space.

## Planned Implementation

* Use TDD where possible
* Use default MVC 5 template
* Document with a README.md
* Use bower and grunt if required
* Use bootstrap

## User Stories

* As a seller I want to register to use the site so that I can sell property. - DONE
* As a seller I want to log in to my account so that I can access my selling options. - DONE
* As a buyer I want to register to use the site so that I can buy property. - DONE
* As a buyer I want to log in to my account so that I can access my buying options. - DONE
* As a seller I want to enter information about a property so that it can be provided to buyers when listing.
* As a seller I want to list a property for sale so that it can be seen by buyers.
* As a buyer I want to search for a property so that I can find a property that meets my needs.
* As a buyer I want to make an offer on a property so that the seller knows of my intent to purchase.
* As a seller I want to accept an offer on a property so that I can agree to the sale of the property.
* As a seller I want to reject an offer on a property so that the buyer knows their offer was not accepted.

## Project Diary

As I have had to split the task out over a few days due to events and prior arrangements in the evenings I've decided to jot down a few notes each day just to reaveal the intent of that chunk of work and my aim for the next steps. The commit history in the public repo can show the history of the incremental changes to the project. This is more just to convey my thoughts during the process.

### Evening 1

Initially I broke down the brief into user stories so that I could work through each one in turn. My first choices were about which kind of app to start off with. The brief sounds like it would suit an MVC web application and I toyed with the idea of using ASP.Net vNext to build and MVC6 application but settled on the more familiar MVC5 as I can guarentee I will be able to build the app and have it deployable. I've done some research into vNext and would definitely recommend using it going forward.

After setting up the basic app using the MVC application template a lot of the initial work was related to properly configuring the auth and setting up roles. With a few tweaks to the provided auth code I had covered a few of the first user stories by providing two role types and modifying the existing user registration process.

Most of the other initial tweaks were to the default app template, changing things like the app name and default text. I also needed to remove some of the default pages such as the contact page. Finishing this I went on to create a property model and a test fixture which will test the first part of the business logic.

I've intentionally removed the controller tests provided. I prefer to move as much logic out of the controllers as possible and test isolated classes and test those rather than testing the framework. Left myself a failing unit test to begin with on the next opportunity.

### Evening 2

Limited for time this evening due to being out at a tech meetup. Decided to use the pomodoro technique and limit myself to a single pomodoro with an achieveable goal which was to implement the code required to pass the failing unit test I set up last time. This involved some setting up of dependency injection so that I could mock/substitute the database context.

### Day 3



