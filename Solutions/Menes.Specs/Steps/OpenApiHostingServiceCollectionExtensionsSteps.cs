﻿// <copyright file="OpenApiHostingServiceCollectionExtensionsSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Menes.Auditing;
    using Menes.Auditing.AuditLogSinks.Development;
    using Menes.Auditing.Internal;
    using Menes.Hal;
    using Menes.Specs.Steps.TestClasses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiHostingServiceCollectionExtensionsSteps
    {
        private readonly ScenarioContext scenarioContext;

        public OpenApiHostingServiceCollectionExtensionsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I have created a service collection to register my services against")]
        public void GivenIHaveCreatedAServiceCollectionToRegisterMyServicesAgainst()
        {
            this.scenarioContext.Set(new ServiceCollection());
        }

        [Given("I have added AspNetCore OpenApi hosting to the service collection")]
        [When("I add AspNetCore OpenApi hosting to the service collection")]
        public void WhenIAddOpenApiHostingToTheServiceCollection()
        {
            ServiceCollection collection = this.scenarioContext.Get<ServiceCollection>();

            collection.AddLogging();
            collection.AddOpenApiHttpRequestHosting<SimpleOpenApiContext>(config => { }, null);
        }

        [Given("I have built the service provider from the service collection")]
        public void GivenIHaveBuiltTheServiceCollection()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceCollection>().BuildServiceProvider();
            this.scenarioContext.Set(provider);
        }

        [Given("I have registered a HalDocumentMapper for a resource type to the service collection")]
        [When("I register a HalDocumentMapper for a resource type to the service collection")]
        public void WhenIRegisterAHalDocumentMapperForAResourceTypeToTheServiceCollection()
        {
            this.scenarioContext.Get<ServiceCollection>().AddHalDocumentMapper<Pet, PetHalDocumentMapper>();
        }

        [Given("I have registered a HalDocumentMapper for a resource and context type to the service collection")]
        [When("I register a HalDocumentMapper for a resource and context type to the service collection")]
        public void WhenIAddAHalDocumentMapperForAResourceAndContextTypeToTheServiceCollection()
        {
            this.scenarioContext.Get<ServiceCollection>()
                .AddHalDocumentMapper<Pet, MappingContext, PetHalDocumentMapperWithContext>();
        }

        [Then("a service is added as a Singleton for type IOpenApiHost{HttpRequest, IActionResult}")]
        public void ThenAServiceIsAddedAsASingletonForTypeIOpenApiHostHttpRequestIActionResult()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>()
                .FirstOrDefault(x => x.ServiceType == typeof(IOpenApiHost<HttpRequest, IActionResult>));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then("it should be added as a Singleton with the service type matching the concrete type of the mapper")]
        public void ThenItShouldBeAddedAsASingletonWithTheServiceTypeMatchingTheMapperType()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>()
                .FirstOrDefault(x => x.ServiceType == typeof(PetHalDocumentMapper));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then("it should be added as a Singleton with the service type matching the concrete type of the mapper with context")]
        public void ThenItShouldBeAddedAsASingletonWithTheServiceTypeMatchingTheMapperTypeWithContext()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>()
                .FirstOrDefault(x => x.ServiceType == typeof(PetHalDocumentMapperWithContext));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then("It should be added as a Singleton with a service type of IHalDocumentMapper")]
        public void ThenItShouldBeAddedAsASingletonWithAServiceTypeOfIHalDocumentMapper()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>()
                .FirstOrDefault(x => x.ServiceType == typeof(IHalDocumentMapper));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then("it should be added as a Singleton with a service type of IHalDocumentMapper{TResource}")]
        public void ThenItShouldBeAddedAsASingletonWithAServiceTypeOfIHalDocumentMapperTResource()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>()
                .FirstOrDefault(x => x.ServiceType == typeof(IHalDocumentMapper<Pet>));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [Then("it should be added as a Singleton with a service type of IHalDocumentMapper{TResource, TContext}")]
        public void ThenItShouldBeAddedAsASingletonWithAServiceTypeOfIHalDocumentMapperWithResourceAndContext()
        {
            ServiceDescriptor registration = this.scenarioContext.Get<ServiceCollection>()
                .FirstOrDefault(x => x.ServiceType == typeof(IHalDocumentMapper<Pet, MappingContext>));
            Assert.NotNull(registration);
            Assert.AreEqual(ServiceLifetime.Singleton, registration.Lifetime);
        }

        [When("I request an instance of the OpenApi host")]
        public void WhenIRequestAnInstanceOfTheOpenApiHost()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();
            IOpenApiHost<HttpRequest, IActionResult> host = 
                provider.GetRequiredService<IOpenApiHost<HttpRequest, IActionResult>>();

            this.scenarioContext.Set(host);
        }

        [Then("the HalDocumentMapper for resource type has configured its links")]
        public void ThenTheHalDocumentMapperForResourceTypeHasConfiguredItsLinks()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();
            PetHalDocumentMapper mapper = provider.GetRequiredService<PetHalDocumentMapper>();
            Assert.IsTrue(mapper.LinkMapConfigured);
        }

        [Then("the HalDocumentMapper for resource and context types has configured its links")]
        public void ThenTheHalDocumentMapperForResourceAndContextTypesHasConfiguredItsLinks()
        {
            ServiceProvider provider = this.scenarioContext.Get<ServiceProvider>();
            PetHalDocumentMapperWithContext mapper = provider.GetRequiredService<PetHalDocumentMapperWithContext>();
            Assert.IsTrue(mapper.LinkMapConfigured);
        }

        [Then("the exception of type '(.*)' is mapped to response code '(.*)'")]
        public void ThenTheExceptionOfTypeIsMappedToResponseCode(string exceptionType, int statusCode)
        {
            IOpenApiExceptionMapper exceptionMapper = this.scenarioContext.Get<ServiceProvider>()
                .GetRequiredService<IOpenApiExceptionMapper>();

            // The only way to tell if it's been mapped without reflecting into the guts of the mapper is to try and register
            // a new mapper for the given type/status code... even with this we need a little bit of reflection to invoke the
            // method.
            var type = Type.GetType(exceptionType);
            MethodInfo mapMethod = exceptionMapper
                .GetType()
                .GetMethods()
                .First(x => x.Name == "Map" && x.GetGenericArguments().Length == 1);
            
            MethodInfo createdMapMethod = mapMethod.MakeGenericMethod(type);

            try
            {
                createdMapMethod.Invoke(exceptionMapper, new object[] { statusCode, null });

                Assert.Fail($"Exception of type '{exceptionType}' was not registered");
            }
            catch (TargetInvocationException ex) when (ex.InnerException is ArgumentException)
            {
                // This is the expected exception result, so swallow to let the test pass. Anything
            }
        }

        [Then("an audit log builder service is added for auditing operations which return OpenApiResults")]
        public void ThenAnAuditLogBuilderServiceIsAddedForAuditingOperationsWhichReturnOpenApiResults()
        {
            this.AssertServiceIsRegistered<IAuditLogBuilder, OpenApiResultAuditLogBuilder>();
        }

        [Then("an audit log builder service is added for auditing operations which return a POCO")]
        public void ThenAnAuditLogBuilderServiceIsAddedForAuditingOperationsWhichReturnAPOCO()
        {
            this.AssertServiceIsRegistered<IAuditLogBuilder, PocoAuditLogBuilder>();
        }

        [Then("an audit log sink service is added for console logging")]
        public void ThenAnAuditLogSinkServiceIsAddedForConsoleLogging()
        {
            this.AssertServiceIsRegistered<IAuditLogSink, ConsoleAuditLogSink>();
        }

        [Then("auditing is enabled")]
        public void ThenAuditingIsEnabled()
        {
            IAuditContext auditContext = this.scenarioContext.Get<ServiceProvider>().GetRequiredService<IAuditContext>();
            Assert.IsTrue(auditContext.IsAuditingEnabled);
        }

        private void AssertServiceIsRegistered<TService, TImplementation>()
        {
            bool expectedServiceIsRegistered = this.scenarioContext.Get<ServiceCollection>()
                .Any(x => x.ServiceType == typeof(TService) && x.ImplementationType == typeof(TImplementation));
            Assert.IsTrue(expectedServiceIsRegistered);
        }
    }
}
