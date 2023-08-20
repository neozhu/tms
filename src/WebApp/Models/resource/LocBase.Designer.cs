﻿namespace WebApp.Models.resource {
  using System;
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public class LocBase {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocBase() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApp.Models.resource.LocBase", typeof(LocBase).Assembly);
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
    public static string Id {
            get {
                return ResourceManager.GetString("Id", resourceCulture);
            }
    }
    public static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
    }
    public static string Description {
            get {
                return ResourceManager.GetString("Description", resourceCulture);
            }
    }
    public static string Longitude {
            get {
                return ResourceManager.GetString("Longitude", resourceCulture);
            }
    }
    public static string Latitude {
            get {
                return ResourceManager.GetString("Latitude", resourceCulture);
            }
    }
    public static string Radius {
            get {
                return ResourceManager.GetString("Radius", resourceCulture);
            }
    }
    public static string Gid {
            get {
                return ResourceManager.GetString("Gid", resourceCulture);
            }
    }
    public static string Enable {
            get {
                return ResourceManager.GetString("Enable", resourceCulture);
            }
    }
 }
}