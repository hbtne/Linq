using Linq.DataLayer;
using Linq.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.Controller
{
    public class SanPhamController
    {
        private DAL sanPhamDAL;

        public SanPhamController()
        {
            sanPhamDAL = new DAL();
        }

        public List<SanPham> GetAllSanPham()
        {
            return sanPhamDAL.GetAll();
        }

        public void AddSanPham(SanPham sanPham)
        {
            sanPhamDAL.Add(sanPham);
        }

        public bool DeleteSanPham(string MaSp)
        {
            var sanPham = sanPhamDAL.GetAll().FirstOrDefault(sp => sp.MaSanPham == MaSp);

            if (sanPham == null)
            {
                return false;
            }

            return sanPhamDAL.Delete(MaSp);
        }

        public SanPham GetSanPhamCoDonGiaCaoNhat()
        {
            List<SanPham> sanPhams = sanPhamDAL.GetAll();

            SanPham sp = sanPhams.OrderByDescending(s => s.DonGia).FirstOrDefault();

            return sp;
        }

        public SanPham GetSanPhamXuatXuNhatBan()
        {
            SanPham sanPham = sanPhamDAL.GetAll().FirstOrDefault(sp => sp.XuatXu == "Nhật Bản");

            return sanPham;
        }

        public List<SanPham> GetSanPhamQuaHan()
        {
            List<SanPham> sanPhams = sanPhamDAL.GetAll();

            List<SanPham> sanPhamsQuaHan = sanPhams.Where(sp => sp.NgayHetHan < DateTime.Now).ToList();

            return sanPhamsQuaHan;
        }

        public List<SanPham> GetSanPhamCoDonGia(decimal min, decimal max)
        {
            List<SanPham> sanPhams = sanPhamDAL.GetAll();

            List<SanPham> sanPhamCoDonGia = sanPhams.Where(sp => sp.DonGia > min && sp.DonGia < max).ToList();

            return sanPhamCoDonGia;
        }

        public bool DeleteSanPhamsByXuatXu(string xuatXu)
        {
            List<SanPham> sanPhams = sanPhamDAL.GetAll().Where(sp => sp.XuatXu == xuatXu).ToList();

            if (sanPhams.Count == 0)
            {
                return false;
            }

            foreach (var sanPham in sanPhams)
            {
                sanPhamDAL.Delete(sanPham.MaSanPham);
            }

            return true;
        }

        public bool DeleteAllSanPham()
        {
            return sanPhamDAL.DeleteAll();
        }

        public bool DeleteExpiredSanPham()
        {
            return sanPhamDAL.DeleteExpired();
        }
    }
}