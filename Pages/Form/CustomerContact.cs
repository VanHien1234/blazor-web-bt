using System.ComponentModel.DataAnnotations;

namespace web_blazor_server.Pages.Form;

public class CustomerContactModel
{
    [Required(ErrorMessage = "Họ và tên là bắt buộc")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Họ và tên phải có tối thiểu 3 ký tự")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
    public string Phone { get; set; } = string.Empty;

    [MinLengthIfNotEmpty(5, ErrorMessage = "Địa chỉ phải có tối thiểu 5 ký tự (nếu có nhập)")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Nội dung tin nhắn là bắt buộc")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Nội dung tin nhắn phải có tối thiểu 10 ký tự")]
    public string Message { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn dịch vụ cần tư vấn")]
    public string Service { get; set; } = string.Empty;

    [MustBeTrue(ErrorMessage = "Bạn phải đồng ý với điều khoản và chính sách")]
    public bool TermsAndConditions { get; set; } = false;
}

// Custom validation attribute cho checkbox
public class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is bool boolValue)
        {
            return boolValue;
        }
        return false;
    }
}

// Custom validation attribute cho Address - chỉ validate khi có giá trị
public class MinLengthIfNotEmptyAttribute : ValidationAttribute
{
    private readonly int _minLength;

    public MinLengthIfNotEmptyAttribute(int minLength)
    {
        _minLength = minLength;
    }

    public override bool IsValid(object? value)
    {
        // Nếu null hoặc empty, không validate (trường tùy chọn)
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return true;
        }

        // Nếu có giá trị, kiểm tra độ dài tối thiểu
        string? stringValue = value.ToString();
        return stringValue != null && stringValue.Length >= _minLength;
    }
}