﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SC.Recaptcha.Resources {
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
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SC.Recaptcha.Resources.Strings", typeof(Strings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to General error occured. Please try again..
        /// </summary>
        public static string ResponseError_GeneralError {
            get {
                return ResourceManager.GetString("ResponseError_GeneralError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The response parameter is invalid or malformed..
        /// </summary>
        public static string ResponseError_InvalidInputResponse {
            get {
                return ResourceManager.GetString("ResponseError_InvalidInputResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The secret parameter is invalid or malformed..
        /// </summary>
        public static string ResponseError_InvalidInputSecret {
            get {
                return ResourceManager.GetString("ResponseError_InvalidInputSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The response parameter is missing..
        /// </summary>
        public static string ResponseError_MissingInputResponse {
            get {
                return ResourceManager.GetString("ResponseError_MissingInputResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The secret parameter is missing..
        /// </summary>
        public static string ResponseError_MissingInputSecret {
            get {
                return ResourceManager.GetString("ResponseError_MissingInputSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you&apos;re not a robot?.
        /// </summary>
        public static string ResponseError_ValidationFailed {
            get {
                return ResourceManager.GetString("ResponseError_ValidationFailed", resourceCulture);
            }
        }
    }
}
