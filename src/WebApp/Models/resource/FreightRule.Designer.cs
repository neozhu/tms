namespace WebApp.Models.resource {
  using System;
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public class FreightRule {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FreightRule() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApp.Models.resource.FreightRule", typeof(FreightRule).Assembly);
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
    public static string ORIGINAL {
            get {
                return ResourceManager.GetString("ORIGINAL", resourceCulture);
            }
    }
    public static string DESTINATION {
            get {
                return ResourceManager.GetString("DESTINATION", resourceCulture);
            }
    }
    public static string SHPTYPE {
            get {
                return ResourceManager.GetString("SHPTYPE", resourceCulture);
            }
    }
    public static string CALTYPE {
            get {
                return ResourceManager.GetString("CALTYPE", resourceCulture);
            }
    }
    public static string CARLWT1 {
            get {
                return ResourceManager.GetString("CARLWT1", resourceCulture);
            }
    }
    public static string CARLWT2 {
            get {
                return ResourceManager.GetString("CARLWT2", resourceCulture);
            }
    }
    public static string PRICE {
            get {
                return ResourceManager.GetString("PRICE", resourceCulture);
            }
    }
    public static string MINAMOUNT {
            get {
                return ResourceManager.GetString("MINAMOUNT", resourceCulture);
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
    public static string LOTTABLE1 {
            get {
                return ResourceManager.GetString("LOTTABLE1", resourceCulture);
            }
    }
    public static string LOTTABLE2 {
            get {
                return ResourceManager.GetString("LOTTABLE2", resourceCulture);
            }
    }
    public static string LOTTABLE3 {
            get {
                return ResourceManager.GetString("LOTTABLE3", resourceCulture);
            }
    }
 }
}