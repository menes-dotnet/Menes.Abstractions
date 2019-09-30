﻿// <copyright file="DiffCSharp.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ServiceBuilder.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using McMaster.Extensions.CommandLineUtils;
    using Menes.ServiceBuilder.Internal;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Command to build a service in CSharp, from an OpenAPI document.
    /// </summary>
    [Command(Name = "diff-csharp", Description = "Find differences between the OpenApi documentation and the csharp implementation of the service.", ThrowOnUnexpectedArgument = false, ShowInHelpText = true)]
    [HelpOption]
    internal class DiffCSharp
    {
        /// <summary>
        /// Gets or sets a value indicating the OpenAPI document to load.
        /// </summary>
        [Option(Description = "The path to the OpenAPI document to load", LongName = "document", ShortName = "d")]
        [FileExists]
        public string OpenApiDocumentPath { get; set; }

        /// <summary>
        /// Gets or sets the path to the directory containing the output project files.
        /// </summary>
        [Option(Description = "The path to the directory for the project files", LongName = "output", ShortName = "o")]
        [DirectoryExists]
        public string ProjectDirectory { get; set; }

        /// <summary>
        /// Gets or sets the root namespace to use for the output.
        /// </summary>
        [Option(Description = "The root namespace to use for the output.", LongName = "namespace", ShortName = "n")]
        public string Namespace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Conventional form for command line application.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Conventional form for command line application.")]
        private async Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken = default)
        {
            if (!OpenApiDocumentTasks.TryLoadOpenApiDocument(app, this.OpenApiDocumentPath, out OpenApiDocument openApiDocument))
            {
                return -1;
            }

            return await Task.FromResult(0).ConfigureAwait(false);
        }
    }
}
