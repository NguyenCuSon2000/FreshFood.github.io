/// <reference path="../angular.js" />
var app = angular.module("myApp", [])

app.controller("SanPhamController", function ($scope, $http) {
    $http.get('/SanPham/GetSanPham').then(function (d) {
        $scope.ListSanPham = d.data;
    }, function (error) { alert('Failed'); })
});

app.controller("MenuController", function ($scope, $http) {
    $http.get('/Home/GetLoaiSanPham').then(function (d) {
        $scope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); })
});

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
        }, function () { alert("Lỗi"); });
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
        }, function () { })
    }

});