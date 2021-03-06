﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.VisualBasic;

namespace Microsoft.CodeAnalysis.Testing
{
    internal class VisualBasicAnalyzerTest<TAnalyzer> : AnalyzerTest<DefaultVerifier>
        where TAnalyzer : DiagnosticAnalyzer, new()
    {
        public override string Language => LanguageNames.VisualBasic;

        protected override string DefaultFileExt => "vb";

        protected override CompilationOptions CreateCompilationOptions()
            => new VisualBasicCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

        protected override ParseOptions CreateParseOptions()
            => new VisualBasicParseOptions(LanguageVersion.Default, DocumentationMode.Diagnose);

        protected override IEnumerable<DiagnosticAnalyzer> GetDiagnosticAnalyzers()
        {
            yield return new TAnalyzer();
        }
    }
}
