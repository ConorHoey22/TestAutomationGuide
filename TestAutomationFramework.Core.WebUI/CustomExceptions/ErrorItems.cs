using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.CustomExceptions
{
    public enum ErrorItems
    {
        None, // No error
        InvalidDBCredentials,
        InvalidKlovReportCredential,
        ScenerioNotFound,
        InvalidSQLQueryException,
        StepDefinitionNotFound, // Step definition missing for a scenario step
        ScenarioOutlineMismatch, // Mismatch between scenario outline and provided examples
        InvalidStepArgument, // Incorrect or invalid step argument passed
        FeatureFileParseError, // Error while parsing the feature file
        UndefinedStep, // Step is undefined in the feature file
        BindingError, // Error in binding attribute or method
        PendingStep, // Step is marked as 'pending'
        InconclusiveStep, // Step marked as inconclusive
        DuplicateStepDefinition, // Duplicate step definition found
        TestExecutionTimeout, // Test execution exceeded the time limit
        HookFailure, // Before/After hook failed
        ScenarioExecutionError, // Error during scenario execution
        DataTableConversionError, // Error converting table data in scenario
        MissingScenarioContext, // Missing or null scenario context
        TestRunnerInitializationError, // Issue with test runner initialization
        ScenarioSkipped, // Scenario was skipped
        BackgroundStepFailure // Failure in background steps before the scenario
    }
}
