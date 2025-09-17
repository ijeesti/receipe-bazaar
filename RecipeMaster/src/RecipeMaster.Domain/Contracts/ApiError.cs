namespace RecipeMaster.Domain.Contracts;

public class ApiError
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Details { get; set; }
}