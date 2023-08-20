namespace WebApp.Models.resource {
  using System;
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public class StatusHistory {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StatusHistory() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApp.Models.resource.StatusHistory", typeof(StatusHistory).Assembly);
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
    public static string ORDERKEY {
            get {
                return ResourceManager.GetString("ORDERKEY", resourceCulture);
            }
    }
    public static string SHIPORDERKEY {
            get {
                return ResourceManager.GetString("SHIPORDERKEY", resourceCulture);
            }
    }
    public static string STATUS {
            get {
                return ResourceManager.GetString("STATUS", resourceCulture);
            }
    }
    public static string DESCRIPTION {
            get {
                return ResourceManager.GetString("DESCRIPTION", resourceCulture);
            }
    }
    public static string REMARK {
            get {
                return ResourceManager.GetString("REMARK", resourceCulture);
            }
    }
    public static string TRANSACTIONDATETIME {
            get {
                return ResourceManager.GetString("TRANSACTIONDATETIME", resourceCulture);
            }
    }
    public static string USER {
            get {
                return ResourceManager.GetString("USER", resourceCulture);
            }
    }
    public static string LONGITUDE {
            get {
                return ResourceManager.GetString("LONGITUDE", resourceCulture);
            }
    }
    public static string LATITUDE {
            get {
                return ResourceManager.GetString("LATITUDE", resourceCulture);
            }
    }
 }
}