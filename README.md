# Concept thiết kế Game 

## Khái niệm/thiết kế cấp cao
### Tên game
Gem catcher
### Mệnh đề khái niệm
Thu thập những hạt gem để ghi điểm. Có các vật phẩm bất lợi và nâng cấp để người chơi thu thập và ảnh hưởng đến khả năng thu thập của nhân vật.
### Thể loại
casual
### Khán giả mục tiêu
Những người thích chơi game casual ở mọi độ tuổi. Game có màn chơi ngắn, cốt truyện đơn giản.
Người dùng PC, điện thoại
### Các điểm khác biệt của game
Nhân vật có thể dash, phân thân, hút toàn bộ gem trong khoảng thời gian ngắn; game có nhiều skin nhân vật. (IDP)
Có enemy và chướng ngại spawn liên tục để cản đường người chơi, tạo thử thách.

## Thiết kế sản phẩm/game
### Trải nghiệm người chơi và góc nhìn của trò chơi
#### Điều khiển:
Với người chơi PC: w, a, s, d hoặc phím mũi tên để di chuyển trái, phải, nhảy, đáp xuống; shift hoặc cách để dash
Với điện thoại: nút mũi tên điều khiển trên màn hình
Các màn chơi mới khó hơn và có nhiều loại vật phẩm hơn: gem x2, x3 điểm, bom, gai, vật phẩm phân thân,...
Vật phẩm thụ động: tác dụng tức thì sau khi được thu thập
Gem: vật phẩm chính cần thu thập; các loại có điểm và tốc độ rơi khác nhau 1 điểm, 2 điểm, 3 điểm,...
Speed boost: tăng tốc nhân vật
Slower spike: giảm tốc nhân vật
Vật phẩm chủ động:  sau khi thu thập sẽ được lưu trữ và sau đó người chơi sẽ chủ động kích hoạt
Nam châm: hút gem trên toàn màn hình hiện tại
phân thân: tạo 1 phân thân di chuyển tự do trong thời gian 5s
### Phong cách của giao diện và âm thanh trong trò chơi
Trò chơi là giao diện 2D landscape với nhân vật di chuyển qua lại trong khung hình cố định. Game sử dụng đồ họa pixel.
### Cốt truyện của thế giới trò chơi
Thu thập thật nhiều đá quý để làm giàu và mua quần áo đẹp (có thể dùng điểm để mua 1 số vật phẩm trong shop)
### Kiếm tiền
Trò chơi là F2P lúc ban đầu và sẽ thêm quảng cáo với một số microtransaction với các skin và vật phẩm trong game 
### Nền tảng, Công nghệ và phạm vi của nó
Máy tính hay điện thoại? Máy tính bảng? 2D hay 3D? Unity hay là Javascript? Bản trải nghiệm lần đầu tiên sẽ bao gồm những gì? Bao lâu sẽ hoàn thành tựa game này? Các nguy cơ tiềm ẩn là gì (ví dụ, bạn dự định thử đưa ChatGPT để làm thoại realtime cho các NPC. Rủi ro là vì bạn chưa thử bao giờ, có khả năng bạn sẽ không hoàn thiện được tính năng này) ?
Nền tảng PC, game 2D, dùng Unity
Bản release gồm 3 level: 
level 1: thu thập gem đơn thuần, không có boost hay chướng ngại
level 2: thu thập gem nhiều loại, có boost speed và chướng ngại gai làm chậm
level 3: có 3 loại gem, boost và chướng ngại gai, thêm kẻ địch dưới mặt đất để quấy rối người chơi
Dự kiến 1 tháng hoàn thành. Có thể không tìm đủ asset cần thiết và gặp bug trong quá trình develop.

## Thiết kế chi tiết và hệ thống trò chơi
### Các vòng lặp cốt lõi
Game sẽ có nhiều level. Người chơi có thể vào chơi từ trang menu chính bằng cách bấm Play hoặc chọn level.
Mỗi level yêu cầu người chơi thu thập số lượng gem tối thiểu để qua đến màn tiếp theo. Người chơi có mục tiêu thu thập gem và né tránh chướng ngại để ghi nhiều điểm nhất có thể. Sau khi qua màn, người chơi có thể chơi lại màn đó bằng cách chọn màn trong menu.
Việc quái và gem spawn là ngẫu nhiên nên có thể mang lại cảm giác mới mẻ trong mỗi lần chơi: có thể người chơi sẽ gặp thuận lợi với nhiều gem cùng rơi gần nhau hoặc bất lợi khi gem rơi ở những vị trí khác nhau tùy theo mỗi lần chơi. Vì thế việc ghi điểm cao cũng mang tính thử thách cho người chơi.
#### Kế hoạch kiếm tiền: 
Cho người chơi mua skin trong cửa hàng của game
Chạy quảng cáo mỗi lần hoàn thành 1 level.
### Mục tiêu và tiến trình
Về mặt cơ chế:
Người chơi xuất phát từ Main menu để chơi màn đầu tiên rồi hoàn thành từng level để mở khóa level tiếp theo.
Mỗi level sẽ có độ khó tăng dần, người chơi phải thu thập những gem rơi nhanh hơn, tránh né nhiều vật cản hơn qua từng level.
Khi kết thúc màn chơi sẽ lưu lại số điểm cao nhất mà người chơi từng đạt được để cổ vũ họ phá kỷ lục.
Số điểm thu được sau mỗi màn sẽ được cộng lại vào tổng điểm gọi là tài sản của nhân vật. Người chơi có thể tiêu số điểm đó để mua vật phẩm trong shop: skin, vật phẩm hỗ trợ
### Tính tương tác
Nhân vật chính có thể tương tác với:
Mặt đất: Hoạt động vật lý tương tự hiện thực như: chạy, nhảy, đáp
Gem: Nhân vật chính va chạm làm gem biến mất và trở thành điểm được ghi lại 
Vật phẩm tăng cường: nhiều vật phẩm có tác dụng khác nhau với nhân vật:
Tăng tốc nhân vật
Cộng thêm thời gian chơi
Thu thập gem và các vật phẩm lân cận
Tiêu diệt enemy
Enemy: trừ bớt điểm của người chơi và gây ra những hiệu ứng bất lợi khác
Ground enemy: trừ thời gian chơi 
Fly enemy: làm tê liệt nhân vật 1 lúc
Chướng ngại vât: 
Gai: làm chậm nhân vật
Ngoài ra mặt đất sẽ đảm bảo các vật thể trong game không rơi ra ngoài bằng cách hủy chúng (gem) hoặc chặn lại (enemy)
Các enemy sẽ không va chạm nhau và không va chạm chướng ngại vật
