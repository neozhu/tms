namespace WebApp.Models.resource {
  using System;
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public class Document {
        private static global::System.Resources.ResourceManager resourceMan;
        private static global::System.Globalization.CultureInfo resourceCulture;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Document() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApp.Models.resource.Document", typeof(Document).Assembly);
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
    public static string OrderKey {
            get {
                return ResourceManager.GetString("OrderKey", resourceCulture);
            }
    }
    public static string FileName {
            get {
                return ResourceManager.GetString("FileName", resourceCulture);
            }
    }
    public static string FileType {
            get {
                return ResourceManager.GetString("FileType", resourceCulture);
            }
    }
    public static string Path {
            get {
                return ResourceManager.GetString("Path", resourceCulture);
            }
    }
    public static string Url {
            get {
                return ResourceManager.GetString("Url", resourceCulture);
            }
    }
    public static string MD5 {
            get {
                return ResourceManager.GetString("MD5", resourceCulture);
            }
    }
    public static string Size {
            get {
                return ResourceManager.GetString("Size", resourceCulture);
            }
    }
    public static string Width {
            get {
                return ResourceManager.GetString("Width", resourceCulture);
            }
    }
    public static string Height {
            get {
                return ResourceManager.GetString("Height", resourceCulture);
            }
    }
    public static string Description {
            get {
                return ResourceManager.GetString("Description", resourceCulture);
            }
    }
    public static string User {
            get {
                return ResourceManager.GetString("User", resourceCulture);
            }
    }
    public static string UploadDateTime {
            get {
                return ResourceManager.GetString("UploadDateTime", resourceCulture);
            }
    }
 }
}