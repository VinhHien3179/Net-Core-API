# Mô tả hệ thống
- đây là source backend mẫu cho hệ thống POS (Point Of Sale)
- hướng tới khách hàng là các chuỗi bán lẽ và nhà hàng, khách sạn
- tham khảo quy trình từ các program như "mango mint", "Fresha", "LLD Tech"

# Source Document
- Source chạy Framework NET 6.0 (Yêu cầu Visual Studio 2022)
- Authorize dùng JWT
- Cấu trúc source có 3 phần

  
![image](https://github.com/hposvinhhien/Test-API/assets/111078757/f9dc9315-16ec-47c0-a10d-66c55b41c891)

.Core là phần để chứa các function xử lý.
  * Repository: Lớp liên kết trực tiếp với database, chỉ được gọi tới database (từ đây sẽ gọi là DB) thông qua lớp này, và lớp này chỉ làm nhiệm vụ gọi xuống database để lấy kết quả.
  * Service: Đối với các trường hợp cần xử lý logic sau khi lấy kết quả từ DB sẽ được xử lý ở lớp Event.
  * Extension: các static Function xử lý không liên quan tới DB hoặc các service chạy theo kiểu singleton.

==> Thứ tự gọi sẽ là API => Event => Service
    
.Model là để chứa các class khai báo.
  * Auth: là model của Authorize, thường thì sẽ chia làm nhiều role (Admin, User, Tech, e.t.c...)
  * Comon: những model dùng chung.
  * Proc: Model Custom lại Từ data Proc DB trả về
  * Request: Model dùng trong các POST method
  * Table: Model chứa data từ các bảng trong DB (không custom, không tùy ý thê mcootj trừ khi đã thêm trong 
DB)
  * ViewModel: Model kết quả trả về của API.
    
.API là lớp khởi tạo để người dùng tương tác
  * Controller: Code chính

# Database Document

các bảng chính:
- Client
  * CUS_CUSTOMER
- Setting
  * GlobPara
  * RDPara
- Sale
  * SPOS_APPOINTMENT
  * RDTmpTrn
  * RDAppointmentDetails
- Tech
  * EMP_EMPLOYEE
