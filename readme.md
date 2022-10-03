# WEBSITE TIN TỨC
## _TRANG WEB PHỎNG VẤN SOFTZ_
### người Thực Hiện: _Võ Thành Thuận - DPM185194_
### Thông tin liên hệ: [Facebook](https://www.facebook.com/anome69/) - [Zalo](zalo.me/anome69)
[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Tính năng
- Thêm xóa sửa thể loại tin tức.
- Thêm xóa sửa tin tức.
- Phân trang.
- Tìm kiếm.
- Lọc tin tức theo thể loại.
- Bình luận với Facebook.
- Máy tính tuổi thông minh.

## Công Nghệ
Hệ thống sử dụng các công cụ và ngôn ngữ như:

- [.NET6](https://dotnet.microsoft.com/download/dotnet/6.0) - Framework .NET6.
- [Visual Studio 2022](https://visualstudio.microsoft.com/) - IDE Editor.
- [Visual Studio Code](https://code.visualstudio.com/) - IDE Editor.
- [Bootstrap](https://getbootstrap.com/) - Một thư viện CSS giúp giảm thời giản phát triển UI
- [Materialdesignicons](https://materialdesignicons.com/) - Bộ icon dùng cho việc design.
- [DNN](https://www.dnnsoftware.com/) - Phát triển modules cho web ("Cái này tệ, không muốn dùng.")

## Hướng dẫn
- Server sử dụng DotnetNuke (DNN).
- Client sử dụng ASP.NET MVC trên nền .NET 6.
    > Thay đổi đường dẫn server tại "\client\NewsForDNN\appsettings.json" (đường dẫn này là đường dẫn của server DNN, mặc định là "http://local.dnndemo.com/DesktopModules/") 
    - Chạy file "RunMe" trong thư mục "client" để chạy web, lưu ý phải cài đặt .NET6 và thay đổi đường dẫn "BaseAddress" trong file "appsettings.json".
    - Thư mục SQL chứa 2 file script, một file là script tạo bảng và thêm dữ liệu, một file chỉ thêm dữ liệu (2 file phòng hờ trường hợp module không tự cài đặt dữ liệu được, nếu module chạy bình thường thì không cần đụng đến.)
## Hình Ảnh Demo
![Trang chủ](https://github.com/VoThanhThuan/DNNNewsInterview/blob/main/imgs/GiaoDienClient.jpg?raw=true)
![Trang chi tiết](https://github.com/VoThanhThuan/DNNNewsInterview/blob/main/imgs/GiaoDienClientDocBao.jpg?raw=true)