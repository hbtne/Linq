create database CuaHang
use CuaHang

CREATE TABLE SanPham (
    MaSanPham NVARCHAR(50) PRIMARY KEY,  
    TenSanPham NVARCHAR(255) NOT NULL,    
    SoLuong INT NOT NULL,                 
    DonGia DECIMAL(18, 2) NOT NULL,       
    XuatXu NVARCHAR(100),                 
    NgayHetHan DATE                       
);