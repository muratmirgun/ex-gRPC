using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Kutuphane;

namespace kutuphaneSunucu.Servisler
{
    class KutuphaneServiceImpl : Kutuphane.KutuphaneService.KutuphaneServiceBase
    {
        public override async Task<KutuphaneServiceResponse> KitapGetirID(KutuphaneServiceRequest request, ServerCallContext context)
        {
            KutuphaneServiceResponse yanit = new KutuphaneServiceResponse();
            var veriler = new List<ResponseKitap>();
            try
            {
                veriler = Helper.SqlLiteHelper.SqlKomutCalistirSorgu(request.Id);
            }
            catch (System.Exception ex)
            {
                yanit.StatusMessage = "Hata";
                yanit.ErrorMessage = ex.ToString();
                return await Task.FromResult(yanit);
            }
            yanit.StatusMessage = "Başarılı";
            yanit.Sonuclar.Add(veriler);
            return await Task.FromResult(yanit);
        }

        public override async Task<KutuphaneServiceResponse> TumKitaplariGetir(Empty empty, ServerCallContext context)
        {
            KutuphaneServiceResponse yanit = new KutuphaneServiceResponse();
            var veriler = new List<ResponseKitap>();
            try
            {
                veriler = Helper.SqlLiteHelper.SqlKomutCalistirSorguTumKitaplar();
            }
            catch (System.Exception ex)
            {
                yanit.StatusMessage = "Hata";
                yanit.ErrorMessage = ex.ToString();
                return await Task.FromResult(yanit);
            }
            yanit.StatusMessage = "Başarılı";
            yanit.Sonuclar.Add(veriler);
            return await Task.FromResult(yanit);
        }

        public override async Task<KutuphaneServiceResponse> KitapSilID(KutuphaneServiceRequest request, ServerCallContext context)
        {
            KutuphaneServiceResponse yanit = new KutuphaneServiceResponse();
            bool sonuc;
            try
            {
                sonuc = Helper.SqlLiteHelper.SqlKomutCalistirSil(request.Id);
            }
            catch (System.Exception ex)
            {
                yanit.StatusMessage = "Hata";
                yanit.ErrorMessage = ex.ToString();
                return await Task.FromResult(yanit);
            }
            if (sonuc)
            {
                yanit.StatusMessage = "Silme işlemi başarılı.";                
            }           
            return await Task.FromResult(yanit);
        }

        public override async Task<KutuphaneServiceResponse> KitapEkle(ResponseKitap kitap, ServerCallContext context)
        {
            KutuphaneServiceResponse yanit = new KutuphaneServiceResponse();
            bool sonuc;
            try
            {
                sonuc = Helper.SqlLiteHelper.SqlKomutCalistirEkle(kitap);
            }
            catch (System.Exception ex)
            {
                yanit.StatusMessage = "Hata";
                yanit.ErrorMessage = ex.ToString();
                return await Task.FromResult(yanit);
            }
            if (sonuc)
            {
                yanit.StatusMessage = "Kitap ekleme işlemi başarılı.";                
            }           
            return await Task.FromResult(yanit);
        }

        public override async Task<KutuphaneServiceResponse> KitapGuncelle(ResponseKitap kitap, ServerCallContext context)
        {
            KutuphaneServiceResponse yanit = new KutuphaneServiceResponse();
            bool sonuc;
            try
            {
                sonuc = Helper.SqlLiteHelper.SqlKomutCalistirGuncelle(kitap);
            }
            catch (System.Exception ex)
            {
                yanit.StatusMessage = "Hata";
                yanit.ErrorMessage = ex.ToString();
                return await Task.FromResult(yanit);
            }
            if (sonuc)
            {
                yanit.StatusMessage = "Kitap güncelleme işlemi başarılı.";                
            }
            else
            {
                yanit.StatusMessage = "Kitap güncelleme işlemi başarısız.";                

            }           
            return await Task.FromResult(yanit);
        }
    }
}