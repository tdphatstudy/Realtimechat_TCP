# Realtimechat TCP
## Mô tả
Ứng dụng chat realtime được viết bằng ngôn ngữ lập trình C# và sử dụng công nghệ WebSocket để tạo kết nối liên tục và nhanh chóng giữa máy chủ và người dùng. Giao diện của ứng dụng được xây dựng bằng WinForms, cung cấp trải nghiệm sử dụng trực quan và dễ sử dụng.
Người dùng có thể nhập văn bản vào ô chat và gửi nó đến máy chủ, nơi nó sẽ được chuyển đến các người dùng khác kết nối đến ứng dụng. Đồng thời, người dùng cũng có thể chọn biểu tượng cảm xúc từ một tập hợp các biểu tượng có sẵn để thể hiện cảm xúc của mình.
Ứng dụng cũng hỗ trợ gửi tất cả các loại file. Người dùng có thể chọn một file từ hệ thống tệp và gửi nó đến máy chủ. File này sau đó sẽ được truyền đến các người dùng khác, cho phép người dùng chia sẻ hình ảnh, tài liệu, video và các loại file khác trong quá trình chat.
## Hệ điều hành hỗ trợ.
| Hệ Điều Hành | Windows    | Linux   | MacOS|
| :---:   | :---: | :---: | :---: |
| Hỗ trợ | ✔️  | ❌  |  ❌ |
## Nền tảng phát triển
Việc phát triển hoặc build với các phiên bản khác có thể gây ra lỗi.
Chúng tôi phát triển phần mềm dựa trên các thư viện, ngôn ngữ với phiên bản sau đây:
  - .NET 6.0.8
## Các tính năng
  - [x] Đăng nhập
  - [x] Đăng ký
  - [x] Chat text realtime
  - [x] Chat file, emoji.
  - [ ] Kết bạn, tạo nhóm
  - [ ] Các tính năng bảo mật (Mã hóa nội dung chat, băm mật khẩu)
  ### Bằng zip
  - Bước 1: Nhấn **Code** -->  **Download ZIP**
 ![image](https://github.com/tdphatstudy/ODZ_WifiManager/assets/124871402/afd1b8d6-4b20-452a-8dc7-10629f703ac9)
 - Bước 2: Giải nén ZIP. Hướng dẫn: https://support.microsoft.com/en-us/windows/zip-and-unzip-files-f6dde0a7-0fec-8294-e1d3-703ed85e7ebc
  - Bước 3: Mở project mới giải nén bằng Visual Code. Nên mở client và server ở 2 cửa sổ khác nhau để thuận tiện trong việc code và debug
## Giao diện ứng dụng
### Giao diện server
Hiển thị IP server, Port, Nút **Start** và màn hình hiển thị danh sách các client đăng nhập
![image](https://github.com/tdphatstudy/Realtimechat_TCP/assets/124871402/df800cb1-a6e6-4606-a17c-a7ff532edd41)
### Giao diện client
  - Giao diện đăng nhập.
 
![image](https://github.com/tdphatstudy/Realtimechat_TCP/assets/124871402/6059c846-3057-4d97-b77c-06f2dd571304)

  - Giao diện chat
 
 
 ![image-removebg-preview (1)](https://github.com/tdphatstudy/Realtimechat_TCP/assets/124871402/9c0220ab-6f4c-4a39-b792-2803a8c25664)

  


 
