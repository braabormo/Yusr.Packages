namespace Yusr.Core.Abstractions.Enums
{
    public enum ResultType
    {
        Ok = 200,
        BadRequest = 400,
        NotFound = 404,
        Conflict = 409,
        PreconditionFailed = 412,
        UnprocessableEntity = 422,
        Cancelled = 499,
        InternalError = 500
    }
}
