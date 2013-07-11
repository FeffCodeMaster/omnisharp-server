using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem;
using OmniSharp.AutoComplete.Overrides;

namespace OmniSharp.AutoComplete.Overrides {

    public class GetOverrideTargetsResponse {

        public GetOverrideTargetsResponse() {}

        public GetOverrideTargetsResponse
            ( IMember m
            , CSharpTypeResolveContext resolveContext) {
            if (resolveContext == null)
                throw new ArgumentNullException("resolveContext");

            if (m == null)
                throw new ArgumentNullException("m");

            var builder = new TypeSystemAstBuilder
                (new CSharpResolver(resolveContext));

            this.OverrideTargetName =
                builder.ConvertEntity(m).GetText()
                // Builder automatically adds a trailing newline
                .TrimEnd(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        ///   A human readable signature of the member that is to be
        ///   overridden.
        /// </summary>
        public string OverrideTargetName {get; set;}

    }

}
