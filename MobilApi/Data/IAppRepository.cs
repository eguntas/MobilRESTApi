using MobilApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Data
{
    public interface IAppRepository
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveAll();
        List<KayitTbl> GetKayitTbls();
        List<KullaniciTbl> GetKullaniciTbls();
        KayitTbl GetKayitById(int id);
        List<HareketTbl> GetHareket();
        List<FirmaTbl> GetFirma();
        FirmaTbl GetFirmaById(int id);
        KullaniciTbl GetKullaniciById(string id, string password);
        HareketTbl GetHareketById(int id);
        List<TupTanimTbl> GetTupKayit();
        TupTanimTbl GetTupKayitById(int id);
        List<KayitTbl> GetKayitHareket();
        List<TupTanimTbl> GetTupTanim();
        TupTanimTbl GetTupTanimById(int id);
        List<BolumTbl> GetBolum();
        BolumTbl GetBolumById(int id);
        FirmaTbl GetFirmaByFirmaAdi(string FirmaAdi);
        TupTanimTbl GetTupBySeriNo(int TupSeriNo);
        List<AmbarTbl> GetAmbar();
        AmbarTbl GetAmbarById(int id);
        AmbarTbl GetAmbarByAd(string AmbarAdi);
        BolumTbl GetBolumByAd(string BolumAdi);
        TupTanimTbl GetTupTanimByAd(string TupAdi);
        //KayitTbl GetKayitTarih(DateTime GirisTarih, DateTime CikisTarih);
        List<KayitTbl> GetKayitTarih(DateTime GirisTarih, DateTime CikisTarih);
        List<KayitTbl> GetKayitTupStok(DateTime GirisTarih, int TupDurums);
        KayitTbl GetKayitBySeri(int TupSeriNo);
        List<HareketTbl> GetBolumRapor(int BolumId, String HareketTipi);
        //List<KayitTbl> GetKayitHareketSeriNo(int TupSeriNos);

        
        
    }
}
