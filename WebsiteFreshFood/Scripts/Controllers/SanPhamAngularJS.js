/// <reference path="../angular.js" />
var app = angular.module("myApp", ['angularUtils.directives.dirPagination']);


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



app.controller("CTSanPhamController", CTSanPhamController);
function CTSanPhamController($scope, $rootScope, $http) {
    //Danh sách sản phẩm
    $http.get('/CTSanPham/GetCTSanPham').then(function (d) {
        $rootScope.CTSanPham = d.data;
    }, function (error) { alert('Failed'); });

}


app.controller("SearchController", SearchController);
function SearchController($scope, $rootScope, $http) {
    $rootScope.TenSP = "";
    $rootScope.Search = function (tensp) {
        $http.get('/SanPham/SearchName', {
            params: {
                TenSP: tensp
            }
        }).then(function (d) {
            if (d.data == "") {
                $rootScope.TenSP = "";
                alert("Sản phẩm không tồn tại");
            }
            else {
                $rootScope.ListTimKiem = d.data;
                alert("Search success... !!!")
            }
        }, function (e) { });
    }
};

//Giỏ hàng
app.controller("GioHangController", GioHangController);
function GioHangController($rootScope, $scope, $http) {
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
                        $rootScope.dsDonHang[i].SoLuong + 1;
                    }
                }
            }
            $rootScope.SoLuong = d.data.sl;
        }, function (e) { alert("Lỗi"); });
    }
}

app.controller("HomeController", HomeController);
function HomeController($rootScope, $scope, $http) {
    $rootScope.dsDonHang = null;
    $http.get("/Home/GetLoaiSanPham").then(function (d) { }, function (e) { });

    $rootScope.GetCart = function () {
        $http.get('/GioHang/GetCarts').then(function (d) {
            $rootScope.dsDonHang = d.data.DSDonHang;
            $rootScope.SoLuong = d.data.soluong;
            $rootScope.ThanhTien = d.data.ThanhTien;
        }, function (e) { })
    }
}


app.controller("DatHangController", function ($rootScope, $scope, $http) {

    $rootScope.DatHang = function () {
        $http.get('/DatHang/DatHang', function () {
           
        })
    }
})


