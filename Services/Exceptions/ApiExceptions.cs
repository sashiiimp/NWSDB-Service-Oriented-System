namespace NWSDB.Server.Services.Exceptions;

// Thrown when a requested resource (customer, connection, bill, payment...) does not exist.
// Mapped to HTTP 404 by ExceptionHandlingMiddleware.
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}

// Thrown for business-rule/input validation failures (e.g. payment amount <= 0,
// payment exceeds outstanding balance, current reading lower than previous).
// Mapped to HTTP 400.
public class BusinessValidationException : Exception
{
    public BusinessValidationException(string message) : base(message)
    {
    }
}

// Thrown when an action conflicts with the current state of a resource
// (e.g. trying to pay a bill that is already fully paid).
// Mapped to HTTP 409.
public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}
