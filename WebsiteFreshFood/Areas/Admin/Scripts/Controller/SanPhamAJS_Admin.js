/// <reference path="../angular.js" />
var app = angular.module("myApp", ['angularUtils.directives.dirPagination','ngFileUpload']);

// Hiển thị sản phẩm và phân trang
app.controller("SanPhamController", function ($scope,$rootScope, $http, Upload, $timeout, $document) {

    //Danh sách sản phẩm
    $http.get('/Admin/QLSanPham/GetSanPham').then(function (d) {
        $rootScope.ListSanPham = d.data;
    }, function (error) { alert('Failed'); });

    $http.get('/Admin/QLSanPham/GetLoaiSanPham').then(function (d) {
        $rootScope.listloai = d.data;
    }, function (e) { alert("Lỗi lấy loại"); });
     
    $scope.Them = function () {
        $scope._function = "Thêm sản phẩm";
        $scope.buttext = "Save";
        $scope.s = null;
    };

    $scope.Sua = function (s) {
        $scope._function = "Sửa sản phẩm";
        $scope.buttext = "Save changes";
        $scope.sp = s;
    };

    $scope.Save = function () {
        //Sửa sản phẩm
        if ($scope.buttext != "Save") {
            $http({
                method: 'Post',
                datatype: 'Json',
                data: JSON.stringify($scope.s),
                url: '/Admin/QLSanPham/Update'
            }).then(function (d) {
                if (d.data == "") {
                    var index = $scope.ListSanPham;
                    for (var i = 0; i < $scope.ListSanPham.length; i++)
                    { //Sửa thành công thì tiến hành sửa trên $scope
                        if ($scope.ListSanPham[i].MaSP == $scope.s.MaSP) {
                            $scope.ListSanPham[i].TenSP = $scope.s.TenSP;
                            $scope.ListSanPham[i].MaLoaiSP = $scope.s.MaLoaiSP;
                            $scope.ListSanPham[i].DonVi = $scope.s.DonVi;
                            $scope.ListSanPham[i].MoTa = $scope.s.MoTa;
                            $scope.ListSanPham[i].HinhAnh = $scope.s.HinhAnh;
                            $scope.ListSanPham[i].DonGia = $scope.s.DonGia;
                            break;
                        }
                    }
                }
            }, function (e) { alert(e); });
        }
        else //Thêm sản phẩm
        {
            $http({
                method: 'POST',
                datatype: 'json',
                url: '/Admin/QLSanPham/Insert',
                data: JSON.stringify($scope.s)
            }).then(function (d) {
                alert($scope.s.MaSP);
                if (d.data == "") {
                    $scope.ListSanPham.push($scope.s);
                    $scope.s = null;
                    alert("Data Submitted...!");
                }
                else {
                    alert(d.data);
                }
            }, function (e) {
                alert("Lỗi nhập...!");
            });
        }
    };

    $scope.XoaSanPham = function (s) {
        $http({
            method: 'Post',
            url: '/Admin/QLSanPham/Delete',
            datatype: 'Json',
            data: { id: s.MaSP }
        }).then(function (d) {
            var vt = $scope.ListSanPham.indexOf(s);
            $scope.ListSanPham.splice(vt, 1);
        }, function (e) { alert(e) });
    };

    $scope.UploadFiles = function (file, kieu) {
        $scope.SelectedFiles = file;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: 'Admin/QLSanPham/Upload',
                data: { file: $scope.SelectedFiles, maloai: $scope.s.MaLoaiSP }
            }).then(function (d) {
                if (kieu == 'Anh') { $scope.s.HinhAnh = d.data[0]; }
                else { $scope.s.HinhAnh = d.data[0]; }
            }, function (e) { alert("Lỗi"); });
        }
    }
    //$scope.totalCount = 0;
    //$scope.maxSize = 3;
    //$scope.pageIndex = 1;
    //$scope.pageISize = 5;
    //$scope.searchName = "";

    //$scope.GetSanPhamList = function (index) {
    //    $http.get('/Admin/QLSanPham/GetSanPhamPT', {
    //        params: { pageIndex: index, pageSize: $scope.pageISize, productName = $scope.searchName }
    //    }).then(function (response) {

    //        $scope.ListSanPham = response.data.SanPhams;
    //        $scope.totalCount = response.data.totalCount;
    //        var sotrang = parseInt(response.data.totalCount) / parseInt($scope.pageISize);
    //        if (parseInt(response.data.totalCount) > sotrang * parseInt($scope.pageISize))
    //            sotrang = sotrang + 1;
    //        if (sotrang < $scope.maxSize) { $scope.maxSize = sotrang; }
    //        else { $scope.maxSize = 5; }
    //    },
    //        function (e) { alert(e); });
    //};
    //$scope.GetSanPhamList($scope.pageIndex);
});


app.controller("KhachHangController", KhachHangController);
function KhachHangController($scope, $rootScope, $http, Upload, $timeout, $document) {
    //Danh sách khách hàng
    $http.get('/Admin/QLKhachHang/GetKhachHang').then(function (d) {
        $rootScope.ListKhachHang = d.data;
    }, function (error) { alert('Failed'); });
}

app.controller("NCCController", NCCController);
function NCCController($scope, $rootScope, $http, Upload, $timeout, $document) {
    //Danh sách nhà cung cấp
    $http.get('/Admin/QLNhaCungCap/GetNhaCungCap').then(function (d) {
        $rootScope.ListNhaCungCap = d.data;
    }, function (error) { alert('Failed'); });
}








   