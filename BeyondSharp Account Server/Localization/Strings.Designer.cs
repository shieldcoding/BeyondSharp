﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeyondSharp.AccountServer.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BeyondSharp.AccountServer.Localization.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The required values were not supplied..
        /// </summary>
        internal static string LoginBadArguments {
            get {
                return ResourceManager.GetString("LoginBadArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The login attempt failed..
        /// </summary>
        internal static string LoginInvalid {
            get {
                return ResourceManager.GetString("LoginInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no account with that username..
        /// </summary>
        internal static string LoginNoAccount {
            get {
                return ResourceManager.GetString("LoginNoAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The login attempt was successful..
        /// </summary>
        internal static string LoginOK {
            get {
                return ResourceManager.GetString("LoginOK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The required values were not supplied..
        /// </summary>
        internal static string VerifyBadArguments {
            get {
                return ResourceManager.GetString("VerifyBadArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The client&apos;s token has expired..
        /// </summary>
        internal static string VerifyExpired {
            get {
                return ResourceManager.GetString("VerifyExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The client is not authenticated..
        /// </summary>
        internal static string VerifyInvalid {
            get {
                return ResourceManager.GetString("VerifyInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no account with that username..
        /// </summary>
        internal static string VerifyNoAccount {
            get {
                return ResourceManager.GetString("VerifyNoAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The client was verified successfully..
        /// </summary>
        internal static string VerifyOK {
            get {
                return ResourceManager.GetString("VerifyOK", resourceCulture);
            }
        }
    }
}