using System.ComponentModel.DataAnnotations;

namespace EHRsystem.Models.Entities
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        [Display(Name = "Error Message")]
        public string? ErrorMessage { get; set; }

        public string? ErrorDetails { get; set; }

        public int? StatusCode { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string? ErrorSource { get; set; }

        public string? StackTrace { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public bool ShowErrorDetails => !string.IsNullOrEmpty(ErrorDetails);

        public bool ShowStackTrace => !string.IsNullOrEmpty(StackTrace);

        public string ErrorTitle => StatusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized Access",
            403 => "Access Forbidden",
            404 => "Page Not Found",
            500 => "Internal Server Error",
            503 => "Service Unavailable",
            _ => "An Error Occurred"
        };

        public string GetUserFriendlyMessage()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
                return ErrorMessage;

            return StatusCode switch
            {
                400 => "The request was invalid. Please check your input and try again.",
                401 => "You need to log in to access this resource.",
                403 => "You don't have permission to access this resource.",
                404 => "The requested page or resource could not be found.",
                500 => "An internal server error occurred. Please try again later.",
                503 => "The service is temporarily unavailable. Please try again later.",
                _ => "An unexpected error occurred. Please try again or contact support."
            };
        }

        // Factory methods for common error scenarios
        public static ErrorViewModel NotFound(string? requestId = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 404,
                ErrorMessage = "The requested resource was not found."
            };
        }

        public static ErrorViewModel InternalServerError(string? requestId = null, string? details = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 500,
                ErrorMessage = "An internal server error occurred.",
                ErrorDetails = details
            };
        }

        public static ErrorViewModel Unauthorized(string? requestId = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 401,
                ErrorMessage = "You are not authorized to access this resource."
            };
        }

        // Additional factory methods for EHR-specific scenarios
        public static ErrorViewModel BadRequest(string? requestId = null, string? customMessage = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 400,
                ErrorMessage = customMessage ?? "The request was invalid."
            };
        }

        public static ErrorViewModel Forbidden(string? requestId = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 403,
                ErrorMessage = "You don't have permission to access this resource."
            };
        }

        public static ErrorViewModel ServiceUnavailable(string? requestId = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 503,
                ErrorMessage = "The service is temporarily unavailable. Please try again later."
            };
        }

        // EHR-specific error scenarios
        public static ErrorViewModel PatientNotFound(string? requestId = null, string? patientId = null)
        {
            var message = string.IsNullOrEmpty(patientId) 
                ? "Patient record not found." 
                : $"Patient with ID '{patientId}' not found.";
                
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 404,
                ErrorMessage = message,
                ErrorSource = "Patient Management"
            };
        }

        public static ErrorViewModel RecordAccessDenied(string? requestId = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 403,
                ErrorMessage = "You don't have permission to access this medical record.",
                ErrorSource = "Authorization Service"
            };
        }

        public static ErrorViewModel ValidationError(string? requestId = null, string? details = null)
        {
            return new ErrorViewModel
            {
                RequestId = requestId,
                StatusCode = 400,
                ErrorMessage = "Data validation failed.",
                ErrorDetails = details,
                ErrorSource = "Validation Service"
            };
        }
    }
}