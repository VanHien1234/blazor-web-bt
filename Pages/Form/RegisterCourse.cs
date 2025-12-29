using System.ComponentModel.DataAnnotations;

namespace web_blazor_server.Pages.Form;

public class RegisterCourseModel
{
    [Required(ErrorMessage = "Họ và tên là bắt buộc")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ và tên phải có tối thiểu 2 ký tự")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn khóa học")]
    public string Course { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn hình thức học")]
    public string StudyMethod { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ngày bắt đầu mong muốn là bắt buộc")]
    public DateTime? DesiredStartDate { get; set; }

    public string? Comments { get; set; }

    [MustBeTrue(ErrorMessage = "Bạn phải đồng ý với điều khoản và chính sách")]
    public bool TermsAndConditions { get; set; } = false;
}