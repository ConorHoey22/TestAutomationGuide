![image](https://github.com/user-attachments/assets/bf20e024-9c71-46d4-8496-7443bd809751)Selenium , SpecFlow , C#

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

---------------------------------------------

lets create an interface for our AtConfiguration class now 

Create a class called IAtConfiguration in our IWebAbstraction folder (you may need to create this)

![image](https://github.com/user-attachments/assets/c92c658c-c7d0-482e-a652-58a012455be4)

In our AtConfiguration we will create the interface and create our getConfiguration 

![image](https://github.com/user-attachments/assets/adacc47a-c08a-4e8f-9d9f-52db2ee13407)

Which is then called in our Interface 

![image](https://github.com/user-attachments/assets/6051ad6c-b57b-47cf-b505-b993ff109e1b)

Create a folder called Container and within create a class called ContainerConfig

**BeforeScenario Hook**
The BeforeScenario method registers dependencies with IObjectContainer. For example, it ensures that whenever an IAtConfiguration is required, an instance of AtConfiguration is provided.

Order = 1: Specifies the execution order of hooks. Hooks with lower order values execute first. This ensures that this setup occurs before other BeforeScenario hooks with higher order values.

Purpose: IObjectContainer allows you to register and resolve types specific to SpecFlow's lifecycle (e.g., per scenario, per step).
The BeforeScenario method registers dependencies with IObjectContainer. For example, it ensures that whenever an IAtConfiguration is required, an instance of AtConfiguration is provided.

SpecFlow automatically injects IAtConfiguration wherever it’s needed (e.g., in step definitions or other dependencies).

![image](https://github.com/user-attachments/assets/1412cda0-e50b-423e-b10a-63ef566a2a8d)

inherit IAtConfiguration interface

Add it to the LoginSteps parameters which will then allow you to use the object and the method .GetConfiguration() and call/read the application settings URL , Username and Password.

![image](https://github.com/user-attachments/assets/6e68de94-b8c3-49c3-8c9c-054fcda93497)

Update Login Page Class 

![image](https://github.com/user-attachments/assets/92684c66-c3bc-43f3-88dc-ae7630d8360f)

Add to assembly 

![image](https://github.com/user-attachments/assets/88e8a95c-c988-4757-9eb2-8e411f3d6758)

------------ Creating ChromeDriver + FirefoxDriver as an Object ---- - 
Create Folder  called selenium 

Create a folder within called localWebdrivers 

Chrome 
Create a new class called ChromeWebdriver 
![image](https://github.com/user-attachments/assets/367033d8-f37a-4fb8-bfe5-3e32f2f81fe3)

set and get methods on global properties class which allows us to inherit datasetLocation
![image](https://github.com/user-attachments/assets/43cc8a21-b564-47de-93df-af16278fff90)

Create interface class within  Abstraction folder called IChromeWebDriver 
![image](https://github.com/user-attachments/assets/05b1fdbd-5127-4ddd-b680-e7c537c9ad01)
![image](https://github.com/user-attachments/assets/2cfa1219-9b3c-4f0b-8631-ca8f679141d0)


Then repeat for other browsers

Firefox
Create a new class called FirefoxWebdriver 
![image](https://github.com/user-attachments/assets/b99c8f3f-782e-4f42-a7d5-8de399d05b81)


Create interface class within Abstraction folder called IFirefox WebDriver 
![image](https://github.com/user-attachments/assets/dfd4dc68-1527-441e-b3f3-ef4154dd49fe)


Within WebUI -> rename the containerconfig to CoreContainerConfig 
![image](https://github.com/user-attachments/assets/8107fbc7-f308-43b9-83ad-e1630dbeedc8)

within this file we will create an new method called SetContainer which will reference our chrome and firefox interfaces 
![image](https://github.com/user-attachments/assets/dd2fc54a-8a35-46c3-a6c6-0717dac00e04)

next within ContainerConfig within DemoUI containerConfig , we will reference the CoreContainerConfig which will reference our 2 browsers 
![image](https://github.com/user-attachments/assets/d8c2bf0a-427c-4182-b3a8-583b8d1590d8)


Create a new folder called Hooks 
Within this folder create a class called SpecFlowBase within WebUI Project
![image](https://github.com/user-attachments/assets/01f160d1-7a44-4093-a1f5-63f2a71e3a5d)

SpecflowBase.cs 
the class below will use the browser interfaces within our switch statement which will look within the global Properties file for browser type and select the matching browserType before the Scenario runs
![image](https://github.com/user-attachments/assets/de10462c-5893-4ecf-9f58-2b0be572eec8)

in order to use this Specflowbase with our scenario , we will add WebDriver to our Login Step class 
![image](https://github.com/user-attachments/assets/a51d6fe4-3895-475b-9cad-7a9ce9d53d86)

We can now update and replace the WebDriver steps on Login Page which will use the Webdriver switch and browser interfaces created 
![image](https://github.com/user-attachments/assets/e9f4f340-73b7-4a53-8a54-c767234143db)


--- WebDriver Interface --- 

Create a folder called DriversContext
Create a new Class called Drivers 
Create a constructor 
Inherit IChromeWebdriver , IFirefoxWebdriver , IGlobalProperties and IWebdriver
Create a method called GetWebdrivers - This will be used to check if a webdriver has been defined or not  
![image](https://github.com/user-attachments/assets/27e7ee22-b217-43f2-88da-cb7a12163d3d)


Create a Method called GetNewWebDriver  - This is our Switch cases that was previously created wtihin 
![image](https://github.com/user-attachments/assets/4f592cb5-74f8-48ee-8f53-26285ba8a199)

Create an interface for Drivers called IDrivers and attach the Method IWebDriver GetWebDrivers
![image](https://github.com/user-attachments/assets/2e38fb07-8887-4ea7-bd56-ae6e2010f310)

Within CoreContainerConfig , define the relationship between the objects 
![image](https://github.com/user-attachments/assets/cf397438-d854-4821-ab8a-b3152d88ef7f)

Now we need to update our BeforeScenario Method within our SpecflowBase class and remove the switch case as it will now be called using idrivers 
![image](https://github.com/user-attachments/assets/7115f80e-9c2f-44db-b2ba-0d120252a1b2)

Update LoginSteps and LoginPage Class

LoginSteps
![image](https://github.com/user-attachments/assets/546fc735-8ce6-447d-b156-47d2a9745581)

LoginPage 
![image](https://github.com/user-attachments/assets/9f6db634-5b22-444e-b3db-04206481fb64)

Now that we have a Driver class and interface , can create Driver operations method to for example , Close , Maximise the tab 
![image](https://github.com/user-attachments/assets/99628b46-0276-43b0-8e64-ad01a6f1c5de)

Always remember to declare the method within the interface so that the method can be inherited 
![image](https://github.com/user-attachments/assets/3cf631cc-cb2c-4e34-b493-ba2557987dda)



---- Example of Explicit Wait and logging--- 

![image](https://github.com/user-attachments/assets/780b2447-0c5d-4a0b-ba64-1286205a941d)


--- StaleElement --- 

![image](https://github.com/user-attachments/assets/c32c2b8c-374e-4450-b2e8-17eeedf35fa8)


--- Using ExtentReport --- 

This can be used for a visual display/ Reports 

Download Nuget Package : ExtentReport Core 

Create a new Class within Web UI project -> Reports folder called ExtentFeatureReports 
Create its interface class aswell -> Abstraction -> Create class called IExtendFeatureReports 
Then aswell we need to add it to are ServiceProvider interface 


Within our ExtentFeatureReports class let create a method called intializeExtentReport 
in this method we wil create the ExtentHtmlReporter object which will be used to provide a filepath to store the report using our DefaultVariables class 

Add a method to our DefaultVariables class , which will show direct the program to the folder and it will create a .html page 


update the IDefault interface class so that we can inherit the method using 


intializeExtentReport 


Now we can inherit ExtentFeatureReports object within GlobalProperties and use the our intialize method within our Configuration method 
![image](https://github.com/user-attachments/assets/17f370a4-e291-4251-b3a5-0309898f9b8c)

![image](https://github.com/user-attachments/assets/4702382a-7039-402b-9355-5ec86fec1c2f)

Create another class which will he used to create variable requrired for our reports 
![image](https://github.com/user-attachments/assets/c23047f7-3ccb-4796-a3a8-e91c0af35e68)

Create the linked interface for this aswell and allow the inheritance of methods
![image](https://github.com/user-attachments/assets/178d6129-9524-49b5-9b06-e5c6dad37522)

Update the SpecflowRunner and then add globalproperties to the serviceprovider BeforeTest
![image](https://github.com/user-attachments/assets/5541475f-8d8a-45cc-b1e7-dbe13443f724)

Update the Iserviceprovider Interface and add the ExtentReport Interface to the service provider using AddTransient as this will mean each feature report is unique 
![image](https://github.com/user-attachments/assets/7a96fa77-49df-43e5-a246-854827d7fee1)

Within the SpecflowRunner -> Create a BeforeFeature Method which defines the report and the FeatureInfo 
![image](https://github.com/user-attachments/assets/5b083d5a-34fa-4f7e-b509-9ef4a88f2687)

After Scenario - which will be used to close the browser by inherting the CloseBrowser Driver operations method 
![image](https://github.com/user-attachments/assets/9adbf2bb-dd57-4fdb-be07-b17e790de1e9)

Update BeforeScenario so that we aredeclaring extentreport BeforeScenario starts which will allow us to get the scenario info
![image](https://github.com/user-attachments/assets/0639d936-8da5-40d2-9093-5efd25f13855)

Create a new method called AfterStep which will define the StepInfo as Pass or Fail if there is an error after every step
![image](https://github.com/user-attachments/assets/cdce89ad-2251-4b08-b87e-8fa2e3abd7fa)

We need to create a Flush method 

Create our Flush Method within the ExtentFeatureReport class and also declare in our IExtentFeatureReport interface to call the method
![image](https://github.com/user-attachments/assets/3e569101-c203-4b5b-b948-2f54cdfd4e4c)

![image](https://github.com/user-attachments/assets/66dacd5b-0710-4427-b2b6-f86ced3add46)

update AfterScenario within SpecflowBase class 
![image](https://github.com/user-attachments/assets/4de7f93c-4a48-4a45-84bf-104a6b461641)

AfterStep which uses IExtentReport  and will use our ITakescreenshot method 
![image](https://github.com/user-attachments/assets/338b69cf-6be4-45ec-bbca-99c0648866a2)

Update frameworkSettings.json -> StepScreenshot
![image](https://github.com/user-attachments/assets/41683c11-4586-4503-9054-3b0ac25b8d79)


ExtentReport -> Create Methods for status and also using AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
![image](https://github.com/user-attachments/assets/f8fdffa2-51fd-462b-b022-0808499578ea)

IExtentReport -> Methods added to interface 
![image](https://github.com/user-attachments/assets/6dd3a24f-9625-47c9-a89b-38c7b4825af8)

Create a GetScreenshot Method within our Driver class and also add to the interface  
![image](https://github.com/user-attachments/assets/3129eb9d-70f8-44e0-918b-865680050809)

![image](https://github.com/user-attachments/assets/1be1a688-496d-4f23-965f-daeae9726917)

AfterStep which uses IExtentReport  and will use our GetScreenshot Method which is inherted from Idriver
![image](https://github.com/user-attachments/assets/338b69cf-6be4-45ec-bbca-99c0648866a2)


![image](https://github.com/user-attachments/assets/331f8083-a8eb-497c-8179-85f5ced37ad3)

We can also set a scenario to FAIL if it meets certain conditions 
![image](https://github.com/user-attachments/assets/e759e4f5-9795-4815-baca-70097d0f002a)

![image](https://github.com/user-attachments/assets/59feba8a-649a-4330-bb50-f1963881788c)


----------------------

Creating a new test case  

Create a Feature file within our Test Case Folder
![image](https://github.com/user-attachments/assets/16c41ba8-7441-4a95-bd09-b8831b0befd3)

![image](https://github.com/user-attachments/assets/9644edbe-2a7d-47b1-bf8a-cb1f3ebbd321)

**Build project to auto create AddRemoveFromCart.cs file 

Create Steps file 

Right click feature file -> Define Steps 
![image](https://github.com/user-attachments/assets/5be98749-d26a-4600-826e-047191fd9211)

Copy to Clipboard and then create a new class ending in e.g. AddRemoveToCartSteps
![image](https://github.com/user-attachments/assets/01f22406-6ae4-47ae-abf6-974bacab8ce3)

Make your class public and include [Binding] which marks that this class contains step definitions and then paste steps within 
![image](https://github.com/user-attachments/assets/03c5ad24-6889-4d8d-a697-80b2c57f7b15)



Next we will create the new Class within our Page folder called AddRemoveFromCartPage which will contain the Selenium WebDriver instructions
![image](https://github.com/user-attachments/assets/284da816-343c-446e-8eab-39e2a1971bca)

First make your class public and Create a constructor 
![image](https://github.com/user-attachments/assets/9fa2905c-565f-4751-8382-301e37a588a2)

Next we will create our methods which we will use for each steps











