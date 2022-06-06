// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using ApiStudioIO.VsOptions.General;
using ApiStudioIO.VsOptions.HttpHeaders;
using ApiStudioIO.VsOptions.HttpResponseCodes;
using ApiStudioIO.VsOptions.HttpSecurity;
using ApiStudioIO.VsOptions.HttpSpecification;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO
{
    [ProvideOptionPage(typeof(GeneralDialogPage), "Api Studio", "General", 0, 0, true)]
    [ProvideOptionPage(typeof(SpecificationDialogPage), "Api Studio", "Api Specification", 0, 0, true)]
    [ProvideOptionPage(typeof(SecurityDialogPage), "Api Studio", "Api Security", 0, 0, true)]
    [ProvideOptionPage(typeof(HttpResponseCodesDialogPage), "Api Studio", "HTTP Response Codes", 0, 0, true)]
    [ProvideOptionPage(typeof(HttpHeadersDialogPage), "Api Studio", "HTTP Headers", 0, 0, true)]
    internal sealed partial class ApiStudioIOPackage
    {
    }
}