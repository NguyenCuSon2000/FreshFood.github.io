/// <reference path="../angular.js" />
var app = angular.module("myApp", ['angularUtils.directives.dirPagination']);

app.controller("DatHangController", function ($rootScope, $scope, $http) {
    $rootScope.DatHang = function () {
        $rootScope.DonHang.Khach = $rootScope.Khach;
        $rootScope.DonHang.TongTien = $rootScope.ThanhTien;
        $rootScope.DonHang.LCTDonHang = $rootScope.dsDonHang;
        $http({
            method: "POST",
            datatype: 'json',
            url: '/DatHang/DatHang',
            data: JSON.stringify($rootScope.DonHang)
        }).then(function (d) {

        }, function (e) { })
    };
});

//Phân trang và tìm kiếm
app.controller("PhanTrangController", PhanTrangController);
function PhanTrangController($scope, $rootScope, $http) {

    $rootScope.maxSize = 3;
    $rootScope.totalCount = 0;
    $rootScope.pageIndex = 1;
    $rootScope.pageSize = 9;
    $rootScope.searchName = "";

    $rootScope.GetSanPhamList = function (index) {
        $http.get('/SanPham/GetSanPhamPTLoai', {
            params: {
                pageIndex: index,
                pageSize: $rootScope.pageSize, productName: $rootScope.searchName
            }
        }).then(
            function (response) {
                $rootScope.ListSanPham = response.data.SanPhams;
                $rootScope.totalCount = response.data.totalCount;
            },
            function (e) {
                alert(e);
            });
    };
    $rootScope.GetSanPhamList($rootScope.pageIndex);

    //$rootScope.GetSanPhamList = function () {
    //    $http.get("/SanPham/GetSanPhamPTLoai?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {
    //        $scope.SanPhams = response.data.SanPhams;
    //        $scope.totalCount = response.data.totalCount;
    //    }, function (e) {
    //        alert("Lỗi");
    //    });
    //};
    //$rootScope.GetSanPhamList();

    //$scope.pagechanged = function () {
    //    $scope.GetSanPhamList();
    //}

    //$scope.changePageSize = function () {
    //    $scope.pageIndex = 1;
    //    $scope.GetSanPhamList();
    //}
};

//Menu 
app.controller("MenuController", MenuController);
function MenuController($scope, $rootScope, $http) {
    $http.get('/Home/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });
}


app.controller("SanPhamController", SanPhamController);
function SanPhamController($scope, $rootScope, $http) {

    // DS sản phẩm nổi bật
    $http.get('/SanPham/GetSanPhamNoiBat').then(function (d) {
        $rootScope.ListSPNoiBat = d.data;
    }, function (error) { alert('Failed'); });

    // Add vào giỏ hàng
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);
            }
            else {
                for (var i = 0; i < $rootScope.dsDonHang.length; i++) {
                    if ($rootScope.dsDonHang[i].MaSP == s.MaSP) {
                        $rootScope.dsDonHang[i].SoLuong = $rootScope.dsDonHang[i].SoLuong + 1;
                    }
                }
            }
            $rootScope.SoLuong = d.data.sl;
        }, function (e) { alert("Lỗi"); });
    };

    //Danh sách sản phẩm
    $http.get('/SanPham/GetSanPham').then(function (d) {
        $rootScope.ListSanPham = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/SanPham/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });

    //Sắp xếp dữ liệu
    $rootScope.sortcolumn = "TenSP";
    $rootScope.reverse = true;
    $rootScope.dr = "Ascending";

    $rootScope.Chon = function (d) {
        if ($rootScope.dr == "Ascending") {
            $rootScope.reverse = false;
            $rootScope.dr = "Descreasing";
        }
        else {
            $rootScope.reverse = true;
            $rootScope.dr = "Ascending";
        }
    };
};


