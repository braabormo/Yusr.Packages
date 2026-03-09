namespace Yusr.Core.Abstractions.Constants
{
    public class ErrorMessages
    {
        public const string NotFound = "لا يوجد نتائج";
        public const string Conflict = "تعارض في البيانات";
        public const string RetrievingError = "حصل خطأ أثناء جلب البيانات";
        public const string OperationFailed = "لا يمكن إتمام العملية";

        public const string NoEffectedRows = "No Effected Rows";

        public static string FailedToAdd(string tableRowName) => $"لم يتم إضافة {tableRowName} بنجاح";
        public static string EntityNotFound(string tableRowName) => $"غير موجودة أو تم حذفها {tableRowName}";
        public static string FailedToUpdate(string tableRowName) => $"لم يتم تعديل {tableRowName} بنجاح";
        public static string FailedToDelete(string tableRowName) => $"لم يتم حذف {tableRowName} بنجاح";
        public static string UpdateConcurrencyError(string tableRowName) => $"تم تعديل {tableRowName} من قبل مستخدم آخر. الرجاء إعادة التحميل.";


        public static string BadRequest(string? columnName = null) { return columnName == null ? "مدخلات خاطئة" : $"، إدخال خاطئ للحقل '{columnName}'"; }
    }
}
