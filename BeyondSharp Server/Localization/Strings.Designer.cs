﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeyondSharp.Server.Localization {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BeyondSharp.Server.Localization.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Configuration file does not exist, using default configuration..
        /// </summary>
        internal static string ProgramNoConfiguration {
            get {
                return ResourceManager.GetString("ProgramNoConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command-line arguments have been processed..
        /// </summary>
        internal static string ProgramProcessedCommandLine {
            get {
                return ResourceManager.GetString("ProgramProcessedCommandLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configuration file has been processed..
        /// </summary>
        internal static string ProgramProcessedConfiguration {
            get {
                return ResourceManager.GetString("ProgramProcessedConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reading the program&apos;s command-line..
        /// </summary>
        internal static string ProgramReadingCommandLine {
            get {
                return ResourceManager.GetString("ProgramReadingCommandLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reading the program&apos;s configuration..
        /// </summary>
        internal static string ProgramReadingConfiguration {
            get {
                return ResourceManager.GetString("ProgramReadingConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Saving the program&apos;s configuration..
        /// </summary>
        internal static string ProgramSavingConfiguration {
            get {
                return ResourceManager.GetString("ProgramSavingConfiguration", resourceCulture);
            }
        }
    }
}
