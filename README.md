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






-------------------------------------------------------------------------------------------------------------------------------
