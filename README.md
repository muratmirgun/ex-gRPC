# gRpcOrnek

gRPC teknolojisi ile ilgili .Net Core 3 (v3.0.0-preview7) ile geliştirilmiş basit bir örnek.

![](https://github.com/MuratSs/ex-gRPC/blob/master/grpcBloom.JPG "")

gRPC teknolojisi ile ilgili iki tane çok güzel makale var <a href="https://medium.com/@sddkal/grpc-api-rehberi-6dc561070c03" target="_blank">birincisi</a> ve Burak Selim Şenyurt hocanın <a href="https://buraksenyurt.com/post/grpc-nedir-nasil-uygulanir" target="_blank">makalesi</a>  mutlaka okunmalıdır.

.Net Core 3 ile gelen template kullanırken hata aldığımdan dolayı sunucu ve istemci console uygulaması olarak oluşturulmuştur.

gRPC teknolojisi çok yeni bir teknoloji olduğu için kodlar ve içerikler türkçe olmasına özen gösterdim.

Projede veri kullanımını basit tutmak için SQLite kullanılmıştır. (EF Core projeyi daha karmaşık hale getirmemesi için.)

Farklı platformlar arası iletişim söz konusu olunca web servisler direk aklımıza geliyor. SOAP (xml tabanlı) servisler, .Net tarafında Web Service(.asmx) WCF teknolojileri. JSON tabanlı RESTfull servisler Web API ve GraphQL gibi. (Facebook tarafından geliştirilen).

gRPC teknolojisi ise Google 'ın geliştirdiği en güncel yapı. Temel olarak bana SOAP servislerini anımsattı. Hatırlarsak SOAP servislerde bir wsdl adresimiz yani dosyamız vardı. Bu dosyadan bir vekil sınıf (proxy class) oluşturarak metotlarımızı çağırabiliyorduk.

gRPC teknolojisinde wsdl adresimiz yerine .proto dosyamız var. Bu dosyamızdan vekil sınıflar oluşturarak metotlarımızı veya fonksiyonlarımızı çağırıyoruz.
Buradaki sıkıntı wsdl dosyamız bir adreste bulunuyordu. Proto dosyamızın paylaşımı nasıl olacak güzel bir yol bulamadım. Çünkü İstemci uygulaması için .proto dosyasının güncelliği çok önemli.

## Proje Geliştirme

### Sunucu Uygulaması

Proje geliştirme kısmında öncelikle *.proto* dosyamızı oluşturmakla başlayalım.

(Bu projede **.proto** dosyası **protos** klasöründe tutarak hem sunucu hem istemci uygulamaları açısından kolaylık sağlanmıştır.)

Proto dosyalarını oluştururken <a href="https://developers.google.com/protocol-buffers/docs/proto3" target="_blank">bu adreste</a> bulunan yönergelere dikkat etmeliyiz.

Aslında çok basit; metotlar, parametreler, dönüş tipleri ve genel veri tipleri çok güzel açıklanmış. Bu kısımda parametresiz metot tanımlamayı ben başaramadım.
Araştırmalarım sonucunda genel olarak Empty adında bir parametre oluşturulup içi boş geçilmiş. Bende metotların birinde o şekilde kullandım.

Proto dosyamızı yazdıktan sonra sunucu uygulamamız için bir klasör içinde **(kutuphaneSunucu)** console uygulaması oluşturuyoruz. Gerekli paketleri yükledikten sonra (Google.Protobuf-Grpc-Grpc.Tools-Microsoft.Data.Sqlite.Core-Microsoft.EntityFrameworkCore.Sqlite) .csproj dosyamıza proto dosyamızın adresini veriyoruz.

> Protobuf Include="../protos/kutuphane.proto" Link="kutuphane.proto"

Projeyi derlediğimizde .proto dosyamızdan vekil sınıfımız otomatik oluşturulmuş olacak. Servisler klasörü oluşturarak .proto dosyası içinde tanımladığımız servislerin içini doldurabiliriz. (Service Implementation) Bu projede sqlite ile (Helper sınıfı) db ye basit kitap ekleme-silme işlemleri yapıyoruz.

Son olarak **program.cs** dosyamızda Server nesnemize parametreleri vererek sunucuyu başlatıyoruz.

### İstemci Uygulamaları

İstemci uygulamaları yazmadan <a href="https://github.com/uw-labs/bloomrpc/releases" target="_blank">BloomRPC</a> kullanarak  (SoapUI veya Postman gibi.) servislerimizi deneyebiliriz. BloomRPC açık kaynak kodlu ve çok güzel yazılmış sadece proto dosyasını seçerek tüm işlemleri kolaylıkla yapabiliyoruz.

**.net Core Console Uygulaması**

İstemci uygulamalarında ise **(kutuphaneIstemci)** gerekli paketleri yükledikten sonra (Google.Protobuf-Grpc-Grpc.Tools) .csproj dosyamıza .proto dosyamızın adresini veriyoruz ve projeyi derliyoruz. **.program.cs** dosyamızda bir client oluşturup metot çağrılarımızı yapıyoruz.

**NodeJS Uygulaması**

NodeJS istemci uygulaması için **(grpc-kit)** paketi kullanarak basit bir şekilde metot çağrıları yapılabilir.

Son olarak gRPC çok yeni bir teknoloji ve türkçe kaynak çok az. Bu projede anladığım kadarıyla bir şeyler anlatmaya çalıştım. Muhtemelen atladığım veya yanlış anladığım kısımlar vardır. Düzelten olursa sevinirim.








