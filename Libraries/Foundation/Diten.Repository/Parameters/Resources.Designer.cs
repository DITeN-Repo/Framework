﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diten.Parameters {
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Diten.Parameters.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to 0,Null character,
        ///1,Start of Header,
        ///2,&quot;End of Text, hearts card suit&quot;,&amp;hearts;
        ///3,End of Text,
        ///4,&quot;End of Transmission, diamonds card suit&quot;,&amp;diams;
        ///5,&quot;Enquiry, clubs card suit&quot;,&amp;clubs;
        ///6,&quot;Acknowledgement, spade card suit&quot;,&amp;spades;
        ///7,Bell,
        ///8,Backspace,
        ///9,Horizontal Tab,
        ///10,Line feed,&amp;NewLine;
        ///11,&quot;Vertical Tab, male symbol, symbol for Mars&quot;,&amp;male;
        ///12,&quot;Form feed, female symbol, symbol for Venus&quot;,&amp;female;
        ///13,Carriage return,
        ///14,Shift Out,
        ///15,Shift In,
        ///16,Data link escape,
        ///17,Device control 1,
        ///1 [rest of string was truncated]&quot;;.
        /// </summary>
        public static System.String AsciiTable {
            get {
                return ResourceManager.GetString("AsciiTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        public static byte[] KeySource {
            get {
                object obj = ResourceManager.GetObject("KeySource", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///
        ///&lt;Task version=&quot;1.2&quot; xmlns=&quot;http://schemas.microsoft.com/windows/2004/02/mit/task&quot;&gt;
        ///	&lt;RegistrationInfo&gt;
        ///		&lt;Date&gt;2017-03-05T15:55:05.0461087&lt;/Date&gt;
        ///		&lt;Author&gt;DITeN Corporation.&lt;/Author&gt;
        ///		&lt;Version&gt;1.0.0&lt;/Version&gt;
        ///		&lt;Description&gt;Import %SiteName% IIS logs into database.&lt;/Description&gt;
        ///	&lt;/RegistrationInfo&gt;
        ///	&lt;Triggers&gt;
        ///		&lt;CalendarTrigger&gt;
        ///			&lt;StartBoundary&gt;2017-03-05T00:01:00&lt;/StartBoundary&gt;
        ///			&lt;Enabled&gt;true&lt;/Enabled&gt;
        ///			&lt;ScheduleByDay&gt;
        ///				&lt;DaysInterval&gt;1&lt;/Da [rest of string was truncated]&quot;;.
        /// </summary>
        public static System.String Manifest000 {
            get {
                return ResourceManager.GetString("Manifest000", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;C:\Program Files (x86)\Log Parser 2.2\logparser&quot; &quot;SELECT * INTO W3SVC%1 FROM %2\W3SVC%1\*.log&quot; -i:iisw3c -o:SQL -server:localhost -database:DTDB003V100 -username:IISLOGUSR -password:85kE47Ck6G67hJNyA3J6RDrR6mEpuJn4gNEyC9v3Ka6n68Tf5c -createTable: ON
        ///erase C:\inetpub\logs\LogFiles\W3SVC2\*.log.
        /// </summary>
        public static System.String Script000 {
            get {
                return ResourceManager.GetString("Script000", resourceCulture);
            }
        }
    }
}
