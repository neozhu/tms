namespace WebApp.Models.resource {
  using System;
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public class SUPPLIER {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SUPPLIER() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApp.Models.resource.SUPPLIER", typeof(SUPPLIER).Assembly);
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
    public static string ID {
            get {
                return ResourceManager.GetString("ID", resourceCulture);
            }
    }
    public static string SUPPLIERCODE {
            get {
                return ResourceManager.GetString("SUPPLIERCODE", resourceCulture);
            }
    }
    public static string SUPPLIERNAME {
            get {
                return ResourceManager.GetString("SUPPLIERNAME", resourceCulture);
            }
    }
    public static string ISDISABLED {
            get {
                return ResourceManager.GetString("ISDISABLED", resourceCulture);
            }
    }
    public static string ADDRESS1 {
            get {
                return ResourceManager.GetString("ADDRESS1", resourceCulture);
            }
    }
    public static string ADDRESS2 {
            get {
                return ResourceManager.GetString("ADDRESS2", resourceCulture);
            }
    }
    public static string CONTACT {
            get {
                return ResourceManager.GetString("CONTACT", resourceCulture);
            }
    }
    public static string PHONENUMBER {
            get {
                return ResourceManager.GetString("PHONENUMBER", resourceCulture);
            }
    }
    public static string EMAIL {
            get {
                return ResourceManager.GetString("EMAIL", resourceCulture);
            }
    }
    public static string NOTES {
            get {
                return ResourceManager.GetString("NOTES", resourceCulture);
            }
    }
 }
}