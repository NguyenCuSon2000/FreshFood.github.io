/// <reference path="../angular-1.3.9/angular.js" />
var app = angular.module("myApp", ['angularUtils.directives.dirPagination', 'ui.bootstrap']);

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
            alert("Thêm vào giỏ hàng thành công !!!");
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

    $http.get('/GioiThieu/GetLoaiSanPham').then(function (d) {
        $rootScope.listloaisp = d.data;
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

    $scope.maxSize = 3;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 9; // Maximum number of items per page.  

    $rootScope.GetSanPhamList = function () {
        $http.get("http://localhost:64769/SanPham/GetSanPhamPTLoai?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListSanPham = response.data.SanPhams;
                $scope.totalCount = response.data.totalCount;
            }, function (e) {
                alert("Lỗi");
            });
    };

    //Loading employees list on first time  
    $scope.GetSanPhamList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetSanPhamList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetSanPhamList();
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



    // Add vào giỏ hàng
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            alert("Thêm vào giỏ hàng thành công !!!");
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
                    $rootScope.dathang = "/Admin/Login/Index";
                    $window.location.href = '/Admin/Login/Index';
                }
            }, function (e) { })
    };

    //$rootScope.dathang = "";
    //$rootScope.SoLuong = 0;
    //$rootScope.Payment = function () {
    //    $rootScope.dathang = "";
    //    //$rootScope.Khach = d.data.Khach;
    //    //console.log(JSON.stringify($rootScope.Khach));
    //    $http.get('/GioHang/GetCarts').then(function (d) {
    //        $rootScope.dsDonHang = d.data.DSDonHang;
    //        $rootScope.SoLuong = d.data.soluong;
    //        $rootScope.ThanhTien = d.data.ThanhTien;
    //    }, function (e) { });
    //    $window.location.href = '/DatHang/Index';
    //};
};

app.controller("DatHangController", function ($rootScope, $scope, $http) {
    $rootScope.DatHang = function () {
        $rootScope.DonDatHang.Khach = $rootScope.Khach;
        $rootScope.DonDatHang.TongTien = $rootScope.ThanhTien;
        $rootScope.DonDatHang.LCTDonHang = $rootScope.dsDonHang;
        $http({
            method: "POST",
            datatype: 'JSON',
            url: '/DatHang/DatHang',
            data: JSON.stringify($rootScope.DonDatHang)
        }).then(function (d) {

        }, function (e) { });

    };
});



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


    $scope.maxSize = 3;     // Limit number for pagination display number.  
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 3; // Maximum number of items per page.  

    $scope.GetTinTucList = function () {
        $http.get("http://localhost:64769/TinTuc/GetTinTucPT?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListTinTuc = response.data.TinTucs;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetTinTucList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetTinTucList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetTinTucList();
    };  
};


app.controller("GioiThieuController", function ($rootScope, $scope, $http) {
    $http.get('/SanPham/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });

    // DS sản phẩm nổi bật
    $http.get('/SanPham/GetSanPhamNoiBat').then(function (d) {
        $rootScope.ListSPNoiBat = d.data;
    }, function (error) { alert('Failed'); });

})


