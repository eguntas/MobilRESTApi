using Microsoft.EntityFrameworkCore;
using MobilApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Data
{
    public class AppRepository : IAppRepository
    {
        
            private MobilApiContext _db;
            public AppRepository(MobilApiContext db)
            {
                _db = db;
            }

            public void Add<T>(T entity) where T : class
            {
                _db.Add(entity);
            }

            public KayitTbl GetKayitById(int id)
            {
                var kayit = _db.KayitTbl.FirstOrDefault(p => p.KayitId == id);
                return kayit;
            }

            public List<KayitTbl> GetKayitTbls()
            {
                var kayit = _db.KayitTbl.Include(c => c.HareketTbls).ToList();
                return kayit;
            }

            public List<KullaniciTbl> GetKullaniciTbls()
            {
                var kullanici = _db.KullaniciTbl.ToList();
                return kullanici;
            }

            public bool SaveAll()
            {
                return _db.SaveChanges() > 0;
            }

            public void Update<T>(T entity) where T : class
            {
                _db.Update(entity);
            }
            public List<HareketTbl> GetHareket()
            {
                var hareket = _db.HareketTbl.Include(p => p.KayitIdsNavigation).ToList();
                return hareket;
            }
            //public List<HareketTbl> GetHareketById(int id)
            //{
            //    var hareket = _db.HareketTbl.Where(p => p.HareketId == id).ToList();
            //    return hareket;
            //}
            public List<FirmaTbl> GetFirma()
            {
                var firma = _db.FirmaTbl.ToList();
                return firma;
            }

            public FirmaTbl GetFirmaById(int id)
            {
                var company = _db.FirmaTbl.FirstOrDefault(p => p.FirmaId == id);
                return company;
            }

            public KullaniciTbl GetKullaniciById(string id, string password)
            {
                var user = _db.KullaniciTbl.FirstOrDefault(p => p.Username == id);
                return user;
            }

            public HareketTbl GetHareketById(int id)
            {
                var hareket = _db.HareketTbl.FirstOrDefault(p => p.HareketId == id);
                return hareket;
            }

            public List<TupTanimTbl> GetTupKayit()
            {
                var tup = _db.TupTanimTbl.Include(p => p.KayitTbl).ToList();
                return tup;
            }

            public TupTanimTbl GetTupKayitById(int id)
            {
                var tup = _db.TupTanimTbl.Include(p => p.KayitTbl).FirstOrDefault(p => p.TupId == id);
                return tup;
            }

            public List<KayitTbl> GetKayitTupTanim()
            {
                throw new NotImplementedException();
            }

            public List<KayitTbl> GetKayitHareket()
            {
                //var kayit = _db.KayitTbl.Include(p => p.HareketTbls).ToList();
                var kayit = _db.KayitTbl.Include(p => p.HareketTbls).ToList();
                return kayit;
            }

            public List<TupTanimTbl> GetTupTanim()
            {
                var tup = _db.TupTanimTbl.ToList();
                return tup;
            }

            public TupTanimTbl GetTupTanimById(int id)
            {
                var tup = _db.TupTanimTbl.FirstOrDefault(p => p.TupSeriNo == id);
                return tup;
            }

            public List<BolumTbl> GetBolum()
            {
                var bolum = _db.BolumTbl.ToList();
                return bolum;
            }

            public BolumTbl GetBolumById(int id)
            {
                var bolum = _db.BolumTbl.FirstOrDefault(p => p.BolumId == id);
                return bolum;
            }

            public FirmaTbl GetFirmaByFirmaAdi(string FirmaAdi)
            {
                var firma = _db.FirmaTbl.FirstOrDefault(p => p.FirmaAdi == FirmaAdi);
                return firma;
            }

            public TupTanimTbl GetTupBySeriNo(int TupSeriNo)
            {
                var tup = _db.TupTanimTbl.FirstOrDefault(p => p.TupSeriNo == TupSeriNo);
                return tup;
            }

            public List<AmbarTbl> GetAmbar()
            {
                var ambar = _db.AmbarTbl.ToList();
                return ambar;
            }

            public AmbarTbl GetAmbarById(int id)
            {
                var ambar = _db.AmbarTbl.FirstOrDefault(p => p.AmbarId == id);
                return ambar;
            }

            public AmbarTbl GetAmbarByAd(string AmbarAdi)
            {
                var ambar = _db.AmbarTbl.FirstOrDefault(p => p.AmbarAdi == AmbarAdi);
                return ambar;
            }

            public BolumTbl GetBolumByAd(string BolumAdi)
            {
                var bolum = _db.BolumTbl.FirstOrDefault(p => p.BolumAdi == BolumAdi);
                return bolum;
            }

            public TupTanimTbl GetTupTanimByAd(string TupAdi)
            {
                var tup = _db.TupTanimTbl.FirstOrDefault(p => p.TupTipi == TupAdi);
                return tup;
            }

            public List<KayitTbl> GetKayitTarih(DateTime GirisTarihi, DateTime CikisTarihi)
            {
                var kayit = _db.KayitTbl.Where(p => p.GirisTarih >= GirisTarihi && p.CikisTarih <= CikisTarihi).ToList();
                return kayit;
            }

            public List<KayitTbl> GetKayitTupStok(DateTime GirisTarihi, int TupDurums)
            {
                var kayit = _db.KayitTbl.Where(p => p.GirisTarih >= GirisTarihi && p.TupDurums == TupDurums).ToList();
                return kayit;
            }

            public KayitTbl GetKayitBySeri(int TupSeriNo)
            {
                var kayit = _db.KayitTbl.FirstOrDefault(p => p.TupSeriNos == TupSeriNo);
                return kayit;
            }
            public List<HareketTbl> GetBolumRapor(int BolumId, String HareketTipi)
            {
                var hareket = _db.HareketTbl.Where(p => p.BolumIds == BolumId && p.HareketTipi == HareketTipi).ToList();
                return hareket;
            }
            public List<KayitTbl> GetKayitTarihi(DateTime GirisTarihi, DateTime CikisTarihi)
            {
            var kayit = _db.KayitTbl.Where(p => p.GirisTarih >= GirisTarihi && p.CikisTarih <= CikisTarihi).ToList();
            return kayit;
            }


    }
    }