//Chi tiết sản phẩm
app.controller("CTSanPhamController", CTSanPhamController);
function CTSanPhamController($scope, $rootScope, $http) {

    //Chi tiết sản phẩm
    $http.get('/CTSanPham/GetCTSanPham').then(function (d) {
        $rootScope.CTSanPham = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/SanPham/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });


    // DS sản phẩm nổi bật
    $http.get('/CTSanPham/GetSanPhamNoiBat').then(function (d) {
        $rootScope.ListSPNoiBat = d.data;
    }, function (error) { alert('Failed'); });

    //DANH SÁCH LOẠI SẢN PHẨM
    $http.get('/CTSanPham/GetSanPhamMoiNhat').then(function (d) {
        $rootScope.ListMoiNhat = d.data;
    }, function (error) { alert('Failed'); });


    // Add vào giỏ hàng
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            alert("Thêm vào giỏ hàng thành công !")
            if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);
            }
            else {
                for (var i = 0; i < $rootScope.dsDonHang.length; i++) {
                    if ($rootScope.dsDonHang[i].MaSP == s.MaSP) {
                        $rootScope.dsDonHang[i].SoLuong = $rootScope.dsDonHang[i].SoLuong + 1;
                    }
                }
            }
            $rootScope.SoLuong = d.data.sl;
        }, function (e) { alert("Lỗi"); });
    };
};

// Tìm kiếm sản phẩm
app.controller("SearchController", SearchController);
function SearchController($scope, $rootScope, $window, $http ) {
    $rootScope.TenSP = "";
    $rootScope.Search = function (tensp) {
        $rootScope.ListTimKiem = null;
        $http.get('/SanPham/SearchName', {
            params: {
                TenSP: tensp
            }
        }).then(function (d) {
            if (d.data == "") {
                alert("Sản phẩm không tồn tại");
            }
            else {
                $rootScope.ListTimKiem = d.data;
                //$window.location.href = '/SanPham/Search';
            }
        }, function (e) { });
    }
};

////Giỏ hàng
//app.controller("GioHangController", GioHangController);
//function GioHangController($rootScope, $scope, $http) {
   
//}

app.controller("HomeController", HomeController);
function HomeController($rootScope, $scope, $http, $window) {

    // DS sản phẩm nổi bật
    $http.get('/Home/GetSanPhamNoiBat').then(function (d) {
        $rootScope.ListNoiBat = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/Home/GetSanPhamMoiNhat').then(function (d) {
        $rootScope.ListMoiNhat = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/Home/GetSanPhamKhuyenMai').then(function (d) {
        $rootScope.ListKhuyenMai = d.data;
    }, function (error) { alert('Failed'); });

    $rootScope.dsDonHang = null;
    $http.get("/Home/GetLoaiSanPham").then(function (d) { }, function (e) { });

    $rootScope.GetCart = function () {
        $http.get('/GioHang/GetCarts').then(function (d) {
            $rootScope.dsDonHang = d.data.DSDonHang;
            $rootScope.SoLuong = d.data.soluong;
            $rootScope.ThanhTien = d.data.ThanhTien;
        }, function (e) { })
    };


    $rootScope.dathang = "";
    $rootScope.SoLuong = 0;
    $rootScope.Log = "Login";
    $rootScope.KiemTraDangNhap = function () {
        $http.get('/DatHang/ReadAccount').then(
            function (d) {
                if (d.data.login == "1")
                //Đã đăng nhập thì hiển thị giao diện đặt hàng
                {
                    $rootScope.dathang = "";
                    $rootScope.Khach = d.data.Khach;
                    console.log(JSON.stringify($rootScope.Khach));
                    $http.get('/GioHang/GetCarts').then(function (d) {
                        $rootScope.dsDonHang = d.data.DSDonHang;
                        $rootScope.SoLuong = d.data.soluong;
                        $rootScope.ThanhTien = d.data.ThanhTien;
                    }, function (e) { });
                    $window.location.href = '/DatHang/Index';
                }
                else { //Hiển thị giao diện đăng nhập
                    $rootScope.dathang = "#myModalLogin";
                    $window.location.href = '/Admin/Login/Index';
                }
            }, function (e) { })
    };


    // Add vào giỏ hàng
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);
            }
            else {
                for (var i = 0; i < $rootScope.dsDonHang.length; i++) {
                    if ($rootScope.dsDonHang[i].MaSP == s.MaSP) {
                        $rootScope.dsDonHang[i].SoLuong = $rootScope.dsDonHang[i].SoLuong + 1;
                    }
                }
            }
            $rootScope.SoLuong = d.data.sl;
        }, function (e) { alert("Lỗi"); });
    };
};


app.controller("TinTucController", TinTucController);
function TinTucController($rootScope, $scope, $http, $window) {
    //Danh sách tin tức
    $http.get('/TinTuc/GetTinTuc').then(function (d) {
        $rootScope.ListTinTuc = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/SanPham/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });

    //DS tin tức mới nhất
    $http.get('/TinTuc/GetTinTucMoiNhat').then(function (d) {
        $rootScope.ListNew = d.data;
    }, function (error) { alert('Failed'); });
}


