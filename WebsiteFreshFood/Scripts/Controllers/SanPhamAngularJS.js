/// <reference path="../angular.js" />
var app = angular.module("myApp", ['angularUtils.directives.dirPagination']);

app.controller("SanPhamController", function ($scope, $rootScope, $http) {

    //Danh sách sản phẩm
    $http.get('/SanPham/GetSanPham').then(function (d) {
        $rootScope.ListSanPham = d.data;
    }, function (error) { alert('Failed'); });

    //Sắp xếp dữ liệu
    $rootScope.sortcolumn = "DonGia";
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

    
});


//Menu 
app.controller("MenuController", function ($scope, $rootScope, $http) {
    $http.get('/Home/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); })
});


//Giỏ hàng
app.controller("GioHangController", function ($rootScope, $scope, $http) {
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
});


app.controller("HomeController", function ($rootScope, $scope, $http) {
    $rootScope.dsDonHang = null;
    $http.get("/Home/GetLoaiSanPham").then(function (d) { }, function (e) { });

    $rootScope.GetCart = function () {
        $http.get('/GioHang/GetCarts').then(function (d) {
            $rootScope.dsDonHang = d.data.DSDonHang;
            $rootScope.SoLuong = d.data.soluong;
            $rootScope.ThanhTien = d.data.ThanhTien;
        }, function (e) { })
    }

});

//Phân trang và tim kiếm
app.controller("SearchController", function ($scope, $rootScope, $http) {
    $rootScope.maxSize = 3;
    $rootScope.totalConut = 0;
    $rootScope.pageIndex = 1;
    $rootScope.pageSize = 9;
    $rootScope.searchName = "";
    $rootScope.GetSanPhamList = function (index) {
        $htpp.get('/Administrator/QLSanPham/GetSanPhamPT', {
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
    
});




