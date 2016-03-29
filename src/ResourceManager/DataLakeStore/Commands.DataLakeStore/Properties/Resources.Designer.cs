﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.DataLakeStore.Properties {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [DebuggerNonUserCode()]
    [CompilerGenerated()]
    internal class Resources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static CultureInfo resourceCulture;
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (ReferenceEquals(resourceMan, null)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Microsoft.Azure.Commands.DataLakeStore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot perform the requested operation because the specified account &apos;{0}&apos; does not exist..
        /// </summary>
        internal static string AccountDoesNotExist {
            get {
                return ResourceManager.GetString("AccountDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DataLakeStore account with name &apos;{0}&apos; already exists..
        /// </summary>
        internal static string DataLakeStoreAccountExists {
            get {
                return ResourceManager.GetString("DataLakeStoreAccountExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;default &quot;.
        /// </summary>
        internal static string DefaultAclWord {
            get {
                return ResourceManager.GetString("DefaultAclWord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find account: &apos;{0}&apos; in any resource group in the currently selected subscription: {1}. Please ensure this account exists and that the current user has access to it..
        /// </summary>
        internal static string FailedToDiscoverResourceGroup {
            get {
                return ResourceManager.GetString("FailedToDiscoverResourceGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source path &apos;{0}&apos; does not exist or the current user cannot access it. Ensure the path exists and is accessible and try again..
        /// </summary>
        internal static string FileOrFolderDoesNotExist {
            get {
                return ResourceManager.GetString("FileOrFolderDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The remaining data to preview is greater than {0} bytes. Please specify a length or use the Force parameter to preview the entire file. The length of the file that would have been previewed: {1}.
        /// </summary>
        internal static string FilePreviewTooLarge {
            get {
                return ResourceManager.GetString("FilePreviewTooLarge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid ACE returned. Expected ACE format: &apos;[default]:&lt;scope&gt;:&lt;identity&gt;:&lt;permissions&gt;&apos;. Actual ACE: {0}.
        /// </summary>
        internal static string InvalidAce {
            get {
                return ResourceManager.GetString("InvalidAce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid content passed in. Only byte[] and string content is supported. If bytes are passed in, &apos;Byte&apos; encoding must be selected..
        /// </summary>
        internal static string InvalidContent {
            get {
                return ResourceManager.GetString("InvalidContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid encoding selected. &apos;Byte&apos; encoding can only be used with byte content. Use text encoding instead..
        /// </summary>
        internal static string InvalidEncoding {
            get {
                return ResourceManager.GetString("InvalidEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The path &apos;{0}&apos; either does not exist or is not a file. This cmdlet can only export individual files that exist in ADL.
        /// </summary>
        internal static string InvalidExportPathType {
            get {
                return ResourceManager.GetString("InvalidExportPathType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid file path: {0}. Files cannot end in &apos;/&apos; or &apos;\\&apos;. If creating a folder please use the -Folder flag.
        /// </summary>
        internal static string InvalidFilePath {
            get {
                return ResourceManager.GetString("InvalidFilePath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source and destination path type must be the same. Both paths must be webhdfs compliant paths..
        /// </summary>
        internal static string InvalidMovePathTypeCombination {
            get {
                return ResourceManager.GetString("InvalidMovePathTypeCombination", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid ACE Supplied. Expected ACE format: &apos;[default]:&lt;scope&gt;:&lt;identity&gt;:&lt;permissions&gt;&apos;. Actual ACE: {0}. Note: parsing is only supported for user and group ACEs. The mask and other permissions are set through Set-AzureDataLakeItemOwner.
        /// </summary>
        internal static string InvalidParseAce {
            get {
                return ResourceManager.GetString("InvalidParseAce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified path &apos;{0}&apos; is in an invalid format. The valid formats is an account relative full path: &apos;/someFolder/someFile.txt&apos;, &apos;/&apos; (for the root). Please enter the path in valid format and try again.&quot;.
        /// </summary>
        internal static string InvalidPath {
            get {
                return ResourceManager.GetString("InvalidPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permission values must be in Octal form and in the range of 0 to 777, inclusive. &apos;{0}&apos; falls outside this range..
        /// </summary>
        internal static string InvalidPermissionOctalRange {
            get {
                return ResourceManager.GetString("InvalidPermissionOctalRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The permissions string &apos;{0}&apos; is invalid. It must either be in octal form (e.g 777) or in standard posix format (e.g. &apos;rwxrwxrwx&apos;).
        /// </summary>
        internal static string InvalidPermissionString {
            get {
                return ResourceManager.GetString("InvalidPermissionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid permission type &apos;{0}&apos; selected..
        /// </summary>
        internal static string InvalidPermissionType {
            get {
                return ResourceManager.GetString("InvalidPermissionType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source and destination path type cannot be the same. One must be webhdfs qualified and the other a local or network path..
        /// </summary>
        internal static string InvalidSourceDestinationPathTypeCombination {
            get {
                return ResourceManager.GetString("InvalidSourceDestinationPathTypeCombination", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The destination path &apos;{0}&apos; already exists. Please set overwrite to true or use the force switch in order to overwrite this file.
        /// </summary>
        internal static string LocalFileAlreadyExists {
            get {
                return ResourceManager.GetString("LocalFileAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DataLakeStore account operation failed with the following error code: {0} and message: {1}.
        /// </summary>
        internal static string LongRunningOperationFailed {
            get {
                return ResourceManager.GetString("LongRunningOperationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to move source: &apos;{0}&apos; to destination: &apos;{1}&apos;. Please ensure the file or folder exists at the source and that the destination does not or force was used..
        /// </summary>
        internal static string MoveFailed {
            get {
                return ResourceManager.GetString("MoveFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing DataLakeStore account &apos;{0}&apos; ....
        /// </summary>
        internal static string RemoveDataLakeStoreAccount {
            get {
                return ResourceManager.GetString("RemoveDataLakeStoreAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing Data Lake file or folder at path: &apos;{0}&apos; ....
        /// </summary>
        internal static string RemoveDataLakeStoreItem {
            get {
                return ResourceManager.GetString("RemoveDataLakeStoreItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing {0}DataLake ACL at path: &apos;{1}&apos; ....
        /// </summary>
        internal static string RemoveDataLakeStoreItemAcl {
            get {
                return ResourceManager.GetString("RemoveDataLakeStoreItemAcl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove DataLakeStore account &apos;{0}&apos;?.
        /// </summary>
        internal static string RemovingDataLakeStoreAccount {
            get {
                return ResourceManager.GetString("RemovingDataLakeStoreAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Data Lake item at path: &apos;{0}&apos;?.
        /// </summary>
        internal static string RemovingDataLakeStoreItem {
            get {
                return ResourceManager.GetString("RemovingDataLakeStoreItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the {0}DataLake ACL at path: &apos;{1}&apos;?.
        /// </summary>
        internal static string RemovingDataLakeStoreItemAcl {
            get {
                return ResourceManager.GetString("RemovingDataLakeStoreItemAcl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The script file at path &apos;{0}&apos; does not exist or the current user does not have permission to it. Please ensure the path exists and is accessible..
        /// </summary>
        internal static string ScriptFilePathDoesNotExist {
            get {
                return ResourceManager.GetString("ScriptFilePathDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The destination path &apos;{0}&apos; already exists in the system. To overwrite this location, use the -Force parameter..
        /// </summary>
        internal static string ServerFileAlreadyExists {
            get {
                return ResourceManager.GetString("ServerFileAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setting the Data Lake file or folder ACL at path: &apos;{0}&apos; ....
        /// </summary>
        internal static string SetDataLakeStoreItemAcl {
            get {
                return ResourceManager.GetString("SetDataLakeStoreItemAcl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setting the Data Lake file or folder owning group or user at path: &apos;{0}&apos; ....
        /// </summary>
        internal static string SetDataLakeStoreItemOwner {
            get {
                return ResourceManager.GetString("SetDataLakeStoreItemOwner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The entry or entries you provided may already exist in the item&apos;s ACL. Are you sure you want to overwrite the existing entry or entries at item path &apos;{0}&apos;?.
        /// </summary>
        internal static string SettingDataLakeStoreItemAcl {
            get {
                return ResourceManager.GetString("SettingDataLakeStoreItemAcl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to replace the existing owning group or user at the Data Lake item at path: &apos;{0}&apos;?.
        /// </summary>
        internal static string SettingDataLakeStoreItemOwner {
            get {
                return ResourceManager.GetString("SettingDataLakeStoreItemOwner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operation is being cancelled, please wait....
        /// </summary>
        internal static string TaskCancelledMessage {
            get {
                return ResourceManager.GetString("TaskCancelledMessage", resourceCulture);
            }
        }
    }
}
