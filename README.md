Selenium , SpecFlow , C#

------ Setup ------

Create a new Project (NUnit Project)

Install Nuget Packages -> 

SpecFlow 

SpecFlow.NUnit 

Webdriver Manager 

Selenium Webdriver 

Selenium Support

Right click -> Add an Item -> SpecFlow Configuration

Add "language": { "feature": "en-US" }

Right click SpecFLow.json -> Proporities and set Copy to Output Directory to "Copy always"

Lets step up some of our basic feature files for Specflow which uses the Gherkin Language

Login.feature

** NOTE - Sometimes Net 8.0 will give you all steps are already defined when they actually aren't , to resolve this change the Target framework to 6.0 or 7 and then revert back

---- EXAMPLE ----- Feature: Login

Check login

@tag1 Scenario: User provides Valid login details Given The user is on the login page When The user provides a username When The user provides a password Then The user is logged in

Next Rebuild and the feature file text should turn purple and no longer back

Right click Define step and copy to Clipboard -> Create a C# Class and call it Websteps and paste our steps and change it to a public class

Within your websteps -> Create a public Webstep function and define WebDriverManager and IWebdriver

![image](https://github.com/user-attachments/assets/a2321ccd-9728-4b67-8d16-ee1115951886)


Next using Selenium, can we navigate to the login page and enter the username+password and click the login button image

![image](https://github.com/user-attachments/assets/ce555bee-a168-4708-a506-5137c63d6420)

Create a Configuration json file

Install Nuget Packages Microsoft.Extensions.Configuration Microsoft.Extensions.Configuration.Json Microsoft.Extensions.Configuration.EnvironmentalVariables

Here you can create a json file to hold Username/Password or any other details for configuration

---- Create a Runner File --- - You can create a Runner file and use the function BeforeTestRun to create your configuration image

![image](https://github.com/user-attachments/assets/61421f5d-8fe3-4f68-8119-40a5a1b7292b)

------ Hooks ----

Can be used to perform at different times within our Runner class image

![image](https://github.com/user-attachments/assets/33ef5c03-012f-439c-904f-f18b25473679)

Or when can use Hooks in our WebSteps image

![image](https://github.com/user-attachments/assets/cdee72e5-5782-4f79-9efc-e7f292d244ae)

--- Exernal Assemblies

This will allow you to call other projects / user there Websteps

Create a new Project-> install nuget packages -> delete thoses that you dont need as you will be using another projects go to Add -> Project Reference and check the project you want to reference create a specflow.json file and add your stepAssemblie or multiple if you need to

![image](https://github.com/user-attachments/assets/0b68f092-ea2f-4d1f-b337-0c2842c66a38)


----- Parallel Execution (Run two browsers at the same time) ----

Ablity to run multiple feature files

Add new Item to the project -> Assembly infomation file -> add assembly info as seen below image

![image](https://github.com/user-attachments/assets/48b334e3-8dad-4120-b2b1-7a91ca38d276)

------- Specflow Data Table --------------

Add a data table to your feature file image

![image](https://github.com/user-attachments/assets/12b52399-ff72-4b7a-9bde-b68707b9873e)

Create an instance class called UserCheckoutInfo which contains your set and gets image

![image](https://github.com/user-attachments/assets/3c029780-153e-4bb9-90f3-3aeb43872e7c)

Once you have defined your Websteps , you can see that our When function has a Table parameter image

![image](https://github.com/user-attachments/assets/9cf48f5b-b916-4c66-9d55-c02925270d9c)

Next you can then call instance "UserCheckoutInfo class" to retrive the variables image

![image](https://github.com/user-attachments/assets/d0b7db4d-cddc-423c-9b66-28069dfb2c57)

Another way to obtain data from the Table Rows is by using a foreach to iterate through the array image

![image](https://github.com/user-attachments/assets/e7144647-4036-448a-a757-d8d9c27499ba)

// There is also ways to Create/compare tables and its sets by using .CompareToSet



---------------------------------- CREATING A TEST AUTOMATION FRAMEWORK -----------------------------------------------------


Create a 3 new Projects 

![image](https://github.com/user-attachments/assets/19b2cb7c-fbd6-48f3-8076-762806a111d8)

install Nugets packages to the project 

Specflow NUnit and then delete Nunit in the dependencies as will be using specflow.Nunit 

Next create a Resources Folder and within that folder create the a applicationConfig.json + FrameworkSettings.json#

![image](https://github.com/user-attachments/assets/a0b339a6-794c-4f1b-8796-68adcec5bd6a)

Create folders 

DataSet

Result - will have report of executed testcases with logs to debug failed testcases

TestCases - this folder will be used to place all testscripts and framework engine will target to execute testcases.

frameworkSetting.json file is having information related framework environment

applicationRegionSettings.json will be saving all the information related to application environments. 


----- CUSTOM EXCEPTIONS ----
Create a new folder within TestAutomationFramework.Core.WebUI project and call it CustomExceptions 

Create 2 new classes

![image](https://github.com/user-attachments/assets/f07ed3a5-444a-45e4-b788-f5ebb6f5660e)

AutomationException

![image](https://github.com/user-attachments/assets/dbdda0bd-0c3f-4311-8787-00128c341230)

Error Items stored as Enums
![image](https://github.com/user-attachments/assets/c1b8f190-567b-4e48-af66-c2aa99b6b49b)



------ Logging -----

Create a new folder within WebUI project and call it Reports.

Create a new class called Logging
Download the nuget package - Serilog and Serilog.Sinks.File , Serilog.Enrichers.Thread ,

Create a constuctor of logging 

use Log.Logger to create the Object and define the level and controlledBy 

define out LoggingLevelSwitch which is then used to call out framework settings from Framework.json 


Define logginglevels - Create a method for each Log - Warning, Fatal , Error , Debug and Information 
![image](https://github.com/user-attachments/assets/ca956b9f-c4fd-4913-b0bd-a538c3829ad2)

using a Switch we can now call each of these methods when needed

![image](https://github.com/user-attachments/assets/e405ced1-a599-45ae-a470-32864941ab72)

Create a new folder within WebUI project and call its Params 

Create a class called DefaultVariables 
![image](https://github.com/user-attachments/assets/97d0a8ec-7aae-4636-8306-a56de78523e5)


Within this class  , Create a getReport Method and GetLog Method 

getReport will navigate to our Result\Report folder and when a new report is created itt will Timestamp it 
getLog will create a new log.txt file within the report folder

![image](https://github.com/user-attachments/assets/8332167d-6bdc-48a9-876a-d2c58ba701fc)



define the class DefaultVariables object within our constructor and then call the getLog method within the WriteTo.File Method which will then create a log .
![image](https://github.com/user-attachments/assets/de1efc1d-d145-44f9-9f81-57dbf7c6458f)


Lastly we need to invoke out Logger within TestAutomationFramework.DemoUI.Test. We can do this by referencing our project which contains our Logger class. Right Click DemoUI.Test -> Project Reference -> select the project you want to reference and then type the class you want to reference press alt+Enter and import project

After running our Unit test we can now see that the Results folder is populated with a log.txt file. Each time we get a new log it will be added to its own report folder like below.
![image](https://github.com/user-attachments/assets/d13eb95a-fd2d-409d-aa63-8a2a5ba8a4da)


---------------------------------------------------

Dependency injection  - Reuseable code and functionality - we can do the way above but for Coding standards and efficiently readable code we should use this

install the nuget package -> Microsoft.Extensions.

Create a new Folder called ContainerConfig within WebUI Project
Within this folder , create a class called ContainerConfig.cs

This class will create a container and user the service collection to request the object 
![image](https://github.com/user-attachments/assets/5c652943-6f9c-4117-95d8-53981c6bfab6)

Inheritance of Objects 
We can inherit defaultVariable by adding the below 
![image](https://github.com/user-attachments/assets/1dcd1517-acdc-4e26-a7fb-047deb937528)


Create another Folder called Abstraction 
Within this folder , create an interface called IDefaultVariables which will hold the function we would like to inherit/reuse thoughout our codebase

![image](https://github.com/user-attachments/assets/4238d79e-00f1-4dbe-be57-6536c7381532)

![image](https://github.com/user-attachments/assets/53dd16a1-1578-4c94-95f9-d4835df97c79)

Now within Logging.cs we can no longer need to create an object for defaultVariables , we can declare IdefaualtVariables by declaring it within Logging constructor and outside of ti which will allow us to use _idefaultVariables.getLog function 


lets create an interface for our Logging class now 

Create a class called ILogging in our Abstract class and declare the functions we want to inherit
![image](https://github.com/user-attachments/assets/f1f324c1-148e-435c-b222-8e5f47c57cca)


Inherit the Logging class
![image](https://github.com/user-attachments/assets/0a28d2e0-f7ba-4dfc-81ca-9c97bd5de776)

Add Logging to our service container
![image](https://github.com/user-attachments/assets/3edc827d-746c-4c81-bf9c-efd1e49dddf6)


We can then pass our logging object to our UnitTest , by declaring iserviceProvider which will use the ContainerConfig class and services method  
![image](https://github.com/user-attachments/assets/3e7b3a31-09cd-4e22-9535-0373f6eeb6ef)


----- CREATE A RUNNER --------

Create a new folder called Runner 
Create a new Class named SpecFlowRunner.cs

Make the class public 
Declare a function 

Binding using e.g. [BeforeTestRun] and [Binding] the class

declare and call Class/Object 
![image](https://github.com/user-attachments/assets/1a826f28-ae16-413a-b385-b45dfa909b35)

Create a new class 
GlobalProperties.cs

Install Nuget Package 
Microsoft.Extensions.Configuration.Json

Create a configurationbuilder which will be used to read the json file -> before running the script make sure to edit the File Properties to Copy as always.

![image](https://github.com/user-attachments/assets/9f9ffc6f-29a0-48e1-8e4f-65a7a7148457)

Add GlobalProperties to the UnitTest within DemoUI.Test before doing this make sure to add Project reference to this project(DemoUI.Test)
![image](https://github.com/user-attachments/assets/f6acac18-6700-4e78-a713-a41299341786)

inhertance of GlobalProperties 

lets create an interface for our GlobalProperties class now 

Create a class called IGlobalProperties in our Abstract class and declare the functions we want to inherit
add a try catch for when to catch the frameworksettings json file incase its not present and inherit the logging system
![image](https://github.com/user-attachments/assets/3f028dfb-eff7-42ef-b000-33159f8ce4e5)



Inherit the GlobalProperties class
![image](https://github.com/user-attachments/assets/65ba3367-c485-466e-9159-71cf79e2d482)


Add GlobalProperties to our service container
We can then pass our logging object to our UnitTest , by declaring iserviceProvider 
![image](https://github.com/user-attachments/assets/0a8f557c-c80b-4386-a434-5780c41ff77e)



Setting Default Values as properties using the Frameworksetting.json

Below us the complete global properties file , whee we use Set and get variables to assign the default properties and using the configbuilder to set values and validation 

we are use inherit _idefaultVariables to call certain methods for the configbuulder and using ilogging we display the Config settings in a report when we run/debug the tests 
![image](https://github.com/user-attachments/assets/f46532a6-e7b8-41a2-a1fd-a632f2689e84)

![image](https://github.com/user-attachments/assets/0253e72c-2249-4ecf-b655-084c6bee043f)


-------------------------------------------------------------------------------------------------------------------------------

Defining Scenerios 

TIP - After creating this file , ensure to rebuild the project but before this Ensure SpecFlow.Tools.MsBuild.Generation Nuget package is downloaded as this will auto generate the Feature.cs file 

Create an item within the Test_Cases folder and create a SpecFlow feature file 

Start by creating the Login scenerio. 

1. Give the Scenerio a name :
2. Give a Condition to begin
3. define steps by right clicking -> define steps -> Copy to clipboard ( TIP : If you are unable to define , try close  VS studio and the text should be a light grey or purple.
![image](https://github.com/user-attachments/assets/d8f3646a-0885-4258-b985-67fe207c8df0)

![image](https://github.com/user-attachments/assets/f3f6a9d7-e177-4552-97b5-5a847f5f7e21)

Next create 2 new folders within Demo.UI called Steps and the other called Pages 
![image](https://github.com/user-attachments/assets/b1b9f73f-5941-4008-8c99-5741a6f32240)

Within Steps create a Class called Login and declare the construtor and copy the Login Steps 
![image](https://github.com/user-attachments/assets/cc81bbd0-22de-4eaa-902e-decf689cdd78)

Within Page create a Class called LoginPages and declare the constructor, create method called LoginWithValidCredentials and have the username and password as the parameters.

![image](https://github.com/user-attachments/assets/2042a096-29cb-4dc3-b6d5-226ac8dadac3)

Before the next step , install the Nuget Package Selenium webdriver and webdriver manager to DemoUI Project


declare WebdriverManager and setup the driver with new chromeconfig

And declare the Selenium WebDriver Object with chromeDriver and put it at Class level to allow us to use it through the file



Useful chrome extension to get Xpath selectors 
![image](https://github.com/user-attachments/assets/98f1d4fe-b6ba-400d-9c0a-de4c41bc8f6c)




Within our LoginWithValidCredentials we will be using IWebElement and our  Webdriver to navigate to the Login page and Find the element using selenium Webdriver  and sendkeys(username) and password and tell the webDriver to click the login btn.
![image](https://github.com/user-attachments/assets/17bc47cc-0a07-45fa-9c64-0e31c9ccfe98)


Within our LoginSteps file , we will declare LoginPage as an object so that we can access its methods 
Within GivenLoginWithValidLogin() , we will call our object and the LoginWithValidationCredentials and pass 2 values which are the username + password.  
-- TIP : ensure to bind class using Binding in order to reference
![image](https://github.com/user-attachments/assets/f62bb322-95b3-4322-b8e1-67fec5dd1e4e)



Due to our feature files being within DemoUI.Test Project , we need to reference the project to be able to define our Steps within LoginStep file
![image](https://github.com/user-attachments/assets/69d1952d-caf2-4106-a97b-69c634b37fa2)

Go to DemoUi.test project and Right Click -> Add -> Project Reference
![image](https://github.com/user-attachments/assets/2806e93a-981f-4b17-a7a9-1ee0ccf07ebb)

Go to DemoUi.test project and Right Click -> Add ->  New item -> Specflow configuration file
Add a step assembly and then assign the project you want to reference and then also set the files properties-> copy to output directory to Copy always 
![image](https://github.com/user-attachments/assets/bb933d98-a24d-4848-800c-06b2940744b2)

After you have rebuilt the solution -> Navigate to you feature file and you can now see that the Steo is defined
![image](https://github.com/user-attachments/assets/dc5ad2d1-83bd-453a-b010-1731b60afa2a)

you can also right the Step and click Go to Definition to find it and in this case it brought us to LoginSteps file which is located within DemoUi Project which means our project reference as worked 
![image](https://github.com/user-attachments/assets/bf854e0c-f10f-4a00-8a31-ce1c9ac53401)

Now open your Test Explorer and run the LoginFeature. The Test was successful and opened the browser and signed in using the login page . 
![image](https://github.com/user-attachments/assets/99e833e1-92be-48e4-bcf8-634992414c44)

lets create another scenario for Invalid login 
![image](https://github.com/user-attachments/assets/daa1b2c0-65e7-4922-bfae-0a20f85b6149)

Define the step defination and copy to clipboard and paste it within the LoginSteps class 
![image](https://github.com/user-attachments/assets/8f98254d-5f3b-43f7-afc0-b507485f5671)

We then need to create a new method within LoginPage.cs and add the selenium webdriver instructions . Also to reduce code , we will put the elements on the Class level and user => operator
![image](https://github.com/user-attachments/assets/d4555c9a-6f0c-4ec0-9a46-204cbcf14e43)

Go back to LoginSteps.cs and using our LoginPage Object, We will call upon our method 
![image](https://github.com/user-attachments/assets/3f9d13c7-287a-40cd-b19a-b3aac93848c9)

 
---------------------

Within you DefaultVariables Class , create a method for getting you Application Config json file .

![image](https://github.com/user-attachments/assets/23d83e13-d9a8-4ef3-a7a4-9ea456e53fdd)

Then add it to our interface 
![image](https://github.com/user-attachments/assets/b439bd55-fc3c-46b1-9519-efded6f91ffd)

ensure that you file properties, Copy to Output Directory - "Copy always"
![image](https://github.com/user-attachments/assets/b433c9d2-509c-4a76-9171-ffe1398cc409)

Create a Class called AtConfiguration within DemoUi (you will need to create a new folder aswell )
![image](https://github.com/user-attachments/assets/d5c001e4-b21e-4546-915b-24e04cd29400)

Within this Class , call the specflowRunner as seen below and ensure that the specflow object is updated to public and ensure to Project reference the project that has SpecflowRunner present in . 
![image](https://github.com/user-attachments/assets/3983af75-ef47-4934-8a71-b765c570908a)

![image](https://github.com/user-attachments/assets/aa660c57-69db-46a1-9380-454796aee195)







