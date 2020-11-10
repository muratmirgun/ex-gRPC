const {createClient} = require("grpc-kit");
const client = createClient({
  protoPath: "../protos/kutuphane.proto",
  packageName: "kutuphane",
  serviceName: "KutuphaneService"
}, "0.0.0.0:50051");


//Tüm kitapları getiriyoruz.
/*
client.TumKitaplariGetir(null,(err, response) => {
  if(err) throw err;
  console.log(response.statusMessage);
  console.log(response.sonuclar);
});
*/


//ID göre kitap getiriyoruz.
/*
client.KitapGetirID({id:482},(err, response) => {
  if(err) throw err;
  console.log(response.sonuclar);
});
*/


//ID ile kitap siliyoruz.
/*
client.KitapSilID({id:479},(err, response) => {
  if(err) throw err;
  console.log(response.statusMessage);
});
*/

//Kitap ekleme işlemi
/*
client.KitapEkle({KitapAdi:"node kitap",Yazar:"node yazar"},(err, response) => {
  if(err) throw err;
  console.log(response.statusMessage);
});
*/

//Kitap güncelleme işlemi yapıyoruz.
/*
client.KitapGuncelle({ID:482 ,KitapAdi:"node kitap2",Yazar:"node yazar2"},(err, response) => {
  if(err) throw err;
  console.log(response.statusMessage);
});
*/