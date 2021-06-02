﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Features.JsonModel
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("JsonDateEquals")]
    public partial class JsonDateEqualsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "JsonDateEquals.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/JsonModel", "JsonDateEquals", "\tValidate the Json Equals operator, equality overrides and hashcode", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for json element backed value as a date")]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("null", "null", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "\"2018-11-13\"", "false", null)]
        public virtual void EqualsForJsonElementBackedValueAsADate(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for json element backed value as a date", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given(string.Format("the JsonElement backed JsonDate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("I compare it to the date {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for dotnet backed value as a date")]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Goodbye\"", "false", null)]
        public virtual void EqualsForDotnetBackedValueAsADate(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for dotnet backed value as a date", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 19
 testRunner.Given(string.Format("the dotnet backed JsonDate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 20
 testRunner.When(string.Format("I compare it to the date {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for date json element backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"2018-11-13\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        public virtual void EqualsForDateJsonElementBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for date json element backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 30
 testRunner.Given(string.Format("the JsonElement backed JsonDate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 31
 testRunner.When(string.Format("I compare the date to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 32
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for date dotnet backed value as an IJsonValue")]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"Garbage\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        public virtual void EqualsForDateDotnetBackedValueAsAnIJsonValue(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for date dotnet backed value as an IJsonValue", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 56
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 57
 testRunner.Given(string.Format("the dotnet backed JsonDate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 58
 testRunner.When(string.Format("I compare the date to the IJsonValue {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 59
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for date json element backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "<new object()>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "null", "false", null)]
        public virtual void EqualsForDateJsonElementBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for date json element backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 83
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 84
 testRunner.Given(string.Format("the JsonElement backed JsonDate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 85
 testRunner.When(string.Format("I compare the date to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 86
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Equals for date dotnet backed value as an object")]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Hello\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"Goodbye\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "1.1", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "[1,2,3]", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "{ \"first\": \"1\" }", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "true", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "false", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13T20:20:39+00:00\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"P3Y6M4DT12H30M5S\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"2018-11-13\"", "true", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"hello@endjin.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"www.example.com\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"http://foo.bar/?baz=qux#quux\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"eyAiaGVsbG8iOiAid29ybGQiIH0=\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"{ \\\"first\\\": \\\"1\\\" }\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"192.168.0.1\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "\"0:0:0:0:0:ffff:c0a8:0001\"", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "<new object()>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "null", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "<null>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("\"2018-11-13\"", "<undefined>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("null", "null", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "<null>", "true", null)]
        [NUnit.Framework.TestCaseAttribute("null", "<undefined>", "false", null)]
        public virtual void EqualsForDateDotnetBackedValueAsAnObject(string jsonValue, string value, string result, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("jsonValue", jsonValue);
            argumentsOfScenario.Add("value", value);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Equals for date dotnet backed value as an object", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 111
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 112
 testRunner.Given(string.Format("the dotnet backed JsonDate {0}", jsonValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 113
 testRunner.When(string.Format("I compare the date to the object {0}", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 114
 testRunner.Then(string.Format("the result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
