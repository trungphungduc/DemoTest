public class Constants
{

    // Extension Files
    public static string[] CONFIGIMAGEEXTENSION = { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".ico" };
    public static string[] CONFIGFLASHEXTENSION = { ".swf" };
    public static string[] CONFIGMEDIAEXTENSION = { ".avi", ".mp3", ".mp4", ".mpg3", ".mpg4", ".wma", ".wmv", ".avi", ".wav" };
    public static string[] CONFIGVALIDEXTENSION = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".swf", ".txt", ".flv", ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".rar", ".zip", ".chm", ".ppt", ".pptx", ".rtf", ".avi", ".mp3", ".mp4", ".mpg3",
            ".mpg4", ".wma", ".wmv", ".avi", ".wav", ".PPS", ".ogg", ".tif", ".tiff", ".jpe", ".jfif", ".dib", ".ico" };
    public static string[] CONFIGPDFEXTENSION = { ".pdf" };

    // Token default time out
    public const int CONST_DEFAULT_TOKEN_TIME_OUT = -24;

    // FORMAT DATE
    public const string DEFAULT_DATE_FORMAT = "dd-MM-yyyy";

    //========================================================================
    // Session
    //========================================================================
    // System
    public static string SESSION_KEY_LOGIN_SYSTEM_ADMIN_ID = "SESSION_KEY_LOGIN_SYSTEM_ADMIN_ID";
	public static string SESSION_KEY_LOGIN_SYSTEM_ADMIN_NAME = "SESSION_KEY_LOGIN_SYSTEM_ADMIN_NAME";
	public static string SESSION_KEY_LOGIN_SYSTEM_ADMIN_TYPE = "SESSION_KEY_LOGIN_SYSTEM_ADMIN_TYPE";
	public static string SESSION_KEY_LOGIN_SYSTEM_ADMIN_EMAIL = "SESSION_KEY_LOGIN_SYSTEM_ADMIN_EMAIL";

	// Value text common
	public const string VALUE_TEXT_COMMON = "Common";
	public const string VALUE_TEXT_PAGE_SIZE = "page_size";

	// List sort class css
	public const string LIST_SORT_ACTIVE_CLASS = "sort-active";
	public const string LIST_SORT_DEFAULT_CLASS = "sort-default";
}