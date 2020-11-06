﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("JsonReference")]
    public partial class JsonReferenceFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "JsonReference.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "JsonReference", "\tIn order to make use of RF3986 compliant referencing when working with JSON\r\n\tAs" +
                    " a developer\r\n\tI want to support JsonReference resolution.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Apply references to an absolute base (normal examples)")]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g:h", "g:h", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g", "http://a/b/c/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "./g", "http://a/b/c/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g/", "http://a/b/c/g/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "/g", "http://a/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "//g", "http://g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "?y", "http://a/b/c/d;p?y", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g?y", "http://a/b/c/g?y", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "#s", "http://a/b/c/d;p?q#s", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g#s", "http://a/b/c/g#s", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g?y#s", "http://a/b/c/g?y#s", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", ";x", "http://a/b/c/;x", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g;x", "http://a/b/c/g;x", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g;x?y#s", "http://a/b/c/g;x?y#s", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "", "http://a/b/c/d;p?q", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", ".", "http://a/b/c/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "./", "http://a/b/c/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "..", "http://a/b/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../", "http://a/b/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../g", "http://a/b/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../..", "http://a/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../../", "http://a/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../../g", "http://a/g", null)]
        public virtual void ApplyReferencesToAnAbsoluteBaseNormalExamples(string @base, string @ref, string applied, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("base", @base);
            argumentsOfScenario.Add("ref", @ref);
            argumentsOfScenario.Add("applied", applied);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Apply references to an absolute base (normal examples)", null, tagsOfScenario, argumentsOfScenario);
#line 6
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
#line 7
 testRunner.When(string.Format("I apply \"{0}\" to the base reference \"{1}\"", @ref, @base), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("the applied reference will be \"{0}\"", applied), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Apply references to an absolute base (abnormal examples)")]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../../../g", "http://a/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "../../../../g", "http://a/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "/./g", "http://a/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "/../g", "http://a/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g.", "http://a/b/c/g.", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", ".g", "http://a/b/c/.g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g..", "http://a/b/c/g..", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "..g", "http://a/b/c/..g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "./../g", "http://a/b/g", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "./g/.", "http://a/b/c/g/", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g/./h", "http://a/b/c/g/h", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g/../h", "http://a/b/c/h", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g;x=1/./y", "http://a/b/c/g;x=1/y", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g;x=1/../y", "http://a/b/c/y", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g?y/./x", "http://a/b/c/g?y/./x", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g?y/../x", "http://a/b/c/g?y/../x", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g#s/./x", "http://a/b/c/g#s/./x", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "g#s/../x", "http://a/b/c/g#s/../x", null)]
        public virtual void ApplyReferencesToAnAbsoluteBaseAbnormalExamples(string @base, string @ref, string applied, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("base", @base);
            argumentsOfScenario.Add("ref", @ref);
            argumentsOfScenario.Add("applied", applied);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Apply references to an absolute base (abnormal examples)", null, tagsOfScenario, argumentsOfScenario);
#line 36
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
#line 37
 testRunner.When(string.Format("I apply \"{0}\" to the base reference \"{1}\"", @ref, @base), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then(string.Format("the applied reference will be \"{0}\"", applied), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Apply references to an absolute base (backwards compatibility)")]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "http:g", "http:g", "true", null)]
        [NUnit.Framework.TestCaseAttribute("http://a/b/c/d;p?q", "http:g", "http://a/b/c/g", "false", null)]
        public virtual void ApplyReferencesToAnAbsoluteBaseBackwardsCompatibility(string @base, string @ref, string applied, string strict, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("base", @base);
            argumentsOfScenario.Add("ref", @ref);
            argumentsOfScenario.Add("applied", applied);
            argumentsOfScenario.Add("strict", strict);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Apply references to an absolute base (backwards compatibility)", null, tagsOfScenario, argumentsOfScenario);
#line 61
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
#line 62
 testRunner.When(string.Format("I apply \"{0}\" to the base reference \"{1}\" using {2}", @ref, @base, strict), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.Then(string.Format("the applied reference will be \"{0}\"", applied), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
