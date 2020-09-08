//----------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject
{
    public sealed class UserPasswordCredential : UserCredential
    {
        internal SecureString SecurePassword { get; private set; }

        internal string Password { get; }

        /// <summary>
        /// Constructor to create credential with client id and secret
        /// </summary>
        /// <param name="userName">Identifier of the user application requests token on behalf.</param>
        /// <param name="password">User password.</param>
        public UserPasswordCredential(string userName, string password) : base(userName)
        {
            this.Password = password;
        }

        /// <summary>
        /// Constructor to create credential with client id and secret
        /// </summary>
        /// <param name="userName">Identifier of the user application requests token on behalf.</param>
        /// <param name="securePassword">User password.</param>
        public UserPasswordCredential(string userName, SecureString securePassword) : base(userName)
        {
            this.SecurePassword = securePassword;
        }

        internal char[] PasswordToCharArray()
        {
            if (SecurePassword != null)
            {
                var output = new char[SecurePassword.Length];
                IntPtr secureStringPtr = Marshal.SecureStringToCoTaskMemUnicode(SecurePassword);
                for (var i = 0; i < SecurePassword.Length; i++)
                {
                    output[i] = (char)Marshal.ReadInt16(secureStringPtr, i * 2);
                }

                Marshal.ZeroFreeCoTaskMemUnicode(secureStringPtr);
                return output;
            }

            return Password?.ToCharArray();
        }

        //internal void ApplyTo(DictionaryRequestParameters requestParameters)
        //{
        //    requestParameters[OAuthParameter.GrantType] = OAuthGrantType.Password;
        //    requestParameters[OAuthParameter.Username] = this.UserName;
        //    requestParameters[OAuthParameter.Password] = new string(PasswordToCharArray());

        //    if (SecurePassword != null && !SecurePassword.IsReadOnly())
        //    {
        //        SecurePassword.Clear();
        //    }

        //    SecurePassword = null;
        //}
    }
}
