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




-------------------------------------------------------------------------------------------------------------------------------
